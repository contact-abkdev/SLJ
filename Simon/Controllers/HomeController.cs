using Simon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
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
            
using(SmtpClient smtpClient = new SmtpClient())
{
    var basicCredential = new NetworkCredential(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["PassWord"]); 
    using(MailMessage message = new MailMessage())
    {
        MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]); 

        smtpClient.Host = ConfigurationManager.AppSettings["HostName"];
        smtpClient.UseDefaultCredentials = false;
		smtpClient.Port = 25;
        smtpClient.Credentials = basicCredential;

        message.From = fromAddress;
        message.Subject = ConfigurationManager.AppSettings["Subject"];
        message.IsBodyHtml = true;
         string appPath = Server.MapPath("~");
            string path = appPath + "EmailTemplates\\AdminEnquiryTemplate.html";
            string messageHtml = getMessage(path);
            messageHtml = messageHtml.Replace("#Name#", objContactUS.Name).Replace("#Email#", objContactUS.Phone).Replace("#Subject#", objContactUS.Address).Replace("#Message#", objContactUS.Message);

            message.Body = messageHtml;
            System.IO.Stream stream = new System.IO.MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(Msg.Body));
            AlternateView alternate = new AlternateView(stream, new System.Net.Mime.ContentType("text/html"));
            message.AlternateViews.Add(alternate);
        
        message.To.Add(ConfigurationManager.AppSettings["ToEmail"]); 

        try
        {
            smtpClient.Send(message);
			Console.Write("send");
        }
        catch(Exception ex)
        {
            //Error, could not send the message
            Console.Write(ex.Message);
        }
    }
    }
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
