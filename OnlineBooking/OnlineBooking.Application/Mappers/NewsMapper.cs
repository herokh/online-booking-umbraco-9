using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Extensions;
using OnlineBooking.ViewModel.News;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace OnlineBooking.Application.Mappers
{
    public static class NewsMapper
    {
        public static NewsListView ToNewsListView(this IPublishedContent publishedContent, 
            IPublishedValueFallback publishedValueFallback, 
            IPublishedUrlProvider publishedUrlProvider)
        {
            var view = new NewsListView(publishedContent, publishedValueFallback);
            view.Title = publishedContent.GetPropertyValueString(DocumentPropertyAliases.NewsMainTitle);
            view.BriefText = publishedContent.GetPropertyValueString(DocumentPropertyAliases.NewsMainDescription);
            view.Items = publishedContent.Children.Select(c => new NewsItemView
            {
                Title = c.GetPropertyValueString(DocumentPropertyAliases.NewsItemTitle),
                Content = c.GetPropertyValueString(DocumentPropertyAliases.NewsItemDescription),
                Url = c.Url(publishedUrlProvider),
                Created = c.CreateDate
            });

            return view;
        }

        public static NewsDetailView ToNewsDetailView(this IPublishedContent publishedContent, 
            IUserService userService,
            IPublishedValueFallback publishedValueFallback,
            IPublishedUrlProvider publishedUrlProvider)
        {
            var view = new NewsDetailView(publishedContent, publishedValueFallback);
            view.Title = publishedContent.GetPropertyValueString(DocumentPropertyAliases.NewsDetailTitle);
            view.Content = publishedContent.GetPropertyValueString(DocumentPropertyAliases.NewsDetailDescription);
            view.Created = publishedContent.CreateDate;
            view.Updated = publishedContent.UpdateDate;
            view.CreatedBy = publishedContent.GetCreatorName(userService);
            view.ParentUrl = publishedContent.Parent.Url(publishedUrlProvider);
            return view;
        }
    }
}
