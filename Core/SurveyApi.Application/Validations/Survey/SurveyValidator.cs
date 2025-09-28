using FluentValidation;
using SurveyApi.Application.ViewModels.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Validations.Survey
{
    public class SurveyValidator : AbstractValidator<VM_Create_Survey>
    {
        public SurveyValidator()
        {
            RuleFor(s => s.Name)
                .Length(5, 200)
                .WithMessage("Survey name length must be between 5 and 20");

            RuleFor(s => s.Description)
                .Length(10, 200)
                .WithMessage("Description length must be between 10 and 100");

            RuleFor(s => s.Visibility)
                .Must(v => (int)v <= 2 && (int)v >= 0)
                .WithMessage("Unknown visibility");

            RuleFor(s => s.StartDate)
                .NotEmpty().WithMessage("Date cannot be empty")
                .Must(d => d >= DateTime.UtcNow)
                .WithMessage("The start date cannot be earlier than now");

            RuleFor(s => s.EndDate)
                .NotEmpty().WithMessage("Date cannot be empty")
                .Must((s, endDate) => endDate > s.StartDate || endDate > DateTime.UtcNow.AddMinutes(10))
                .WithMessage("End date cannot be earlier than start date or now (minimum 10 minutes)");

            RuleFor(s => s.MinResponse)
                .GreaterThan(0)
                .WithMessage("Minimum response is 1")
                .LessThanOrEqualTo(int.MaxValue - 1)
                .WithMessage($"Pls enter a number not greater than {int.MaxValue - 1}");

            RuleFor(s => s.MaxResponse)
                .GreaterThanOrEqualTo((s) => s.MinResponse)
                .WithMessage("Max response must be greater or equal to min response")
                .LessThanOrEqualTo(int.MaxValue)
                .WithMessage($"Pls enter a number not greater than {int.MaxValue}");
        }
    }
}
