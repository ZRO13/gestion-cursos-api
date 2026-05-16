using ApiGestionCursos.Models;
namespace ApiGestionCursos.Services.IServices
{

   
        public interface IEstudianteService
        {
            ICollection<Estudiante> GetEstudiantes();
            Estudiante? GetEstudiante(int id);
            bool CreateEstudiante(Estudiante estudiante);
            bool UpdateEstudiante(Estudiante estudiante);
            bool DeleteEstudiante(Estudiante estudiante);
        }
    
}
