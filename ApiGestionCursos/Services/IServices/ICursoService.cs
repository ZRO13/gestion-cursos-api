using ApiGestionCursos.Models;

namespace ApiGestionCursos.Services.IServices
{
    public interface ICursoService
    {
        ICollection<Curso> GetCursos();

        Curso? GetCurso(int id);

        bool CreateCurso(Curso curso);

        bool UpdateCurso(Curso curso);

        bool DeleteCurso(int id);
    }
}
