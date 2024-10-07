using CNC5Core;
using HMI5;
using HMIAPI;

namespace PluginIGEMS
{
    internal class IndicatorTower
    {
        bool closing;
        Machine? machine;

        internal IndicatorTower(Machine machine) 
        {
            //Check if there is setting defined or not 
            if (MySettings.IndicatorRedBulb < 0 && MySettings.IndicatorGreenBulb < 0 && MySettings.IndicatorYellowBulb < 0)
                return;

            this.machine = machine;

            //Light Test to Control Hardware
            LightTest();

            //Subscribe Slow Timer Event
            HMIEvents.SlowTimerTick += HMIEvents_SlowTimerTick;

            //Subscribe System Closing Event to Turn Off Light when HMI Closed
            HMIEvents.SystemClosing += HMIEvents_SystemClosing;
        }

        private void HMIEvents_SystemClosing(object? sender, EventArgs e)
        {
            //Set closing true to not coincide with SlowTimer
            closing = true;

            //Close all bulbs
            SetColor(LedColors.Off);
        }

        private void LightTest()
        {
            //Set the color off to turn off all lights
            SetColor(LedColors.Off);

            //Turn On all the lights then close again
            machine.DOWrite(MySettings.IndicatorRedBulb, true);
            Thread.Sleep(200);
            machine.DOWrite(MySettings.IndicatorGreenBulb, true);
            Thread.Sleep(200);
            machine.DOWrite(MySettings.IndicatorYellowBulb, true);
            Thread.Sleep(200);
            SetColor(LedColors.Off);
        }

        private void SetColor(LedColors color)
        {
            //Set Defined Color
            machine.DOWrite(MySettings.IndicatorRedBulb, color.HasFlag(LedColors.Red));
            machine.DOWrite(MySettings.IndicatorGreenBulb, color.HasFlag(LedColors.Green));
            machine.DOWrite(MySettings.IndicatorYellowBulb, color.HasFlag(LedColors.Yellow));
        }

        private void HMIEvents_SlowTimerTick(object? sender, EventArgs e)
        {
            //Check Defined Case and Set your Color
            DecideColor();
        }

        private void DecideColor()
        {
            bool error_progstop = false;
            bool error_warning = false;

            if (closing)
                return;

            LedColors color = LedColors.Off;

            //Check Alarms
            if (ErrorManager.ActiveErrorCount > 0) //There is active errors
            {
                if (ErrorManager.MostSevereError.ErrorLevel != CNCExceptionLevel.Level5Warning) //Error level not equal warning so program stopped 
                {
                    error_progstop = true;
                }
                else
                {
                    error_warning = true;
                }
            }

            //Set Color Depend of Conditions
            if (!Funcs.EmergencyOK || error_progstop) //Emergency Stop active or Program Stopped Couse of one Error
            {
                color = LedColors.Red;
            }
            else if (machine.RunState == RunState.Running) //Machine Running
            {
                if (machine.HaltState == HaltState.Paused) //Machine Paused
                {
                    if (error_warning) //Paused and Has Warning
                    {
                        color |= LedColors.Red_Yellow;
                    }
                    else //Paused and no Warning
                    {
                        color |= LedColors.Green_Yellow;
                    } 
                }
                else if (error_warning) //Program still running but there is a warning
                {
                    color |= LedColors.Red_Yellow;
                }
                else
                {
                    color |= LedColors.Yellow;
                }
            }
            else if (machine.RunState != RunState.Running && error_warning) //No running program but have a warning
            {
                color |= LedColors.Red_Green;
            }
            else //Ready to Run
            {
                color |= LedColors.Green;
            }

            SetColor(color);  
        }

        enum LedColors
        {
            Off = 0,
            Red = 1,
            Green = 2,
            Red_Green = 3,
            Yellow = 4,
            Red_Yellow = 5,
            Green_Yellow = 6,
        }
    }
}
