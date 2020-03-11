using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cookboard.Models
{
    public partial class cookBoardContext : DbContext
    {
        public cookBoardContext()
        {
        }

        public cookBoardContext(DbContextOptions<cookBoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<EmentaSemanal> EmentaSemanal { get; set; }
        public virtual DbSet<EmentaSemanalReceita> EmentaSemanalReceita { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<IngredienteSupermercado> IngredienteSupermercado { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<ReceitaAuxiliar> ReceitaAuxiliar { get; set; }
        public virtual DbSet<ReceitaIngrediente> ReceitaIngrediente { get; set; }
        public virtual DbSet<ReceitaReceitaAuxiliar> ReceitaReceitaAuxiliar { get; set; }
        public virtual DbSet<Supermercado> Supermercado { get; set; }
        public virtual DbSet<SupermercadoLocal> SupermercadoLocal { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
        public virtual DbSet<UtilizadorReceita> UtilizadorReceita { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B57KUKN;Database=cookBoard;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Avaliaca__3214EC06DCE417B4")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avaliacao_Receita");
            });

            modelBuilder.Entity<EmentaSemanal>(entity =>
            {
                entity.HasIndex(e => e.DataLancamento)
                    .HasName("UQ__EmentaSe__F974C94811FCE7C3")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("datetime");

                entity.Property(e => e.UtilizadorUsername)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.UtilizadorUsernameNavigation)
                    .WithMany(p => p.EmentaSemanal)
                    .HasForeignKey(d => d.UtilizadorUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmentaSemanal_Utilizador");
            });

            modelBuilder.Entity<EmentaSemanalReceita>(entity =>
            {
                entity.HasKey(e => new { e.EmentaSemanalId, e.ReceitaId })
                    .HasName("PK__EmentaSe__3BD41B65F331B5C8")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("EmentaSemanal_Receita");

                entity.Property(e => e.Dia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmentaSemanal)
                    .WithMany(p => p.EmentaSemanalReceita)
                    .HasForeignKey(d => d.EmentaSemanalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmentaSemal_Receita_EmentaSemanal");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.EmentaSemanalReceita)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmentaSemal_Receita_Receita");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Ingredie__7D8FE3B22C1DFD41")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IngredienteSupermercado>(entity =>
            {
                entity.HasKey(e => new { e.IngredienteId, e.SupermercadoId })
                    .HasName("PK__Ingredie__293F7CCE542B0CF8");

                entity.ToTable("Ingrediente_Supermercado");

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.IngredienteSupermercado)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingrediente_Supermercado_Ingrediente");

                entity.HasOne(d => d.Supermercado)
                    .WithMany(p => p.IngredienteSupermercado)
                    .HasForeignKey(d => d.SupermercadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingrediente_Supermercado_Supermercado");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Localidade)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasIndex(e => e.Imagem)
                    .HasName("UQ__Receita__345530D74B5F094F")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Receita__7D8FE3B2B8A38DA7")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Dificuldade)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.InfoNutricional)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TempoConfecao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UtilizadorUsername)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.UtilizadorUsernameNavigation)
                    .WithMany(p => p.Receita)
                    .HasForeignKey(d => d.UtilizadorUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receita_Utilizador");
            });

            modelBuilder.Entity<ReceitaAuxiliar>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ReceitaIngrediente>(entity =>
            {
                entity.HasKey(e => new { e.ReceitaId, e.IngredienteId })
                    .HasName("PK__Receita___061B6A522CEE07EA");

                entity.ToTable("Receita_Ingrediente");

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ingrediente)
                    .WithMany(p => p.ReceitaIngrediente)
                    .HasForeignKey(d => d.IngredienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receita_Ingrediente_Ingrediente");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.ReceitaIngrediente)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receita_Ingrediente_Receita");
            });

            modelBuilder.Entity<ReceitaReceitaAuxiliar>(entity =>
            {
                entity.HasKey(e => new { e.ReceitaId, e.ReceitaAuxiliarId })
                    .HasName("PK__Receita___08244E72664B9848");

                entity.ToTable("Receita_ReceitaAuxiliar");

                entity.HasOne(d => d.ReceitaAuxiliar)
                    .WithMany(p => p.ReceitaReceitaAuxiliar)
                    .HasForeignKey(d => d.ReceitaAuxiliarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receita_ReceitaAuxiliar_ReceitaAuxiliar");

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.ReceitaReceitaAuxiliar)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receita_ReceitaAuxiliar_Receita");
            });

            modelBuilder.Entity<Supermercado>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SupermercadoLocal>(entity =>
            {
                entity.HasKey(e => new { e.SupermercadoId, e.LocalId })
                    .HasName("PK__Supermer__FCFB17F46631209D");

                entity.ToTable("Supermercado_Local");

                entity.HasOne(d => d.Local)
                    .WithMany(p => p.SupermercadoLocal)
                    .HasForeignKey(d => d.LocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supermercado_Local_Local");

                entity.HasOne(d => d.Supermercado)
                    .WithMany(p => p.SupermercadoLocal)
                    .HasForeignKey(d => d.SupermercadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supermercado_Local_Supermercado");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Utilizad__536C85E55CF8253E");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Utilizad__A9D10534E297AB18")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UQ__Utilizad__87909B15AFEF4A7E")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UtilizadorReceita>(entity =>
            {
                entity.HasKey(e => new { e.UtilizadorUsername, e.ReceitaId })
                    .HasName("PK__Utilizad__52C3C0A8560EB201");

                entity.ToTable("Utilizador_Receita");

                entity.Property(e => e.UtilizadorUsername)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Receita)
                    .WithMany(p => p.UtilizadorReceita)
                    .HasForeignKey(d => d.ReceitaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Utilizador_Receita_Receita");

                entity.HasOne(d => d.UtilizadorUsernameNavigation)
                    .WithMany(p => p.UtilizadorReceita)
                    .HasForeignKey(d => d.UtilizadorUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Utilizador_Receita_Utilizador");
            });
        }
    }
}
