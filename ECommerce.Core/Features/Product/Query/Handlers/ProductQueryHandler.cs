using AutoMapper;
using ECommerce.Core.Features.Product.Query.Dtos;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Core.Response;
using ECommerce.Infrastructure.Interfaces;
using ECommerce.Infrastructure.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Query.Handlers
{
    public class ProductQueryHandler : IRequestHandler<GetProductsDto, ApiResponse<IEnumerable<ProductResponseDto>>>,
        IRequestHandler<GetNotApprovedProductsDto, ApiResponse<IEnumerable<ProductResponseDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> Handle(GetProductsDto request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAsNoTracking(new ProductSpecification(request.Id, request.Name, request.Description, request.Price, request.CategoryId, request.CategoryName, request.Quantity, true ,request.PageSize, request.PageNumber));

            var productResponse = _mapper.Map<IEnumerable<ProductResponseDto>>(products);

            return new ApiResponse<IEnumerable<ProductResponseDto>>
            {
                Data = productResponse,
                Message = "Products retrieved successfully",
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> Handle(GetNotApprovedProductsDto request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAsNoTracking(new ProductSpecification(null, null, null, null, null, null, null, false, request.PageSize, request.PageNumber));

            var productResponse = _mapper.Map<IEnumerable<ProductResponseDto>>(products);

            return new ApiResponse<IEnumerable<ProductResponseDto>>
            {
                Data = productResponse,
                Message = "Products retrieved successfully",
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
