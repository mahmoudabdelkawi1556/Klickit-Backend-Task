using ECommerce.Core.Features.Category.Command.Dtos;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Query.Dtos
{
    public class GetProductsDto : IRequest<ApiResponse<IEnumerable<ProductResponseDto>>>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Quantity { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
