using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.ViewModel.News
{
    public class NewsDetailView : PublishedContentWrapped
    {
        public NewsDetailView(IPublishedContent content, 
            IPublishedValueFallback publishedValueFallback) 
            : base(content, publishedValueFallback)
        {
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Updated { get; set; }

        public string ParentUrl { get; set; }
    }
}
