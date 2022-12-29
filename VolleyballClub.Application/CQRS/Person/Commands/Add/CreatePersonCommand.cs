
using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Person.Commands.Add
{
    public class CreatePersonCommand : IRequest<PersonDto>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
