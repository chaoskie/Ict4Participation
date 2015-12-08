using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Management;
using System.Security;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_Layer.Utility_Classes;

namespace ICT4P_HASPDetection
{
    class Program
    {
        /// <summary>
        /// Authentication code in file to match with
        /// </summary>
        static string Credmatch = "ICT4Participation 1.0 Lars Blom, Koen Schilders, Lukas Derksen, Rowan Dings @ Fontys semester 2 maatwerk s21m";

        /// <summary>
        /// Hide and show parameters, DO NOT TOUCH
        /// </summary>
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static BackgroundWorker BGW = new BackgroundWorker();

        static void Main(string[] args)
        {
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerAsync();


            //Sleep for a long time so the app doesn't close until then
            System.Threading.Thread.Sleep(2000000000);
        }

        static private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //Hide the console screen and let it work in the background
            var handle = Win32Call.GetConsoleWindow();
            Win32Call.ShowWindow(handle, SW_HIDE);

            //Check for USB insertion
            //Set up the query upon activation
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_LogicalDisk'");

            //Create a watcher to trigger
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertEvent);
            //Start the watcher
            insertWatcher.Start();

            //Do something while waiting for events
            System.Threading.Thread.Sleep(2000000000);
        }

        /// <summary>
        /// Method to trigger upon watcher call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void DeviceInsertEvent(object sender, EventArrivedEventArgs e)
        {
            //Create instance of inserted object
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            //Browse through properties of inserted object and find the drive letter
            foreach (var property in instance.Properties)
            {
                if (property.Name == "Caption")
                {
                    //Verify that plugged in USB has the correct authentication file
                    if (verifiedUSBContent(property.Value.ToString()))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Ict4Participation.Inloggen(true));
                        Environment.Exit(0);
                    }
                }
            }
        }

        static bool verifiedUSBContent(string DLetter)
        {
            string AuthCode = string.Empty;
            //If filename is present, read said file
            try
            {
                using (FileStream stream = new FileStream(String.Format("{0}\\Auth", DLetter), FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        AuthCode = reader.ReadString();
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            //Check if file matches credentials
            return PasswordHashing.ValidatePassword(Credmatch, AuthCode);
        }

        //Code to generate a new authentication file
        public static void Writefile()
        {
            using (FileStream stream = new FileStream("Auth", FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(PasswordHashing.CreateHash(Credmatch));
                    writer.Close();
                }
            }
        }
    }
}
