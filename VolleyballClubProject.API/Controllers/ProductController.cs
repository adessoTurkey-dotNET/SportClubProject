using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VolleyballClub.Application.CQRS.Product.Commands.Add;
using VolleyballClub.Application.CQRS.Product.Commands.Remove;
using VolleyballClub.Application.CQRS.Product.Commands.Update;
using VolleyballClub.Application.CQRS.Product.Queries.GetAll;
using VolleyballClub.Application.CQRS.Product.Queries.GetById;
using VolleyballClub.Application.Dtos;

namespace VolleyballClubProject.API.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductQuery();
            var allProducts = await _mediator.Send(query);
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK, allProducts.ToList()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductQuery request)
        {
            var product = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, product));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] DeleteProductCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<bool>.Success(StatusCodes.Status204NoContent, response));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CreateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateProductCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(StatusCodes.Status204NoContent, response));
        }
    }
}
