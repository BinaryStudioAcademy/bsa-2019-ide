using FluentValidation;
using IDE.Common.ModelsDTO.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.API.Validators
{
    public class UserUpdateInfoDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateInfoDTOValidator()
        {
            RuleFor(u => u.FirstName)
                    .NotEmpty().WithMessage("User first name can not be empty")
                    .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                    .Matches("[а-яА-Яa-zA-ZіІїЇ]{2,32}").WithMessage("First name can only contain latin\\cyrillic letters (upper\\lowercase).");

            RuleFor(u => u.LastName)
                    .NotEmpty().WithMessage("User last name can not be empty")
                    .Length(2, 32).WithMessage("User last name length should have 2-32 symbol")
                    .Matches("[а-яА-Яa-zA-ZіІїЇ]{2,32}").WithMessage("Last name can only contain latin\\cyrillic letters (upper\\lowercase).");

            RuleFor(u => u.NickName)
                    .NotEmpty().WithMessage("Nickname can not be empty")
                    .Length(2, 32).WithMessage("Nickname length should have 2-32 symbol")
                    .Matches("[a-zA-Z0-9]{2,32}").WithMessage("Nickname can only contain latin letters (upper\\lowercase).");
        }
    }
}
