using OnlineBooking.Application.Models.Email;
using System.Collections.Generic;

namespace OnlineBooking.Application.Extensions
{
    public static class TagReplacementExtensions
    {
        public static void AddNewTagReplacement(this List<TagReplacement> tagReplacements, string key, string value)
        {
            tagReplacements.Add(new TagReplacement { Key = key, Value = value });
        }
    }
}
