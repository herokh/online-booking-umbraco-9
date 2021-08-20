using OnlineBooking.ViewModel.Language;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace OnlineBooking.Application.Mappers
{
    public static class LanguageSelectionMapper
    {
        public static LanguageSelectionView ToLanguageSelectionView(this IEnumerable<IPublishedContent> publishedContents, IPublishedContent currentPage)
        {
            var currentPageIdAtRoot = currentPage.Root().Id;
            var view = new LanguageSelectionView();
            view.Items = publishedContents.Select(c => ToLanguageSelectionItem(c, currentPageIdAtRoot));

            return view;
        }

        private static LanguageSelectionItemView ToLanguageSelectionItem(IPublishedContent c, int currentPageIdAtRoot)
        {
            var item = new LanguageSelectionItemView();
            item.LanguageName = c.Name;
            item.Url = c.UrlSegment;
            item.IsActive = c.Root().Id == currentPageIdAtRoot;

            return item;
        }
    }
}
