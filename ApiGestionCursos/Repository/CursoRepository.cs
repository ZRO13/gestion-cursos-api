using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;

namespace ApiGestionCursos.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _db;

        public CursoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Curso> GetCursos()
        {
            return _db.Cursos.OrderBy(c => c.Nombre).ToList();
        }

        public Curso? GetCurso(int id)
        {
            return _db.Cursos.FirstOrDefault(c => c.CursoId == id);
        }

        public bool CursoExists(int id)
        {
            return _db.Cursos.Any(c => c.CursoId == id);
        }

        public bool CreateCurso(Curso curso)
        {
            _db.Cursos.Add(curso);
            return Save();
        }

        public bool UpdateCurso(Curso curso)
        {
            _db.Cursos.Update(curso);
            return Save();
        }

        public bool DeleteCurso(Curso curso)
        {
            _db.Cursos.Remove(curso);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}
