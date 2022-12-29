using MediatR;
using VolleyballClub.Application.Interfaces;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Commands.Add
{
    public class AddMemberToTeamCommandHandler : IRequestHandler<AddMemberToTeamCommand, bool>
    {
        private readonly IPersonRepository _repository;
        private readonly ITeamRepository _teamRepository;

        public AddMemberToTeamCommandHandler(IPersonRepository repository, ITeamRepository teamRepository)
        {
            _repository = repository;
            _teamRepository = teamRepository;
        }

        public async Task<bool> Handle(AddMemberToTeamCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.Get(request.PersonId);
            var team = await _teamRepository.Get(request.Id);
            if (person != null && team != null)
            {
                await _teamRepository.AddMember(request.Id, request.PersonId);
                return true;
            }            
            return false;
        }
    }
}
