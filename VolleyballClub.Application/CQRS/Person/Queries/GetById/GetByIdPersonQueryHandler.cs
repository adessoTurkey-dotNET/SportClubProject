using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Queries.GetById
{
    public class GetByIdPersonQueryHandler : IRequestHandler<GetByIdPersonQuery, PersonDto>
    {
        private readonly IPersonRepository _context;
        private readonly IMapper _mapper;
        public GetByIdPersonQueryHandler(IPersonRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(GetByIdPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _context.Get(request.Id);
            if (person != null)
                return _mapper.Map<PersonDto>(person);
            return null;
        }
    }
}
