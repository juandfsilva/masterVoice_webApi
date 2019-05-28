using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MasterVoiceService.Model
{
    public partial class mastervoiceContext : DbContext
    {
        public mastervoiceContext()
        {
        }

        public mastervoiceContext(DbContextOptions<mastervoiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClientePerguntaResposta> ClientePerguntaResposta { get; set; }
        public virtual DbSet<ClienteResultado> ClienteResultado { get; set; }
        public virtual DbSet<FormularioPergunta> FormularioPergunta { get; set; }
        public virtual DbSet<FormularioQuestionario> FormularioQuestionario { get; set; }
        public virtual DbSet<FormularioResposta> FormularioResposta { get; set; }
        public virtual DbSet<FormularioResultado> FormularioResultado { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=01031996;database=mastervoice");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente", "mastervoice");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("fk_grupo");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuario_cliente");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnName("celular")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("id_grupo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nascimento)
                    .HasColumnName("nascimento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Responsavel)
                    .HasColumnName("responsavel")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grupo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_usuario_cliente");
            });

            modelBuilder.Entity<ClientePerguntaResposta>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdPergunta, e.IdResposta, e.IdCliente });

                entity.ToTable("cliente_pergunta_resposta", "mastervoice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPergunta)
                    .HasColumnName("id_pergunta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdResposta)
                    .HasColumnName("id_resposta")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataPreenchimento)
                    .HasColumnName("data_preenchimento")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Respondido)
                    .HasColumnName("respondido")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ClienteResultado>(entity =>
            {
                entity.ToTable("cliente_resultado", "mastervoice");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("cliente_id_idx");

                entity.HasIndex(e => e.IdQuestionario)
                    .HasName("questionario_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataResposta)
                    .IsRequired()
                    .HasColumnName("dataResposta")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdQuestionario)
                    .HasColumnName("idQuestionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Resultado)
                    .HasColumnName("resultado")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteResultado)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_id");

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.ClienteResultado)
                    .HasForeignKey(d => d.IdQuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("questionario_id");
            });

            modelBuilder.Entity<FormularioPergunta>(entity =>
            {
                entity.ToTable("formulario_pergunta", "mastervoice");

                entity.HasIndex(e => e.IdQuestionario)
                    .HasName("fk_pergunta_questionario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdQuestionario)
                    .HasColumnName("id_questionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pergunta)
                    .HasColumnName("pergunta")
                    .HasColumnType("longtext");

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.FormularioPergunta)
                    .HasForeignKey(d => d.IdQuestionario)
                    .HasConstraintName("fk_pergunta_questionario");
            });

            modelBuilder.Entity<FormularioQuestionario>(entity =>
            {
                entity.ToTable("formulario_questionario", "mastervoice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormularioResposta>(entity =>
            {
                entity.ToTable("formulario_resposta", "mastervoice");

                entity.HasIndex(e => e.IdQuestionario)
                    .HasName("fk_resposta_questionario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdQuestionario)
                    .HasColumnName("id_questionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PesoResposta)
                    .HasColumnName("peso_resposta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Resposta)
                    .HasColumnName("resposta")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.FormularioResposta)
                    .HasForeignKey(d => d.IdQuestionario)
                    .HasConstraintName("fk_resposta_questionario");
            });

            modelBuilder.Entity<FormularioResultado>(entity =>
            {
                entity.ToTable("formulario_resultado", "mastervoice");

                entity.HasIndex(e => e.IdQuestionario)
                    .HasName("fk_resultado_questionario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdQuestionario)
                    .HasColumnName("id_questionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RangeFim)
                    .HasColumnName("range_fim")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RangeIni)
                    .HasColumnName("range_ini")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Resultado)
                    .HasColumnName("resultado")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.FormularioResultado)
                    .HasForeignKey(d => d.IdQuestionario)
                    .HasConstraintName("fk_resultado_questionario");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo", "mastervoice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login", "mastervoice");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_usuario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario", "mastervoice");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
