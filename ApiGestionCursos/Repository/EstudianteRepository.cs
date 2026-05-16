using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiGestionCursos.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationDbContext _db;

        public EstudianteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Estudiante> GetEstudiantes()
        {
            return _db.Estudiantes.OrderBy(e => e.NombreCompleto).ToList();
        }

        public Estudiante? GetEstudiante(int id)
        {
            return _db.Estudiantes.AsNoTracking().FirstOrDefault(e => e.EstudianteId == id);
        }

        public bool EstudianteExists(int id)
        {
            return _db.Estudiantes.Any(e => e.EstudianteId == id);
        }

        public bool CreateEstudiante(Estudiante estudiante)
        {
            _db.Estudiantes.Add(estudiante);
            return Save();
        }

        public bool UpdateEstudiante(Estudiante estudiante)
        {
            _db.Estudiantes.Update(estudiante); // Corregido typo común
            return Save();
        }

        public bool DeleteEstudiante(Estudiante estudiante)
        {
            _db.Estudiantes.Remove(estudiante);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }
    }
}