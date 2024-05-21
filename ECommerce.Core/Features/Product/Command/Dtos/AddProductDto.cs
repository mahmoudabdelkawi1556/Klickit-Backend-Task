using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Command.Dtos
{
    public class AddProductDto : IRequest<ApiResponse<ProductResponseDto>>
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public IFormFile? Image { get; set; }
        public int? Quantity { get; set; }
    }
}
