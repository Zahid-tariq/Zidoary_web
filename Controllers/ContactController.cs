using System;
using System.Collections.Generic;
using System.Linq;
using zidoary.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace zidoary.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult zidoary()
        {
            return View();
        }

        //method execute when click contact_form
        [HttpPost]
        public ActionResult zidoary(string Name, string Email, string Subject, string Message)
        {

            try
            {
                Contact obj = new Contact();
                obj.Name = Name;
                obj.Email = Email;
                obj.Subject = Subject;
                obj.Message = Message;

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("hr@zidoary.com");
                message.To.Add(new MailAddress("hr@zidoary.com"));
                message.Subject = obj.Subject;
                message.IsBodyHtml = true;
                message.Body = "Your Sender_Name:" + " " + obj.Name + "\nYour Sender_Message:" + obj.Message + "\nYour Sender Email:" + obj.Email;
                smtp.Port = 587;
                smtp.Host = "smtp.zoho.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("hr@zidoary.com", "zidoary123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            ViewBag.Message = "Successfully submit";

            return View();

        }
   }
}
 