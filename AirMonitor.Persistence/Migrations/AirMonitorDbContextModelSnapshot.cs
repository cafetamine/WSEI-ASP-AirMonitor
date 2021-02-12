﻿// <auto-generated />
using System;
using AirMonitor.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirMonitor.Persistence.Migrations
{
    [DbContext(typeof(AirMonitorDbContext))]
    partial class AirMonitorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Polish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationAddressEntity", b =>
                {
                    b.Property<long?>("Id")
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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.ToTable("InstallationAddress");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AddressId")
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

                    b.HasIndex("AddressId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Installations");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationSponsorEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint");

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

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset>("FromDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("TillDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("UpdateDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementIndexEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Advice")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<long>("MeasurementId")
                        .HasColumnType("bigint");

                    b.Property<int>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementId");

                    b.ToTable("MeasurementIndexes");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementStandardEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Averaging")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Limit")
                        .HasColumnType("float");

                    b.Property<long>("MeasurementId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.Property<int>("Pollutant")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementId");

                    b.ToTable("MeasurementStandards");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementValueEntity", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("MeasurementId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementId");

                    b.ToTable("MeasurementValues");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Installation.Entity.InstallationEntity", b =>
                {
                    b.HasOne("AirMonitor.Persistence.Installation.Entity.InstallationAddressEntity", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("AirMonitor.Persistence.Installation.Entity.InstallationSponsorEntity", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId");

                    b.Navigation("Address");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementIndexEntity", b =>
                {
                    b.HasOne("AirMonitor.Persistence.Measurement.Entity.MeasurementEntity", "Measurement")
                        .WithMany("Indexes")
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementStandardEntity", b =>
                {
                    b.HasOne("AirMonitor.Persistence.Measurement.Entity.MeasurementEntity", "Measurement")
                        .WithMany("Standards")
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementValueEntity", b =>
                {
                    b.HasOne("AirMonitor.Persistence.Measurement.Entity.MeasurementEntity", "Measurement")
                        .WithMany("Values")
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("AirMonitor.Persistence.Measurement.Entity.MeasurementEntity", b =>
                {
                    b.Navigation("Indexes");

                    b.Navigation("Standards");

                    b.Navigation("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
