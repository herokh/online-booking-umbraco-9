using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Extensions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Extensions;

namespace OnlineBooking.Controllers.Base
{
    public abstract class SurfaceBaseController : SurfaceController
    {
        protected readonly IVariationContextAccessor _variationContextAccessor;
        protected SurfaceBaseController(Umbraco.Cms.Core.Web.IUmbracoContextAccessor umbracoContextAccessor,
            Umbraco.Cms.Infrastructure.Persistence.IUmbracoDatabaseFactory databaseFactory,
            Umbraco.Cms.Core.Services.ServiceContext services,
            Umbraco.Cms.Core.Cache.AppCaches appCaches,
            Umbraco.Cms.Core.Logging.IProfilingLogger profilingLogger,
            Umbraco.Cms.Core.Routing.IPublishedUrlProvider publishedUrlProvider, 
            IVariationContextAccessor variationContextAccessor)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _variationContextAccessor = variationContextAccessor;
        }

        protected virtual IActionResult RedirectToUmbracoPageBySettings(string propertyAlias)
        {
            var contentAtRoot = CurrentPage.Root();
            var formSettings = contentAtRoot.GetFormSettingsNode(DocumentPropertyAliases.FormMappingsVaccineRegistration, _variationContextAccessor);
            var nodeContent = formSettings.GetPropertyValue<IPublishedContent>(propertyAlias);
            if (nodeContent != null)
                return RedirectToUmbracoPage(nodeContent);
            else
                return RedirectToCurrentUmbracoPage();
        }
    }
}
