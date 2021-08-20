using OnlineBooking.Application.Models.Email;

namespace OnlineBooking.Application.Contracts
{
    public interface IEmailService
    {
        void SendEmail(EmailModel email);
    }
}
