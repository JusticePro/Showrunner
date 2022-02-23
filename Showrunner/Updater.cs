﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Showrunner
{
    class Updater
    {
        private static string version = "1.0.2";
        private static int versionID = 2;
        
        private static string updateDetailURL = "";
        private static string downloadPage = "https://github.com/JusticePro/Showrunner/releases";

        /***
         * Get the name of this version.
         */
        public static string getVersionName()
        {
            return version;
        }

        public static int getVersionID()
        {
            return versionID;
        }

        /***
         * Check for an update. If there's an update, show a message box.
         */
        public static void checkForUpdate()
        {
            if (isUpdateAvailable())
            {
                DialogResult result = MessageBox.Show("You have an update available. Would you like to go to the download page for "
                    + getVersionName() + "?",
                    "Showrunner", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Process.Start(downloadPage);
                }
            }
        }

        private static bool isUpdateAvailable()
        {
            try
            {
                WebClient wc = new WebClient();

                string updateDetails = wc.DownloadString(updateDetailURL);
                string[] detailArray = updateDetails.Split('~');

                string vID = detailArray[1]; // versionName~versionID
                int id = int.Parse(vID);

                return id > versionID;
            }catch (Exception e)
            {
                return false;
            }
        }
    }
}
