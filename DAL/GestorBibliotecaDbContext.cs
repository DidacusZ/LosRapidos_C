using DAL.Modelos;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class GestorBibliotecaDbContext : DbContext
    {

        public GestorBibliotecaDbContext(DbContextOptions options) : base(options)
        {
        }

        public GestorBibliotecaDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Proyecto-GestorBiblioteca-LosRapidos;User Id=postgres;Password=diego; SearchPath=public");

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            Usuarios admin = new Usuarios
            {
                id_usuario = 1,
                dni_usuario = "1",
                clave_usuario = "ac9689e2272427085e35b9d3e3e8bed88cb3434828b43b86fc0596cad4c6e270",
                nombre_usuario = "ADMIN",
                apellidos_usuario = "ADMIN",
                email_usuario = "admin@gmail.com",
                tlf_usuario = "1",
                fch_alta_usuario = DateTime.Now.ToUniversalTime(),
            };

            modelBuilder.Entity<Usuarios>().HasData(admin);

            //Prestamos-Usuario
            modelBuilder.Entity<Prestamos>()
            .HasOne(uno => uno.usuario)
            .WithMany(muchos => muchos.PrestamoUsuario)
            .HasForeignKey(uno => uno.id_usuario);

            //Libros-Prestamos
            modelBuilder.Entity<Libros>()
            .HasMany(e => e.PrestamosLibros)
            .WithMany(e => e.LibrosPrestamos)
            .UsingEntity(
            "Rel_Prestamos_Libros",
            r => r.HasOne(typeof(Prestamos)).WithMany().HasForeignKey("id_prestamo").HasPrincipalKey(nameof(Prestamos.id_prestamo)),//poner primero contrario a entidad inicial(Libros)
            l => l.HasOne(typeof(Libros)).WithMany().HasForeignKey("id_libro").HasPrincipalKey(nameof(Libros.id_libro)),
            j => j.HasKey("id_libro", "id_prestamo")
            );
        }

    }
}