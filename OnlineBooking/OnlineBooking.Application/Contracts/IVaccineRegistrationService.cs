using OnlineBooking.ViewModel.Forms;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace OnlineBooking.Application.Contracts
{
    public interface IVaccineRegistrationService
    {
        void Register(VaccineRegistrationView vaccineRegistrationView, IPublishedContent publishedContent);
    }
}
