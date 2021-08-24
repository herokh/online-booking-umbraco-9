using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Extensions;
using OnlineBooking.ViewModel.Chatbot;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Mappers
{
    public static class ChatbotMapper
    {
        public static ChatbotView ToChatbotView(this IPublishedContent publishedContent)
        {
            var view = new ChatbotView();
            view.WidgetCode = publishedContent.GetPropertyValueString(DocumentPropertyAliases.ChatbotWidgetCode);
            return view;
        }
    }
}
