using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ies_301_WebApi.Domains;

#nullable disable

namespace ies_301_WebApi.Contexts
{
    public partial class OfertasContext : DbContext
    {
        public OfertasContext()
        {
        }

        public OfertasContext(DbContextOptions<OfertasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pfisica> Pfisicas { get; set; }
        public virtual DbSet<Pjuridica> Pjuridicas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QP4FDS5; initial catalog=JaReservei; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Pfisica>(entity =>
            {
                entity.HasKey(e => e.IdPfisica)
                    .HasName("PK__Pfisica__60B4281DEEA0DFC4");

                entity.ToTable("Pfisica");

                entity.HasIndex(e => e.Cpf, "UQ__Pfisica__C1F89731AF636953")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnType("decimal(13, 0)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pfisicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pfisica__IdUsuar__2C3393D0");
            });

            modelBuilder.Entity<Pjuridica>(entity =>
            {
                entity.HasKey(e => e.IdPjuridica)
                    .HasName("PK__Pjuridic__4EE9FF32A92CDBAB");

                entity.ToTable("Pjuridica");

                entity.HasIndex(e => e.Cnpj, "UQ__Pjuridic__AA57D6B4E1042476")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.EmailEmpresa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone).HasColumnType("decimal(13, 0)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pjuridicas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pjuridica__IdUsu__300424B4");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__2E883C236E5AA0F7");

                entity.ToTable("Produto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ImagemProduto)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LinkProduto)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdTipoProdutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdTipoProduto)
                    .HasConstraintName("FK__Produto__IdTipoP__398D8EEE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Produto__IdUsuar__38996AB5");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__0E49C69D96864996");

                entity.ToTable("Reserva");

                entity.Property(e => e.PrecoTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Reserva__IdProdu__3C69FB99");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Reserva__IdUsuar__3D5E1FD2");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProduto)
                    .HasName("PK__TipoProd__F71CDF61045085DC");

                entity.ToTable("TipoProduto");

                entity.Property(e => e.NomeTipoProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B87DEBEDD");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__TipoUsua__52F7E3AA0A88DC39")
                    .IsUnique();

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97A07F7DB6");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105349E226D64")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
