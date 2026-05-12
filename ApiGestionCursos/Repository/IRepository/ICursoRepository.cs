using ApiGestionCursos.Models;

namespace ApiGestionCursos.Repository.IRepository
{
    public interface ICursoRepository
    {
        ICollection<Curso> GetCursos();

        Curso? GetCurso(int id);

        bool CursoExists(int id);

        bool CreateCurso(Curso curso);

        bool UpdateCurso(Curso curso);

        bool DeleteCurso(Curso curso);

        bool Save();
    }
}
