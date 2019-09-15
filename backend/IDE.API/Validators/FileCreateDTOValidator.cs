using FluentValidation;
using IDE.Common.DTO.File;

namespace IDE.API.Validators
{
    public class FileCreateDTOValidator : AbstractValidator<FileCreateDTO>
    {
        public FileCreateDTOValidator()
        {            
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Name is mandatory.")
                .MaximumLength(256)
                .WithMessage("Name length should have no more than 256 characters.")
                .Matches("[A-Za-z0-9.]{2,256}")
                .WithMessage("File name can contain only letters, numbers and \".\"");
           
            RuleFor(f => f.Folder)
                .NotEmpty()
                .WithMessage("Folder is mandatory.");

            RuleFor(f => f.ProjectId)
                .NotEmpty()
                .WithMessage("ProjectId is mandatory.");
        }
    }
}
