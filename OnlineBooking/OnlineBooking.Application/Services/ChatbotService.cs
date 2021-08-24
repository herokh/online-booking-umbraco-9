using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.Application.Mappers;
using OnlineBooking.ViewModel.Chatbot;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Services
{
    public class ChatbotService : IChatbotService
    {
        private readonly IVariationContextAccessor _variationContextAccessor;

        public ChatbotService(IVariationContextAccessor variationContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
        }

        public ChatbotView GetChatbotView(IPublishedContent publishedContent)
        {
            var chatbotSettings = publishedContent.GetChatbotSettingsNode(_variationContextAccessor);
            var view = chatbotSettings.ToChatbotView();
            return view;
        }
    }
}
