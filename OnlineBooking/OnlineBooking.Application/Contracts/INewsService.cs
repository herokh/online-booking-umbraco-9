using OnlineBooking.ViewModel.News;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Contracts
{
    public interface INewsService
    {
        NewsListView GetNewsListView(IPublishedContent publishedContent);

        NewsDetailView GetNewsDetailView(IPublishedContent publishedContent);
    }
}
