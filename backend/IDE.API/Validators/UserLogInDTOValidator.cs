using FluentValidation;
using IDE.Common.DTO.User;

namespace IDE.API.Validators
{
    public class UserLogInDTOValidator: AbstractValidator<UserLoginDTO>
    {
        public UserLogInDTOValidator()
        {
            RuleFor(u => u.Email)
                .Length(2, 32).WithMessage("Email length should have 2-32 symbol")
                .Matches("[a-zA-Z0-9._]{1,35}@[a-zA-Z0-9.]{1,35}");

            RuleFor(u => u.Password)
                .Length(8, 16).WithMessage("Email length should have 8-16 symbol")
                .Matches("[а-яА-Яa-zA-Z]");
        }
    }
}
