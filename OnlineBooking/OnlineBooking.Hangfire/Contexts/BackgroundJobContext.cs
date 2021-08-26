using OnlineBooking.Application.Enums;
using OnlineBooking.Hangfire.Contexts.Contracts;
using OnlineBooking.Hangfire.Jobs.Contracts;
using System;

namespace OnlineBooking.Hangfire.Contexts
{
    public class BackgroundJobContext : IBackgroundJobContext
    {
        private readonly IVaccineRegistrationEmailJob _vaccineRegistrationEmailJob;

        public BackgroundJobContext(IVaccineRegistrationEmailJob vaccineRegistrationEmailJob)
        {
            _vaccineRegistrationEmailJob = vaccineRegistrationEmailJob;
        }

        public IBackgroundJob GetBackgroundJobWorker(EnumJobType jobType)
        {
            switch (jobType)
            {
                case EnumJobType.VaccineRegistrationEmail:
                    return _vaccineRegistrationEmailJob;
                default:
                    throw new InvalidOperationException($"{jobType} is not support.");
            }
        }
    }
}
