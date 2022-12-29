using MediatR;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.CQRS.Team.Queries.GetByIdWithProducts
{
    public class GetByIdWithMembersQuery : IRequest<TeamWithMembersDto>
    {
        public int Id { get; set; }
    }
}
