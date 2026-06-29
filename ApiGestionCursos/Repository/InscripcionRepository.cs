using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiGestionCursos.Repository
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly ApplicationDbContext _db;

        public InscripcionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Inscripcion> GetInscripciones()
        {
            return _db.Inscripciones
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .ToList();
        }

        public Inscripcion? GetInscripcion(int id)
        {
            return _db.Inscripciones
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .AsNoTracking()
                .FirstOrDefault(i => i.InscripcionId == id);
        }

        public bool InscripcionExists(int id)
        {
            return _db.Inscripciones.Any(i => i.InscripcionId == id);
        }

        public bool CreateInscripcion(Inscripcion inscripcion)
        {
            _db.Inscripciones.Add(inscripcion);
            return Save();
        }

        public bool UpdateInscripcion(Inscripcion inscripcion)
        {
            _db.Inscripciones.Update(inscripcion);
            return Save();
        }

        public bool DeleteInscripcion(Inscripcion inscripcion)
        {
            _db.Inscripciones.Remove(inscripcion);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }
    }
}