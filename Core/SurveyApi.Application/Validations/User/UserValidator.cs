using FluentValidation;
using SurveyApi.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Validations.User
{
    public class UserValidator : AbstractValidator<VM_Create_User>
    {
       public UserValidator()
        {
            RuleFor(u => u.UserName)
               .NotNull()
               .NotEmpty()
               .WithMessage("User Name cannot be null or empty")
               .Length(3, 100)
               .WithMessage("Pls enter a name with minimum 3 maximum 100 length");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage("Pls Enter a number")
                .Matches(@"^\+90\d{10}$").WithMessage("Phone number must starts with +90 and include 10 digits");

            RuleFor(u => u.EMail)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Pls Enter a valid e mail");

            RuleFor(u => u.Password)
                   .Length(7, 20).WithMessage("Password length must be between 7 and 20")
                   .Matches(@"[A-Z]").WithMessage("Password must contain minimum one uppercase character")
                   .Matches(@"[a-z]").WithMessage("password must contain minimum one lowercase character")
                   .Matches(@"\d").WithMessage("Password must contain minimum one number")
                   .Matches(@"[!@#$%^&*(),.?""':{}|<>]").WithMessage("Password must contain minimum one special character");
        }
    }
}
