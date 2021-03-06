﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeNotas.Data;

namespace SistemaDeNotas.Migrations
{
    [DbContext(typeof(SistemaDeNotasContext))]
    partial class SistemaDeNotasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SistemaDeNotas.EstudanteModel", b =>
                {
                    b.Property<int>("IdEstudante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstudante");

                    b.ToTable("Estudante");
                });

            modelBuilder.Entity("SistemaDeNotas.Models.NotasModel", b =>
                {
                    b.Property<int>("NotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdEstudante")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.HasKey("NotaId");

                    b.ToTable("Notas");
                });
#pragma warning restore 612, 618
        }
    }
}
