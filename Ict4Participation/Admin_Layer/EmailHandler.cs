using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Layer
{
    public static class EmailHandler
    {
        /// <summary>
        /// Contains the basic information of a mail message header
        /// </summary>
        private static MailMessage mail = new MailMessage()
        {
            From = new MailAddress("no-reply@plumbum.com")
        };
        /// <summary>
        /// Contains the basic information of the smtp which is used to send the mail from
        /// </summary>
        private const SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new System.Net.NetworkCredential("s21mplumbum@gmail.com", "Em72@Gmai111"),
            EnableSsl = true
        };
        /// <summary>
        /// Contains the standard email end message
        /// </summary>
        private const string emailEnd =
                "\nVoor vragen en contact kunt u het volgende emailadres mailen: s21mplumbum@gmail.com"
                + "\n"
                + "\nMet vriendelijke groet,"
                + "\nHet ICT4Participation-Team";

        /// <summary>
        /// Sends a mail regarding a registration
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        public static void SendRegistration(string email, string username)
        {
            mail.To.Add(email);
            mail.Subject = "U hebt een account geregistreerd voor ICT4Participation";
            mail.Body = "Hallo!"
                + "\nU kunt nu registreren door middel van uw account:"
                + "\n" + username + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding a deactivation, as well as a reason
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="reason"></param>
        public static void SendDeactivation(string email, string username, string reason)
        {
            mail.To.Add(email);
            mail.Subject = "Uw ICT4Participation account is gedeactiveerd";
            mail.Body = "Hallo!"
                + "\nUw account " + username
                + "\nIs gedeactiveerd om de volgende reden: " + reason + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding an avatar that violates the terms of usage, as well as sends a mail to a webhost
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        public static void SendWrongAvatar(string email, string username)
        {
            mail.To.Add(email);
            mail.Subject = "Uw hebt een ICT4Participation waarschuwing ontvangen";
            mail.Body = "Hallo!"
                + "\nUw account " + username
                + "\nHeeft een ongepaste avatar, indien u deze niet in 24 uur aanpast, zullen de webbeheerders maatregelen nemen." + emailEnd;
            FinalSend();

            mail.To.Add("biepbot@gmail.com");
            mail.Subject = "ICT4Participation account gewaarschuwd";
            mail.Body = "Hallo!"
                + "\nHet volgende account" + username
                + "\nHeeft een waarschuwing gekregen over hun avatar, gelieve hier na 24 uur naar te kijken, of contact met de gebruiker op te nemen." + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding a password change
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="byAdmin"></param>
        public static void SendPassChange(string email, string username, string password, bool byAdmin)
        {
            string ex = byAdmin ? " door een administrator" : "";

            mail.To.Add(email);
            mail.Subject = "Uw ICT4Participation wachtwoord is veranderd";
            mail.Body = "Hallo!"
                + "\nHet wachtwoord van uw account: " + username + " is" + ex + " aangepast."
                + "\nUw nieuwe wachtwoord is: " + password
                + "\nWe raden dit wachtwoord aan te passen zodra u inlogt" + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Finalises and sends the mail
        /// </summary>
        private static void FinalSend()
        {
            SmtpServer.Send(mail);
        }
    }
}
