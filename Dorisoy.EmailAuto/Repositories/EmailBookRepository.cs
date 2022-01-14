using Dorisoy.EmailAuto.Infrastructure.DataContext;
using Dorisoy.EmailAuto.Model;
using Dorisoy.EmailAuto.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorisoy.EmailAuto.Repositories
{
    /// <summary>
    /// Email Book Repository
    /// </summary>
    /// <seealso cref="Dorisoy.EmailAuto.Repositories.Interface.IEmailBookRepository" />
    public class EmailBookRepository : IEmailBookRepository
    {
        /// <summary>
        /// The database
        /// </summary>
        protected readonly DataDBContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailBookRepository"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <exception cref="ArgumentNullException">db</exception>
        public EmailBookRepository(DataDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>List of EmailBookModel</returns>
        public async Task<List<EmailBookModel>> Get()
        {
            return await _db.EmailBook.AsNoTrackingWithIdentityResolution().OrderByDescending(p => p.CreatedDate).AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        /// <summary>
        /// Existses the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>bool</returns>
        public async Task<bool> Exists(string email)
        {
            return await _db.EmailBook.Where(p => p.Email == email).Select(p => p.EmailBookId).AnyAsync();
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task Add(List<EmailBookModel> model)
        {
            await _db.EmailBook.AddRangeAsync(model);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task Add(EmailBookModel model)
        {
            await _db.EmailBook.AddAsync(model);
            await _db.SaveChangesAsync();
            _db.Entry(model).State = EntityState.Detached;
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task Edit(EmailBookModel model)
        {
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified email book identifier.
        /// </summary>
        /// <param name="emailBookId">The email book identifier.</param>
        public async Task Delete(List<int> emailBookId)
        {
            _db.EmailBook.RemoveRange(_db.EmailBook.Where(p => emailBookId.Contains(p.EmailBookId)));
            await _db.SaveChangesAsync();
        }
    }
}
