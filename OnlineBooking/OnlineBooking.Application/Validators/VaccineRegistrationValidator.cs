using FluentValidation;
using OnlineBooking.ViewModel.Forms;
using System;

namespace OnlineBooking.Application.Validators
{
    public class VaccineRegistrationValidator : AbstractValidator<VaccineRegistrationView>
    {
        public VaccineRegistrationValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(x => x.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("Date of birth is required.")
                .Must(x => {
                    var minimumDate = DateTime.Today.AddYears(-18);
                    var diffDate = minimumDate - x.Value;
                    return diffDate.TotalSeconds > 0;
                })
                .WithMessage("You are so kid. please ask your parent for registration.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Email address is required.")
                .EmailAddress()
                .WithMessage("Email address is invalid.");
        }
    }
}
