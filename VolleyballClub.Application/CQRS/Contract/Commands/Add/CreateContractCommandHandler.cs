using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Exceptions;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Contract.Commands.Add
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, ContractDto>
    {
        private readonly IContractRepository _repository;
        private readonly IMapper _mapper;
        public CreateContractCommandHandler(IContractRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContractDto> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contract = _mapper.Map<VolleyballClubProject.Core.Entities.Contract>(request);
                await _repository.Add(contract);
                return _mapper.Map<ContractDto>(contract);
            }
            catch (Exception ex)
            {
                throw new MyExceptions(ex.Message, ex);
            }
        }
    }
}
