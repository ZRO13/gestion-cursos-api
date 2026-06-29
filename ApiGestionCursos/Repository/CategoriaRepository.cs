using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiGestionCursos.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _db.Categorias
                .OrderBy(c => c.Nombre)
                .ToList();
        }

        public Categoria? GetCategoria(int id)
        {
            return _db.Categorias
                .AsNoTracking()
                .FirstOrDefault(c => c.CategoriaId == id);
        }

        public bool CategoriaExists(int id)
        {
            return _db.Categorias.Any(c => c.CategoriaId == id);
        }

        public bool CreateCategoria(Categoria categoria)
        {
            _db.Categorias.Add(categoria);
            return Save();
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            _db.Categorias.Update(categoria);
            return Save();
        }

        public bool DeleteCategoria(Categoria categoria)
        {
            _db.Categorias.Remove(categoria);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }
    }
}