using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Services.IServices;

namespace ApiGestionCursos.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepo;

        public CursoService(ICursoRepository cursoRepo)
        {
            _cursoRepo = cursoRepo;
        }

        public ICollection<Curso> GetCursos()
        {
            return _cursoRepo.GetCursos();
        }

        public Curso? GetCurso(int id)
        {
            return _cursoRepo.GetCurso(id);
        }

        public bool CreateCurso(Curso curso)
        {
            if (_cursoRepo.CursoExists(curso.CursoId))
            {
                return false;
            }

            return _cursoRepo.CreateCurso(curso);
        }

        public bool UpdateCurso(Curso curso)
        {
            return _cursoRepo.UpdateCurso(curso);
        }

        public bool DeleteCurso(int id)
        {
            var curso = _cursoRepo.GetCurso(id);

            if (curso == null)
            {
                return false;
            }

            return _cursoRepo.DeleteCurso(curso);
        }
    }
}
