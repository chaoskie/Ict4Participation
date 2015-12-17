using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Admin_Layer
{
    public abstract class Check
    {
        static bool invalidMail = false;
 
        public static bool CheckAccount(Accountdetails acc, out string message)
        {
            message = String.Empty;
            if (!Check.Birthday(acc.Birthdate))
            {
                message = "Verjaardag is fout ingegeven.";
                return false;
            }
            if (!Check.Name(acc.Name))
            {
                message = "Naam is fout ingegeven. \r\nDeze mag geen nummers of speciale tekens bevatten!";
                return false;
            }
            if (!Check.LiteralUsername(acc.Username))
            {
                message = "Gebruikersnaam is fout ingegeven. \r\nUw gebruikersnaam mag geen speciale tekens bevatten!";
                return false;
            }
            if (!Check.Phonenumber(acc.Phonenumber))
            {
                message = "Telefoonnummer is fout ingegeven. \r\nUw telefoon voldoet niet aan ons format: \r\nProbeer: XXX-XXX-XXXX";
                return false;
            }
            if (acc.VOGPath != null)
            {
                if (!Check.isOfFileExt(acc.VOGPath, ".pdf"))
                {
                    message = "Uw VOG is geen pdf.";
                    return false;
                }
            }
            if (!Check.isImage(acc.AvatarPath))
            {
                message = "Uw avatar is geen afbeelding.";
                return false;
            }
            if (!Check.isLocation(acc.City, acc.Address))
            {
                message = "Uw locatie kon niet gevonden worden.";
                return false;
            }
            if (!Check.isEmail(acc.Email))
            {
                message = "Uw email kon niet gevonden worden.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the phone-number is one of the following:
        /// <para>0402001888</para>
        /// <para>040.200.1888</para>
        /// <para>040-200-1888</para>
        /// <para>+31 0402001888</para>
        /// <para>+31 040.200.1888</para>
        /// <para>+31 040-200-1888</para>
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Yields true when this is the case</returns>
        public static bool Phonenumber(string s)
        {
            s = Regex.Replace(s, " ", "", RegexOptions.None);
            return Regex.IsMatch(s, @"([+]\d{2} ){0,1}\d{3}[-.]?\d{3}[-.]?\d{4}");
        }

        /// <summary>
        /// Checks if the birthday is more than 12 hours ago
        /// </summary>
        /// <param name="d"></param>
        /// <returns>Yields false when this is the case</returns>
        public static bool Birthday(DateTime d)
        {
            return d.AddHours(12) < DateTime.Now;
        }

        /// <summary>
        /// Checks if the string is plain text (made from letters and spaces) only
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Yields true when this is the case</returns>
        public static bool Letters(string s)
        {
            return Regex.IsMatch(s, "[^a-zA-Z ]{1,}") ? false : true;
        }

        /// <summary>
        /// Checks if the string is a name, including special chars
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Yields true when this is the case</returns>
        public static bool Name(string s)
        {
            return Regex.IsMatch(s, @"([\u00C0-\u017Fa-zA-Z']{0,}[\u00C0-\u017Fa-zA-Z-' ]{0,}[\u00C0-\u017Fa-zA-Z']{0,}){1,}");
        }

        /// <summary>
        /// Checks if the string could be a valid username. No spaces, minimum of 6 chars
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool LiteralUsername(string s)
        {
            return Regex.IsMatch(s, "[a-zA-Z0-9]{6,255}");
        }

        /// <summary>
        /// Checks if the string ends with a specified extension
        /// </summary>
        /// <param name="s"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static bool isOfFileExt(string s, string ext)
        {
            return Regex.IsMatch(s, "(" + ext + ")$");
        }

        public static bool isImage(string s)
        {
            try
            {
                //TO DO
                //Download
                //Try creating an image out of it
                return true;
            }
            catch
            {
                //Delete image
                return false;
            }
        }

        public static bool isEmail(string s)
        {            
            invalidMail = false;
            if (String.IsNullOrEmpty(s))
                return false;

            // use IdnMapping class to convert Unicode domain names.
            try
            {
                s = Regex.Replace(s, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalidMail)
                return false;

            // Return true als parameter 's' in valid e-mail format is.
            try
            {
                return Regex.IsMatch(s,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private static string DomainMapper(Match match)
        {
            // IdnMapping class met default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalidMail = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public static bool isLocation(string city, string address)
        {
            //TODO
            //Check if valid address
            return true;
        }
    }
}
