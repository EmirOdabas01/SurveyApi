using FluentValidation;
using SurveyApi.Application.ViewModels.QuestionOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Validations.QuestionOption
{
    public class QuestionOptionValidator : AbstractValidator<VM_Create_QuestionOption>
    {
        public QuestionOptionValidator()
        {
            RuleFor(q => q.Value)
                .NotNull()
                .NotEmpty()
                .WithMessage("An option cannot be null or empty");
        }
    }
}
