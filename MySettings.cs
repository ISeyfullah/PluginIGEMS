using CNC5Core;
using HMIControls;

namespace PluginIGEMS
{
    internal class MySettings
    {
        //Indicator Light 
        internal static bool IndicatorTowerEnable = false;
        internal static int IndicatorRedBulb = -1;
        internal static int IndicatorGreenBulb = -1;
        internal static int IndicatorYellowBulb = -1;

        //My Logo Path
        internal static string MyLogoPath = "";

        //My Lightning Output
        internal static int LightningPin = -1;


        //My Drill Settings
        internal static bool DrillEnable = false;
        internal static int DrillDownPin = -1;
        internal static int DrillUpPin  = -1;

        public static string FileName
        {
            //Get setting file path
            get => Path.Combine(Machine.ConfigDirectory, "mysettings.ini");
        }

        public static void Load()
        {
            //Check if file exist, if not create default
            if (!File.Exists(FileName))
            {
                Dialogs.Alert("No Settings file found. Created a default one.");
                Save();
            }

            //Read Settings
            using (new IniBackup(FileName, out var ini))
            {
                string section = "IndicatorLight";
                IndicatorTowerEnable = ini.ReadBool(section, "IndicatorTowerEnable", false); 
                IndicatorRedBulb = ini.ReadInt(section, "IndicatorRedBulb", -1);
                IndicatorGreenBulb = ini.ReadInt(section, "IndicatorGreenBulb", -1);
                IndicatorYellowBulb = ini.ReadInt(section, "IndicatorYellowBulb", -1);

                section = "general";
                MyLogoPath = ini.ReadString(section, "MyLogo","");
                LightningPin = ini.ReadInt(section, "LightningPin", -1);

                section = "drill";
                DrillEnable = ini.ReadBool(section, "DrillEnable", false);
                DrillDownPin = ini.ReadInt(section, "DrillDownPin", -1);
                DrillUpPin = ini.ReadInt(section, "DrillUpPin", -1);
            }
        }

        public static void Save() 
        {
            //Write Settings
            using (new IniBackup(FileName, out var ini)) 
            {
                string section = "IndicatorLight";
                ini.Write(section, "IndicatorTowerEnable", IndicatorTowerEnable);
                ini.Write(section, "IndicatorRedBulb", IndicatorRedBulb);
                ini.Write(section, "IndicatorGreenBulb", IndicatorGreenBulb);
                ini.Write(section, "IndicatorYellowBulb", IndicatorYellowBulb);

                section = "general";
                ini.Write(section, "MyLogo", MyLogoPath);
                ini.Write(section, "LightningPin", LightningPin);

                section = "drill";
                ini.Write(section, "DrillEnable", DrillEnable);
                ini.Write(section, "DrillUpPin", DrillUpPin);
                ini.Write(section, "DrillDownPin" , DrillDownPin);
            }
        }
    }
}
