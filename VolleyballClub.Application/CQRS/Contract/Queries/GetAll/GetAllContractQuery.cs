using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Contract.Queries.GetAll
{
    public class GetAllContractQuery : IRequest<IEnumerable<ContractDto>>
    {

    }
}
