using ApiGestionCursos.Models;
using ApiGestionCursos.Models.Dtos;
using Mapster;

namespace ApiGestionCursos.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
       
            TypeAdapterConfig<ApplicationUser, UserDto>.NewConfig()
                .TwoWays();

            TypeAdapterConfig<ApplicationUser, UserDataDto>.NewConfig()
                .TwoWays();

            TypeAdapterConfig<ApplicationUser, UserLoginResponseDto>.NewConfig()
                .TwoWays();
            TypeAdapterConfig<ApplicationUser, UserDataDto>
    .NewConfig()
    .Map(dest => dest.Username, src => src.UserName)
    .TwoWays();
        }
    }
}