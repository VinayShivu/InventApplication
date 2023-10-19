using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using InventApplication.Domain.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
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
    }
}
