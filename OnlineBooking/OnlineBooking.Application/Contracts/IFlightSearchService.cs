using OnlineBooking.ViewModel.FlightSearch;
using OnlineBooking.ViewModel.PaginatedList;

namespace OnlineBooking.Application.Contracts
{
    public interface IFlightSearchService : ISearchService<FlightSearchCriteriaView, PaginatedListView<FlightSearchResultView>>
    {
    }
}
