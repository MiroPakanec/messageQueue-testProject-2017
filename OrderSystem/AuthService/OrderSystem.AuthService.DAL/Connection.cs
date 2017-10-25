using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderSystem.AuthService.DAL
{
    internal class Connection
    {
        private readonly IConfiguration _config;

        internal Connection()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        internal string Local
        {
            get
            {
                return _config.GetConnectionString("LocalSQL");
            }
        }
    }
}
