using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Person.Queries.GetById
{
    public class GetByIdPersonQuery : IRequest<PersonDto>
    {
        public int Id { get; set; }
    }
}
