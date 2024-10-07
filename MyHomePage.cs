using HMIAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginIGEMS
{
    public partial class MyHomePage : Form
    {
        public MyHomePage()
        {
            InitializeComponent();
            
            if (File.Exists(MySettings.MyLogoPath))
                pictureBox1.Image = Bitmap.FromFile(MySettings.MyLogoPath);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (MySettingPage pg_sttng = new MySettingPage())
            {
                pg_sttng.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
