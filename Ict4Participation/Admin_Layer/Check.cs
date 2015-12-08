using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Admin_Layer
{
    public abstract class Check
    {
        /// <summary>
        /// Checks if the phonenumber is one of the following:
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
            return Regex.IsMatch(s, "[a-zA-Z0-9]{6,}");
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
            //TODO
            //Check if valid email
            return true;
        }

        public static bool isLocation(string city, string address)
        {
            //TODO
            //Check if valid address
            return true;
        }
    }
}
