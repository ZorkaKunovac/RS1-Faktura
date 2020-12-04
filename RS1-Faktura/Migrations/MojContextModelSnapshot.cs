﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1.Ispit.Web.EF;

namespace RS1_Faktura.Migrations
{
    [DbContext(typeof(MojContext))]
    partial class MojContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RS1.Ispit.Web.Models.AkcijskiKatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Kraj")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Pocetak")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AkcijskiKatalog");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.Faktura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlijentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlijentId");

                    b.ToTable("Faktura");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.FakturaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FakturaId")
                        .HasColumnType("int");

                    b.Property<float>("Kolicina")
                        .HasColumnType("real");

                    b.Property<float>("PopustProcenat")
                        .HasColumnType("real");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FakturaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("FakturaStavka");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.KatalogStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AkcijskiKatalogId")
                        .HasColumnType("int");

                    b.Property<float>("PopustProcenat")
                        .HasColumnType("real");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AkcijskiKatalogId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("KatalogStavka");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.Klijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ImePrezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.Ponuda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FakturaId")
                        .HasColumnType("int");

                    b.Property<int>("KlijentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FakturaId");

                    b.HasIndex("KlijentId");

                    b.ToTable("Ponuda");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.PonudaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Kolicina")
                        .HasColumnType("real");

                    b.Property<int>("PonudaId")
                        .HasColumnType("int");

                    b.Property<float>("PopustProcenat")
                        .HasColumnType("real");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PonudaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("PonudaStavka");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Cijena")
                        .HasColumnType("real");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.Faktura", b =>
                {
                    b.HasOne("RS1.Ispit.Web.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klijent");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.FakturaStavka", b =>
                {
                    b.HasOne("RS1.Ispit.Web.Models.Faktura", "Faktura")
                        .WithMany()
                        .HasForeignKey("FakturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1.Ispit.Web.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faktura");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.KatalogStavka", b =>
                {
                    b.HasOne("RS1.Ispit.Web.Models.AkcijskiKatalog", "AkcijskiKatalog")
                        .WithMany()
                        .HasForeignKey("AkcijskiKatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1.Ispit.Web.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AkcijskiKatalog");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.Ponuda", b =>
                {
                    b.HasOne("RS1.Ispit.Web.Models.Faktura", "Faktura")
                        .WithMany()
                        .HasForeignKey("FakturaId");

                    b.HasOne("RS1.Ispit.Web.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faktura");

                    b.Navigation("Klijent");
                });

            modelBuilder.Entity("RS1.Ispit.Web.Models.PonudaStavka", b =>
                {
                    b.HasOne("RS1.Ispit.Web.Models.Ponuda", "Ponuda")
                        .WithMany()
                        .HasForeignKey("PonudaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RS1.Ispit.Web.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ponuda");

                    b.Navigation("Proizvod");
                });
#pragma warning restore 612, 618
        }
    }
}