using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Contract.Queries.GetById
{
    public class GetByIdContractQuery : IRequest<ContractDto>
    {
        public int Id { get; set; }
    }
}
