using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Exceptions;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Contract.Queries.GetAll
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllContractQuery, IEnumerable<ContractDto>>
    {
        private readonly IContractRepository _context;
        private readonly IMapper _mapper;
        public GetAllPersonQueryHandler(IContractRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractDto>> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _context.GetAll();
            if (contracts.ToList().Count > 0 && contracts != null)
            {
                return _mapper.Map<IEnumerable<ContractDto>>(contracts);
            }
            throw new Exception("List is Empty");
        }
    }
}
