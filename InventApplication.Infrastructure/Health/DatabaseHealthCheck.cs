using InventApplication.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace InventApplication.Infrastructure.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IDataAccess _dataAccess;
        public DatabaseHealthCheck(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                using var connection = new SqlConnection(_dataAccess.GetConnectionString());
                using var command = connection.CreateCommand();
                command.CommandText = "Select 1";
                connection.Open();
                command.ExecuteScalar();
                connection.Close();
                return HealthCheckResult.Healthy();
            }
            catch (Exception exception)
            {
                return HealthCheckResult.Unhealthy(exception: exception);
            }
        }
    }
}
