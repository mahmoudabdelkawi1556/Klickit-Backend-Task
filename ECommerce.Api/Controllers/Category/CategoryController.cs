using ECommerce.Api.Controllers.Base;
using ECommerce.Core.Features.Category.Command.Dtos;
using ECommerce.Core.Features.Category.Query.Dtos;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Category
{
    public class CategoryController : BaseController
    {
        [HttpGet(CategoryRoutes.GetCategories)]
        public async Task<IActionResult> GetCategories()
        {
            var response = await mediator.Send(new GetCategoriesDto());
            return Result(response);
        }

        [HttpGet(CategoryRoutes.GetCategoryById)]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var response = await mediator.Send(new GetCategoryByIdDto { Id = id });
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        [Route(CategoryRoutes.AddCategory)]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto request)
        {
            var response = await mediator.Send(request);
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut]
        [Route(CategoryRoutes.UpdateCategory)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto request)
        {
            var response = await mediator.Send(request);
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpDelete]
        [Route(CategoryRoutes.DeleteCategory)]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var response = await mediator.Send(new DeleteCategoryDto { Id = id });
            return Result(response);
        }
    }
}
