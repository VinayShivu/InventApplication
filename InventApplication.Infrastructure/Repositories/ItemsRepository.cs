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

        public async Task<bool> AddItem(Items item)
        {
            int result = 0;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_dataAccess.GetConnectionString());
                connection.Open();
                SqlParameter[] sqlParameters = new SqlParameter[12];
                sqlParameters[0] = new SqlParameter("@name", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = item.Name,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[1] = new SqlParameter("@description", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = item.Description,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[2] = new SqlParameter("@unit", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = item.Unit,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[3] = new SqlParameter("@hsn", SqlDbType.Int)
                {
                    Value = item.HSN,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[4] = new SqlParameter("@brand", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = item.Brand,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[5] = new SqlParameter("@partcode", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = item.PartCode,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[6] = new SqlParameter("@gst", SqlDbType.Int)
                {
                    Value = item.GST,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[7] = new SqlParameter("@igst", SqlDbType.Int)
                {
                    Value = item.IGST,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[8] = new SqlParameter("@sellingprice", SqlDbType.Decimal)
                {
                    Value = item.SellingPrice,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Decimal
                };
                sqlParameters[9] = new SqlParameter("@stock", SqlDbType.Int)
                {
                    Value = item.Stock,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                sqlParameters[10] = new SqlParameter("@status", SqlDbType.VarChar, int.MaxValue)
                {
                    Value = item.Status,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.VarChar
                };
                sqlParameters[11] = new SqlParameter("@Result", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                SqlCommand command = new SqlCommand("additems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddRange(sqlParameters);
                await command.ExecuteNonQueryAsync();
                result = (int)command.Parameters["@Result"].Value;
            }
            finally
            {
                connection.Close();
            }
            return result > 0;
        }

        public Task<bool> DeleteItem(int itemid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Items>> GetAllItemAsync()
        {
            List<Items> itemslist = new List<Items>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_dataAccess.GetConnectionString());
                connection.Open();
                SqlCommand command = new SqlCommand("getallitems", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = await command.ExecuteReaderAsync();
                object[] eachRow = null;
                while (reader.Read())
                {
                    eachRow = new object[reader.FieldCount];
                    reader.GetValues(eachRow);

                    Items items = new Items();
                    items.ItemId = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader[0]);
                    items.Name = reader.IsDBNull(1) ? string.Empty : (string)reader[1];
                    items.Description = reader.IsDBNull(2) ? string.Empty : (string)reader[2];
                    items.Unit = reader.IsDBNull(3) ? string.Empty : (string)reader[3];
                    items.HSN = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader[4]);
                    items.Brand = reader.IsDBNull(5) ? string.Empty : (string)reader[5];
                    items.PartCode = reader.IsDBNull(6) ? string.Empty : (string)reader[6];
                    items.GST = reader.IsDBNull(7) ? 0 : Convert.ToInt32(reader[7]);
                    items.IGST = reader.IsDBNull(8) ? 0 : Convert.ToInt32(reader[8]);
                    items.SellingPrice = reader.IsDBNull(9) ? 0 : (decimal)reader[9];
                    items.Stock = reader.IsDBNull(10) ? 0 : Convert.ToInt32(reader[10]);
                    items.Status = reader.IsDBNull(11) ? string.Empty : (string)reader[11];
                    itemslist.Add(items);
                }

            }
            finally
            {
                connection.Close();
            }
            return itemslist;
        }

        public async Task<Items> GetItemByIdAsync(int itemid)
        {
            Items item = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_dataAccess.GetConnectionString());
                connection.Open();
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter("@itemid", SqlDbType.Int)
                {
                    Value = itemid,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Int
                };
                SqlCommand command = new SqlCommand("getitembyid", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddRange(sqlParameters);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                object[] eachRow = null;
                while (reader.Read())
                {
                    eachRow = new object[reader.FieldCount];
                    reader.GetValues(eachRow);

                    item = new Items
                    {
                        ItemId = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader[0]),
                        Name = reader.IsDBNull(1) ? string.Empty : (string)reader[1],
                        Description = reader.IsDBNull(2) ? string.Empty : (string)reader[2],
                        Unit = reader.IsDBNull(3) ? string.Empty : (string)reader[3],
                        HSN = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader[4]),
                        Brand = reader.IsDBNull(5) ? string.Empty : (string)reader[5],
                        PartCode = reader.IsDBNull(6) ? string.Empty : (string)reader[6],
                        GST = reader.IsDBNull(7) ? 0 : Convert.ToInt32(reader[7]),
                        IGST = reader.IsDBNull(8) ? 0 : Convert.ToInt32(reader[8]),
                        SellingPrice = reader.IsDBNull(9) ? 0 : (decimal)reader[9],
                        Stock = reader.IsDBNull(10) ? 0 : Convert.ToInt32(reader[10]),
                        Status = reader.IsDBNull(11) ? string.Empty : (string)reader[11]
                    };
                }
            }
            finally
            {
                connection.Close();
            }
            return item;

        }

        public Task<Items> GetItemByNameAsync(string itemname)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(_dataAccess.GetConnectionString());
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "getitembyname";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = new SqlParameter("@itemname", SqlDbType.VarChar, int.MaxValue);
                    parameter.Value = itemname;
                    parameter.Direction = ParameterDirection.Input;
                    command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();

                    Items result = new Items();
                    int Index = 0;
                    if (reader != null && reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            Index = reader.GetOrdinal("itemid");
                            if (!reader.IsDBNull(Index)) result.ItemId = reader.GetInt32(Index);

                            Index = reader.GetOrdinal("name");
                            if (!reader.IsDBNull(Index)) result.Name = reader.GetString(Index);

                            Index = reader.GetOrdinal("description");
                            if (!reader.IsDBNull(Index)) result.Description = reader.GetString(Index);

                            Index = reader.GetOrdinal("unit");
                            if (!reader.IsDBNull(Index)) result.Unit = reader.GetString(Index);

                            Index = reader.GetOrdinal("hsn");
                            if (!reader.IsDBNull(Index)) result.HSN = reader.GetInt32(Index);

                            Index = reader.GetOrdinal("brand");
                            if (!reader.IsDBNull(Index)) result.Brand = reader.GetString(Index);

                            Index = reader.GetOrdinal("partcode");
                            if (!reader.IsDBNull(Index)) result.PartCode = reader.GetString(Index);

                            Index = reader.GetOrdinal("gst");
                            if (!reader.IsDBNull(Index)) result.GST = reader.GetInt32(Index);

                            Index = reader.GetOrdinal("igst");
                            if (!reader.IsDBNull(Index)) result.IGST = reader.GetInt32(Index);

                            Index = reader.GetOrdinal("sellingprice");
                            if (!reader.IsDBNull(Index)) result.SellingPrice = reader.GetDecimal(Index);

                            Index = reader.GetOrdinal("stock");
                            if (!reader.IsDBNull(Index)) result.Stock = reader.GetInt32(Index);

                            Index = reader.GetOrdinal("status");
                            if (!reader.IsDBNull(Index)) result.Status = reader.GetString(Index);

                        }
                        reader.Close();
                        return Task.FromResult(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
