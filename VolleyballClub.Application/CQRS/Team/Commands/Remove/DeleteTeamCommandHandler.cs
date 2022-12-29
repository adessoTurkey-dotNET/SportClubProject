using MediatR;
using VolleyballClub.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Commands.Remove
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, bool>
    {
        private readonly ITeamRepository _repository;

        public DeleteTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _repository.Get(request.Id);
            if (team != null)
            {
                _repository.Remove(request.Id);
                return true;
            }
            return false;
        }
    }
}
