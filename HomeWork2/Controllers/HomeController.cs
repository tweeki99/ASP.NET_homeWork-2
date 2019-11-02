using HomeWork2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HomeWork2.Controllers
{
    public class HomeController : Controller
    {
        LetterContext letterContext = new LetterContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessData(string name, string email, string subject, string message)
        {
            SmtpClient _smtp = new SmtpClient("smtp.yandex.ru", 25);
            _smtp.Credentials = new NetworkCredential("shipa.danilov@yandex.kz", "5343454karp99");
            _smtp.EnableSsl = true;
            MailMessage _mail = new MailMessage();
            _mail.From = new MailAddress("shipa.danilov@yandex.kz");
            _mail.To.Add(new MailAddress("danil.shipilov.99@gmail.com"));
            _mail.SubjectEncoding = Encoding.UTF8;
            _mail.BodyEncoding = Encoding.UTF8;
            _mail.Subject = subject;
            _mail.Body = message;
            _smtp.Send(_mail);

            letterContext.Letters.Add(new Letter { Name = name, Email = email, Message = message, Subject = subject });
            letterContext.SaveChanges();
            

            return RedirectToAction("index");
        }
    }
}