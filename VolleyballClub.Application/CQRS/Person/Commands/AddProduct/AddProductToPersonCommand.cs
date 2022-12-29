
using MediatR;

namespace VolleyballClub.Application.CQRS.Person.Commands.Add
{
    public class AddProductToPersonCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
    }
}
