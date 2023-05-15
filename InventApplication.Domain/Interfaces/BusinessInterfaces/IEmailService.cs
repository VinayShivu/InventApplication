using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventApplication.Domain.Interfaces.BusinessInterfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string subject, string body);
    }
}
