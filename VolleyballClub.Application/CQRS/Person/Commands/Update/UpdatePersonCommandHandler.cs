using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonDto>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        public UpdatePersonCommandHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.Get(request.Id);
            if (product != null)
            {
                _repository.Update(product);
                return _mapper.Map<PersonDto>(product);
            }
            return null;
        }
    }
}
