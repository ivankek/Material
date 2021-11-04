using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BD.EF
{
    public partial class _20212cEjemplo2ParcialContext : DbContext
    {
        public _20212cEjemplo2ParcialContext()
        {
        }

        public _20212cEjemplo2ParcialContext(DbContextOptions<_20212cEjemplo2ParcialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Perro> Perros { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=2021-2c-Ejemplo-2Parcial;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Perro>(entity =>
            {
                entity.HasKey(e => e.IdPerro);

                entity.ToTable("Perro");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdRazaNavigation)
                    .WithMany(p => p.Perros)
                    .HasForeignKey(d => d.IdRaza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perro_Raza");
            });

            modelBuilder.Entity<Raza>(entity =>
            {
                entity.HasKey(e => e.IdRaza);

                entity.ToTable("Raza");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
