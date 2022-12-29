using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Queries.GetByIdWithProducts
{
    public class GetByIdWithMembersQueryHandler : IRequestHandler<GetByIdWithMembersQuery, TeamWithMembersDto>
    {
        private readonly ITeamRepository _context;
        private readonly IMapper _mapper;
        public GetByIdWithMembersQueryHandler(ITeamRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamWithMembersDto> Handle(GetByIdWithMembersQuery request, CancellationToken cancellationToken)
        {
            var team = await _context.GetTeamWithMembers(request.Id);
            return _mapper.Map<TeamWithMembersDto>(team);
        }
    }
}
