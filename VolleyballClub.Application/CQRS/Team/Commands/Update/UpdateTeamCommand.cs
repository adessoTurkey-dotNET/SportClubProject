using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Team.Commands.Update
{
    public class UpdateTeamCommand : IRequest<TeamDto>
    {
        public int Id { get; set; }
        public string Name { get; set;}
    }
}
