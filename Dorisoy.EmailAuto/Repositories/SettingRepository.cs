using Dorisoy.EmailAuto.Infrastructure.DataContext;
using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dorisoy.EmailAuto.Repositories
{
    /// <summary>
    /// Setting Repository
    /// </summary>
    /// <seealso cref="Dorisoy.EmailAuto.Repositories.Interface.ISettingRepository" />
    public class SettingRepository : ISettingRepository
    {
        /// <summary>
        /// The database
        /// </summary>
        protected readonly DataDBContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingRepository"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <exception cref="ArgumentNullException">db</exception>
        public SettingRepository(DataDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>
        /// Settings Model
        /// </returns>
        public async Task<SettingsModel> Get()
        {
            return await _db.Settings.AsNoTracking().Where(p => p.SettingsId == 1)
                .Select(p => new SettingsModel()
                {
                    SettingsId = p.SettingsId,
                    EmailServer = p.EmailServer,
                    Password = p.Password,
                    Port = p.Port,
                    Ssl = p.Ssl,
                    UserName = p.UserName,
                    DelayMilliseconds = p.DelayMilliseconds
                }).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task Add(SettingsModel model)
        {
            await _db.Settings.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task Edit(SettingsModel model)
        {
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            _db.Entry(model).State = EntityState.Detached;
            //var existing = await _db.Settings.FindAsync(1);
            //if (existing != null)
            //{
            //    existing.EmailServer = model.EmailServer;
            //    existing.Port = model.Port;
            //    existing.Ssl = model.Ssl;
            //    existing.UserName = model.UserName;
            //    existing.Password = model.Password;
            //    existing.DelayMilliseconds = model.DelayMilliseconds;
            //    _db.Entry(existing).State = EntityState.Modified;
            //    await _db.SaveChangesAsync();
            //}
        }
    }
}
