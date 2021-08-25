using Umbraco.Cms.Web.Common.Controllers;

namespace OnlineBooking.Controllers.Base
{
    public abstract class RenderBaseController : RenderController
    {
        public RenderBaseController(Microsoft.Extensions.Logging.ILogger<RenderController> logger, 
            Microsoft.AspNetCore.Mvc.ViewEngines.ICompositeViewEngine compositeViewEngine, 
            Umbraco.Cms.Core.Web.IUmbracoContextAccessor umbracoContextAccessor) 
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}
