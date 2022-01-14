using Dorisoy.EmailAuto.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Dorisoy.EmailAuto.Infrastructure.DataContext
{
    /// <summary>
    /// Data DB Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class DataDBContext : DbContext
    {
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public DbSet<SettingsModel> Settings { get; set; }

        /// <summary>
        /// Gets or sets the email book.
        /// </summary>
        /// <value>
        /// The email book.
        /// </value>
        public DbSet<EmailBookModel> EmailBook { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataDBContext"/> class.
        /// </summary>
        public DataDBContext() : base()
        {
            Database.EnsureCreated();
            Database.Migrate();
            // light sessions only
            // this will improve performance with no tracking
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=EAuto.db");
            optionsBuilder.EnableSensitiveDataLogging();

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "EAuto.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}
