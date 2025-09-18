using FluentValidation;
using SurveyApi.Application.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Validations.Question
{
    public class QuestionValidator : AbstractValidator<VM_Create_Question>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.QuestionText)
                .NotNull()
                .NotEmpty()
                .WithMessage("Question text cannot be null or empty");
        }
    }
}
