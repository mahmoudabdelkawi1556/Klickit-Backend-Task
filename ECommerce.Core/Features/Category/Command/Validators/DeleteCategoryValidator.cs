using ECommerce.Core.Features.Category.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Command.Validators
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryDto>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
