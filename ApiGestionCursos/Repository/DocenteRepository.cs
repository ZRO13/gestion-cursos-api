using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using global::ApiGestionCursos.Models;
using global::ApiGestionCursos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiGestionCursos.Repository
{

        public class DocenteRepository : IDocenteRepository
        {
            private readonly ApplicationDbContext _db;

            public DocenteRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            public ICollection<Docente> GetDocentes()
            {
                return _db.Docentes.OrderBy(d => d.NombreCompleto).ToList();
            }

            public Docente? GetDocente(int id)
            {
                return _db.Docentes.AsNoTracking().FirstOrDefault(d => d.DocenteId == id);
            }

            public bool DocenteExists(int id)
            {
                return _db.Docentes.Any(d => d.DocenteId == id);
            }

            public bool CreateDocente(Docente docente)
            {
                _db.Docentes.Add(docente);
                return Save();
            }

            public bool UpdateDocente(Docente docente)
            {
                _db.Docentes.Update(docente);
                return Save();
            }

            public bool DeleteDocente(Docente docente)
            {
                _db.Docentes.Remove(docente);
                return Save();
            }

            public bool Save()
            {
                return _db.SaveChanges() > 0;
            }
        
    }
}
