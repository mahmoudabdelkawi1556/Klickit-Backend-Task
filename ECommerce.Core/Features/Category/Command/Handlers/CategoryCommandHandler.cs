using AutoMapper;
using ECommerce.Core.Features.Category.Command.Dtos;
using ECommerce.Core.Response;
using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Features.Category.Command.Handlers
{
    public class CategoryCommandHandler :
        IRequestHandler<AddCategoryDto, ApiResponse<Domain.Models.Category>>,
        IRequestHandler<UpdateCategoryDto, ApiResponse<Domain.Models.Category>>,
        IRequestHandler<DeleteCategoryDto, ApiResponse<string>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Domain.Models.Category>> Handle(AddCategoryDto request, CancellationToken cancellationToken)
        {
            var categoryExists = await _categoryRepository.GetByNameAsync(request.Name);

            if (categoryExists != null)
            {
                return new ApiResponse<Domain.Models.Category>
                {
                    Data = null,
                    Message = "Category already exists",
                    Success = false,
                    StatusCode = HttpStatusCode.Conflict
                };
            }

            var category = _mapper.Map<Domain.Models.Category>(request);

            var result = await _categoryRepository.AddAsync(category);

            return new ApiResponse<Domain.Models.Category>
            {
                Data = result,
                Message = "Category added successfully",
                Success = true,
                StatusCode = HttpStatusCode.Created
            };
        }

        public async Task<ApiResponse<Domain.Models.Category>> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Models.Category>(request);

            var result = await _categoryRepository.UpdateAsync(category);

            return new ApiResponse<Domain.Models.Category>
            {
                Data = result,
                Message = "Category updated successfully",
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ApiResponse<string>> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id.Value);

            if (category == null)
            {
                return new ApiResponse<string>
                {
                    Data = null,
                    Message = "Category not found",
                    Success = false,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            await _categoryRepository.DeleteAsync(category);

            return new ApiResponse<string>
            {
                Data = null,
                Message = "Category deleted successfully",
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
