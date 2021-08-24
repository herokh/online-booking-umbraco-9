using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Application.Contracts;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.ViewComponents
{
    public class ChatbotViewComponent : ViewComponent
    {
        private readonly IChatbotService _chatbotService;
        public ChatbotViewComponent(IChatbotService chatbotService)
        {
            _chatbotService = chatbotService;
        }

        public async Task<IViewComponentResult> InvokeAsync(IPublishedContent publishedContent)
        {
            var view = _chatbotService.GetChatbotView(publishedContent);
            return View(view);
        }
    }
}
