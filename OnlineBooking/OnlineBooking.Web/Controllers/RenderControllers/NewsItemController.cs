using OnlineBooking.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;
using OnlineBooking.Controllers.Base;

namespace OnlineBooking.Controllers.RenderControllers
{
    public class NewsItemController : RenderBaseController
    {
        private readonly INewsService _newsService;
        public NewsItemController(Microsoft.Extensions.Logging.ILogger<RenderController> logger,
            Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine compositeViewEngine,
            Umbraco.Cms.Core.Web.IUmbracoContextAccessor umbracoContextAccessor,
            INewsService newsService)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public override IActionResult Index()
        {
            var view = _newsService.GetNewsDetailView(CurrentPage);
            return CurrentTemplate(view);
        }
    }
}
