using Microsoft.EntityFrameworkCore;
using Portafolio.Model;

namespace Portafolio.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Tecnologia> Tecnologia { get; set; }
        public DbSet<TecnologiaProyecto> TecnologiaProyecto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).IsRequired();

            modelBuilder.Entity<Imagen>().ToTable("Imagen");
            modelBuilder.Entity<Imagen>().HasKey(i => i.Id);
            modelBuilder.Entity<Imagen>().Property(i => i.Id);
            modelBuilder.Entity<Imagen>().Property(i => i.Url);

            modelBuilder.Entity<Proyecto>().ToTable("Proyecto");
            modelBuilder.Entity<Proyecto>().HasKey(p => p.Id);
            modelBuilder.Entity<Proyecto>().Property(p => p.Id);
            modelBuilder.Entity<Proyecto>().Property(p => p.Titulo);
            modelBuilder.Entity<Proyecto>().Property(p => p.Descripcion);
            modelBuilder.Entity<Proyecto>().Property(p => p.UrlGitHub);
            modelBuilder.Entity<Proyecto>().Property(p => p.UrlDemo);
            modelBuilder.Entity<Proyecto>().Property(p => p.ImgId);

            modelBuilder.Entity<Tecnologia>().ToTable("Tecnologia");
            modelBuilder.Entity<Tecnologia>().HasKey(t => t.Id);
            modelBuilder.Entity<Tecnologia>().Property(t => t.Id);
            modelBuilder.Entity<Tecnologia>().Property(t => t.Nombre);
            modelBuilder.Entity<Tecnologia>().Property(t => t.ImgId);

            modelBuilder.Entity<TecnologiaProyecto>().ToTable("TecnologiaProyecto");
            modelBuilder.Entity<TecnologiaProyecto>().HasKey(tp => new { tp.ProyectoId, tp.TecnologiaId });
            modelBuilder.Entity<TecnologiaProyecto>().Property(tp => tp.ProyectoId);
            modelBuilder.Entity<TecnologiaProyecto>().Property(tp => tp.TecnologiaId);
        }
    }
}
