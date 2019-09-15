using FluentValidation;
using IDE.Common.DTO.User;

namespace IDE.API.Validators
{
    public class UserLogInDTOValidator: AbstractValidator<UserLoginDTO>
    {
        public UserLogInDTOValidator()
        {
            //RuleFor(u => u.Email)
            //    .Length(2, 32).WithMessage("Email length should have 2-32 symbol");
            //    //.Matches("[^.]{0}[a-zA-Z0-9._]{1,35}[^.]{0}@[^-]{0}[a-zA-Z0-9-]{1,17}[^-]{0}[.]{1}[a-zA-Z]{1,17}").WithMessage("Email can only contain latin letters(upper\\lowercase), digits, \".\", \"_\", \"@\". \".\" can not be first or last symbol.");

            RuleFor(u => u.Password)
                .Length(8, 16).WithMessage("Email length should have 8-16 symbol")
                //.Matches("[а-яА-Яa-zA-Z0-9./,-()]{8,16}").WithMessage("Password can contain latin letters (upper\\lowercase), digits, \",\" , \", \", \"(\", \")\",\" / \",\" - \".\"");
                .Matches("[а-яА-Яa-zA-Z0-9]{8,16}").WithMessage("Password can contain latin letters (upper\\lowercase), digits, \",\" , \", \", \"(\", \")\",\" / \",\" - \".\"");
        }
    }
}
