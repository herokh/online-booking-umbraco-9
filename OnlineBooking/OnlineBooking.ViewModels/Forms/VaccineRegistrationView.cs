using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooking.ViewModel.Forms
{
    public class VaccineRegistrationView
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        public bool DiagnosedWithCovid { get; set; }

        public bool LossOfTaste { get; set; }

        public bool DifficultyBreathing { get; set; }

        public bool Cough { get; set; }

        public bool RunnyNose { get; set; }

        public bool BodyAches { get; set; }

        public bool SoreThroat { get; set; }
    }
}
