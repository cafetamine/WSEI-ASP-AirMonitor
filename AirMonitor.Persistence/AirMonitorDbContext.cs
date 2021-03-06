﻿using AirMonitor.Persistence.Installation.Entity;
using AirMonitor.Persistence.Measurement.Entity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AirMonitor.Persistence
{
    public partial class AirMonitorDbContext : DbContext
    {
        #region DatbaseTables

        public DbSet<InstallationEntity> Installations { get; set; }
        public DbSet<InstallationAddressEntity> InstallationAddresses { get; set; }
        public DbSet<InstallationSponsorEntity> InstallationSponsors { get; set; }
        
        public DbSet<MeasurementEntity> Measurements { get; set; }
        public DbSet<MeasurementIndexEntity> MeasurementIndexes { get; set; }
        public DbSet<MeasurementStandardEntity> MeasurementStandards { get; set; }
        public DbSet<MeasurementValueEntity> MeasurementValues { get; set; }

        #endregion
        
        #region Constructors

        // TODO [dev-only] solve migrations
        public AirMonitorDbContext() { }
        
        internal AirMonitorDbContext(DbContextOptions<AirMonitorDbContext> options) : base(options) { }

        #endregion

        #region BaseOverrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO [dev-only] solve migrations
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer("Data Source=192.168.100.121,1433; Initial Catalog=AirMonitorDev3; User ID=dev; Password=dev;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion
    }
}
