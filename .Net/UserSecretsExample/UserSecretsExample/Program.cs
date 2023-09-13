using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

// NuGet Packages Required:
//      Microsoft.Extensions.Configuration.CommandLine,
//      Microsoft.Extensions.Configuration.EnvironmentVariables,
//      Microsoft.Extensions.Configuration.Json,
//      Microsoft.Extensions.Configuration.UserSecrets,
//      Microsoft.Extensions.DependencyInjection

namespace UserSecretsExample
{
    class Program
    {
        private static readonly IConfiguration _configuration = Startup.BuildConfiguation();
        private static string _connectionString = _configuration["ConnectionString:sqlConnectionString"];
        private static string _password = _configuration["EmailCredentials:password"];
        private static string _from = _configuration["EmailCredentials:email"];
    }
}