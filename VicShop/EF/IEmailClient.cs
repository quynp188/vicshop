using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VicShop.EF
{
    public interface IEmailClient
    {
        Task SentEmail(string email);
        Task<string> SentEmailTemplate(string email, string template)
        {
            string  abc = $"Implement {email}";
            return Task.FromResult(abc);
        }
    }
}
