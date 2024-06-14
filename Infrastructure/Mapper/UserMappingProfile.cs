using AutoMapper;
using Domain.Entity;
using Infrastructure.Entity;


namespace Infrastructure.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UsersSite, UserAutorization>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<Entity.Sotrudnik, Domain.Entity.Sotrudnik>();
        }
    }
}
