using CNC5Core;

namespace PluginIGEMS
{
    internal class Drill
    {
        Machine? Machine;
        bool drillWasActiveAtPause;
        bool drillActive;

        internal Drill(Machine? machine)
        {
            this.Machine = machine;

            //Subscribe for Drill Events
            CNCEvents.DrillEnable += CNCEvents_DrillEnable;
            CNCEvents.DrillDisable += CNCEvents_DrillDisable;

            //Subscribe for HMI Pause and Resume Events
            CNCEvents.ProgramRunPaused += CNCEvents_ProgramRunPaused;
            CNCEvents.ProgramRunResumed += CNCEvents_ProgramRunResumed;


        }

        private void CNCEvents_ProgramRunResumed(object? sender, ProgramRunStartedEventArgs e)
        {
            //Send drill down if drill was active before pause
            if (drillWasActiveAtPause)
            {
                drillWasActiveAtPause = false;
                ChangeDrillState(true);
            }
        }

        private void CNCEvents_ProgramRunPaused(object? sender, EventArgs e)
        {
            //Send drill up of program paused while drilling
            if (drillActive)
            {
                drillWasActiveAtPause = drillActive;
                ChangeDrillState(false);
            }
        }

        private void CNCEvents_DrillDisable(object? sender, EventArgs e)
        {
            //Send the drill up
            ChangeDrillState(false);
        }

        private void CNCEvents_DrillEnable(object? sender, EventArgs e)
        {
            //Send the drill down
            ChangeDrillState(true);
        }

        private void ChangeDrillState(bool state)
        {
            //Set Drill Up/Down outputs depend of state
            drillActive = state;
            Machine.DOWrite(MySettings.DrillDownPin, state);
            Machine.DOWrite(MySettings.DrillUpPin, !state);
        }
    }
}
