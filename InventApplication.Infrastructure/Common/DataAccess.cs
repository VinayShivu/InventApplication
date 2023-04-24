using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Infrastructure.Common
{
    public class DataAccess : IDataAccess
    {
        public readonly IConfiguration _configuration;
        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
#pragma warning disable CS8603 // Possible null reference return.

            return _configuration.GetSection("ConnectionStrings").GetSection("DBConnectionString").Value;

#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
