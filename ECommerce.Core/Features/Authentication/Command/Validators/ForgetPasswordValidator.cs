using ECommerce.Core.Features.Authentication.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Authentication.Command.Validators
{
    public class ForgetPasswordValidator : AbstractValidator<ForgetPasswordDto>
    {
        public ForgetPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
        }
    }
}
