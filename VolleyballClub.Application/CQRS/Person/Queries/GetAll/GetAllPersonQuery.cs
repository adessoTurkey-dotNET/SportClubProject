using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Person.Queries.GetAll
{
    public class GetAllPersonQuery : IRequest<IEnumerable<PersonDto>>
    {

    }
}
