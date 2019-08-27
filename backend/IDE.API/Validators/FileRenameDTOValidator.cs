using FluentValidation;
using IDE.Common.DTO.File;
using IDE.Common.ModelsDTO.DTO.File;

namespace IDE.API.Validators
{
    public class FileRenameDTOValidator : AbstractValidator<FileRenameDTO>
    {
        public FileRenameDTOValidator()
        {            
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("Name is mandatory.")
                .MaximumLength(256)
                .WithMessage("Name length should have no more than 256 characters.")
                .Matches("[A-Za-z0-9.]{2,256}")
                .WithMessage("File name can contain only letters, numbers and \".\"");
        }
    }
}
