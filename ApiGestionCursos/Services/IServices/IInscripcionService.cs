using ApiGestionCursos.Models;

namespace ApiGestionCursos.Services.IServices
{
    public interface IInscripcionService
    {
        ICollection<Inscripcion> GetInscripciones();

        Inscripcion? GetInscripcion(int id);

        bool CreateInscripcion(Inscripcion inscripcion);

        bool UpdateInscripcion(Inscripcion inscripcion);

        bool DeleteInscripcion(Inscripcion inscripcion);
    }
}