using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Product.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _context;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IProductRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.GetAll();
            if (products.ToList().Count > 0)
            {
                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            throw new Exception("List is Empty");
        }
    }
}
