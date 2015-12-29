using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin_Layer;
using Class_Layer;
using Class_Layer.Utility_Classes;

namespace AdministrationParticipation
{
    static class Program
    {
        public static AdminGUIHandler AdminGUIHndlr;
        public static GUIHandler AccountHander;
        static string Credmatch = "ICT4Participation 1.0 Lars Blom, Koen Schilders, Lukas Derksen, Rowan Dings @ Fontys semester 2 maatwerk s21m";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Check arguments
            bool isValid = false;
            foreach (string s in args)
            {
                try
                {
                    isValid = PasswordHashing.ValidatePassword(s, Credmatch);
                    if (isValid)
                    {
                        break;
                    }
                }
                catch
                {
                    //Nothing really. It didn't match
                }
            }

            if (isValid)
            {
                AdminGUIHndlr = new AdminGUIHandler();
                AccountHander = new GUIHandler();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Run log in form
                if (Prompt.ShowDialog())
                {
                    Application.Run(new Home());
                }
            }
        }
    }
}
