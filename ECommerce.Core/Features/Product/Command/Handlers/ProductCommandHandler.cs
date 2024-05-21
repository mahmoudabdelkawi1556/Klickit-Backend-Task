using AutoMapper;
using ECommerce.Core.Features.Product.Command.Dtos;
using ECommerce.Core.Mapper.MapperDtos;
using ECommerce.Core.Response;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Helpers.FileUpload;
using ECommerce.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Product.Command.Handlers
{
    public class ProductCommandHandler : 
        IRequestHandler<AddProductDto, ApiResponse<ProductResponseDto>>,
        IRequestHandler<UpdateProductDto, ApiResponse<ProductResponseDto>>,
        IRequestHandler<DeleteProductDto, ApiResponse<string>>,
        IRequestHandler<ApproveProductDto, ApiResponse<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileUpload fileUpload;

        public ProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper, IFileUpload fileUpload)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            this.fileUpload = fileUpload;
        }

        public async Task<ApiResponse<ProductResponseDto>> Handle(UpdateProductDto request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id.Value);
            if (product == null)
            {
                return new ApiResponse<ProductResponseDto> 
                { 
                    Message = "Product not found",
                    Success = false,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value);
            if (category == null)
            {
                return new ApiResponse<ProductResponseDto> 
                { 
                    Message = "Category not found",
                    Success = false,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var newProduct = _mapper.Map(request, product);

            if (request.Image != null)
            {
                var (imageUrl, _) = fileUpload.UploadFile(request.Image, UploadDirectoriesEnum.Product);
                newProduct.ImageUrl = imageUrl;
            }

            var prouctResponse = _mapper.Map<ProductResponseDto>(await _productRepository.UpdateAsync(newProduct));

            return new ApiResponse<ProductResponseDto> 
            { 
                Data = prouctResponse,
                Message = "Product updated successfully",
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponse<string>> Handle(DeleteProductDto request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id.Value);
            if (product == null)
            {
                return new ApiResponse<string> 
                { 
                    Message = "Product not found",
                    StatusCode = HttpStatusCode.NotFound,
                    Success = false
                };
            }

            await _productRepository.DeleteAsync(product);

            return new ApiResponse<string> 
            { 
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Product deleted successfully"
            };
        }

        public async Task<ApiResponse<ProductResponseDto>> Handle(AddProductDto request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value);
            if (category == null)
            {
                return new ApiResponse<ProductResponseDto>
                {
                    Message = "Category not found",
                    Success = false,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var product = _mapper.Map<Domain.Models.Product>(request);

            if (request.Image != null)
            {
                var (imageUrl, _) = fileUpload.UploadFile(request.Image, UploadDirectoriesEnum.Product);
                product.ImageUrl = imageUrl;
            }

            var productResponse = _mapper.Map<ProductResponseDto>(await _productRepository.AddAsync(product));

            return new ApiResponse<ProductResponseDto>
            {
                Data = productResponse,
                Message = "Product added successfully",
                Success = true,
                StatusCode = HttpStatusCode.Created
            };
        }

        public async Task<ApiResponse<string>> Handle(ApproveProductDto request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id.Value);
            if (product == null)
            {
                return new ApiResponse<string>
                {
                    Message = "Product not found",
                    StatusCode = HttpStatusCode.NotFound,
                    Success = false
                };
            }

            product.IsApproved = true;

            await _productRepository.UpdateAsync(product);

            return new ApiResponse<string>
            {
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Product approved successfully"
            };
        }
    }
}
