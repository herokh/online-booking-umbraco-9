using Examine;
using Examine.Search;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.ViewModel.FlightSearch;
using OnlineBooking.ViewModel.PaginatedList;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;
using static Umbraco.Cms.Core.Constants;

namespace OnlineBooking.Application.Services
{
    public class FlightSearchService : SearchBaseService<FlightSearchResultView>, IFlightSearchService
    {
        public FlightSearchService(IExamineManager examineManager,
            IPublishedContentQuery publishedContentQuery)
            : base(examineManager, publishedContentQuery)
        {
        }

        public PaginatedListView<FlightSearchResultView> GetSearchResults(FlightSearchCriteriaView searchCriteria)
        {
            if (searchCriteria == null)
                searchCriteria = new FlightSearchCriteriaView();

            List<FlightSearchResultView> listView = GetResults(
                UmbracoIndexes.ExternalIndexName, Applications.Content, searchCriteria.SearchTerm, searchCriteria.PageIndex, searchCriteria.PageSize);

            var pagedView = PaginatedListView<FlightSearchResultView>.
                Create(listView, searchCriteria.PageIndex, searchCriteria.PageSize);

            return pagedView;
        }

        protected override IBooleanOperation PerformQuery(IQuery query, string searchTerm)
        {
            var booleanOperation = query.NativeQuery(FilterByNodeTypeAlias("flightItem"));

            if (!string.IsNullOrEmpty(searchTerm))
            {
                booleanOperation = booleanOperation.And()
                    .Field("nodeName", searchTerm.MultipleCharacterWildcard());
            }
            return booleanOperation;
        }

        protected override FlightSearchResultView PopulateItem(IPublishedContent publishedContent)
        {
            var item = new FlightSearchResultView();
            item.FlightNumber = publishedContent.GetPropertyValueString("flightNumber");
            item.FlightDate = publishedContent.GetPropertyValue<DateTime>("flightDate");
            item.Origin = publishedContent.GetPropertyValueString("origin");
            item.Destination = publishedContent.GetPropertyValueString("destination");
            item.DepartureDateTime = publishedContent.GetPropertyValue<DateTime>("departure");
            item.ArrivalDateTime = publishedContent.GetPropertyValue<DateTime>("arrival");
            return item;
        }
    }
}
