using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Models.Email;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Builders
{
    public class EmailBuilder
    {
        private readonly EmailModel _email;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        public EmailBuilder(IEmailService emailService, 
            IEmailTemplateService emailTemplateService)
        {
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _email = new EmailModel();
        }

        public static EmailBuilder GetBuilder(IEmailService emailService,
            IEmailTemplateService emailTemplateService)
        {
            return new EmailBuilder(emailService, emailTemplateService);
        }

        public EmailBuilder Subject(string subject)
        {
            _email.Subject = subject;

            return this;
        }

        public EmailBuilder Body(string body)
        {
            _email.Body = body;

            return this;
        }

        public EmailBuilder EmailTemplate(IPublishedContent emailTemplateSettings, IEnumerable<TagReplacement> tagReplacements = null)
        {
            var emailTemplate = _emailTemplateService.GetEmailTemplate(emailTemplateSettings);
            _email.Subject = emailTemplate.Subject;
            _email.Body = emailTemplate.Body;

            if (tagReplacements != null)
            {
                foreach (var tagReplacement in tagReplacements)
                {
                    _email.Body = _email.Body.Replace(tagReplacement.Key, tagReplacement.Value);
                }
            }

            return this;
        }

        public EmailBuilder To(string to)
        {
            _email.To = new[] { to };

            return this;
        }

        public EmailBuilder To(string[] to)
        {
            _email.To = to;

            return this;
        }

        public EmailBuilder Cc(string[] cc)
        {
            _email.Cc = cc;

            return this;
        }

        public void SendEmail()
        {
            _emailService.SendEmail(_email);
        }
    }
}
