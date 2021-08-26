using System;

namespace OnlineBooking.Application.Models.Forms
{
    public class VaccineRegistrationModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

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
