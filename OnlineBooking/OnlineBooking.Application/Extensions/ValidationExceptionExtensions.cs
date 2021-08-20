using FluentValidation;
using System.Linq;

namespace OnlineBooking.Application.Extensions
{
    public static class ValidationExceptionExtensions
    {
        public static string ToErrorMessages(this ValidationException validationException)
        {
            return string.Join("<br>", validationException.Errors.Select(x => x.ErrorMessage));
        }
    }
}
