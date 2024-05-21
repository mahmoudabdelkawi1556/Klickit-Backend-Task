using ECommerce.Core.Features.Category.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Command.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
