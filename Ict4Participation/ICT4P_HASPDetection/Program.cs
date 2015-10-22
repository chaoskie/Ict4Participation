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

namespace ICT4P_HASPDetection
{
    class Program
    {
        static string Credmatch = "ICT4Participation 1.0 Lars Blom, Koen Schilders, Lukas Derksen, Rowan Dings @ Fontys semester 2 maatwerk s21m";
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = Win32Call.GetConsoleWindow();
            Win32Call.ShowWindow(handle, SW_HIDE);

            //INSERTION
            //Set up the query upon activation
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_LogicalDisk'");

            //Create a watcher to trigger
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertEvent);
            //Start the watcher
            insertWatcher.Start();

            System.Threading.Thread.Sleep(200000000);
        }

        
        static void DeviceInsertEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                if (property.Name == "Caption")
                {
                    if (verifiedUSBContent(property.Value.ToString()))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Ict4Participation.Inloggen(true));
                    }
                }
            }
        }

        static bool verifiedUSBContent(string DLetter)
        {
            string AuthCode = string.Empty;
            //If filename is present, stream said file
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
            }
            //Check if file matches credentials
            return Class_Layer.PasswordHashing.ValidatePassword(Credmatch, AuthCode);
        }

        public static void Writefile()
        {
            using (FileStream stream = new FileStream("Auth", FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Class_Layer.PasswordHashing.CreateHash(Credmatch));
                    writer.Close();
                }
            }
        }
    }
}
