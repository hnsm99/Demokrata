using Microsoft.EntityFrameworkCore;
using TestJelmi.Models;

namespace TestJelmi.Data
{
    public class DataBaseContext: DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("Usuarios");
                //Id
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.Id).ValueGeneratedOnAdd();

                //PrimerNombre
                entity.Property(e => e.PrimerNombre).IsRequired().HasMaxLength(50);

                //SegunNombre
                entity.Property(e=>e.SegundoNombre).HasMaxLength(50);

                //PrimerApellido
                entity.Property(e=>e.PrimerApellido).IsRequired().HasMaxLength(50);

                //SegundoApellido
                entity.Property(e=>e.SegundoApellido).HasMaxLength(50);

                //FechaNacimiento
                entity.Property(e => e.FechaNacimiento).IsRequired();

                //Sueldo
                entity.Property(e => e.Sueldo).IsRequired();

                //FechaCreacion
                entity.Property(e=>e.FechaCreacion).IsRequired();

                //FechaModificación
                entity.Property(e => e.FechaModificacion).IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
