using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VolleyballClub.Application.CQRS.Person.Commands.Add;
using VolleyballClub.Application.CQRS.Person.Commands.Remove;
using VolleyballClub.Application.CQRS.Person.Commands.Update;
using VolleyballClub.Application.CQRS.Person.Queries.GetAll;
using VolleyballClub.Application.CQRS.Person.Queries.GetById;
using VolleyballClub.Application.CQRS.Person.Queries.GetByIdWithProducts;
using VolleyballClub.Application.Dtos;

namespace VolleyballClubProject.API.Controllers
{
    public class PersonController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPersonQuery();
            var allPerson = await _mediator.Send(query);
            return CreateActionResult(CustomResponseDto<List<PersonDto>>.Success(StatusCodes.Status200OK, allPerson.ToList()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdPersonQuery request)
        {
            var person = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(StatusCodes.Status200OK, person));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CreatePersonCommand request) 
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(StatusCodes.Status201Created, response));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] DeletePersonCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<bool>.Success(StatusCodes.Status200OK, response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdatePersonCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(StatusCodes.Status204NoContent, response));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct([FromQuery] AddProductToPersonCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<bool>.Success(StatusCodes.Status200OK, response));
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPersonWithProducts([FromQuery] GetByIdWithProductsQuery request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<GetByIdWithProductsQueryDto>.Success(StatusCodes.Status200OK, response));
        }
    }
}
