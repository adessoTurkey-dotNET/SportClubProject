using MediatR;

namespace VolleyballClub.Application.CQRS.Person.Commands.Remove
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
