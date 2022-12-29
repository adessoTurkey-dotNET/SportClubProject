using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Contract.Commands.Update
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, ContractDto>
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;
        public UpdateContractCommandHandler(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContractDto> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _repository.Get(request.Id);
            if (contract != null)
            {
                _repository.Update(contract);
                return _mapper.Map<ContractDto>(contract);
            }
            return null;
        }
    }
}
