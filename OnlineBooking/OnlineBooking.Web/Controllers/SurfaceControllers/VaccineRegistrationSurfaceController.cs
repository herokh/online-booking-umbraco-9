using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.ViewModel.Forms;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using FluentValidation;
using OnlineBooking.Controllers.Base;
using Umbraco.Cms.Web.Common.Filters;
using Microsoft.AspNetCore.Http;

namespace OnlineBooking.Controllers.SurfaceControllers
{
    public class VaccineRegistrationSurfaceController : BaseSurfaceController
    {
        private readonly IVaccineRegistrationService _vaccineRegistrationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VaccineRegistrationSurfaceController(Umbraco.Cms.Core.Web.IUmbracoContextAccessor umbracoContextAccessor,
            Umbraco.Cms.Infrastructure.Persistence.IUmbracoDatabaseFactory databaseFactory,
            Umbraco.Cms.Core.Services.ServiceContext services, Umbraco.Cms.Core.Cache.AppCaches appCaches,
            Umbraco.Cms.Core.Logging.IProfilingLogger profilingLogger,
            Umbraco.Cms.Core.Routing.IPublishedUrlProvider publishedUrlProvider,
            IVariationContextAccessor variationContextAccessor,
            IVaccineRegistrationService vaccineRegistrationService, 
            IHttpContextAccessor httpContextAccessor)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider, variationContextAccessor)
        {
            _vaccineRegistrationService = vaccineRegistrationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateUmbracoFormRouteString]
        public IActionResult Register(VaccineRegistrationView vaccineRegistrationView)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Invalid model state.");

                _vaccineRegistrationService.Register(vaccineRegistrationView, CurrentPage);

                return RedirectToUmbracoPageBySettings(DocumentPropertyAliases.FormRedirectOnSuccessPage);
            }
            catch (ValidationException ex)
            {
                TempData.Add("ErrorMessages", ex.ToErrorMessages());
                return CurrentUmbracoPage();
            }
            catch (Exception)
            {
                return RedirectToUmbracoPageBySettings(DocumentPropertyAliases.FormRedirectOnFailedPage);
            }
        }
    }
}
