using OnlineBooking.Application.Models.Email;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Contracts
{
    public interface IEmailTemplateService
    {
        EmailTemplate GetEmailTemplate(IPublishedContent emailTemplateSettings);
    }
}
