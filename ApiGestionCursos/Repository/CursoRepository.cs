using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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
            return _db.Cursos
        .Include(c => c.Docente) // <--- Esta es la clave
        .OrderBy(c => c.Nombre)
        .ToList();
            //return _db.Cursos.OrderBy(c => c.Nombre).ToList();
        }

        public Curso? GetCurso(int id)
        {
            // Usamos AsNoTracking para que EF no rastree esta entidad
            // y no choque con la entidad que enviaremos en el Update

            return _db.Cursos.AsNoTracking().FirstOrDefault(c => c.CursoId == id);
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
