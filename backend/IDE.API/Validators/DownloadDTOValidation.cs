using FluentValidation;
using IDE.Common.ModelsDTO.DTO.Project;
using System;

namespace IDE.API.Validators
{
    public class DownloadDTOValidation : AbstractValidator<DownloadDTO>
    {
        public DownloadDTOValidation()
        {
            RuleFor(f => f.FolderGuid)
                .NotNull()
                .NotEmpty()
                .Must(folderGuid => Guid.TryParse(folderGuid, out _))
                .WithMessage("Folder guid is incorrect");
        }
    }
}
