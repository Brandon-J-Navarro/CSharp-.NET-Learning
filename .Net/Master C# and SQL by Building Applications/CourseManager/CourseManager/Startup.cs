using Caliburn.Micro;
using CourseManager.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseManager
{
    internal class Startup : BootstrapperBase
    {
        public Startup()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MainViewModel>();
        }
        public static IConfiguration BuildConfiguation()
        {
            return new ConfigurationBuilder()
                .AddUserSecrets<MainViewModel>()
                .Build();
        }
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .BuildServiceProvider();
            return provider;
        }
    }
}
