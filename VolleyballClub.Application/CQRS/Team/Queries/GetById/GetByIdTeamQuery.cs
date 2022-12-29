using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Team.Queries.GetById
{
    public class GetByIdTeamQuery : IRequest<TeamDto>
    {
        public int Id { get; set; }
    }
}
