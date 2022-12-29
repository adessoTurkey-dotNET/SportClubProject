using MediatR;
using VolleyballClub.Application.Exceptions;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Product.Commands.Remove
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var p = _repository.Get(request.Id);
                if (p != null)
                {
                    _repository.Remove(request.Id);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new MyExceptions(ex.Message, ex);
            }
        }
    }
}
