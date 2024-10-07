using HMI5;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace PluginIGEMS
{
    internal class MySettingWrapper
    {
        [Category("IndicatorTower")]
        [Description("Enable Indicator Tower")]
        [DefaultValue(false)]
        public bool IndicatorTowerEnable
        {
            get => MySettings.IndicatorTowerEnable;
            set => MySettings.IndicatorTowerEnable = value;
        }

        [Category("IndicatorTower")]
        [Description("Digital output pin for Red Indicator Bulb")]
        [Editor(typeof(HMI5.DigitalOutPinEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        public int IndicatorRedBulb
        {
            get => MySettings.IndicatorRedBulb;
            set => MySettings.IndicatorRedBulb = value;
        }

        [Category("IndicatorTower")]
        [Description("Digital output pin for Green Indicator Bulb")]
        [Editor(typeof(HMI5.DigitalOutPinEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        public int IndicatorGreenBulb
        {
            get => MySettings.IndicatorGreenBulb;
            set => MySettings.IndicatorGreenBulb = value;
        }

        [Category("IndicatorTower")]
        [Description("Digital output pin for Yellow Indicator Bulb")]
        [Editor(typeof(HMI5.DigitalOutPinEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        public int IndicatorYellowBulb
        {
            get => MySettings.IndicatorYellowBulb;
            set => MySettings.IndicatorYellowBulb = value;
        }

        [Category("Drill Unit")]
        [Description("Enable Drill Unit")]
        [DefaultValue(false)]
        public bool DrillEnable
        {
            get => MySettings.DrillEnable;
            set => MySettings.DrillEnable = value;
        }

        [Category("Drill Unit")]
        [Description("Digital output pin for Drill Down")]
        [Editor(typeof(HMI5.DigitalOutPinEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        public int DrillDownPin
        {
            get => MySettings.DrillDownPin;
            set => MySettings.DrillDownPin = value;
        }

        [Category("Drill Unit")]
        [Description("Digital output pin for Drill Up")]
        [Editor(typeof(HMI5.DigitalOutPinEditor), typeof(UITypeEditor))]
        [DefaultValue(-1)]
        public int DrillUpPin
        {
            get => MySettings.DrillUpPin;
            set => MySettings.DrillUpPin = value;
        }

        [Category("General")]
        [Description("Define Your Logo Path")]
        [Editor(typeof(ImageBrowser), typeof(UITypeEditor))]
        public string MyLogoPath
        {
            get => MySettings.MyLogoPath;
            set => MySettings.MyLogoPath = value;
        }

        [Category("General")]
        [Description("Define Your Lightning Pin")]
        [Editor(typeof(DigitalOutPinEditor), typeof(UITypeEditor))]
        public int LightningPin
        {
            get => MySettings.LightningPin;
            set => MySettings.LightningPin = value;
        }
    }

    public class ImageBrowser : FileNameEditor
    {
        protected override void InitializeDialog(OpenFileDialog openFileDialog)
        {
            base.InitializeDialog(openFileDialog);
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog.Multiselect = false;
            openFileDialog.InitialDirectory = CNC5Core.Machine.ConfigDirectory;
        }
    }
}
