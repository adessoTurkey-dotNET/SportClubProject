using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Product.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
