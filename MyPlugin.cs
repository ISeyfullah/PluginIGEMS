using CNC5Core;
using HMIAPI;
using HMIControls;

namespace PluginIGEMS
{
    public class MyPlugin : CNCPlugin
    {
        internal static Machine? Machine;
        internal IndicatorTower indicatorTower;
        internal Drill drill;
        

        public MyPlugin() { }


        public override void SystemStarted(Machine machine)
        {
            //Define Our Machine
            Machine = machine;

            //Set Messages When System Started
            Machine.SetMessage("My IGEMS CNC");

            //Load All My Settings
            MySettings.Load();

            if (MySettings.IndicatorTowerEnable)
                indicatorTower = new IndicatorTower(Machine);

            if (MySettings.DrillEnable)
                drill = new Drill(Machine);

            //Susbcripe for Custom Action Button in Integrator Settings
            HMIEvents.IntegratorSettingsCustomAction_Click += IntegratorSettingsCustomAction;

            //Subscribe for Building GUI Even
            HMIEvents.BuildingGUI += HMIEvents_BuildingGUI;
        }

        private void IntegratorSettingsCustomAction(object? sender, EventArgs e)
        {
            //Show your Page
            using (MyHomePage form = new MyHomePage())
            {
                form.ShowDialog();
            }
        }

        private void HMIEvents_BuildingGUI(object? sender, EventArgs e)
        {
            //Register new custom button
            HMIToggleButton myButton = Funcs.RegisterToggleButton("lighton", "Turn On Light",MyButtonClicked);
        }

        private void MyButtonClicked(Machine machine, bool on)
        {
            //Toggle lightning output defined in settings and write message on the top
            if (on)
            {
                machine.SetMessage("Lamp On");
                machine.DOWrite(MySettings.LightningPin, true);
            }
            else
            {
                machine.SetMessage("Lamp Off");
                machine.DOWrite(MySettings.LightningPin, false);
            }
        }

        //State includes 2 bit integer. (0 0)
        //First bit determinate Front Shield status (1 > Up / 0 > Down)
        //Second bit determinate Back Shield status (1 > Up / 0 > Down)
        //We can read states with "ShieldStateChange" and after action we have to set state with "ShieldStateGet" for shields buttons indicator on MainForm.
        public override void ShieldStateChange(int state)
        {
            Shields.SetPrefferedShieldStateWithBits(state);
        }

        public override int ShieldStateGet()
        {
            return Shields.prefferedShieldStateBits;
        }
    }
}
