using MediatR;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Commands.Remove
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public DeletePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.Get(request.Id);
            if (product != null)
            {
                _repository.Remove(request.Id);
                return true;
            }
            return false;
        }
    }
}
