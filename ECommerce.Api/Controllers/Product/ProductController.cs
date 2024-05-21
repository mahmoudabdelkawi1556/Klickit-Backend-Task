using ECommerce.Api.Controllers.Base;
using ECommerce.Core.Features.Product.Command.Dtos;
using ECommerce.Core.Features.Product.Query.Dtos;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Product
{
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpGet(ProductRoutes.GetProducts)]
        public async Task<IActionResult> GetProducts([FromQuery]GetProductsDto getProductsDto)
        {
            var response = await mediator.Send(getProductsDto);
            return Result(response);
        }

        [HttpDelete(ProductRoutes.DeleteProduct)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await mediator.Send(new DeleteProductDto { Id = id });
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.User))]
        [HttpPost(ProductRoutes.AddProduct)]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto addProductDto)
        {
            var response = await mediator.Send(addProductDto);
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.User))]
        [HttpPut(ProductRoutes.UpdateProduct)]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDto updateProductDto)
        {
            var response = await mediator.Send(updateProductDto);
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPut(ProductRoutes.ApproveProduct)]
        public async Task<IActionResult> ApproveProduct([FromBody] ApproveProductDto approveProductDto)
        {
            var response = await mediator.Send(approveProductDto);
            return Result(response);
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpGet(ProductRoutes.GetNotApproved)]
        public async Task<IActionResult> GetNotApproved()
        {
            var response = await mediator.Send(new GetNotApprovedProductsDto());
            return Result(response);
        }
    }
}
