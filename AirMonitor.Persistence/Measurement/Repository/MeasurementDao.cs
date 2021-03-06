using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Persistence.Measurement.Entity;
using Microsoft.EntityFrameworkCore;

namespace AirMonitor.Persistence.Measurement.Repository
{
    public class MeasurementDao
    {
        #region Fields

        private readonly AirMonitorDbContext _db;

        #endregion

        #region Constructors

        private MeasurementDao(AirMonitorDbContext db)
        {
            this._db = db;
        }

        #endregion

        public bool ExistsById(long? id)
            => id != null && _db.Installations.Any(entity => entity.Id == id);

        public MeasurementEntity Save(MeasurementEntity measurement)
        {
            _db.Measurements.Add(measurement);
            _db.SaveChanges();
            return measurement;
        }

        public ISet<MeasurementEntity> FindAll()
            => _db.Measurements.Include(entity => entity.Indexes)
                               .Include(entity => entity.Standards)
                               .Include(entity => entity.Values)
                               .ToHashSet();

        public ISet<MeasurementEntity> FindAllWhereTillDateTimeIsBeforeNow()
            => _db.Measurements.Include(entity => entity.Indexes)
                               .Include(entity => entity.Standards)
                               .Include(entity => entity.Values)
                               // TODO [q/opt] does it include clause in query?
                               .Where(entity => entity.TillDateTime < DateTimeOffset.Now)
                               .ToHashSet();

        public MeasurementEntity FindById(long? id)
            => id == null
             ? null
             : _db.Measurements.Include(entity => entity.Indexes)
                               .Include(entity => entity.Standards)
                               .Include(entity => entity.Values)
                               .SingleOrDefault(entity => entity.Id == id);

        public MeasurementEntity FindByExternalId(long? externalId)
            => externalId == null
             ? null
             : _db.Measurements.Include(entity => entity.Indexes)
                               .Include(entity => entity.Standards)
                               .Include(entity => entity.Values)
                               .SingleOrDefault(entity => entity.InstallationExternalId == externalId);

        // TODO SingleOrDefault and FirstOrDefault throw ArgumentNullException...
        //      How to query nullable limited to 1 query?
        public DateTimeOffset? FindUpdateDateTimeByInstallationExternalId(long installationExternalId)
        {
            try
            {
                var resultSet = _db.Measurements
                    .Where(entity => entity.InstallationExternalId == installationExternalId)
                    .Select(entity => entity.UpdateDateTime);
                return resultSet.SingleOrDefault();
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool ExistsByExternalId(long externalId)
            => _db.Measurements.Any(entity => entity.InstallationExternalId == externalId);

        public bool DeleteById(long id)
        {
            MeasurementEntity entity = FindById(id);
            if (entity == null)
            {
                return false;
            }
            _db.Measurements.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteByExternalId(long externalId)
        {
            MeasurementEntity entity = FindByExternalId(externalId);
            if (entity == null)
            {
                return false;
            }
            _db.Measurements.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public static class Factory
        {
            public static MeasurementDao Create(AirMonitorDbContext db)
                => new MeasurementDao(db ?? throw new AggregateException("DatabaseContext is null"));
        }
    }
}
