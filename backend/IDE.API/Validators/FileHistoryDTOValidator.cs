using FluentValidation;
using IDE.Common.DTO.File;

namespace IDE.API.Validators
{
    public class FileHistoryDTOValidator: AbstractValidator<FileHistoryDTO>
    {
        public FileHistoryDTOValidator()
        {
            RuleFor(fh => fh.Content)
                .NotEmpty().WithMessage("Content is mandatory.");

            RuleFor(fh => fh.UpdaterId)
                .NotEmpty().WithMessage("UpdaterId is mandatory.");
        }
    }
}
