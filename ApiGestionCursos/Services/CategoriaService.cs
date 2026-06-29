using ApiGestionCursos.Models;
using ApiGestionCursos.Repository.IRepository;
using ApiGestionCursos.Services.IServices;

namespace ApiGestionCursos.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _categoriaRepository.GetCategorias();
        }

        public Categoria? GetCategoria(int id)
        {
            return _categoriaRepository.GetCategoria(id);
        }

        public bool CreateCategoria(Categoria categoria)
        {
            return _categoriaRepository.CreateCategoria(categoria);
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            return _categoriaRepository.UpdateCategoria(categoria);
        }

        public bool DeleteCategoria(Categoria categoria)
        {
            return _categoriaRepository.DeleteCategoria(categoria);
        }
    }
}