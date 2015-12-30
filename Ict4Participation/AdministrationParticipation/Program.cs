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
        public static Home home;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            args = new string[1] 
            {
                PasswordHashing.CreateHash(Credmatch)            
            };

            //Check arguments
            bool isValid = false;
            foreach (string s in args)
            {
                try
                {
                    isValid = PasswordHashing.ValidatePassword(Credmatch, s);
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
                AdminGUIHndlr.GetAll();
                AccountHander.GetAll();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Run log in form
                if (Prompt.ShowDialog())
                {
                    home = new Home();
                    Application.Run(home);
                }
            }
        }
    }
}
