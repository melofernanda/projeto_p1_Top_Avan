﻿// <auto-generated />
using System;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("DDD.Domain.RH.Contratacao", b =>
                {
                    b.Property<int>("ContratacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContratacaoId"));

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SetorId")
                        .HasColumnType("int");

                    b.HasKey("ContratacaoId");

                    b.HasIndex("FuncionarioUserId");

                    b.HasIndex("SetorId");

                    b.ToTable("Contratacoes");
                });

            modelBuilder.Entity("DDD.Domain.RH.Setor", b =>
                {
                    b.Property<int>("SetorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SetorId"));

                    b.Property<int>("Bloco")
                        .HasColumnType("int");

                    b.Property<string>("NomeSetor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SetorId");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("DDD.Domain.UserManagementContext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("UserId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DDD.Domain.RH.Funcionario", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("DDD.Domain.RH.Contratacao", b =>
                {
                    b.HasOne("DDD.Domain.RH.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.RH.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Setor");
                });
#pragma warning restore 612, 618
        }
    }
}
