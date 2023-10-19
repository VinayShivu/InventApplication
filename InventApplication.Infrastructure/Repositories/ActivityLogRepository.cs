using InventApplication.Domain.DTOs;
using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Data;

namespace InventApplication.Infrastructure.Repositories
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly IDataAccess _dataAccess;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ActivityLogRepository(IDataAccess dataAccess, IHttpContextAccessor httpContextAccessor)
        {
            _dataAccess = dataAccess;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual string GetCurrentIpAddress()
        {
            var result = string.Empty;
            try
            {
                //first try to get IP address from the forwarded header
                if (_httpContextAccessor.HttpContext.Request.Headers != null)
                {
                    //the X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a client
                    //connecting to a web server through an HTTP proxy or load balancer
                    var forwardedHttpHeaderKey = "X-FORWARDED-FOR";
                    //if (!string.IsNullOrEmpty(_hostingConfig.ForwardedHttpHeader))
                    //{
                    //	//but in some cases server use other HTTP header
                    //	//in these cases an administrator can specify a custom Forwarded HTTP header (e.g. CF-Connecting-IP, X-FORWARDED-PROTO, etc)
                    //	forwardedHttpHeaderKey = _hostingConfig.ForwardedHttpHeader;
                    //}

                    var forwardedHeader = _httpContextAccessor.HttpContext.Request.Headers[forwardedHttpHeaderKey];
                    if (!StringValues.IsNullOrEmpty(forwardedHeader))
                        result = forwardedHeader.FirstOrDefault();
                }

                //if this header not exists try get connection remote IP address
                if (string.IsNullOrEmpty(result) && _httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                    result = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch
            {
                return string.Empty;
            }

            //some of the validation
            if (result != null && result.Equals("::1", StringComparison.InvariantCultureIgnoreCase))
                result = "127.0.0.1";

            //remove port
            if (!string.IsNullOrEmpty(result))
                result = result.Split(':').FirstOrDefault();

            return result;
        }
        public async Task<bool> AddActivityLogAsync(ActivityLog activityLog)
        {
            bool status = false;
            SqlConnection? dbConn = null;
            try
            {
                activityLog.IpAddress = GetCurrentIpAddress();
                dbConn = new SqlConnection(_dataAccess.GetConnectionString());
                dbConn.Open();
                string inputData = JsonConvert.SerializeObject(activityLog);
                SqlCommand command = new SqlCommand(@"dbo.activityloginsert", dbConn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@activitylogdata", SqlDbType.NVarChar)
                {
                    Value = inputData,
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.NVarChar
                });
                await command.ExecuteNonQueryAsync();
                status = true;
            }
            finally
            {
                dbConn.Close();
            }
            return status;
        }
    }
}
