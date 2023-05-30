using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreUI.Models.MailVM;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new();
            MailboxAddress mailboxAddress = new("Admin", "testtestveri1@gmail.com");
            
            mimeMessage.From.Add(mailboxAddress);
            MailboxAddress mailboxAddressTo = new("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //mimeMessage.Body = new MimeEntity(mailRequest.Body);
            mimeMessage.Subject = mailRequest.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("testtestveri1@gmail.com", "sjfcymxrkfussvqw");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

    }
}
