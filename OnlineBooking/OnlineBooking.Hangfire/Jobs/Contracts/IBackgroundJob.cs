namespace OnlineBooking.Hangfire.Jobs.Contracts
{
    public interface IBackgroundJob
    {
        void Invoke(int id);
    }
}
