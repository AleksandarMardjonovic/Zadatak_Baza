﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zadatak_Baza.Models;

namespace Zadatak_Baza.Migrations
{
    [DbContext(typeof(BazaContext))]
    partial class BazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zadatak_Baza.Models.EvidencjijaUpotrebeUredjaja", b =>
                {
                    b.Property<long>("EvidencijaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumRazdruzenjaUredjaja");

                    b.Property<DateTime>("DatumZaduzenjaUredjaja");

                    b.Property<long>("OsobaId");

                    b.Property<long>("UredjajId");

                    b.HasKey("EvidencijaId");

                    b.HasIndex("OsobaId");

                    b.HasIndex("UredjajId");

                    b.ToTable("EvidencijaUpotrebeUredjaja");
                });

            modelBuilder.Entity("Zadatak_Baza.Models.Kancelarija", b =>
                {
                    b.Property<long>("KancelarijaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKancelarije");

                    b.HasKey("KancelarijaId");

                    b.ToTable("Kancelarije");
                });

            modelBuilder.Entity("Zadatak_Baza.Models.Osoba", b =>
                {
                    b.Property<long>("OsobaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImeOsoba");

                    b.Property<long>("KancelarijaId");

                    b.Property<string>("PrezimeOsoba");

                    b.HasKey("OsobaId");

                    b.HasIndex("KancelarijaId");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("Zadatak_Baza.Models.Uredjaj", b =>
                {
                    b.Property<long>("UredjajId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivUredjaja");

                    b.HasKey("UredjajId");

                    b.ToTable("Uredjaji");
                });

            modelBuilder.Entity("Zadatak_Baza.Models.EvidencjijaUpotrebeUredjaja", b =>
                {
                    b.HasOne("Zadatak_Baza.Models.Osoba", "Osoba")
                        .WithMany("UpotrebljavaniUredjaji")
                        .HasForeignKey("OsobaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zadatak_Baza.Models.Uredjaj", "Uredjaj")
                        .WithMany()
                        .HasForeignKey("UredjajId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Zadatak_Baza.Models.Osoba", b =>
                {
                    b.HasOne("Zadatak_Baza.Models.Kancelarija", "Kancelarija")
                        .WithMany("Osobe")
                        .HasForeignKey("KancelarijaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
