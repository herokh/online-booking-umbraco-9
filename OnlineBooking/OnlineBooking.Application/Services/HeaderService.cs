using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.Application.Mappers;
using OnlineBooking.ViewModel.Header;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Extensions;

namespace OnlineBooking.Application.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;
        private readonly IVariationContextAccessor _variationContextAccessor;
        public HeaderService(IPublishedSnapshotAccessor publishedSnapshotAccessor, 
            IVariationContextAccessor variationContextAccessor)
        {
            _publishedSnapshotAccessor = publishedSnapshotAccessor;
            _variationContextAccessor = variationContextAccessor;
        }

        public HeaderView GetHeaderView(IPublishedContent publishedContent)
        {
            var contentAtRoot = publishedContent.Root();
            var headerSettings = contentAtRoot.GetHeaderSettingsNode(_variationContextAccessor);
            var pages = contentAtRoot.Children.Where(c =>
                GetDocumentTypesForPages().Contains(c.ContentType.Alias));
            pages = pages.Prepend(contentAtRoot);
            var view = new HeaderView();
            view.Menus = pages.ToMenuListViews(publishedContent);
            view.Languages = contentAtRoot
                .SiblingsAndSelf(_publishedSnapshotAccessor.GetRequiredPublishedSnapshot(), _variationContextAccessor)
                .ToLanguageSelectionView(publishedContent);
            if (headerSettings != null)
            {
                view.Title = headerSettings.GetPropertyValueString(DocumentPropertyAliases.HeaderTitle);
                view.BackgroundColor = headerSettings.GetPropertyValueString(DocumentPropertyAliases.HeaderBgColor);
            }
            return view;
        }

        private string[] GetDocumentTypesForPages()
        {
            return new[] { DocumentTypeAliases.Page, DocumentTypeAliases.NewsMainPage };
        }
    }
}
