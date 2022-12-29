using MediatR;

namespace VolleyballClub.Application.CQRS.Team.Commands.Remove
{
    public class DeleteTeamCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
