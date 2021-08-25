using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Controllers.Base;
using OnlineBooking.ViewModel.FlightSearch;
using OnlineBooking.ViewModel.PaginatedList;

namespace OnlineBooking.Controllers.SurfaceControllers
{
    public class FlightsSearchController : UmbracoApiBaseController
    {
        private readonly IFlightSearchService _flightSearchService;

        public FlightsSearchController(IFlightSearchService flightSearchService)
        {
            _flightSearchService = flightSearchService;
        }

        [HttpGet]
        public PaginatedListView<FlightSearchResultView> GetSearchResults([FromQuery] FlightSearchCriteriaView flightSearchCriteriaView)
        {
            var pagedView = _flightSearchService.GetSearchResults(flightSearchCriteriaView);

            return pagedView;
        }
    }
}
