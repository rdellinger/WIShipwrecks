using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class ContactController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        //
        // GET: /Contact/
        public ActionResult Index()
        {
            return View();
        }


        // POST: /Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Comments,Email")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                // Stamp it with the date
                feedback.Date = DateTime.Now;

                // Save the record
                db.Feedbacks.Add(feedback);
                db.SaveChanges();

                // Compose email to Feedback Recipients
                MailMessage mail = new MailMessage();

                SmtpClient smtpServer = new SmtpClient("mail.aqua.wisc.edu");
                //smtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                smtpServer.Port = 25;

                if (feedback.Email != null)
                {
                    mail.From = new MailAddress(feedback.Email);
                }
                else {
                    mail.From = new MailAddress("info@aqua.wisc.edu");
                }
                
                mail.Subject = "WI Shipwrecks Feedback";
                mail.Body = feedback.Comments;

                // Send the email to each email in Feedback Recipients
                foreach (var recipient in db.FeedbackRecipients)
                {
                    mail.To.Add(recipient.Email);
                };

                smtpServer.Send(mail);

                // Tell the page to display the success message
                ViewBag.Success = true;

                return View("Index");
            }

            return View("Index", feedback);
        }



	}
}