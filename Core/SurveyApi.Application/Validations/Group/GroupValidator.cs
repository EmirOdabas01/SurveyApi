using FluentValidation;
using SurveyApi.Application.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Validations.Group
{
    public class GroupValidator : AbstractValidator<VM_Create_Group>
    {
        public GroupValidator() 
        {
            RuleFor(g => g.Name)
                .Length(3, 20)
                .WithMessage("Group name length must be between 3 and 20");

            RuleFor(g => g.Description)
                .Length(10, 100)
                .WithMessage("Group Description length must be between 10 and 100");
        }
    }
}
