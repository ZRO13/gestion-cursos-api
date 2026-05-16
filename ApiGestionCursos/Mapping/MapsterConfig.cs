using ApiGestionCursos.Models;
using ApiGestionCursos.Models.Dtos;
using Mapster;

namespace ApiGestionCursos.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            //// =========================
            //// CURSO <-> DTOs
            //// =========================

            //TypeAdapterConfig<Curso, CursoDto>.NewConfig()
            //    .Map(dest => dest.DocenteNombre,
            //         src => src.Docente.Nombre)
            //    .TwoWays();

            //TypeAdapterConfig<Curso, CreateCursoDto>.NewConfig()
            //    .TwoWays();

            //TypeAdapterConfig<Curso, UpdateCursoDto>.NewConfig()
            //    .TwoWays();


            //// =========================
            //// DOCENTE <-> DTOs
            //// =========================

            //TypeAdapterConfig<Docente, DocenteDto>.NewConfig()
            //    .TwoWays();

            //TypeAdapterConfig<Docente, CreateDocenteDto>.NewConfig()
            //    .TwoWays();

            //TypeAdapterConfig<Docente, UpdateDocenteDto>.NewConfig()
            //    .TwoWays();


            //// =========================
            //// ESTUDIANTE <-> DTOs
            //// =========================

            //TypeAdapterConfig<Estudiante, EstudianteDto>.NewConfig()
            //    .TwoWays();

            //TypeAdapterConfig<Estudiante, CreateEstudianteDto>.NewConfig()
            //    .TwoWays();

            //TypeAdapterConfig<Estudiante, UpdateEstudianteDto>.NewConfig()
            //    .TwoWays();


            // =========================
            // USER / AUTH
            // =========================

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