using FluentValidation;
using SurveyApi.Application.Features.Commands.Survey.CreateSurvey;
using SurveyApi.Application.ViewModels.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Validations.Survey
{
    public class SurveyValidator : AbstractValidator<CreateSurveyCommandRequest>
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
                .Must(v => (int)v <= 3 && (int)v >= 1)
                .WithMessage("Unknown visibility");

            RuleFor(s => s.StartDate)
                .NotEmpty().WithMessage("Date cannot be empty")
                .Must(d => d >= DateTime.UtcNow.AddMinutes(5))
                .WithMessage("Start date must be at least 5 minutes from now");

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
