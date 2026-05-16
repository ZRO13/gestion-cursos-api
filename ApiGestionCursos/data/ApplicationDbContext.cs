//using Microsoft.EntityFrameworkCore;

//namespace ApiGestionCursos.data
//{
//    public class ApplicationDbContext
//    {
//    }
//}

using ApiGestionCursos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Categoria> Categorias{ get; set; }
    public DbSet<Docente> Docentes { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }
    //public DbSet<Calificaciones>
    public DbSet<User> Users { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<User> Users { get; set; }
    //    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}