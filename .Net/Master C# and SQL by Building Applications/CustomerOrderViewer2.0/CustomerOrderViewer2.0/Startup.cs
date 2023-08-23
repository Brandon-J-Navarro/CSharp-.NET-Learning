using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer2._0
{
    internal class Startup
    {
        public static IConfiguration BuildConfiguation()
        {
            return new ConfigurationBuilder()
                .AddUserSecrets<Program>()
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
