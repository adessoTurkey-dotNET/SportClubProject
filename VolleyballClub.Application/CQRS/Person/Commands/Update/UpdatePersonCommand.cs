using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Person.Commands.Update
{
    public class UpdatePersonCommand : IRequest<PersonDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
