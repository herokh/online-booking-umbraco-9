using Hangfire;
using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Hangfire.Contexts.Contracts;
using OnlineBooking.Hangfire.Models.Jobs;

namespace OnlineBooking.Hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundJobsController : ControllerBase
    {
        private readonly IBackgroundJobContext _backgroundJobContext;
        private readonly IBackgroundJobClient _backgroundJobs;
        public BackgroundJobsController(IBackgroundJobClient backgroundJobs, 
            IBackgroundJobContext backgroundJobContext)
        {
            _backgroundJobs = backgroundJobs;
            _backgroundJobContext = backgroundJobContext;
        }

        [HttpPost]
        public IActionResult RegisterNewJob([FromBody] BackgroundJobInputView inputView)
        {
            var worker = _backgroundJobContext.GetBackgroundJobWorker(inputView.JobType);
            var jobId = _backgroundJobs.Enqueue(() => worker.Invoke(inputView.ExecutionId));
            return Created("", jobId);
        }
    }
}
