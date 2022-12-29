
using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Team.Commands.Add
{
    public class CreateTeamCommand : IRequest<TeamDto>
    {
        public string Name { get; set; }
    }
}
