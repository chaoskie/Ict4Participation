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
        static void Main(string[] args)
        {

        }

        #region USB handlers
        private void DeviceInsertEvent(object sender, EventArrivedEventArgs e)
        {
            //If the restart on plug in option is checked, check if right USB device is connected, then restart
            if (isExternalHardDiskConnected())
            {
                Console.WriteLine("External Hard Disk detected");
            }
        }
        #endregion

        #region USB detector
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //INSERTION
            //Set up the query upon activation
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PointingDevice'");

            //Create a watcher to trigger
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertEvent);
            //Start the watcher
            insertWatcher.Start();

            System.Threading.Thread.Sleep(200000000);
        }

        /// <summary>
        /// Checks for right device
        /// </summary>
        /// <param name="vendorid"></param>
        /// <returns></returns>
        public bool isExternalHardDiskConnected()
        {
            List<String> removableDisks = new List<string>();
            ManagementClass wmi = new ManagementClass("Win32_DiskDrive");
            var allDiskDrives = wmi.GetInstances();

            foreach (var disk in allDiskDrives)
            {
                if (!Convert.ToString(disk["MediaType"]).ToLower().Contains("fixed"))
                {
                    removableDisks.Add(Convert.ToString(disk["SerialNumber"]) + " " + Convert.ToString(disk["Description"]));
                }
            }
            if (removableDisks.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
