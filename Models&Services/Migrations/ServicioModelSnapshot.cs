﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models_Services;

#nullable disable

namespace Models_Services.Migrations
{
    [DbContext(typeof(Servicio))]
    partial class ServicioModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Models_Services.Clientes", b =>
                {
                    b.Property<int>("iD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("iD")
                        .HasColumnOrder(1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Apellido");

                    b.Property<string>("Carroallevar")
                        .HasColumnType("TEXT")
                        .HasColumnName("Carroallevar");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Correo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Telefono");

                    b.Property<int>("edad")
                        .HasColumnType("INTEGER")
                        .HasColumnName("edad");

                    b.HasKey("iD");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Models_Services.Vehiculos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("iD")
                        .HasColumnOrder(1);

                    b.Property<DateOnly>("Ano")
                        .HasColumnType("TEXT")
                        .HasColumnName("Ano");

                    b.Property<string>("Asignado")
                        .HasColumnType("TEXT")
                        .HasColumnName("Asignado");

                    b.Property<int?>("IDTH")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IDTH");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Modelo");

                    b.HasKey("ID");

                    b.ToTable("Vehiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
