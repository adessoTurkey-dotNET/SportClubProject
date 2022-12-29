using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Exceptions;
using VolleyballClub.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Commands.Add
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, TeamDto>
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;
        public CreateTeamCommandHandler(ITeamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TeamDto> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var team = _mapper.Map<VolleyballClubProject.Core.Entities.Team>(request);
                await _repository.Add(team);
                return _mapper.Map<TeamDto>(team);
            }
            catch (Exception ex)
            {
                throw new MyExceptions(ex.Message, ex);
            }
        }
    }
}
