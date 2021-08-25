using Microsoft.AspNetCore.Mvc;

namespace OnlineBooking.ViewModel.FlightSearch
{
    public class FlightSearchCriteriaView
    {
        public FlightSearchCriteriaView()
        {
            SearchTerm = string.Empty;
            PageIndex = 1;
            PageSize = 50;
        }

        [FromQuery(Name = "q")]
        public string SearchTerm { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
