﻿// <auto-generated />
using System;
using EddyCapellan_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EddyCapellan_Ap1_P1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241008040436_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("EddyCapellan_Ap1_P1.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeudorId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            Nombres = "Samil"
                        },
                        new
                        {
                            DeudorId = 2,
                            Nombres = "Maria"
                        });
                });

            modelBuilder.Entity("EddyCapellan_Ap1_P1.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Balance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeudorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Monto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("EddyCapellan_Ap1_P1.Models.Deudores", b =>
                {
                    b.HasOne("EddyCapellan_Ap1_P1.Models.Prestamos", null)
                        .WithMany("Deudores")
                        .HasForeignKey("PrestamoId");
                });

            modelBuilder.Entity("EddyCapellan_Ap1_P1.Models.Prestamos", b =>
                {
                    b.HasOne("EddyCapellan_Ap1_P1.Models.Deudores", "Deudor")
                        .WithMany()
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");
                });

            modelBuilder.Entity("EddyCapellan_Ap1_P1.Models.Prestamos", b =>
                {
                    b.Navigation("Deudores");
                });
#pragma warning restore 612, 618
        }
    }
}
