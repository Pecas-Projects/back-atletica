using Back_Atletica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Data
{
    public class AtleticaContext : DbContext
    {
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<AtletaModalidade> AtletaModalidades { get; set; }
        public DbSet<AtletaModalidadeTimeEscalado> AtletaModalidadeTimesEscalados { get; set; }
        public DbSet<Atletica> Atleticas { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Faculdade> Faculdades { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<SolicitacaoAtleta> SolicitacaoAtletas { get; set; }
        public DbSet<TimeEscalado> TimeEscalados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string de conexão com o Postgree
            string connStr = Env.ConnString;
            optionsBuilder.UseNpgsql(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Atletas */
            modelBuilder.Entity<Atleta>().HasKey(am => new { am.AtletaId });

            modelBuilder.Entity<Atleta>()
                .Property(p => p.Ativo)
                .IsRequired();

            /* Atletica */
            modelBuilder.Entity<Atletica>().HasKey(am => new { am.AtleticaId });

            modelBuilder.Entity<Atletica>()
               .HasOne<Campus>(am => am.Campus)
               .WithMany(a => a.Atleticas)
               .HasForeignKey(am => am.CampusId);

            modelBuilder.Entity<Atletica>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder
                .Entity<Atletica>()
                .HasIndex(u => u.Email)
                    .IsUnique();

            modelBuilder.Entity<Atletica>()
                .Property(p => p.Email)
                .HasMaxLength(254)
                .IsRequired();

            modelBuilder.Entity<Atletica>()
                .Property(p => p.Senha)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Atletica>()
                .Property(p => p.Descricao)
                .HasMaxLength(500);

            modelBuilder
                .Entity<Atletica>()
                .HasIndex(u => u.PIN)
                    .IsUnique();

            modelBuilder.Entity<Atletica>()
                .Property(p => p.PIN)
                .HasMaxLength(5)
                .IsRequired();

            /* SolicitacaoAtleta*/
            modelBuilder.Entity<SolicitacaoAtleta>().HasKey(am => new { am.SolicitacaoAtletaId });

            modelBuilder.Entity<SolicitacaoAtleta>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.SolicitacaoAtletas)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<SolicitacaoAtleta>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<SolicitacaoAtleta>()
                .Property(p => p.Sobrenome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<SolicitacaoAtleta>()
                .Property(p => p.WhatsApp)
                .HasMaxLength(17);

            modelBuilder.Entity<SolicitacaoAtleta>()
                .Property(p => p.Email)
                .HasMaxLength(254)
                .IsRequired();

            /* AtleticaCurso */
            modelBuilder.Entity<AtleticaCurso>().HasKey(am => new { am.AtleticaCursoId });

            modelBuilder.Entity<AtleticaCurso>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.AtleticaCursos)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<AtleticaCurso>()
              .HasOne<Curso>(am => am.Curso)
              .WithMany(a => a.AtleticaCursos)
              .HasForeignKey(am => am.CursoId);

            /* Campus*/
            modelBuilder.Entity<Campus>()
                .Property(p => p.Cidade)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .Property(p => p.Bairro)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .Property(p => p.Rua)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .Property(p => p.Estado)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .Property(p => p.CEP)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .Property(p => p.Complemento)
                .HasMaxLength(100);

            /* Curso*/
            modelBuilder.Entity<Curso>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Curso>()
                .Property(p => p.Duracao)
                .IsRequired();

            /* Jogo*/
            modelBuilder.Entity<Jogo>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Jogo>()
                .Property(p => p.Categoria)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Jogo>()
                .Property(p => p.DataHora)
                .IsRequired();

            modelBuilder.Entity<Jogo>()
                .Property(p => p.Local)
                .HasMaxLength(45)
                .IsRequired();

            /* Membro*/
            modelBuilder.Entity<Membro>()
                .Property(p => p.Senha)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder
                .Entity<Membro>()
                .HasIndex(u => u.Email)
                    .IsUnique();

            modelBuilder.Entity<Membro>()
                .Property(p => p.Email)
                .HasMaxLength(254)
                .IsRequired();

            /* Publicações*/
            modelBuilder.Entity<Publicacao>().HasKey(am => new { am.PublicacaoId });

            modelBuilder.Entity<Publicacao>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Publicacoes)
              .HasForeignKey(am => am.AtleticaId);

            /* Imagem */
            modelBuilder.Entity<Imagem>().HasKey(am => new { am.ImagemId });

            modelBuilder.Entity<Imagem>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Imagens)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<Imagem>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Imagem>()
                .Property(p => p.Path)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Imagem>()
                .Property(p => p.Extensao)
                .HasMaxLength(10)
                .IsRequired();

            /* Evento */
            modelBuilder.Entity<Evento>().HasKey(am => new { am.EventoId });

            modelBuilder.Entity<Evento>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Eventos)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<Evento>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Descricao)
                .HasMaxLength(100);

            modelBuilder.Entity<Evento>()
                .Property(p => p.Local)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.DataHora)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Categoria)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Cor)
                .HasMaxLength(7);

            /* Faculdade*/
            modelBuilder.Entity<Faculdade>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            /* Funcao*/
            modelBuilder.Entity<Funcao>()
                .Property(p => p.Nome)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Funcao>()
                .Property(p => p.Descricao)
                .HasMaxLength(45);

            /* Modalidade*/
            modelBuilder.Entity<Modalidade>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Modalidade>()
                .Property(p => p.Genero)
                .IsRequired();

            modelBuilder.Entity<Modalidade>()
                .Property(p => p.NomeCoordenador)
                .HasMaxLength(45);

            /* Pessoa */
            modelBuilder.Entity<Pessoa>().HasKey(am => new { am.PessoaId });

            modelBuilder.Entity<Pessoa>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Pessoas)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Sobrenome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Whatsapp)
                .HasMaxLength(17);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Sobrenome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Atleta)
                .IsRequired();

            /* Produto*/
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasMaxLength(300);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Categoria)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(p => p.Estoque)
                .IsRequired();

            /* Publicacao*/
            modelBuilder.Entity<Publicacao>()
                .Property(p => p.Titulo)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Publicacao>()
                .Property(p => p.Descricao)
                .HasMaxLength(500);

            /* TimeEscalado */
            modelBuilder.Entity<TimeEscalado>().HasKey(am => new { am.TimeEscaladoId });

            modelBuilder.Entity<TimeEscalado>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.TimeEscalados)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<TimeEscalado>()
              .HasOne<Jogo>(am => am.Jogos)
              .WithMany(a => a.TimeEscalados)
              .HasForeignKey(am => am.JogoId);

            modelBuilder.Entity<TimeEscalado>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            /*AtletaModalidade*/
            modelBuilder.Entity<AtletaModalidade>().HasKey(am => new { am.AtletaModalidadeId });

            modelBuilder.Entity<AtletaModalidade>()
                .HasOne<Atleta>(am => am.Atleta)
                .WithMany(a => a.AtletaModalidades)
                .HasForeignKey(am => am.AtletaId);

            modelBuilder.Entity<AtletaModalidade>()
                .HasOne<Modalidade>(m => m.Modalidade)
                .WithMany(m => m.AtletaModalidades)
                .HasForeignKey(am => am.ModalidadeId);

            /* AtletaModalidadeTimeEscalado*/
            modelBuilder.Entity<AtletaModalidadeTimeEscalado>().HasKey(am => new { am.AtletaModalidadeTimeEscaladoId });

            modelBuilder.Entity<AtletaModalidadeTimeEscalado>()
                .HasOne<AtletaModalidade>(amt => amt.AtletaModalidade)
                .WithMany(am => am.AtletaModalidadeTimeEscalados)
                .HasForeignKey(amt => amt.AtletaModalidadeId);

            modelBuilder.Entity<AtletaModalidadeTimeEscalado>()
                .HasOne<TimeEscalado>(t => t.TimeEscalado)
                .WithMany(t => t.AtletaModalidadeTimeEscalados)
                .HasForeignKey(amt => amt.TimeEscaladoId);

            modelBuilder.Entity<AtletaModalidadeTimeEscalado>()
                .HasOne<Funcao>(amt => amt.Funcao)
                .WithMany(f => f.AtletaModalidadeTimeEscalados)
                .HasForeignKey(amt => amt.AtletaModalidadeTimeEscaladoId);

        }


        public void Start()
        {
            this.Database.EnsureCreated();
        }

    }
}
