using ECommerce.Core.Features.Product.Command.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Command.Validators
{
    public class AddProductValidator : AbstractValidator<AddProductDto>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required");
            RuleFor(x => x.Image).Cascade(CascadeMode.Stop)
                .NotEmpty().When(x => x.Image != null)
                .Must(x => x?.FileName?.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) == true ||
                           x?.FileName?.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase) == true ||
                           x?.FileName?.EndsWith("png", StringComparison.OrdinalIgnoreCase) == true)
                .When(x => x.Image != null).WithMessage("Invalid file extension");
        }
    }
}
