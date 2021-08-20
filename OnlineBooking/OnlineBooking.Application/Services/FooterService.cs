using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.ViewModel.Footer;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Services
{
    public class FooterService : IFooterService
    {
        private readonly IVariationContextAccessor _variationContextAccessor;
        public FooterService(IVariationContextAccessor variationContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
        }

        public FooterView GetFooterView(IPublishedContent publishedContent)
        {
            var view = new FooterView();
            var footerSettings = publishedContent.GetFooterSettingsNode(_variationContextAccessor);
            if (footerSettings != null)
            {
                view.CopyrightText = footerSettings.GetPropertyValueString(DocumentPropertyAliases.FooterCopyright);
            }
            return view;
        }
    }
}
