using ECommerce.Core.Features.Category.Query.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Query.Validators
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdDto>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
