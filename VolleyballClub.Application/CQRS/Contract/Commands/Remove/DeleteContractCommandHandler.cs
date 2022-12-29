using MediatR;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Contract.Commands.Remove
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, bool>
    {
        private readonly IContractRepository _repository;

        public DeleteContractCommandHandler(IContractRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _repository.Get(request.Id);
            if (contract != null)
            {
                _repository.Remove(request.Id);
                return true;
            }
            return false;
        }
    }
}
