using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Command.Dtos
{
    public class UpdateCategoryDto : IRequest<ApiResponse<Domain.Models.Category>>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}
