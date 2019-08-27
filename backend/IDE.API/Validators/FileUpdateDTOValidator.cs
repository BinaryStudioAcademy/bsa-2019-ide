using FluentValidation;
using IDE.Common.DTO.File;

namespace IDE.API.Validators
{
    public class FileUpdateDTOValidator : AbstractValidator<FileUpdateDTO>
    {
        public FileUpdateDTOValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage("Id is mandatory.");

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Name is mandatory.")
                .MaximumLength(256).WithMessage("Name length should have no more than 256 characters.")
                .Matches("[A-Za-z0-9.]{2,256}")
                .WithMessage("File name can contain only letters, numbers and \".\"");

            RuleFor(f => f.Folder)
                .NotEmpty().WithMessage("Folder is mandatory.");

            RuleFor(f => f.Content)
                .NotEmpty().WithMessage("Content is mandatory.");
        }
    }
}
