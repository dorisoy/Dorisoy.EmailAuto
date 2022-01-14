using Dorisoy.EmailAuto.Infrastructure.DataContext;
using Dorisoy.EmailAuto.Repositories;
using Dorisoy.EmailAuto.Repositories.Interface;
using Dorisoy.EmailAuto.Services;
using Dorisoy.EmailAuto.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace Dorisoy.EmailAuto
{
    static class Program
    {
        /// <summary>
        /// Gets or sets the service provider.
        /// </summary>
        /// <value>
        /// The service provider.
        /// </value>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                ServiceProvider = sp;
                var FormMain = sp.GetRequiredService<FormMain>();
                Application.Run(FormMain);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .AddTransient<ISettingRepository, SettingRepository>()
                .AddTransient<IEmailBookRepository, EmailBookRepository>()
                .AddTransient<IEmailService, EmailService>();
            services.AddEntityFrameworkSqlite().AddDbContext<DataDBContext>();

            services.AddTransient(typeof(FormMain));
            services.AddTransient(typeof(FrmSettings));
            services.AddTransient(typeof(FrmEmailBook));
            services.AddTransient(typeof(FrmSendEmail));
            services.AddTransient(typeof(FrmImportEmailBook));
        }
    }
}
