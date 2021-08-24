using OnlineBooking.ViewModel.Chatbot;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Contracts
{
    public interface IChatbotService
    {
        ChatbotView GetChatbotView(IPublishedContent publishedContent);
    }
}
