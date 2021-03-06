﻿using Back_Atletica.Models;
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
        public DbSet<AtletaAtleticaModalidade> AtletaAtleticaModalidades { get; set; }
        public DbSet<AtletaAtleticaModalidadeTimeEscalado> AtletaAtleticaModalidadeTimesEscalados { get; set; }
        public DbSet<Atletica> Atleticas { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Faculdade> Faculdades { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<ImagemAtletica> ImagemAtleticas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<SolicitacaoAtleta> SolicitacaoAtletas { get; set; }
        public DbSet<TimeEscalado> TimeEscalados { get; set; }
        public DbSet<AtleticaCurso> AtleticaCursos { get; set; }
        public DbSet<AtleticaModalidade> AtleticaModalidades { get; set; }
        public DbSet<JogoCategoria> JogoCategorias { get; set; }
        public DbSet<EventoCategoria> EventoCategorias { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<AgendaTreino> AgendaTreinos { get; set; }
        public DbSet<AtleticaModalidadeJogo> AtleticaModalidadeJogos { get; set; }
        public DbSet<SolicitacaoAtletaModalidade> SolicitacaoAtletaModalidades { get; set; }
        public DbSet<SolicitacaoJogo> SolicitacaoJogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string de conexão com o Postgree
            string connStr = Env.ConnString;
            optionsBuilder.UseNpgsql(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* SolicitacaoJogo */
            modelBuilder.Entity<SolicitacaoJogo>().HasKey(am => new { am.SolicitacaoJogoId });

            modelBuilder.Entity<SolicitacaoJogo>()
               .HasOne<Atletica>(am => am.Atletica)
               .WithMany(a => a.SolicitacaoJogos)
               .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<SolicitacaoJogo>()
               .HasOne<Modalidade>(am => am.Modalidade)
               .WithMany(a => a.SolicitacaoJogos)
               .HasForeignKey(am => am.ModalidadeId);

            modelBuilder.Entity<SolicitacaoJogo>()
               .HasOne<JogoCategoria>(am => am.JogoCategoria)
               .WithMany(a => a.SolicitacaoJogos)
               .HasForeignKey(am => am.JogoCategoriaId);

            modelBuilder.Entity<SolicitacaoJogo>()
                .Property(p => p.AtleticaAdversariaId)
                .IsRequired();

            modelBuilder.Entity<SolicitacaoJogo>()
                .Property(p => p.Local)
                .HasMaxLength(45);

            modelBuilder.Entity<SolicitacaoJogo>()
                .Property(p => p.Local)
                .IsRequired();

            /* SolicitacaoAtletaModalidade */
            modelBuilder.Entity<SolicitacaoAtletaModalidade>().HasKey(am => new { am.SolicitacaoAtletaModalidadeId });

            modelBuilder.Entity<SolicitacaoAtletaModalidade>()
               .HasOne<SolicitacaoAtleta>(am => am.SolicitacaoAtleta)
               .WithMany(a => a.SolicitacaoAtletaModalidades)
               .HasForeignKey(am => am.SolicitacaoAtletaId);

            modelBuilder.Entity<SolicitacaoAtletaModalidade>()
               .HasOne<Modalidade>(am => am.Modalidade)
               .WithMany(a => a.SolicitacaoAtletaModalidades)
               .HasForeignKey(am => am.ModalidadeId);

            /* AtleticaModalidadeJogo */
            modelBuilder.Entity<AtleticaModalidadeJogo>().HasKey(am => new { am.AtleticaModalidadeJogoId });

            modelBuilder.Entity<AtleticaModalidadeJogo>()
               .HasOne<AtleticaModalidade>(am => am.AtleticaModalidade)
               .WithMany(a => a.AtleticaModalidadeJogos)
               .HasForeignKey(am => am.AtleticaModalidadeId);

            modelBuilder.Entity<AtleticaModalidadeJogo>()
               .HasOne<Jogo>(am => am.Jogo)
               .WithMany(a => a.AtleticaModalidadeJogos)
               .HasForeignKey(am => am.JogoId);

            modelBuilder.Entity<AtleticaModalidadeJogo>()
                .Property(amj => amj.Vencedor)
                .HasDefaultValue(false);

            /* AgendaTreino */
            modelBuilder.Entity<AgendaTreino>()
                .Property(p => p.DiaSemana)
                .IsRequired();

            modelBuilder.Entity<AgendaTreino>()
               .HasOne<AtleticaModalidade>(am => am.AtleticaModalidade)
               .WithMany(a => a.AgendaTreinos)
               .HasForeignKey(am => am.AtleticaModalidadeId);

            /* ImagemAtletica */
            modelBuilder.Entity<ImagemAtletica>().HasKey(am => new { am.ImagemAtleticaId });

            modelBuilder.Entity<ImagemAtletica>()
               .HasOne<Atletica>(am => am.Atletica)
               .WithMany(a => a.ImagemAtleticas)
               .HasForeignKey(am => am.AtleticaId);

            /* Atletas */
            modelBuilder.Entity<Atleta>().HasKey(am => new { am.AtletaId });

            modelBuilder.Entity<Atleta>()
                .Property(p => p.Ativo)
                .IsRequired()
                .HasDefaultValue(true);

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

            modelBuilder.Entity<Atletica>()
                .Property(p => p.Telefone)
                .HasMaxLength(17);

            modelBuilder.Entity<Atletica>()
                .Property(p => p.LinkProsel)
                .HasMaxLength(255);

            modelBuilder
                .Entity<Atletica>()
                .HasIndex(u => u.PIN)
                    .IsUnique();

            modelBuilder.Entity<Atletica>()
                .Property(p => p.Username)
                .IsRequired();

            modelBuilder.Entity<Atletica>()
                .Property(p => p.PIN)
                .HasMaxLength(5)
                .IsRequired();

            modelBuilder
                .Entity<Atletica>()
                .HasIndex(u => u.Username)
                    .IsUnique();

            /* SolicitacaoAtleta*/
            modelBuilder.Entity<SolicitacaoAtleta>().HasKey(am => new { am.SolicitacaoAtletaId });

            modelBuilder.Entity<SolicitacaoAtleta>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.SolicitacaoAtletas)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<SolicitacaoAtleta>()
              .HasOne<Curso>(am => am.Curso)
              .WithMany(a => a.SolicitacaoAtletas)
              .HasForeignKey(am => am.CursoId);

            modelBuilder.Entity<SolicitacaoAtleta>()
                .Property(sa => sa.AnoEntradaFacul)
                .HasColumnType("date");

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

            modelBuilder.Entity<SolicitacaoAtleta>()
                .Property(p => p.Genero)
                .HasDefaultValue('I');

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
             .HasOne<Faculdade>(c => c.Faculdade)
             .WithMany(f => f.Campus)
             .HasForeignKey(c => c.FaculdadeId);

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

            /*JogoCategoria */
            modelBuilder
                .Entity<JogoCategoria>()
                .HasIndex(u => u.Nome)
                    .IsUnique();

            modelBuilder.Entity<JogoCategoria>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<JogoCategoria>()
                .Property(p => p.Cor)
                .HasColumnType("CHAR(7)");

            /*EventoCategoria */
            modelBuilder
                .Entity<EventoCategoria>()
                .HasIndex(u => u.Nome)
                    .IsUnique();

            modelBuilder.Entity<EventoCategoria>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<EventoCategoria>()
                .Property(p => p.Cor)
                .HasColumnType("CHAR(7)");

            /*ProdutoCategoria */
            modelBuilder
                .Entity<ProdutoCategoria>()
                .HasIndex(u => u.Nome)
                    .IsUnique();

            modelBuilder.Entity<ProdutoCategoria>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            /* Jogo*/
            modelBuilder.Entity<Jogo>().HasKey(am => new { am.JogoId });

            modelBuilder.Entity<Jogo>()
               .HasOne<JogoCategoria>(am => am.JogoCategoria)
               .WithMany(a => a.Jogos)
               .HasForeignKey(am => am.JogoCategoriaId);

            modelBuilder.Entity<Jogo>()
                .Property(p => p.DataHora)
                .IsRequired();

            modelBuilder.Entity<Jogo>()
                .Property(p => p.Local)
                .HasMaxLength(45)
                .IsRequired();
            modelBuilder.Entity<Jogo>()
                .Property(j => j.Finalizado)
                .HasDefaultValue(false);

            /* Membro */
            modelBuilder.Entity<Membro>()
                .Property(p => p.Senha)
                .HasMaxLength(255)
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
                .Property(p => p.Path)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Imagem>()
                .Property(p => p.Extensao)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Imagem>()
                .Property(p => p.PublicId)
                .HasMaxLength(255)
                .IsRequired();

            /* Evento */
            modelBuilder.Entity<Evento>().HasKey(am => new { am.EventoId });

            modelBuilder.Entity<Evento>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Eventos)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<Evento>()
              .HasOne<EventoCategoria>(am => am.EventoCategoria)
              .WithMany(a => a.Eventos)
              .HasForeignKey(am => am.EventoCategoriaId);

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

            /* Modalidade*/
            modelBuilder.Entity<Modalidade>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Modalidade>()
                .Property(p => p.Genero)
                .HasMaxLength(2)
                .IsRequired();

            /* Pessoa */
            modelBuilder.Entity<Pessoa>().HasKey(am => new { am.PessoaId });

            modelBuilder.Entity<Pessoa>()
              .HasOne<Atletica>(am => am.Atletica)
              .WithMany(a => a.Pessoas)
              .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<Pessoa>()
              .HasOne<Curso>(am => am.Curso)
              .WithMany(a => a.Pessoas)
              .HasForeignKey(am => am.CursoId);

            modelBuilder
               .Entity<Pessoa>()
               .HasIndex(u => u.Email)
                   .IsUnique();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Email)
                .HasMaxLength(254)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Tipo)
                .HasMaxLength(2)
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
                .Property(sample => sample.AnoEntradaFacul)
                .HasColumnType("date");

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Genero)
                .HasDefaultValue('I');

            /* Produto*/
            modelBuilder.Entity<Produto>().HasKey(am => new { am.ProdutoId });

            modelBuilder.Entity<Produto>()
               .HasOne<ProdutoCategoria>(am => am.ProdutoCategoria)
               .WithMany(a => a.Produtos)
               .HasForeignKey(am => am.ProdutoCategoriaId);

            modelBuilder.Entity<Produto>()
                .HasOne<Atletica>(p => p.Atletica)
                .WithMany(a => a.Produtos)
                .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasMaxLength(300);

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
                .HasOne<Atletica>(p => p.Atletica)
                .WithMany(a => a.Publicacoes)
                .HasForeignKey(p => p.AtleticaId);

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
               .Property(t => t.RegistrouEscalacao)
               .HasDefaultValue(false);

            modelBuilder.Entity<TimeEscalado>()
               .Property(t => t.PontuacaoJogo)
               .HasDefaultValue(0);

            /*AtletaAtleticaModalidade*/
            modelBuilder.Entity<AtletaAtleticaModalidade>().HasKey(am => new { am.AtletaAtleticaModalidadeId });

            modelBuilder.Entity<AtletaAtleticaModalidade>()
                .HasOne<Atleta>(am => am.Atleta)
                .WithMany(a => a.AtletaAtleticaModalidades)
                .HasForeignKey(am => am.AtletaId);

            modelBuilder.Entity<AtletaAtleticaModalidade>()
                .HasOne<AtleticaModalidade>(m => m.AtleticaModalidade)
                .WithMany(m => m.AtletaAtleticaModalidades)
                .HasForeignKey(am => am.AtleticaModalidadeId);

            modelBuilder.Entity<AtletaAtleticaModalidade>()
                .Property(p => p.Ativo)
                .HasDefaultValue(true);

            /*AtleticaModalidade*/
            modelBuilder.Entity<AtleticaModalidade>().HasKey(am => new { am.AtleticaModalidadeId });

            modelBuilder.Entity<AtleticaModalidade>()
                .HasOne<Atletica>(am => am.Atletica)
                .WithMany(a => a.AtleticaModalidades)
                .HasForeignKey(am => am.AtleticaId);

            modelBuilder.Entity<AtleticaModalidade>()
                .HasOne<Modalidade>(m => m.Modalidade)
                .WithMany(m => m.AtleticaModalidades)
                .HasForeignKey(am => am.ModalidadeId);

            modelBuilder.Entity<AtleticaModalidade>()
                .HasOne<Membro>(m => m.Membro)
                .WithMany(m => m.AtleticaModalidades)
                .HasForeignKey(am => am.MembroId);

            modelBuilder.Entity<AtleticaModalidade>()
                .Property(p => p.Ativo)
                .IsRequired()
                .HasDefaultValue(true);

            /* AtletaAtleticaModalidadeTimeEscalado*/
            modelBuilder.Entity<AtletaAtleticaModalidadeTimeEscalado>().HasKey(am => new { am.AtletaAtleticaModalidadeTimeEscaladoId });

            modelBuilder.Entity<AtletaAtleticaModalidadeTimeEscalado>()
                .HasOne<AtletaAtleticaModalidade>(amt => amt.AtletaAtleticaModalidade)
                .WithMany(am => am.AtletaAtleticaModalidadeTimeEscalados)
                .HasForeignKey(amt => amt.AtletaAtleticaModalidadeId);

            modelBuilder.Entity<AtletaAtleticaModalidadeTimeEscalado>()
                .HasOne<TimeEscalado>(t => t.TimeEscalado)
                .WithMany(t => t.AtletaAtleticaModalidadeTimeEscalados)
                .HasForeignKey(amt => amt.TimeEscaladoId);

            modelBuilder.Entity<AtletaAtleticaModalidadeTimeEscalado>()
                .HasOne<Funcao>(amt => amt.Funcao)
                .WithMany(f => f.AtletaAtleticaModalidadeTimeEscalados)
                .HasForeignKey(amt => amt.FuncaoId);

            modelBuilder.Entity<AtletaAtleticaModalidadeTimeEscalado>()
                .Property(p => p.Pontos)
                .HasDefaultValue(0);

            modelBuilder.Entity<AtletaAtleticaModalidadeTimeEscalado>()
                .Property(p => p.Infracoes)
                .HasDefaultValue(0);

        }

        public void Start()
        {
            this.Database.EnsureCreated();
            // this.Database.Migrate();
        }

    }
}
