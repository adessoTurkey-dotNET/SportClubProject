using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Commands.Update
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, TeamDto>
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;
        public UpdateTeamCommandHandler(ITeamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TeamDto> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _repository.Get(request.Id);
            if (team != null)
            {
                _repository.Update(team);
                return _mapper.Map<TeamDto>(team);
            }
            return null;
        }
    }
}
