using OnlineBooking.Application.Enums;
using OnlineBooking.Hangfire.Jobs.Contracts;

namespace OnlineBooking.Hangfire.Contexts.Contracts
{
    public interface IBackgroundJobContext
    {
        IBackgroundJob GetBackgroundJobWorker(EnumJobType jobType);
    }
}
