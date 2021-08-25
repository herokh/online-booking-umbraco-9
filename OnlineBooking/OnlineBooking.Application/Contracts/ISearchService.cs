namespace OnlineBooking.Application.Contracts
{
    public interface ISearchService<T, V>
        where T : class
        where V : class
    {
        V GetSearchResults(T searchCriteria);
    }
}
