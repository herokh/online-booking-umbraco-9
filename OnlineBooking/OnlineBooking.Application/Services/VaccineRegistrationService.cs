using FluentValidation;
using Newtonsoft.Json;
using OnlineBooking.Application.Builders;
using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.Application.Models.Email;
using OnlineBooking.Application.Validators;
using OnlineBooking.ViewModel.Forms;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace OnlineBooking.Application.Services
{
    public class VaccineRegistrationService : IVaccineRegistrationService
    {
        private readonly IContentService _contentService;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        public VaccineRegistrationService(IContentService contentService,
            IVariationContextAccessor variationContextAccessor,
            IEmailService emailService, IEmailTemplateService emailTemplateService)
        {
            _contentService = contentService;
            _variationContextAccessor = variationContextAccessor;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
        }

        public void Register(VaccineRegistrationView vaccineRegistrationView, IPublishedContent publishedContent)
        {
            new VaccineRegistrationValidator()
                .ValidateAndThrow(vaccineRegistrationView);

            var contentAtRoot = publishedContent.Root();
            var formSettings = contentAtRoot.GetFormSettingsNode(DocumentPropertyAliases.FormMappingsVaccineRegistration, _variationContextAccessor);
            var emailTemplateSettings = formSettings.FirstChildOfType(_variationContextAccessor, DocumentTypeAliases.VaccineRegistrationEmailSettings);
            var savedFormDataNode = formSettings.GetPropertyValue<IPublishedContent>(DocumentPropertyAliases.FormSavedFormData);

            // save data as content node
            var savedFormData = _contentService.Create($"{vaccineRegistrationView.LastName}_{vaccineRegistrationView.FirstName}", savedFormDataNode.Key, DocumentTypeAliases.FormData);
            var jsonFormData = JsonConvert.SerializeObject(vaccineRegistrationView, Formatting.Indented);
            savedFormData.SetValue(DocumentPropertyAliases.FormDataValues, $"_{jsonFormData}");
            savedFormData.SetValue(DocumentPropertyAliases.FormDataCreatedAt, DateTime.UtcNow);
            _contentService.SaveAndPublish(savedFormData);

            // send email to client
            var tagReplacements = new List<TagReplacement>();
            tagReplacements.AddNewTagReplacement("@FirstName", vaccineRegistrationView.FirstName);
            tagReplacements.AddNewTagReplacement("@LastName", vaccineRegistrationView.LastName);
            EmailBuilder.GetBuilder(_emailService, _emailTemplateService)
                .EmailTemplate(emailTemplateSettings, tagReplacements)
                .To(vaccineRegistrationView.EmailAddress)
                .SendEmail();
        }
    }
}
