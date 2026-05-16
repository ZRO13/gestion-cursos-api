using ApiGestionCursos.Models;
namespace ApiGestionCursos.Repository.IRepository
{
        public interface IEstudianteRepository
        {
            ICollection<Estudiante> GetEstudiantes();
            Estudiante? GetEstudiante(int id);
            bool EstudianteExists(int id);
            bool CreateEstudiante(Estudiante estudiante);
            bool UpdateEstudiante(Estudiante estudiante);
            bool DeleteEstudiante(Estudiante estudiante);
            bool Save();
        }
    
}
