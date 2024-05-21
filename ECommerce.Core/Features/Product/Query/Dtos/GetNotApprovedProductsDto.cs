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
    public class GetNotApprovedProductsDto : IRequest<ApiResponse<IEnumerable<ProductResponseDto>>>
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
