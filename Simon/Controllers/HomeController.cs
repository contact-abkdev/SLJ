using Simon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Simon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult _GetInTouch()
        {
            return PartialView(new ContactUS());
        }

        public ActionResult _GetInTouchMain()
        {
            return PartialView(new ContactUS());
        }

        [HttpPost]
        public ActionResult SendEnquiry(ContactUS objContactUS)
        {

            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);

            Msg.To.Add(ConfigurationManager.AppSettings["ToEmail"]);

            Msg.Subject = ConfigurationManager.AppSettings["Subject"];

            string appPath = Server.MapPath("~");
            string path = appPath + "EmailTemplates\\AdminEnquiryTemplate.html";
            string messageHtml = getMessage(path);
            messageHtml = messageHtml.Replace("#Name#", objContactUS.Name).Replace("#Email#", objContactUS.Phone).Replace("#Subject#", objContactUS.Address).Replace("#Message#", objContactUS.Message);

            Msg.Body = messageHtml;
            System.IO.Stream stream = new System.IO.MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(Msg.Body));
            AlternateView alternate = new AlternateView(stream, new System.Net.Mime.ContentType("text/html"));
            Msg.AlternateViews.Add(alternate);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["HostName"];
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("cms@cmsadmin.eu", ConfigurationManager.AppSettings["PassWord"]);
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            return RedirectToAction("Index");

        }

        private string getMessage(string path)
        {

            StreamReader streamreader = new StreamReader(path);
            string text, stream;
            text = "";
            stream = streamreader.ReadLine();
            while (stream != null)
            {
                stream = streamreader.ReadLine();
                text = text + stream;
            }
            streamreader.Close();
            return text;
        }
    }
}