using FluentValidation;
using IDE.Common.DTO.User;

namespace IDE.API.Validators
{
    public class UserRegusterDTOValidator: AbstractValidator<UserRegisterDTO>
    {
        public UserRegusterDTOValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("User first name can not be empty")
                .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                .Matches("[а-яА-Яa-zA-Z]{2,32}");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("User last name can not be empty")
                .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                .Matches("[а-яА-Яa-zA-Z]{2,32}");

            RuleFor(u => u.Email)
                .Length(2, 32).WithMessage("Email length should have 2-32 symbol")
                .Matches("[a-zA-Z0-9._]{1,35}@[a-zA-Z0-9.]{1,35}");

            RuleFor(u=>u.Password)
                .Length(8, 16).WithMessage("Email length should have 8-16 symbol")
                .Matches("[а-яА-Яa-zA-Z]");



        }
    }
}
