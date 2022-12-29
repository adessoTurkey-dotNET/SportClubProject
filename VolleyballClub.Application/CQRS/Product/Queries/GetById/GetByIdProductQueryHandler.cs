using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Product.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private readonly IProductRepository _context;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Get(request.Id);
            if (product != null)
                return _mapper.Map<ProductDto>(product);
            return null;
        }
    }
}
