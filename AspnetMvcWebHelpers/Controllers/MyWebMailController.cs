using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspnetMvcWebHelpers.Controllers
{
    public class MyWebMailController : Controller
    {
        public ActionResult Index()
        {
            bool sonuc = false;

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "abc@gmail.com";
            WebMail.Password = "123456";

            WebMail.EnableSsl = true;

            string file = Server.MapPath("~/images/murat.jpg");

            try
            {
                WebMail.Send(
                    to: "abc@gmail.com", subject: "Web Mail Test",
                    body: "Bu bir web mail denemesidir.<br><b>Lütfen dikkate almayınız..</b>",
                    replyTo: "dont-reply@gmail.com", isBodyHtml: true,
                    filesToAttach: new[] { file });

                sonuc = true;
            }
            catch (Exception ex)
            {
                ViewBag.Hata = ex.Message;
            }

            ViewBag.Sonuc = sonuc;

            return View();
        }
    }
}