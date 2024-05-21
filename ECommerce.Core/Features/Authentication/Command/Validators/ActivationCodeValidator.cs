using ECommerce.Core.Features.Authentication.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Authentication.Command.Validators
{
    public class ActivationCodeValidator : AbstractValidator<ActivationCodeDto>
    {
        public ActivationCodeValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.ActivationCode).NotEmpty().WithMessage("Activation code is required");
            RuleFor(x => x.ActivationCode).Length(4).WithMessage("Activation code must be 4 characters");
        }
    }
}
