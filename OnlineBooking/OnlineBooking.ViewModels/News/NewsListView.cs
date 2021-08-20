using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.ViewModel.News
{
    public class NewsListView : PublishedContentWrapped
    {
        public NewsListView(IPublishedContent content, 
            IPublishedValueFallback publishedValueFallback)
            : base(content, publishedValueFallback)
        {
        }

        public string Title { get; set; }

        public string BriefText { get; set; }

        public IEnumerable<NewsItemView> Items { get; set; }
    }
}
