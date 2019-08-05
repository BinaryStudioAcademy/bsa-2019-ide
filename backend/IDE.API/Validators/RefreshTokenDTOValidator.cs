using FluentValidation;
using IDE.Common.DTO.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.API.Validators
{
    public class RefreshTokenDTOValidator : AbstractValidator<RefreshTokenDTO>
    {
        public RefreshTokenDTOValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage("Refresh token can not be empty");
            RuleFor(x => x.AccessToken)
                .NotEmpty()
                .WithMessage("Access token can not be empty");
        }
    }
}
