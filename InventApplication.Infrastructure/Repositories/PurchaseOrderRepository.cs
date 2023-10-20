using Dapper;
using InventApplication.Domain.DTOs;
using InventApplication.Domain.DTOs.PurchaseOrder;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using MailKit.Search;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace InventApplication.Infrastructure.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly IDataAccess _dataAccess;
        private readonly IActivityLogRepository _activityLogRepository;
        public PurchaseOrderRepository(IDataAccess dataAccess, IActivityLogRepository activityLogRepository)
        {
            _dataAccess = dataAccess;
            _activityLogRepository = activityLogRepository;
        }
        public async Task<bool> AddPurchaseOrder(PurchaseOrder addPurchaseOrderRequest)
        {
            Boolean status = false;
            SqlConnection? dbConn = null;
            try
            {
                dbConn = new SqlConnection(_dataAccess.GetConnectionString());
                dbConn.Open();
                string inputData = JsonConvert.SerializeObject(addPurchaseOrderRequest);
                SqlCommand command = new SqlCommand("dbo.addpurchaseorder", dbConn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@purchaseorderdata", SqlDbType.NVarChar)
                {
                    Value = inputData,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                });
                await command.ExecuteNonQueryAsync();
                status = true;
                ActivityLog activityLog = new()
                {
                    UserId = Convert.ToInt32(addPurchaseOrderRequest.CreatedBy),
                    Comments = "New Purchase Order Created "
                };
                await _activityLogRepository.AddActivityLogAsync(activityLog);
            }
            finally
            {
                dbConn?.Close();
            }
            return status;
        }

        public async Task<List<PurchaseOrderViewListDto>> GetPurchaseOrderist(PurchaseOrderSearchRequestDto getPurchaseOrderRequest)
        {
            List<PurchaseOrderViewListDto> purchaseOrders = new List<PurchaseOrderViewListDto>();

            using (SqlConnection connection = new SqlConnection(_dataAccess.GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.fngetallpurchaseorder(@purchaseordernumber,@sortfield,@sortorder,@pagenumber,@pagesize)", connection))
                {
                    command.CommandType = CommandType.Text;

                    // Add parameters
                    command.Parameters.Add(new SqlParameter("@purchaseordernumber", getPurchaseOrderRequest.PurchaseOrderNumber));
                    command.Parameters.Add(new SqlParameter("@sortfield", getPurchaseOrderRequest.SortField));
                    command.Parameters.Add(new SqlParameter("@sortorder", getPurchaseOrderRequest.SortOrder));
                    command.Parameters.Add(new SqlParameter("@pagenumber", getPurchaseOrderRequest.PageNo));
                    command.Parameters.Add(new SqlParameter("@pagesize", getPurchaseOrderRequest.PageSize));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            PurchaseOrderViewListDto purchaseOrder = new PurchaseOrderViewListDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                VendorName = reader["VendorName"].ToString(),
                                PurchaseOrderNumber = reader["PurchaseOrderNumber"].ToString(),
                                ReferenceNumber = reader["ReferenceNumber"].ToString(),
                                PODate = Convert.ToDateTime(reader["PODate"]),
                                ExpectedDeliveryDate = Convert.ToDateTime(reader["ExpectedDeliveryDate"]),
                                IsReceived = Convert.ToBoolean(reader["IsReceived"]),
                                TotalCount = Convert.ToInt32(reader["TotalCount"])
                            };

                            purchaseOrders.Add(purchaseOrder);
                        }
                    }
                }
            }

            return purchaseOrders;
        }
    }
}
