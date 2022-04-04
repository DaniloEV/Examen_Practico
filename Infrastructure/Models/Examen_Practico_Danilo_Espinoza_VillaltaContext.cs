using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Models
{
    public partial class Examen_Practico_Danilo_Espinoza_VillaltaContext : DbContext
    {
        public Examen_Practico_Danilo_Espinoza_VillaltaContext()
        {
        }

        public Examen_Practico_Danilo_Espinoza_VillaltaContext(DbContextOptions<Examen_Practico_Danilo_Espinoza_VillaltaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolPermiso> RolPermiso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Examen_Practico_Danilo_Espinoza_Villalta;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.HasKey(e => new { e.RolId, e.PermisoId });

                entity.ToTable("Rol_Permiso");

                entity.Property(e => e.RolId).HasColumnName("Rol_id");

                entity.Property(e => e.PermisoId).HasColumnName("Permiso_id");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.RolPermiso)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Permiso_Rol_Permiso");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolPermiso)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Rol_Rol_Permiso");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NombreUsuario);

                entity.Property(e => e.NombreUsuario)
                    .HasColumnName("Nombre_Usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContrasennaUsuario)
                    .HasColumnName("Contrasenna_Usuario")
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("Rol_Id");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("Fk_Rol_Usuario");
            });
        }
    }
}
