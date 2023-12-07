﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.Models;

#nullable disable

namespace Projeto.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231207191813_Adicionando_campos_no_curso")]
    partial class Adicionando_campos_no_curso
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto.Models.AlunoInformacoes", b =>
                {
                    b.Property<int>("Id_aluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_aluno"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DataNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_aluno");

                    b.ToTable("alunos");
                });

            modelBuilder.Entity("Projeto.Models.Aulas", b =>
                {
                    b.Property<int>("Id_aulas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_aulas"));

                    b.Property<int>("Moduloid")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_aulas");

                    b.HasIndex("Moduloid");

                    b.ToTable("aulas");
                });

            modelBuilder.Entity("Projeto.Models.Carrinho", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("carrinhos");
                });

            modelBuilder.Entity("Projeto.Models.Categorias", b =>
                {
                    b.Property<int>("Id_categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_categoria"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_categoria");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("Projeto.Models.CursoCategoria", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("CursoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("CursoCategorias");
                });

            modelBuilder.Entity("Projeto.Models.Cursos", b =>
                {
                    b.Property<int>("Id_curso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_curso"));

                    b.Property<int>("Data_criacao")
                        .HasColumnType("int");

                    b.Property<int>("Data_update")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Idiomas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstrutorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id_curso");

                    b.HasIndex("InstrutorId");

                    b.ToTable("cursos");
                });

            modelBuilder.Entity("Projeto.Models.InstrutorInformacoes", b =>
                {
                    b.Property<int>("Id_Instrutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Instrutor"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DataNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Instrutor");

                    b.ToTable("instrutors");
                });

            modelBuilder.Entity("Projeto.Models.Matricula", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("matriculas");
                });

            modelBuilder.Entity("Projeto.Models.Modulos", b =>
                {
                    b.Property<int>("Id_Modulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Modulo"));

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Modulo");

                    b.HasIndex("CursoId");

                    b.ToTable("modulos");
                });

            modelBuilder.Entity("Projeto.Models.Aulas", b =>
                {
                    b.HasOne("Projeto.Models.Modulos", "Modulo")
                        .WithMany("Aulas")
                        .HasForeignKey("Moduloid");

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("Projeto.Models.Carrinho", b =>
                {
                    b.HasOne("Projeto.Models.AlunoInformacoes", "Aluno")
                        .WithMany("Carrinhos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.Models.Cursos", "Curso")
                        .WithMany("Carrinhos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Projeto.Models.CursoCategoria", b =>
                {
                    b.HasOne("Projeto.Models.Categorias", "Categorias")
                        .WithMany("CursoCategorias")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Projeto.Models.Cursos", "Cursos")
                        .WithMany("CursoCategorias")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Categorias");

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("Projeto.Models.Cursos", b =>
                {
                    b.HasOne("Projeto.Models.InstrutorInformacoes", "Instrutor")
                        .WithMany("Cursos")
                        .HasForeignKey("InstrutorId");

                    b.Navigation("Instrutor");
                });

            modelBuilder.Entity("Projeto.Models.Matricula", b =>
                {
                    b.HasOne("Projeto.Models.AlunoInformacoes", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId");

                    b.HasOne("Projeto.Models.Cursos", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoId");

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Projeto.Models.Modulos", b =>
                {
                    b.HasOne("Projeto.Models.Cursos", "Curso")
                        .WithMany("Modulos")
                        .HasForeignKey("CursoId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Projeto.Models.AlunoInformacoes", b =>
                {
                    b.Navigation("Carrinhos");

                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Projeto.Models.Categorias", b =>
                {
                    b.Navigation("CursoCategorias");
                });

            modelBuilder.Entity("Projeto.Models.Cursos", b =>
                {
                    b.Navigation("Carrinhos");

                    b.Navigation("CursoCategorias");

                    b.Navigation("Matriculas");

                    b.Navigation("Modulos");
                });

            modelBuilder.Entity("Projeto.Models.InstrutorInformacoes", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("Projeto.Models.Modulos", b =>
                {
                    b.Navigation("Aulas");
                });
#pragma warning restore 612, 618
        }
    }
}
