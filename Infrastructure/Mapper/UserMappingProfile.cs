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
            // Свойство Login должно быть сопоставлено напрямую
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            // Свойство Password в UsersSite игнорируется (предполагается, что его не нужно сопоставлять)
            .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<Domain.Entity.Sotrudnik, Domain.Entity.Sotrudnik>();
        }
    }
}
