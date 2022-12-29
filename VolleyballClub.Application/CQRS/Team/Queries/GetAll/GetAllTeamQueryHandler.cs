using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Team.Queries.GetAll
{
    public class GetAllTeamQueryHandler : IRequestHandler<GetAllTeamQuery, IEnumerable<TeamDto>>
    {
        private readonly ITeamRepository _context;
        private readonly IMapper _mapper;
        public GetAllTeamQueryHandler(ITeamRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamQuery request, CancellationToken cancellationToken)
        {
            var teams = await _context.GetAll();
            if (teams.ToList().Count > 0)
            {
                return _mapper.Map<IEnumerable<TeamDto>>(teams);
            }
            throw new Exception("List is Empty");
        }
    }
}
