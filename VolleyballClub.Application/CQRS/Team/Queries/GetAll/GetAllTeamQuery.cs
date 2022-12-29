using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Team.Queries.GetAll
{
    public class GetAllTeamQuery : IRequest<IEnumerable<TeamDto>>
    {

    }
}
