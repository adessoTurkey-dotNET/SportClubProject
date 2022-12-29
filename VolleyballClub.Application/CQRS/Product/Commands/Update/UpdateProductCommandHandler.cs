using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Exceptions;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.Get(request.Id);
            try
            {
                if (product != null)
                {
                    _repository.Update(product);
                    return _mapper.Map<ProductDto>(product);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new MyExceptions(ex.Message, ex);
            }
                
        }

    }
}
