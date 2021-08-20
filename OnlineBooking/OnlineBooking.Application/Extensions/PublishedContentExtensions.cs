using OnlineBooking.Application.Constants;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace OnlineBooking.Application.Extensions
{
    public static class PublishedContentExtensions
    {
        public static IPublishedContent GetSettingsNode(this IPublishedContent publishedContent, IVariationContextAccessor variationContextAccessor)
        {
            var settings = publishedContent.Root().FirstChildOfType(variationContextAccessor, DocumentTypeAliases.WebSettings);
            
            return settings;
        }

        public static IPublishedContent GetHeaderSettingsNode(this IPublishedContent contentAtRoot, IVariationContextAccessor variationContextAccessor)
        {
            var settings = contentAtRoot.GetSettingsNode(variationContextAccessor);
            var headerSettings = settings?.FirstChildOfType(variationContextAccessor, DocumentTypeAliases.HeaderSettings);

            return headerSettings;
        }

        public static IPublishedContent GetFooterSettingsNode(this IPublishedContent contentAtRoot, IVariationContextAccessor variationContextAccessor)
        {
            var settings = contentAtRoot.GetSettingsNode(variationContextAccessor);
            var footerSettings = settings?.FirstChildOfType(variationContextAccessor, DocumentTypeAliases.FooterSettings);

            return footerSettings;
        }

        public static IPublishedContent GetFormSettingsNode(this IPublishedContent contentAtRoot, string contentPickerAlias, IVariationContextAccessor variationContextAccessor)
        {
            var settings = contentAtRoot.GetSettingsNode(variationContextAccessor);
            var formMappings = settings?.FirstChildOfType(variationContextAccessor, DocumentTypeAliases.FormMappings);
            var formSettings = formMappings.GetPropertyValue<IPublishedContent>(contentPickerAlias);

            return formSettings;
        }

        public static string GetPropertyValueString(this IPublishedContent publishedContent, string propertyAlias, string defaultValue = "")
        {
            if (publishedContent == null)
                return defaultValue;

            var property = publishedContent.GetProperty(propertyAlias);
            if (property != null)
            {
                return property.GetValueString(defaultValue);
            }
            return defaultValue;
        }

        public static bool GetPropertyValueBoolean(this IPublishedContent publishedContent, string propertyAlias, bool defaultValue = false)
        {
            if (publishedContent == null)
                return defaultValue;

            var property = publishedContent.GetProperty(propertyAlias);
            if (property != null)
            {
                return property.GetValueBoolean(defaultValue);
            }
            return defaultValue;
        }

        public static T GetPropertyValue<T>(this IPublishedContent publishedContent, string propertyAlias)
        {
            if (publishedContent == null)
                return default;

            var property = publishedContent.GetProperty(propertyAlias);
            if (property != null)
            {
                return property.GetValue<T>();
            }
            return default;
        }

    }
}
