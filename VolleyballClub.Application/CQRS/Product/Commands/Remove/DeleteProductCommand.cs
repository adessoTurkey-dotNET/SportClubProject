using MediatR;

namespace VolleyballClub.Application.CQRS.Product.Commands.Remove
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
