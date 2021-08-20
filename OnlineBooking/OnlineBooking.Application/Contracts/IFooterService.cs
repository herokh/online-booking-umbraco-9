using OnlineBooking.ViewModel.Footer;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Contracts
{
    public interface IFooterService
    {
        FooterView GetFooterView(IPublishedContent publishedContent);
    }
}
