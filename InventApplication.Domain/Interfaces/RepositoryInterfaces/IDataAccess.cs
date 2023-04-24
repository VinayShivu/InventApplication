using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.Interfaces.RepositoryInterfaces
{
    public interface IDataAccess
    {
        public string GetConnectionString();
    }
}
