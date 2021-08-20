using OnlineBooking.ViewModel.Language;
using OnlineBooking.ViewModel.Menu;

namespace OnlineBooking.ViewModel.Header
{
    public class HeaderView
    {
        public MenuListView Menus { get; set; }

        public LanguageSelectionView Languages { get; set; }

        public string Title { get; set; }

        public string BackgroundColor { get; set; }
    }
}
