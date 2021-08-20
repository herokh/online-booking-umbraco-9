using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.Application.Models.Email;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Services
{
    public class EmailTemplateService : IEmailTemplateService
    {
        public EmailTemplate GetEmailTemplate(IPublishedContent emailTemplateSettings)
        {
            var emailTemplate = new EmailTemplate();
            emailTemplate.Subject = emailTemplateSettings.GetPropertyValueString(DocumentPropertyAliases.EmailTemplateSubject);
            emailTemplate.Body = emailTemplateSettings.GetPropertyValueString(DocumentPropertyAliases.EmailTemplateBody);

            return emailTemplate;
        }
    }
}
