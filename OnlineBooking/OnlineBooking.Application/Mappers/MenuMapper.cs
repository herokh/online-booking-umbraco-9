using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Extensions;
using OnlineBooking.ViewModel.Menu;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Mappers
{
    public static class MenuMapper
    {
        public static MenuListView ToMenuListViews(this IEnumerable<IPublishedContent> contents, IPublishedContent currentPage)
        {
            var view = ToMenuListView(contents, currentPage);

            return view;
        }

        private static MenuListView ToMenuListView(IEnumerable<IPublishedContent> contents, IPublishedContent currentPage)
        {
            var listView = new MenuListView();
            listView.Items = ToMenuItemViews(contents, currentPage);

            return listView;
        }

        private static IEnumerable<MenuItemView> ToMenuItemViews(IEnumerable<IPublishedContent> contents, IPublishedContent currentPage)
        {
            foreach (var content in contents)
            {
                var menuItem = new MenuItemView();
                menuItem.Name = content.GetPropertyValueString(DocumentPropertyAliases.MenuLabel, content.Name);
                menuItem.Url = content.UrlSegment;
                menuItem.IsActived = content.Id == currentPage.Id;
                menuItem.IsEnabled = content.GetPropertyValueBoolean(DocumentPropertyAliases.ShowInMenu);

                yield return menuItem;
            }
        }
    }
}
