using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Queries.GetById
{
    public class GetByIdTeamQueryHandler : IRequestHandler<GetByIdTeamQuery, TeamDto>
    {
        private readonly ITeamRepository _context;
        private readonly IMapper _mapper;
        public GetByIdTeamQueryHandler(ITeamRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeamDto> Handle(GetByIdTeamQuery request, CancellationToken cancellationToken)
        {
            var team = await _context.Get(request.Id);
            if (team != null)
                return _mapper.Map<TeamDto>(team);
            return null;
        }
    }
}
