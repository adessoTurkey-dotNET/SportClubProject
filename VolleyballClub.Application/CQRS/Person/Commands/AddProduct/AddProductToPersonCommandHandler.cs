using MediatR;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Commands.Add
{
    public class AddProductToPersonCommandHandler : IRequestHandler<AddProductToPersonCommand, bool>
    {
        private readonly IPersonRepository _repository;
        private readonly IProductRepository _productRepository;

        public AddProductToPersonCommandHandler(IPersonRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(AddProductToPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.Get(request.Id);
            var product = await _productRepository.Get(request.ProductId);
            if (person != null && product != null)
            {
                await _repository.AddProduct(request.Id, request.ProductId);
                return true;
            }            
            return false;
        }
    }
}
