using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PulposReina.Models
{
    public partial class pulposreinaContext : DbContext
    {
        public pulposreinaContext()
        {
        }

        public pulposreinaContext(DbContextOptions<pulposreinaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=pulposreina;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Clasificacion)
                    .HasColumnType("int(1)")
                    .HasColumnName("clasificacion");

                entity.Property(e => e.Contacto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("contacto");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rappel).HasColumnName("rappel");

                entity.Property(e => e.Telefono)
                    .HasColumnType("int(9)")
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("pass");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
