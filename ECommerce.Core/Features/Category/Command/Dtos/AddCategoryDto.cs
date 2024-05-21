using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Command.Dtos
{
    public class AddCategoryDto : IRequest<ApiResponse<Domain.Models.Category>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
