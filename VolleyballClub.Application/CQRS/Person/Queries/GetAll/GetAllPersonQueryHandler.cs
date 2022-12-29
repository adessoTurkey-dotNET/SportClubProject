using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Queries.GetAll
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, IEnumerable<PersonDto>>
    {
        private readonly IPersonRepository _context;
        private readonly IMapper _mapper;
        public GetAllPersonQueryHandler(IPersonRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var people = await _context.GetAll();
            if (people.ToList().Count > 0)
            {
                return _mapper.Map<IEnumerable<PersonDto>>(people);
            }
            throw new Exception("List is Empty");
        }
    }
}
