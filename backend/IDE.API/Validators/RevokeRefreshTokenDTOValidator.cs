using FluentValidation;
using IDE.Common.DTO.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.API.Validators
{
    public class RevokeRefreshTokenDTOValidator : AbstractValidator<RevokeRefreshTokenDTO>
    {
        public RevokeRefreshTokenDTOValidator()
        {
            RuleFor(r => r.RefreshToken)
                .NotEmpty()
                .WithMessage("Refresh token can not be empty");
        }
    }
}
