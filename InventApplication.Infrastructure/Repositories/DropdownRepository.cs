using Dapper;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;

namespace InventApplication.Infrastructure.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly IDataAccess _dataAccess;
        public DropdownRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<List<DropDownValues>> GetDropDownListAsync()
        {
            IEnumerable<DropDownValues>? details = null;
            SqlConnection? dbConn = null;
            try
            {
                dbConn = new SqlConnection(_dataAccess.GetConnectionString());
                dbConn.Open();
                details = await dbConn.QueryAsync<DropDownValues>("SELECT * FROM dbo.getdropdownlistfun()");
            }
            finally
            {
                dbConn?.Close();
            }
            return details.ToList();
        }
    }
}
