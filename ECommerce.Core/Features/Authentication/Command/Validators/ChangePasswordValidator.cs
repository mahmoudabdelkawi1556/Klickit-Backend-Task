using ECommerce.Core.Features.Authentication.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Authentication.Command.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New Password is required");
            RuleFor(x => x.NewPassword).Length(6, 20).WithMessage("Password must be between 6 and 20 characters");
        }
    }
}
