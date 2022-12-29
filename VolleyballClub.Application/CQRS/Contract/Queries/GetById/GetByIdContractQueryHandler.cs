using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Contract.Queries.GetById
{
    public class GetByIdContractQueryHandler : IRequestHandler<GetByIdContractQuery, ContractDto>
    {
        private readonly IContractRepository _context;
        private readonly IMapper _mapper;
        public GetByIdContractQueryHandler(IContractRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContractDto> Handle(GetByIdContractQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Get(request.Id);
            if (contract != null)
                return _mapper.Map<ContractDto>(contract);
            return null;
        }
    }
}
