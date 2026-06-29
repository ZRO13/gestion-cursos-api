using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Services.IServices;

namespace ApiGestionCursos.Services
{
    public class InscripcionService : IInscripcionService
    {
        private readonly IInscripcionRepository _inscripcionRepository;

        public InscripcionService(IInscripcionRepository inscripcionRepository)
        {
            _inscripcionRepository = inscripcionRepository;
        }

        public ICollection<Inscripcion> GetInscripciones()
            => _inscripcionRepository.GetInscripciones();

        public Inscripcion? GetInscripcion(int id)
            => _inscripcionRepository.GetInscripcion(id);

        public bool CreateInscripcion(Inscripcion inscripcion)
            => _inscripcionRepository.CreateInscripcion(inscripcion);

        public bool UpdateInscripcion(Inscripcion inscripcion)
            => _inscripcionRepository.UpdateInscripcion(inscripcion);

        public bool DeleteInscripcion(Inscripcion inscripcion)
            => _inscripcionRepository.DeleteInscripcion(inscripcion);
    }
}