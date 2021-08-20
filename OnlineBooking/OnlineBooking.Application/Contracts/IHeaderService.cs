using OnlineBooking.ViewModel.Header;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Contracts
{
    public interface IHeaderService
    {
        HeaderView GetHeaderView(IPublishedContent publishedContent);
    }
}
