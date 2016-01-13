using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Layer
{
    public static class EmailHandler
    {
        private static string emailHead = "gfjfaskdas";
        private static string emailTitle = "sadjsdhusaj";
        private static string emailDescription = "sadsadasdsadsa";

        private static string emailBody = 
    @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
	<head>
        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
        <title>{0}</title>
    </head>
    <body leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;margin: 0;padding: 0;background-color: #EEE;height: 100% !important;width: 100% !important;"">
    	<center>
        	<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;margin: 0;padding: 0;background-color: #EEE;border-collapse: collapse !important;height: 100% !important;width: 100% !important;"">
            	<tr>
                	<td align=""center"" valign=""top"" id=""bodyCell"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;margin: 0;padding: 20px;border-top: 4px solid #BBBBBB;height: 100% !important;width: 100% !important;"">
                    	<!-- BEGIN TEMPLATE // -->
                    	<table border=""0"" cellpadding=""0"" cellspacing=""0"" id=""templateContainer"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;width: 600px;border: 1px solid #BBBBBB;border-collapse: collapse !important;"">
                        	<tr>
                            	<td align=""center"" valign=""top"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templatePreheader"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;background-color: #F3F3F3;border-bottom: 1px solid #CCCCCC;border-collapse: collapse !important;"">
                                        <tr>
                                            <td valign=""top"" class=""preheaderContent"" style=""padding-top: 10px;padding-right: 20px;padding-bottom: 10px;padding-left: 20px;-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;color: #808080;font-family: Helvetica;font-size: 10px;line-height: 125%;text-align: left;"" mc:edit=""preheader_content00"">
                                                {0}
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        	<tr>
                            	<td align=""center"" valign=""top"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateHeader"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;background-color: #F4F4F4;border-bottom: 1px solid #CCCCCC;border-collapse: collapse !important;"">
                                        <tr>
                                            <td valign=""top"" class=""headerContent"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;color: #505050;font-family: Helvetica;font-size: 20px;font-weight: bold;line-height: 100%;padding-top: 0;padding-right: 0;padding-bottom: 0;padding-left: 0;text-align: left;vertical-align: middle;"">
                                            	<img src=""http://i.imgur.com/tmy8Ouy.png"" id=""headerImage"" mc:label=""header_image"" mc:edit=""header_image"" mc:allowdesigner mc:allowtext style=""-ms-interpolation-mode: bicubic;border: 0;height: auto;line-height: 100%;outline: none;text-decoration: none;max-width: 600px;"">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        	<tr>
                            	<td align=""center"" valign=""top"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateBody"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;background-color: #FFF;border-top: 1px solid #FFFFFF;border-bottom: 1px solid #CCCCCC;border-collapse: collapse !important;"">
                                        <tr>
                                            <td valign=""top"" class=""bodyContent"" mc:edit=""body_content"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;color: #505050;font-family: Helvetica;font-size: 16px;line-height: 150%;padding-top: 20px;padding-right: 20px;padding-bottom: 20px;padding-left: 20px;text-align: left;"">
                                                   {0}
                                                <br> {1}
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        	<tr>
                            	<td align=""center"" valign=""top"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""templateFooter"" style=""-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;background-color: #F3F3F3;border-top: 1px solid #FFFFFF;border-collapse: collapse !important;"">
                                        <tr>
                                            <td valign=""top"" class=""footerContent"" style=""padding-top: 20px;-webkit-text-size-adjust: 100%;-ms-text-size-adjust: 100%;mso-table-lspace: 0pt;mso-table-rspace: 0pt;color: #808080;font-family: Helvetica;font-size: 10px;line-height: 150%;padding-right: 20px;padding-bottom: 20px;padding-left: 20px;text-align: left;"" mc:edit=""footer_content01"">
                                            	<br>
                                                <em>Copyright &copy; 2015 ict4participation, Alle rechten gereserveerd.</em>
                                                <br>
                                                <br>
                                                <strong>Ons mailadres is:</strong>
                                                <br>
                                                s21mplumbum@gmail.com
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </center>
    </body>
</html>";
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
        private static SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new System.Net.NetworkCredential("s21mplumbum@gmail.com", "Em72@Gmai111"),
            EnableSsl = true
        };
        /// <summary>
        /// Contains the standard email end message
        /// </summary>
        private const string emailEnd =
                "<br />Voor vragen en contact kunt u het volgende emailadres mailen: s21mplumbum@gmail.com"
                + "<br />"
                + "<br />Met vriendelijke groet,"
                + "<br />Het ICT4Participation-Team";

        /// <summary>
        /// Sends a mail regarding a registration
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        public static void SendRegistration(string email, string username)
        {
            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "U hebt een account geregistreerd voor ICT4Participation";
            emailDescription = "Hallo!"
                + "<br />U kunt nu registreren door middel van uw account:"
                + "<br />" + username + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding a planned meeting
        /// </summary>
        /// <param name="m">The meeting</param>
        /// <param name="emailReq">The mail of the account on which the meeting was made</param>
        /// <param name="emailRed">The mail of the account the meeting was planned with</param>
        /// <param name="usernameReq">The username of the account on which the meeting was made</param>
        /// <param name="usernameRed">The username of the account the meeting was planned with</param>
        public static void SendMeeting(Meetingdetails m, string emailReq, string emailRed, string usernameReq, string usernameRed)
        {
            string meetingdetails = "<br />";
            if (m.CreationDate != null)
            {
                meetingdetails += string.Format("Startdatum: {0} <br />Einddatum: {1}", m.StartDate, m.EndDate);
            }
            if (m.Location != null)
            {
                meetingdetails += string.Format("<br />Op de volgende locatie: {0}", m.Location);
            }

            mail.To.Clear();
            mail.To.Add(emailReq);
            mail.To.Add(emailRed);
            emailHead = emailTitle = mail.Subject = usernameReq + " heeft een ontmoeting voor u ingepland";
            emailDescription = "Hallo!"
                + "<br />U bent ingepland voor een ontmoeting" + meetingdetails;
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
            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "Uw ICT4Participation account is gedeactiveerd";
            emailDescription = "Hallo!"
                + "<br />Uw account " + username
                + "<br />Is gedeactiveerd om de volgende reden: " + reason + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding an avatar that violates the terms of usage, as well as sends a mail to a webhost
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        public static void SendWrongAvatar(string email, string username)
        {
            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "Uw hebt een ICT4Participation waarschuwing ontvangen";
            emailDescription = "Hallo!"
               + "<br />Uw account " + username
               + "<br />Heeft een ongepaste avatar, indien u deze niet in 24 uur aanpast, zullen de webbeheerders maatregelen nemen." + emailEnd;
            FinalSend();

            mail.To.Clear();
            mail.To.Add("biepbot@gmail.com");
            emailHead = emailTitle = mail.Subject = "ICT4Participation account gewaarschuwd";
            emailDescription = "Hallo!"
               + "<br />Het volgende account " + username
               + "<br />Heeft een waarschuwing gekregen over hun avatar, gelieve hier na 24 uur naar te kijken, of contact met de gebruiker op te nemen." + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding a comment that violates the terms of usage
        /// </summary>
        /// <param name="email"></param>
        /// <param name="question"></param>
        /// <param name="reason"></param>
        public static void SendWrongComment(string email, string question, string reason)
        {
            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "Uw reactie op de vraag " + question + " is verwijderd";
            emailDescription = "Hallo!"
               + "<br />Uw reactie op de vraag " + question + " is verwijderd door een webbeheerder met de volgende reden:"
               + "<br />" + reason + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding a question that violates the terms of usage
        /// </summary>
        /// <param name="email"></param>
        /// <param name="question"></param>
        /// <param name="reason"></param>
        public static void SendWrongQuestion(string email, string question, string reason)
        {
            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "Uw vraag " + question + " is verwijderd";
            emailDescription = "Hallo!"
               + "<br />Uw vraag " + question + " is verwijderd door een webbeheerder met de volgende reden:"
               + "<br />" + reason + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Sends a mail regarding a review that violates the terms of usage
        /// </summary>
        /// <param name="email"></param>
        /// <param name="review"></param>
        /// <param name="reason"></param>
        public static void SendWrongReview(string email, string username, string reason)
        {
            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "Uw review op " + username + " is verwijderd";
            emailDescription = "Hallo!"
               + "<br />Uw review is verwijderd door een webbeheerder met de volgende reden:"
               + "<br />" + reason + emailEnd;
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

            mail.To.Clear();
            mail.To.Add(email);
            emailHead = emailTitle = mail.Subject = "Uw ICT4Participation wachtwoord is veranderd";
            emailDescription = "Hallo!"
               + "<br />Het wachtwoord van uw account: " + username + " is" + ex + " aangepast."
               + "<br />Uw nieuwe wachtwoord is: " + password
               + "<br />We raden dit wachtwoord aan te passen zodra u inlogt" + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Finalises and sends the mail
        /// </summary>
        private static void FinalSend()
        {
            mail.IsBodyHtml = true;
            emailBody = String.Format(emailBody, emailTitle, emailDescription);
            mail.Body = emailBody;

            SmtpServer.Send(mail);
        }
    }
}
