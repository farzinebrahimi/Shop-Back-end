using AutoMapper;
using Shop_API.DTOs;
using Shop_API.Entities.Photos;
using Shop_API.Entities.Users;

namespace Shop_API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(d => d.PhotoUrl,
                opt => 
                    opt.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url));
        CreateMap<Photo, PhotoDto>();
    }
}