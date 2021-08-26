using OnlineBooking.Application.Enums;

namespace OnlineBooking.Hangfire.Models.Jobs
{
    public class BackgroundJobInputView
    {
        public EnumJobType JobType { get; set; }

        public int ExecutionId { get; set; }
    }
}
