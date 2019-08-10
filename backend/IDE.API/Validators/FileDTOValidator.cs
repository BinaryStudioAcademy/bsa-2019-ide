using FluentValidation;
using IDE.Common.DTO.File;

namespace IDE.API.Validators
{
    public class FileDTOValidator: AbstractValidator<FileDTO>
    {
        public FileDTOValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Name is mandatory.")
                .Length(2, 32).WithMessage("Name length should have 2-32 symbols.");

            RuleFor(f => f.Folder)
                .NotEmpty().WithMessage("Folder is mandatory.");

            RuleFor(f => f.Content)
                .NotEmpty().WithMessage("Content is mandatory.");

            RuleFor(f => f.FileHistoryId)
                .NotEmpty().WithMessage("FileHistoryId is mandatory.")
                .Length(24).WithMessage("FileHistoryId length should have 24 symbols.");

            RuleFor(f => f.ProjectId)
               .NotEmpty().WithMessage("ProjectId is mandatory.");
        }
    }
}
