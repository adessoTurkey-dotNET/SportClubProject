using AutoMapper;
using MediatR;
using VolleyballClub.Application.Dtos;
using VolleyballClub.Application.Exceptions;
using VolleyballClubProject.Application.Interfaces;

namespace VolleyballClub.Application.CQRS.Person.Commands.Add
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonDto>
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        public CreatePersonCommandHandler(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = _mapper.Map<VolleyballClubProject.Core.Entities.Person>(request);
                await _repository.Add(person);
                return _mapper.Map<PersonDto>(person);
            }
            catch (Exception ex)
            {
                throw new MyExceptions(ex.Message, ex);
            }
        }
    }
}
