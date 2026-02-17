using Microsoft.EntityFrameworkCore;
using Entidades;

namespace AccesoDatos
{
    public class PruebaSDContext : DbContext
    {
        public PruebaSDContext(DbContextOptions<PruebaSDContext> options)
            : base(options)
        {
        }

        public DbSet<User> Usuario { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Usuario");
                entity.Property(e => e.Id).HasColumnName("usulD").HasPrecision(18, 0);
                entity.Property(e => e.FirstName).HasColumnName("nombre");
                entity.Property(e => e.LastName).HasColumnName("apellido");
            });
        }
    }
}
