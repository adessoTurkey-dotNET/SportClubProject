using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Contract.Commands.Update
{
    public class UpdateContractCommand : IRequest<ContractDto>
    {
        public int Id { get; set; }
    }
}
