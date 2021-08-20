using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Mappers;
using OnlineBooking.ViewModel.News;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;

namespace OnlineBooking.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly ServiceContext _serviceContext;
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly IPublishedUrlProvider _publishedUrlProvider;
        private readonly IUserService _userService;

        public NewsService(ServiceContext serviceContext,
            IVariationContextAccessor variationContextAccessor,
            IPublishedUrlProvider publishedUrlProvider,
            IUserService userService)
        {
            _serviceContext = serviceContext;
            _variationContextAccessor = variationContextAccessor;
            _publishedUrlProvider = publishedUrlProvider;
            _userService = userService;
        }

        public NewsListView GetNewsListView(IPublishedContent publishedContent)
        {
            var publishedValueFallback = new PublishedValueFallback(_serviceContext, _variationContextAccessor);
            var view = publishedContent.ToNewsListView(publishedValueFallback, _publishedUrlProvider);
            view.Items = view.Items.OrderByDescending(x => x.Created).ThenByDescending(x => x.Title).ToList();
            return view;
        }

        public NewsDetailView GetNewsDetailView(IPublishedContent publishedContent)
        {
            var publishedValueFallback = new PublishedValueFallback(_serviceContext, _variationContextAccessor);
            var view = publishedContent.ToNewsDetailView(_userService, publishedValueFallback, _publishedUrlProvider);
            return view;
        }

    }
}
