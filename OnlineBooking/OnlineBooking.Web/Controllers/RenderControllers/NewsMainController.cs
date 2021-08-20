using OnlineBooking.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using OnlineBooking.Controllers.Base;

namespace OnlineBooking.Controllers.RenderControllers
{
    public class NewsMainController : BaseRenderController
    {
        private readonly INewsService _newsService;
        public NewsMainController(ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor, 
            INewsService newsService)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public override IActionResult Index()
        {
            var view = _newsService.GetNewsListView(CurrentPage);
            return CurrentTemplate(view);
        }
    }
}
