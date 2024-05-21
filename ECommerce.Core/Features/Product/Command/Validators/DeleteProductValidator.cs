using ECommerce.Core.Features.Product.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Command.Validators
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductDto>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
