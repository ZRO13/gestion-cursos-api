using AutoMapper;
using ApiGestionCursos.Models;
using ApiGestionCursos.Models.Dtos;

namespace ApiGestionCursos.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserLoginResponseDto>().ReverseMap();
        }
    }
}
