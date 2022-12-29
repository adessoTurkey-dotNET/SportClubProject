using MediatR;

namespace VolleyballClub.Application.CQRS.Contract.Commands.Remove
{
    public class DeleteContractCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
