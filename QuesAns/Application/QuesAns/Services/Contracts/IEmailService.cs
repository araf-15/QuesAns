using QuesAns.Models.AccountModels;
using System.Threading.Tasks;

namespace QuesAns.Services.Contracts
{
    public interface IEmailService
    {
        public void SendEmail(string sendAddress, string body, string fromAddress);

        Task SendTestEmail(UserEmailOptionsModel userEmailOptions);
        Task SendConfirmEmail(UserEmailOptionsModel userEmailOptions);
    }
}
