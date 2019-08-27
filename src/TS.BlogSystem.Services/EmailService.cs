using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TS.BlogSystem.Core.Interfaces.Services;

namespace TS.BlogSystem.Services
{
    public class EmailService : IEmailService
    {
       
        public async Task SendEmailAsync(string email, string subject, string body, bool isHtml = false)
        {
            //throw new NotImplementedException();
        }
    }
}
