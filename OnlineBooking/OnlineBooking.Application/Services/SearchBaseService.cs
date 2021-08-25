using Examine;
using Examine.Search;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Services
{
    public abstract class SearchBaseService<T> where T : class
    {
        protected readonly IExamineManager ExamineManager;
        protected readonly IPublishedContentQuery PublishedContentQuery;

        protected SearchBaseService(IExamineManager examineManager, 
            IPublishedContentQuery publishedContentQuery)
        {
            ExamineManager = examineManager;
            PublishedContentQuery = publishedContentQuery;
        }

        protected abstract IBooleanOperation PerformQuery(IQuery query, string searchTerm);

        protected abstract T PopulateItem(IPublishedContent publishedContent);

        protected virtual List<T> GetResults(string indexName, string category, string searchTerm, int pageIndex, int pageSize)
        {
            if (!ExamineManager.TryGetIndex(indexName, out var index))
                throw new InvalidOperationException($"No index found by name {indexName}");

            var searcher = index.Searcher;
            var query = searcher.CreateQuery(category);
            var booleanOperation = PerformQuery(query, searchTerm);
            var searchResults = booleanOperation.Execute(CreateQueryOptions(pageIndex, pageSize));
            List<T> listView = PopulateItems(searchResults);

            return listView;
        }

        protected virtual List<T> PopulateItems(ISearchResults searchResults)
        {
            var listView = new List<T>();

            if (searchResults.TotalItemCount == 0)
                return listView;

            var searchResultsEnumerator = searchResults.GetEnumerator();

            try
            {
                while (searchResultsEnumerator.MoveNext())
                {
                    var nodeId = searchResultsEnumerator.Current.Id;
                    var nodeContent = PublishedContentQuery.Content(nodeId);
                    var item = PopulateItem(nodeContent);
                    listView.Add(item);
                }

                return listView;
            }
            finally
            {
                searchResultsEnumerator.Dispose();
            }
        }

        protected virtual string FilterByNodeTypeAlias(string nodeTypeAlias)
        {
            return $"+__NodeTypeAlias:{nodeTypeAlias}";
        }

        private QueryOptions CreateQueryOptions(int pageIndex, int pageSize)
        {
            var queryOptions = new QueryOptions((pageIndex - 1) * pageSize, pageSize);
            return queryOptions;
        }

    }
}
