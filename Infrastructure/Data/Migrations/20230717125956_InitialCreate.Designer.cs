﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(InventarioContext))]
    [Migration("20230717125956_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Property<string>("codEstado")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodPais")
                        .HasColumnType("longtext");

                    b.Property<string>("PaisCodPais")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("nombreEstado")
                        .HasColumnType("longtext");

                    b.HasKey("codEstado");

                    b.HasIndex("PaisCodPais");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Property<string>("CodPais")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombrePais")
                        .HasColumnType("longtext");

                    b.HasKey("CodPais");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Property<string>("codRegion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EstadocodEstado")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("codEstado")
                        .HasColumnType("longtext");

                    b.Property<string>("nombreRegion")
                        .HasColumnType("longtext");

                    b.HasKey("codRegion");

                    b.HasIndex("EstadocodEstado");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.HasOne("Core.Entities.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("PaisCodPais");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("Regiones")
                        .HasForeignKey("EstadocodEstado");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Navigation("Regiones");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Navigation("Estados");
                });
#pragma warning restore 612, 618
        }
    }
}
