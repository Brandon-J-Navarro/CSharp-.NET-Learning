using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace UserSecretsExample
{
    class Program
    {
        private static readonly IConfiguration _configuration = Startup.BuildConfiguation();
        private static string _connectionString = _configuration["ConnectionString:sqlConnectionString"];
    }
}