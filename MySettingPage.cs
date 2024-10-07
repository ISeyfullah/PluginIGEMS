using CNC5Core;
using System.Diagnostics;
using HMIControls;

namespace PluginIGEMS
{

    public partial class MySettingPage : Form
    {
        public MySettingPage()
        {
            InitializeComponent();

            var mysw = new MySettingWrapper();
            propertyGrid1.SelectedObject = mysw;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("osk.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySettings.Save();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(MySettings.FileName))
            {
                var psi = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = MySettings.FileName,
                };
                Process.Start(psi);
            }
            else
            {
                Dialogs.Alert("My settings file does not exist.");
            }
        }
    }
}
