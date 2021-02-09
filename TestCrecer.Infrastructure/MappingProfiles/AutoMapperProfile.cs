using AutoMapper;
using TestCrecer.Core.Dtos;
using TestCrecer.Core.Entities;

namespace TestCrecer.Infrastructure.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<AccountDto, Account>().ReverseMap();
        }
    }
}