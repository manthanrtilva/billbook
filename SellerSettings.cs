﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillBook
{
    public partial class SellerSettings : Form
    {
        public SellerSettings()
        {
            InitializeComponent();
            //System.Configuration.ConfigurationManager.AppSettings["keyname"];
            gstTextBox.Text = System.Configuration.ConfigurationManager.AppSettings["GSTNO"];
            panTextBox.Text = System.Configuration.ConfigurationManager.AppSettings["PANNO"];
            statecodeTextBox.Text = System.Configuration.ConfigurationManager.AppSettings["STATECODE"];
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
            appSettings.Settings.Remove("GSTNO");
            appSettings.Settings.Remove("PANNO");
            appSettings.Settings.Remove("STATECODE");
            appSettings.Settings.Add("GSTNO", gstTextBox.Text);
            appSettings.Settings.Add("PANNO", panTextBox.Text);
            appSettings.Settings.Add("STATECODE", statecodeTextBox.Text);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            Close();
        }
    }
}
