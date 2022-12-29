using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Person.Queries.GetByIdWithProducts
{
    public class GetByIdWithProductsQuery : IRequest<GetByIdWithProductsQueryDto>
    {
        public int Id { get; set; }
    }
}
