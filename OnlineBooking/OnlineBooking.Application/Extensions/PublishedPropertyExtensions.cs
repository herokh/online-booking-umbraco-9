using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Extensions
{
    public static class PublishedPropertyExtensions
    {
        public static bool IsNullOrEmpty(this IPublishedProperty publishedProperty)
        {
            return publishedProperty == null || !publishedProperty.HasValue();
        }

        public static string GetValueString(this IPublishedProperty publishedProperty, string defaultValue = "")
        {
            return !publishedProperty.IsNullOrEmpty() ? publishedProperty.GetValue()?.ToString() ?? defaultValue : defaultValue;
        }

        public static bool GetValueBoolean(this IPublishedProperty publishedProperty, bool defaultValue = false)
        {
            var val = publishedProperty.GetValueString();
            if (val != "")
                return bool.Parse(val);
            else
                return defaultValue;
        }

        public static T GetValue<T>(this IPublishedProperty publishedProperty)
        {
            if (!publishedProperty.IsNullOrEmpty())
                return (T)publishedProperty.GetValue();
            else
                return default;
        }
    }
}
