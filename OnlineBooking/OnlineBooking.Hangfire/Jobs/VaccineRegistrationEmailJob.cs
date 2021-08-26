using OnlineBooking.Application.Builders;
using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.Application.Models.Email;
using OnlineBooking.Application.Models.Forms;
using OnlineBooking.Hangfire.Jobs.Contracts;
using System.Collections.Generic;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace OnlineBooking.Hangfire.Jobs
{
    public class VaccineRegistrationEmailJob : IVaccineRegistrationEmailJob
    {
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IUmbracoContextFactory _umbracoContextFactory;

        public VaccineRegistrationEmailJob(IEmailService emailService,
            IEmailTemplateService emailTemplateService,
            IUmbracoContextFactory context)
        {
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _umbracoContextFactory = context;
        }

        public void Invoke(int id)
        {
            using (var reference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var context = reference.UmbracoContext;
                var formNode = context.PublishedSnapshot.Content.GetById(id);
                var rootNode = formNode.Root();
                var formSettings = rootNode
                    .FirstChildOfType(DocumentTypeAliases.WebSettings)
                    .FirstChildOfType(DocumentTypeAliases.FormSettings);
                var emailTemplateSettings = formSettings
                    .FirstChildOfType(DocumentTypeAliases.RegistrationCompletedEmail);

                var tagReplacements = new List<TagReplacement>();
                var savedFormData = formNode.GetPropertyValueString(DocumentPropertyAliases.FormDataValues);
                savedFormData = savedFormData.StartsWith("_") ? savedFormData.Remove(0, 1) : savedFormData;
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VaccineRegistrationModel>(savedFormData);
                tagReplacements.AddNewTagReplacement("@FirstName", model.FirstName);
                tagReplacements.AddNewTagReplacement("@LastName", model.LastName);
                EmailBuilder.GetBuilder(_emailService, _emailTemplateService)
                    .EmailTemplate(emailTemplateSettings, tagReplacements)
                    .To(model.EmailAddress)
                    .SendEmail();
            }
        }
    }
}
