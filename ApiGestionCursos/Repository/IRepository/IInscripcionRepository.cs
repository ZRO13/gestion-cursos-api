using ApiGestionCursos.Models;

namespace ApiGestionCursos.Repository.IRepository
{
    public interface IInscripcionRepository
    {
        ICollection<Inscripcion> GetInscripciones();

        Inscripcion? GetInscripcion(int id);

        bool InscripcionExists(int id);

        bool CreateInscripcion(Inscripcion inscripcion);

        bool UpdateInscripcion(Inscripcion inscripcion);

        bool DeleteInscripcion(Inscripcion inscripcion);

        bool Save();
    }
}