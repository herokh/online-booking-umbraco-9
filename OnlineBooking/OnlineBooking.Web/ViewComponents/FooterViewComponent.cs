using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooking.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IFooterService _footerService;
        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync(IPublishedContent publishedContent)
        {
            var view = _footerService.GetFooterView(publishedContent);
            return View(view);
        }
    }
}
