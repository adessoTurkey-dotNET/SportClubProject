using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Queries.GetByIdWithProducts
{
    public class GetByIdWithProductsQueryHandler : IRequestHandler<GetByIdWithProductsQuery, GetByIdWithProductsQueryDto>
    {
        private readonly IPersonRepository _context;
        private readonly IMapper _mapper;
        public GetByIdWithProductsQueryHandler(IPersonRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetByIdWithProductsQueryDto> Handle(GetByIdWithProductsQuery request, CancellationToken cancellationToken)
        {
            var person = await _context.GetPersonWithProducts(request.Id);
            return _mapper.Map<GetByIdWithProductsQueryDto>(person);
        }
    }
}
