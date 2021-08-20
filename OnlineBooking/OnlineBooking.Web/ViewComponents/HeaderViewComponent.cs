using OnlineBooking.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHeaderService _headerService;
        public HeaderViewComponent(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync(IPublishedContent publishedContent)
        {
            var header = _headerService.GetHeaderView(publishedContent);
            return View(header);
        }
    }
}
