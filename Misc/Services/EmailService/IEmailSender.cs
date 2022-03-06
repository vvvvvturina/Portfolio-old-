using MimeKit;

namespace Misc.Services.EmailService;
using System.Threading.Tasks;

public interface IEmailSender
{
    void SendEmail(string messageBody);
}