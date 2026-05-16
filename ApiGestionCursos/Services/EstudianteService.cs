using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Services.IServices;

namespace ApiGestionCursos.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public ICollection<Estudiante> GetEstudiantes() => _estudianteRepository.GetEstudiantes();

        public Estudiante? GetEstudiante(int id) => _estudianteRepository.GetEstudiante(id);

        public bool CreateEstudiante(Estudiante estudiante) => _estudianteRepository.CreateEstudiante(estudiante);

        public bool UpdateEstudiante(Estudiante estudiante) => _estudianteRepository.UpdateEstudiante(estudiante);

        public bool DeleteEstudiante(Estudiante estudiante) => _estudianteRepository.DeleteEstudiante(estudiante);
    }
}
