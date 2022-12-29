using AutoMapper;
using VolleyballClub.Application.CQRS.Contract.Commands.Add;
using VolleyballClub.Application.CQRS.Person.Commands.Add;
using VolleyballClub.Application.CQRS.Product.Commands.Add;
using VolleyballClub.Application.CQRS.Team.Commands.Add;
using VolleyballClub.Application.Dtos;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClub.Application.Mapping
{
    public class MyMapping : Profile
    {
        public MyMapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Contract, ContractDto>().ReverseMap();

            CreateMap<UserInfoDto, UserInfo>().ReverseMap();

            CreateMap<TeamDto, Team>().ReverseMap();

            CreateMap<Team, TeamWithMembersDto>();

            CreateMap<Person, PersonWithProductsDto>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreatePersonCommand,Person>();
            CreateMap<CreateContractCommand, Contract>();
            CreateMap<CreateTeamCommand, Team>();

            CreateMap<Person, GetByIdWithProductsQueryDto>();
        }
    }
}
