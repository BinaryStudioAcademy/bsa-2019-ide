using FluentValidation;
using IDE.Common.ModelsDTO.DTO.Authentification;

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
