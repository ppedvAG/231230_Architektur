using Microsoft.Extensions.DependencyInjection;
using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.UI.WPF.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ppedv.CarRent7000.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IRepository, Data.EfCore.CarRentRepository>();
            services.AddSingleton<CarsViewModel>();
            

            return services.BuildServiceProvider();
        }

    }

}
