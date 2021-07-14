using AutoMapper;
using Domain.Models;
using System.Linq;


namespace Domain.DTO
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, UserProfileRequestDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserProfileResponseDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserRequestDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserResponseDTO>().ReverseMap();
        }
    }
}
