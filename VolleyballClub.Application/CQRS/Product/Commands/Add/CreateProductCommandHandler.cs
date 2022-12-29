using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Exceptions;
using VolleyballClubProject.Application.Interfaces;


namespace VolleyballClub.Application.CQRS.Product.Commands.Add
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<VolleyballClubProject.Core.Entities.Product>(request);
            try
            {
                await _repository.Add(product);
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                throw new MyExceptions(ex.Message, ex);
            }
        }
    }
}
