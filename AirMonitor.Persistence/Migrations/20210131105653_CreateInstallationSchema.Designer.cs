﻿// <auto-generated />
using System;
using AirMonitor.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirMonitor.Persistence.Migrations
{
    [DbContext(typeof(AirMonitorDbContext))]
    [Migration("20210131105653_CreateInstallationSchema")]
    partial class CreateInstallationSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationAddressEntity", b =>
                {
                    b.Property<long>("InstallationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("DisplayAddress1")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("DisplayAddress2")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("InstallationId");

                    b.ToTable("InstallationAddress");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AddressInstallationId")
                        .HasColumnType("bigint");

                    b.Property<double>("Elevation")
                        .HasColumnType("float");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAirly")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<long?>("SponsorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddressInstallationId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Installations");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationSponsorEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkUri")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("LogoUri")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("InstallationSponsor");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationEntity", b =>
                {
                    b.HasOne("AirMonitor.Persistence.Installation.Entity.InstallationAddressEntity", "Address")
                        .WithMany()
                        .HasForeignKey("AddressInstallationId");

                    b.HasOne("AirMonitor.Persistence.Installation.Entity.InstallationSponsorEntity", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId");

                    b.Navigation("Address");

                    b.Navigation("Sponsor");
                });
#pragma warning restore 612, 618
        }
    }
}
