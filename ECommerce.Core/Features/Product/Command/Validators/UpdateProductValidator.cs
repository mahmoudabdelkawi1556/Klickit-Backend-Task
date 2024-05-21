using ECommerce.Core.Features.Product.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Command.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Image).Cascade(CascadeMode.Stop)
                .NotEmpty().When(x => x.Image != null).WithMessage("Image is required")
                .Must(x => x?.FileName?.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) == true ||
                           x?.FileName?.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase) == true ||
                           x?.FileName?.EndsWith("png", StringComparison.OrdinalIgnoreCase) == true)
                .When(x => x.Image != null).WithMessage("Invalid file extension");
        }
    }
}
