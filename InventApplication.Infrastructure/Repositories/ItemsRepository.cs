using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InventApplication.Infrastructure.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly IDataAccess _dataAccess;
        public ItemsRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<bool> AddItems(Items items)
        {
            int result = 0;
            SqlConnection dbConn = null;
            try
            {
                dbConn = new SqlConnection(_dataAccess.GetConnectionString());
                dbConn.Open();
                SqlParameter[] sqlParameters = new SqlParameter[10];
                sqlParameters[0] = new SqlParameter("@name", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = items.Name,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[1] = new SqlParameter("@description", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = items.Description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[2] = new SqlParameter("@unit", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = items.Unit,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[3] = new SqlParameter("@hsn", SqlDbType.Int)
                {
                    Value = items.HSN,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[4] = new SqlParameter("@brand", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = items.Brand,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[5] = new SqlParameter("@partcode", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = items.PartCode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[6] = new SqlParameter("@gst", SqlDbType.Int)
                {
                    Value = items.GST,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[7] = new SqlParameter("@igst", SqlDbType.Int)
                {
                    Value = items.IGST,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[8] = new SqlParameter("@sellingprice", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = items.SellingPrice,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[9] = new SqlParameter("@Status", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlCommand command = new SqlCommand("additems", dbConn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddRange(sqlParameters);
                await command.ExecuteNonQueryAsync();
                result = (int)command.Parameters["@Status"].Value;
            }
            finally
            {
                dbConn.Close();
            }
            return result > 0;
        }

        public Task<bool> DeleteItems(int itemsid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Items>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Items> GetItemsByIdAsync(int itemsid)
        {
            throw new NotImplementedException();
        }

        public Task<Items> GetItemsByNameAsync(string itemsname)
        {
            return null;
        }
    }
}
