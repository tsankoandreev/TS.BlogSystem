using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TS.BlogSystem.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message, bool isHtml = false);
    }
}
