﻿// <auto-generated />
using System;
using MyBank.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBank.Dados.Contexto;

namespace MyBank.Dados.Migrations
{
    [DbContext(typeof(MyBankContexto))]
    [Migration("20211027185826_Atualizacao3")]
    partial class Atualizacao3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("MyBank.Dominio.Entidades.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("agencia");
                });

            modelBuilder.Entity("MyBank.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("MyBank.Dominio.Entidades.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<Guid>("PixConta")
                        .HasColumnType("char(36)");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("conta_corrente");
                });

            modelBuilder.Entity("MyBank.Dominio.Entidades.ContaCorrente", b =>
                {
                    b.HasOne("MyBank.Dominio.Entidades.Agencia", "Agencia")
                        .WithMany("Contas")
                        .HasForeignKey("AgenciaId");

                    b.HasOne("MyBank.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany("Contas")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Agencia");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MyBank.Dominio.Entidades.Agencia", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("MyBank.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
