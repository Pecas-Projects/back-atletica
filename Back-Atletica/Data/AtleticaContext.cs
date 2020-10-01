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

            /* Atletica */
            modelBuilder.Entity<Atletica>().HasKey(am => new { am.AtleticaId });

            modelBuilder.Entity<Atletica>()
               .HasOne<Campus>(am => am.Campus)
               .WithMany(a => a.Atleticas)
               .HasForeignKey(am => am.CampusId);

            /* Campus */
            modelBuilder.Entity<Campus>().HasKey(am => new { am.CampusId });

            //modelBuilder.Entity<Campus>()
            //.HasOne<Faculdade>(c => c.Faculdade)
            //.WithMany(f => f.Campus)
            //.HasForeignKey(c => c.FaculdadeId);

            /* SolicitacaoAtleta*/
            modelBuilder.Entity<SolicitacaoAtleta>().HasKey(am => new { am.SolicitacaoAtletaId });

            modelBuilder.Entity<SolicitacaoAtleta>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.SolicitacaoAtletas)
              .HasForeignKey(am => am.AtleticaId);

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

            /* Evento */
            modelBuilder.Entity<Evento>().HasKey(am => new { am.EventoId });

            modelBuilder.Entity<Evento>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Eventos)
              .HasForeignKey(am => am.AtleticaId);

            /* Pessoa */
            modelBuilder.Entity<Pessoa>().HasKey(am => new { am.PessoaId });

            modelBuilder.Entity<Pessoa>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Pessoas)
              .HasForeignKey(am => am.AtleticaId);

            /* TimeEscalado */
            modelBuilder.Entity<TimeEscalado>().HasKey(am => new { am.TimeEscaladoId });

            modelBuilder.Entity<TimeEscalado>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.TimeEscalados)
              .HasForeignKey(am => am.AtleticaId);


            modelBuilder.Entity<AtletaModalidade>().HasKey(am => new { am.AtletaModalidadeId });

            modelBuilder.Entity<AtletaModalidade>()
                .HasOne<Atleta>(am => am.Atleta)
                .WithMany(a => a.AtletaModalidades)
                .HasForeignKey(am => am.AtletaId);

            modelBuilder.Entity<AtletaModalidade>()
                .HasOne<Modalidade>(m => m.Modalidade)
                .WithMany(m => m.AtletaModalidades)
                .HasForeignKey(am => am.ModalidadeId);

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

            modelBuilder.Entity<Atletica>()
                .HasOne<Campus>(a => a.Campus)
                .WithMany(c => c.Atleticas)
                .HasForeignKey(a => a.CampusId);



            modelBuilder.Entity<Evento>()
                .HasOne<Atletica>(e => e.Atletica)
                .WithMany(a => a.Eventos)
                .HasForeignKey(e => e.AtleticaId);

            modelBuilder.Entity<Faculdade>();
            modelBuilder.Entity<Funcao>();

            modelBuilder.Entity<Imagem>()
                .HasOne<Atletica>(i => i.Atletica)
                .WithMany(a => a.Imagens)
                .HasForeignKey(i => i.AtleticaId);

            modelBuilder.Entity<AtleticaCurso>()
                .HasOne<Atletica>(am => am.Atletica)
                .WithMany(a => a.AtleticaCursos)
                .HasForeignKey(am =>am.AtleticaId);

            modelBuilder.Entity<AtleticaCurso>()
                .HasOne<Curso>(am => am.Curso)
                .WithMany(a => a.AtleticaCursos)
                .HasForeignKey(am => am.CursoId);

            //adicionar one to many de jogo e time escalado

            modelBuilder.Entity<Membro>() //precisa ser conferido
                .HasOne<Pessoa>(a => a.Pessoa);

            modelBuilder.Entity<Modalidade>();

            modelBuilder.Entity<Pessoa>()
                .HasOne<Atletica>(p => p.Atletica)
                .WithMany(a => a.Pessoas)
                .HasForeignKey(p => p.AtleticaId);

            modelBuilder.Entity<Produto>()
                .HasOne<Atletica>(p => p.Atletica)
                .WithMany(a => a.Produtos)
                .HasForeignKey(p => p.AtleticaId);

            modelBuilder.Entity<Produto>() //precisa conferir
                .HasOne<Imagem>(p => p.Imagem);

            modelBuilder.Entity<Publicacao>()
                .HasOne<Atletica>(p => p.Atletica)
                .WithMany(a => a.Publicacoes)
                .HasForeignKey(p => p.AtleticaId);

            modelBuilder.Entity<Publicacao>() //precisa conferir
                .HasOne<Imagem>(p => p.Imagem);

            modelBuilder.Entity<SolicitacaoAtleta>()
                .HasOne<Atletica>(s => s.Atletica)
                .WithMany(a => a.SolicitacaoAtletas)
                .HasForeignKey(s => s.AtleticaId);


        }


        public void Start()
        {
            this.Database.EnsureCreated();
        }

    }
}
