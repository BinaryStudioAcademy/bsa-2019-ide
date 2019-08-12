using FluentValidation;
using IDE.Common.DTO.User;

namespace IDE.API.Validators
{
    public class UserRegisterDTOValidator: AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterDTOValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("User first name can not be empty")
                .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                .Matches("[а-яА-Яa-zA-ZіІїЇ^0-9]{2,32}").WithMessage("First name can only contain latin\\cyrillic letters (upper\\lowercase).");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("User last name can not be empty")
                .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                .Matches("[а-яА-Яa-zA-ZіІїЇ^0-9]{2,32}").WithMessage("Last name can only contain latin\\cyrillic letters (upper\\lowercase).");

            RuleFor(u => u.NickName)
                .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                .Matches("[a-zA-Z0-9]{2,32}").WithMessage("Nickname can only contain latin letters (upper\\lowercase).");

            RuleFor(u => u.Email)
                .Length(2, 32).WithMessage("Email length should have 2-32 symbol")
                .Matches("[^.]{0}[a-zA-Z0-9._]{1,35}[^.]{0}@[^-]{0}[a-zA-Z0-9.]{3,35}[^-]{0}")
                .WithMessage("Email can only contain latin letters(upper\\lowercase), digits, \".\", \"_\", \"@\". \".\" can not be first or last symbol.");

            RuleFor(u=>u.Password)
                .Length(8, 16).WithMessage("Email length should have 8-16 symbol")
                .Matches("[а-яА-Яa-zA-Z0-9./,-()]{8,16}").WithMessage("Password can contain latin letters (upper\\lowercase), digits, \",\" , \", \", \"(\", \")\",\" / \",\" - \".\"");



        }
    }
}
