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

        private void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).IsRequired();
        }
    }
}
