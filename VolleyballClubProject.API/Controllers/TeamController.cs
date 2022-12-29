using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VolleyballClub.Application.CQRS.Team.Commands.Add;
using VolleyballClub.Application.CQRS.Team.Commands.Remove;
using VolleyballClub.Application.CQRS.Team.Commands.Update;
using VolleyballClub.Application.CQRS.Team.Queries.GetAll;
using VolleyballClub.Application.CQRS.Team.Queries.GetById;
using VolleyballClub.Application.CQRS.Team.Queries.GetByIdWithProducts;
using VolleyballClub.Application.Dtos;

namespace VolleyballClubProject.API.Controllers
{
    public class TeamController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTeamQuery();
            var all = await _mediator.Send(query);
            return CreateActionResult(CustomResponseDto<List<TeamDto>>.Success(StatusCodes.Status200OK, all.ToList()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdTeamQuery request)
        {
            var team = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(StatusCodes.Status200OK, team));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] CreateTeamCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(StatusCodes.Status201Created, response));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromQuery] DeleteTeamCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<bool>.Success(StatusCodes.Status200OK, response));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateTeamCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(StatusCodes.Status204NoContent, response));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMember([FromQuery] AddMemberToTeamCommand request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<bool>.Success(StatusCodes.Status200OK, response));
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTeamWithMembers([FromQuery] GetByIdWithMembersQuery request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResult(CustomResponseDto<TeamWithMembersDto>.Success(StatusCodes.Status200OK, response));
        }
    }
}
