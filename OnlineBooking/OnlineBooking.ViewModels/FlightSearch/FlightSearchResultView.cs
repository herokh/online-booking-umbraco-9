using System;

namespace OnlineBooking.ViewModel.FlightSearch
{
    public class FlightSearchResultView
    {
        public string FlightNumber { get; set; }

        public DateTime FlightDate { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }
    }
}
