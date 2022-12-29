using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VolleyballClub.Application.CQRS.Contract.Commands.Add;
using VolleyballClub.Application.CQRS.Contract.Commands.Update;
using VolleyballClub.Application.CQRS.Contract.Queries.GetAll;
using VolleyballClub.Application.CQRS.Contract.Queries.GetById;
using VolleyballClub.Application.CQRS.Person.Commands.Remove;
using VolleyballClub.Application.Dtos;

namespace VolleyballClubProject.API.Controllers
{
    public class ContractController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ContractController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllContractQuery();
            var all = await _mediator.Send(query);
            return CreateActionResult(CustomResponseDto<List<ContractDto>>.Success(StatusCodes.Status200OK, all.ToList()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdContractQuery request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<ContractDto>.Success(StatusCodes.Status200OK, response));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CreateContractCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<ContractDto>.Success(StatusCodes.Status201Created, response));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] DeletePersonCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<bool>.Success(StatusCodes.Status200OK, response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateContractCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<ContractDto>.Success(StatusCodes.Status204NoContent, response));
        }
    }
}
