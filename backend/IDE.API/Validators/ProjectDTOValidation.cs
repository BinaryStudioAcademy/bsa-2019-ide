
using FluentValidation;
using IDE.Common.DTO.Common;

namespace IDE.API.Validators
{
    public class ProjectDTOValidation: AbstractValidator<ProjectDTO>
    {
        public ProjectDTOValidation()
        {
            RuleFor(a => a.Name)
                .NotNull().WithMessage("Project name can not be empty")
                .Length(2, 40).WithMessage("Project name length should have 2-40 symbol")
                .Matches("[a-zA-Z0-9]{2,40}");
        }
    }
}
