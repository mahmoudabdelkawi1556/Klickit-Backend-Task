using ECommerce.Core.Features.Authentication.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Authentication.Command.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).Length(6, 20).WithMessage("Password must be between 6 and 20 characters");
        }
    }
}
