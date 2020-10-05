﻿// <auto-generated />
using System;
using Back_Atletica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Back_Atletica.Migrations
{
    [DbContext(typeof(AtleticaContext))]
    [Migration("20201005134149_Banco_Restricoes")]
    partial class Banco_Restricoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Back_Atletica.Models.Atleta", b =>
                {
                    b.Property<int>("AtletaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("AtletaId");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("Back_Atletica.Models.AtletaModalidade", b =>
                {
                    b.Property<int>("AtletaModalidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtletaId")
                        .HasColumnType("integer");

                    b.Property<int>("ModalidadeId")
                        .HasColumnType("integer");

                    b.HasKey("AtletaModalidadeId");

                    b.HasIndex("AtletaId");

                    b.HasIndex("ModalidadeId");

                    b.ToTable("AtletaModalidades");
                });

            modelBuilder.Entity("Back_Atletica.Models.AtletaModalidadeTimeEscalado", b =>
                {
                    b.Property<int>("AtletaModalidadeTimeEscaladoId")
                        .HasColumnType("integer");

                    b.Property<int>("AtletaModalidadeId")
                        .HasColumnType("integer");

                    b.Property<int>("FuncaoId")
                        .HasColumnType("integer");

                    b.Property<int>("Infracoes")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<int>("Pontos")
                        .HasColumnType("integer");

                    b.Property<int>("TimeEscaladoId")
                        .HasColumnType("integer");

                    b.HasKey("AtletaModalidadeTimeEscaladoId");

                    b.HasIndex("AtletaModalidadeId");

                    b.HasIndex("TimeEscaladoId");

                    b.ToTable("AtletaModalidadeTimesEscalados");
                });

            modelBuilder.Entity("Back_Atletica.Models.Atletica", b =>
                {
                    b.Property<int>("AtleticaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CampusId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(254)")
                        .HasMaxLength(254);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasColumnType("character varying(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("AtleticaId");

                    b.HasIndex("CampusId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PIN")
                        .IsUnique();

                    b.ToTable("Atleticas");
                });

            modelBuilder.Entity("Back_Atletica.Models.AtleticaCurso", b =>
                {
                    b.Property<int>("AtleticaCursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.HasKey("AtleticaCursoId");

                    b.HasIndex("AtleticaId");

                    b.HasIndex("CursoId");

                    b.ToTable("AtleticaCurso");
                });

            modelBuilder.Entity("Back_Atletica.Models.Campus", b =>
                {
                    b.Property<int>("CampusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Complemento")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<int>("FaculdadeId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("CampusId");

                    b.HasIndex("FaculdadeId");

                    b.ToTable("Campus");
                });

            modelBuilder.Entity("Back_Atletica.Models.Curso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Duracao")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("ID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Back_Atletica.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Cor")
                        .HasColumnType("character varying(7)")
                        .HasMaxLength(7);

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<double>("PrecoIngresso")
                        .HasColumnType("double precision");

                    b.HasKey("EventoId");

                    b.HasIndex("AtleticaId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Back_Atletica.Models.Faculdade", b =>
                {
                    b.Property<int>("FaculdadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("FaculdadeId");

                    b.ToTable("Faculdades");
                });

            modelBuilder.Entity("Back_Atletica.Models.Funcao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Funcoes");
                });

            modelBuilder.Entity("Back_Atletica.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<string>("Extensao")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("ImagemId");

                    b.HasIndex("AtleticaId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("Back_Atletica.Models.Jogo", b =>
                {
                    b.Property<int>("JogoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("JogoId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("Back_Atletica.Models.Membro", b =>
                {
                    b.Property<int>("MembroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(254)")
                        .HasMaxLength(254);

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("MembroId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("Back_Atletica.Models.Modalidade", b =>
                {
                    b.Property<int>("ModalidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Genero")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("NomeCoordenador")
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("ModalidadeId");

                    b.ToTable("Modalidades");
                });

            modelBuilder.Entity("Back_Atletica.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Atleta")
                        .HasColumnType("boolean");

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Genero")
                        .HasColumnType("integer");

                    b.Property<bool>("Membro")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Whatsapp")
                        .HasColumnType("character varying(17)")
                        .HasMaxLength(17);

                    b.HasKey("PessoaId");

                    b.HasIndex("AtleticaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Back_Atletica.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.Property<int>("Estoque")
                        .HasColumnType("integer");

                    b.Property<int>("ImagemId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.HasKey("ProdutoId");

                    b.HasIndex("AtleticaId");

                    b.HasIndex("ImagemId")
                        .IsUnique();

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Back_Atletica.Models.Publicacao", b =>
                {
                    b.Property<int>("PublicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<int>("ImagemId")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("PublicacaoId");

                    b.HasIndex("AtleticaId");

                    b.HasIndex("ImagemId")
                        .IsUnique();

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("Back_Atletica.Models.SolicitacaoAtleta", b =>
                {
                    b.Property<int>("SolicitacaoAtletaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(254)")
                        .HasMaxLength(254);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.Property<string>("WhatsApp")
                        .HasColumnType("character varying(17)")
                        .HasMaxLength(17);

                    b.HasKey("SolicitacaoAtletaId");

                    b.HasIndex("AtleticaId");

                    b.ToTable("SolicitacaoAtletas");
                });

            modelBuilder.Entity("Back_Atletica.Models.TimeEscalado", b =>
                {
                    b.Property<int>("TimeEscaladoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtleticaId")
                        .HasColumnType("integer");

                    b.Property<int>("JogoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(45)")
                        .HasMaxLength(45);

                    b.HasKey("TimeEscaladoId");

                    b.HasIndex("AtleticaId");

                    b.HasIndex("JogoId");

                    b.ToTable("TimeEscalados");
                });

            modelBuilder.Entity("Back_Atletica.Models.Atleta", b =>
                {
                    b.HasOne("Back_Atletica.Models.Pessoa", "Pessoa")
                        .WithOne("Atletas")
                        .HasForeignKey("Back_Atletica.Models.Atleta", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.AtletaModalidade", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atleta", "Atleta")
                        .WithMany("AtletaModalidades")
                        .HasForeignKey("AtletaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.Modalidade", "Modalidade")
                        .WithMany("AtletaModalidades")
                        .HasForeignKey("ModalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.AtletaModalidadeTimeEscalado", b =>
                {
                    b.HasOne("Back_Atletica.Models.AtletaModalidade", "AtletaModalidade")
                        .WithMany("AtletaModalidadeTimeEscalados")
                        .HasForeignKey("AtletaModalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.Funcao", "Funcao")
                        .WithMany("AtletaModalidadeTimeEscalados")
                        .HasForeignKey("AtletaModalidadeTimeEscaladoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.TimeEscalado", "TimeEscalado")
                        .WithMany("AtletaModalidadeTimeEscalados")
                        .HasForeignKey("TimeEscaladoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Atletica", b =>
                {
                    b.HasOne("Back_Atletica.Models.Campus", "Campus")
                        .WithMany("Atleticas")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.AtleticaCurso", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("AtleticaCursos")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.Curso", "Curso")
                        .WithMany("AtleticaCursos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Campus", b =>
                {
                    b.HasOne("Back_Atletica.Models.Faculdade", "Faculdade")
                        .WithMany("Campus")
                        .HasForeignKey("FaculdadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Evento", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("Eventos")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Imagem", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("Imagens")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Membro", b =>
                {
                    b.HasOne("Back_Atletica.Models.Pessoa", "Pessoa")
                        .WithOne("Membros")
                        .HasForeignKey("Back_Atletica.Models.Membro", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Pessoa", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("Pessoas")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Produto", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("Produtos")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.Imagem", "Imagem")
                        .WithOne("Produto")
                        .HasForeignKey("Back_Atletica.Models.Produto", "ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.Publicacao", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("Publicacoes")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.Imagem", "Imagem")
                        .WithOne("Publicacao")
                        .HasForeignKey("Back_Atletica.Models.Publicacao", "ImagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.SolicitacaoAtleta", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("SolicitacaoAtletas")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Back_Atletica.Models.TimeEscalado", b =>
                {
                    b.HasOne("Back_Atletica.Models.Atletica", "Atletica")
                        .WithMany("TimeEscalados")
                        .HasForeignKey("AtleticaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_Atletica.Models.Jogo", "Jogos")
                        .WithMany("TimeEscalados")
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
