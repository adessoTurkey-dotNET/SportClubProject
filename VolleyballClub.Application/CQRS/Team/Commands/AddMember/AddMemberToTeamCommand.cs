
using MediatR;

namespace VolleyballClub.Application.CQRS.Team.Commands.Add
{
    public class AddMemberToTeamCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
    }
}
