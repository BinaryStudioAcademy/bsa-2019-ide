using FluentValidation;
using IDE.Common.DTO.File;

namespace IDE.API.Validators
{
    public class FileUpdateDTOValidator : AbstractValidator<FileUpdateDTO>
    {
        public FileUpdateDTOValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Id is mandatory.")
                .Length(24).WithMessage("Id length should have 24 characters.");

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Name is mandatory.")
                .MaximumLength(256).WithMessage("Name length should have no more than 256 characters.");

            RuleFor(f => f.Folder)
                .NotEmpty().WithMessage("Folder is mandatory.");

            RuleFor(f => f.Content)
                .NotEmpty().WithMessage("Content is mandatory.");

            RuleFor(f => f.UpdaterId)
                .NotEmpty().WithMessage("UpdaterId is mandatory.");
        }
    }
}
