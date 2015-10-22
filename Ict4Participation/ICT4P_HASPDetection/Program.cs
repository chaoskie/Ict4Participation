using System;
using System.ServiceProcess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using System.Diagnostics;

namespace ICT4P_HASPDetection
{
    class Program
    {
        static string LastDriverConnected;

        static void Main(string[] args)
        {
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

        #region USB handlers
        static void DeviceInsertEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                if (property.Name == "Caption")
                {
                    LastDriverConnected = property.Value.ToString();
                    
                }
            }
        }
        #endregion
    }
}
