using FluentValidation;
using IDE.Common.DTO.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.API.Validators
{
    public class ProjectCreateDTOValidator : AbstractValidator<ProjectCreateDTO>
    {
        public ProjectCreateDTOValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(32)
                .WithMessage("Name should have contain no more than 32 symbols")
                .NotEmpty()
                .WithMessage("Name is mandatory")
                .Matches("[A-Za-z0-9]+")
                .WithMessage("Name can contain only latin letters and numbers.");

            RuleFor(p => p.CountOfBuildAttempts)
                .NotEmpty()
                .WithMessage("CountOfBuildAttempts is mandatory")
                .InclusiveBetween(1, 10)
                .WithMessage("CountOfBuildAttempts should be in range (1,10)");

            RuleFor(p => p.CountOfSaveBuilds)
                .NotEmpty()
                .WithMessage("CountOfSaveBuilds is mandatory")
                .InclusiveBetween(1, 10)
                .WithMessage("CountOfSaveBuilds should be in range (1,10)");

            RuleFor(p => p.Description)
                .MaximumLength(1024)
                .WithMessage("Description should have contain no more than 1024 symbols");
        }
    }
}
