using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Admin_Layer
{
    abstract public class Check
    {
        static bool invalidMail = false;

        public static bool CheckAccount(Accountdetails acc, out string message, bool isAdmin = false)
        {
            message = String.Empty;
            if (!Check.Birthday(acc.Birthdate))
            {
                message = "Verjaardag is fout ingegeven.";
                return false;
            }
            if (!Check.Name(acc.Name, out message))
            {
                message = "Naam is fout ingegeven. \r\n" + message;
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
            if (!isAdmin)
            {
                if (!string.IsNullOrEmpty(acc.VOGPath))
                {
                    if (!Check.isOfFileExt(acc.VOGPath, ".pdf"))
                    {
                        message = "Uw VOG is geen pdf.";
                        return false;
                    }
                }
                if (!Check.isImage(acc.AvatarPath.ToLower()))
                {
                    message = "Uw avatar is geen .PNG, .JPG of .JPEG.";
                    return false;
                }
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
        public static bool Name(string s, out string message)
        {
            message = "";
            //Check if the string is longer than 255
            if (s.Length > 255)
            {
                message = "Uw naam is te lang.";
                return false;
            }

            //Check if the full name contains at least 1 space (= 2 words)
            if (!s.Contains(' '))
            {
                message = "Uw volledige naam bestaat uit minimaal twee delen";
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                char prev = i == 0 ? ' ' : s[i - 1];
                char next = i >= s.Length - 1 ? ' ' : s[i + 1];
                char nextdot = i >= s.Length - 2 ? ' ' : s[i + 2];
                char prevdot = i < 2 ? ' ' : s[i-2];

                //Check if the dots are preceded by a letter, and have a space placed after, or another dot 2 places further
                if (current == '.')
                {
                    //If there is no proper character 1 place before this character
                    if (!Regex.IsMatch(prev.ToString(), @"[\u00C0-\u017Fa-zA-Z]{1}"))
                    {
                        //If this is not the case
                        message = "Een puntteken zoals in 'J.K. Rowling' moet altijd worden geplaatst na een letter.";
                        return false;
                    }

                    //If there is no other dot 2 places away AND the next character is no space
                    if (current != nextdot && next != ' ')
                    {
                        message = "Een naam-afkorting moet of gevolgd worden door nog een afkorting, of een spatie. Zie de J.K. in 'J.K. Rowling'.";
                        return false;
                    }

                    //If there is no other dot, or space, 2 places before this one
                    if (prevdot != ' ' && prevdot != '.')
                    {
                        message = "Een puntteken zoals in 'J.K. Rowling' moet alleen met een letter staan, of nog een afkorting";
                        return false;
                    }
                }

                //Check if the minus symbol is surrounded by letters
                if (current == '-')
                {
                    if (!(Regex.IsMatch(prev.ToString(), @"[\u00C0-\u017Fa-zA-Z]{1}") && Regex.IsMatch(next.ToString(), @"[\u00C0-\u017Fa-zA-Z]{1}")))
                    {
                        message = "Een streepje zoals in 'Henk van Bart-Veldden' moet altijd tussen letters komen te staan";
                        return false;
                    }
                }
            }

            s = s.Replace(@"/ +/g", "");
            //Check if every symbol is what it needs to be
            if (!Regex.IsMatch(s, @"^[\u00C0-\u017Fa-zA-Z'-.]{1,}$"))
            {
                message = "Naam bevat ongeldige tekens!";
                return false;
            }

            return true;
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
        /// <param name="s">string to check</param>
        /// <param name="ext">extension to match</param>
        /// <returns>succes bool</returns>
        public static bool isOfFileExt(string s, string ext)
        {
            return Regex.IsMatch(s, "(" + ext + ")$");
        }

        public static bool isImage(string s)
        {
            //Check if .png .jpg .jpeg
            if (Check.isOfFileExt(s, ".png"))
            {
                return true;
            }
            if (Check.isOfFileExt(s, ".jpg"))
            {
                return true;
            }
            if (Check.isOfFileExt(s, ".jpeg"))
            {
                return true;
            }
            if (Check.isOfFileExt(s, ".gif"))
            {
                return true;
            }
            return false;
        }

        public static bool isEmail(string s)
        {
            string us = s.Substring(0, 1);
            if (us == "_")
            {
                s = s.Substring(1);
            }

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
            //http://www.postcodedata.nl/ check voor relevante info
            return true;
        }

        /// <summary>
        /// check the question details for correct input
        /// </summary>
        /// <param name="qd">question details object</param>
        /// <param name="message">error output message</param>
        /// <returns>succes boolean</returns>
        public static bool QuestionDetails(Questiondetails qd, out string message, bool isByAdmin = false)
        {
            if (!Check.checkIfFilledIn(qd.Title))
            {
                message = "Titel is niet ingevuld!";
                return false;
            }
            if (!Check.checkIfFilledIn(qd.Description))
            {
                message = "Beschrijving is niet ingevuld!";
                return false;
            }
            if (!Check.checkIfFilledIn(qd.Location))
            {
                message = "Locatie is niet ingevuld!";
                return false;
            }
            if (checkSkillCountIsEmpty(qd.Skills.Count)) //if 0 then true
            {
                message = "Geen skills toegevoegd!";
                return false;
            }
            if (!isByAdmin)
            {
                bool isStartDateNull = true;
                bool isEndDateNull = true;
                if (qd.StartDate != null)
                {
                    if (((DateTime)qd.StartDate).Subtract(DateTime.Now) < TimeSpan.Zero)
                    {
                        message = "De begintijd is al geweest!";
                        return false;
                    }
                    isStartDateNull = false;
                }
                if (qd.StartDate != null)
                {
                    if (((DateTime)qd.EndDate).Subtract(DateTime.Now) < TimeSpan.Zero)
                    {
                        message = "De eindtijd is al geweest!";
                        return false;
                    }
                    isEndDateNull = false;
                }
                if (!isEndDateNull && !isStartDateNull)
                {
                    if ((DateTime)qd.StartDate < (DateTime)qd.EndDate)
                    {
                        message = "De einddatum mag niet eerder zijn dan/gelijk zijn aan de startdatum!";
                        return false;
                    }
                }
            }
            message = "Vraag succesvol aangemaakt";
            return true;
        }
        /// <summary>
        /// check if the string is null or empty
        /// </summary>
        /// <param name="Content">parameter to check</param>
        /// <returns></returns>
        public static bool checkIfFilledIn(string Content)
        {
            return !string.IsNullOrEmpty(Content);
        }

        /// <summary>
        /// returns true if list of skills is 0
        /// </summary>
        /// <param name="Content">skills to count or other object to compare to zero</param>
        /// <returns></returns>
        public static bool checkSkillCountIsEmpty(int Content)
        {
            return Content == 0;
        }
    }
}
