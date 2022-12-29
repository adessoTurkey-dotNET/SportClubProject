using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Product.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
}
