namespace PluginIGEMS
{
    internal class Shields
    {
        public static int prefferedShieldStateBits = 0;
        internal Shields()
        {
        }

        public static void SetPrefferedShieldStateWithBits(int state)
        {
            int oldbits = prefferedShieldStateBits;
            prefferedShieldStateBits = state;

            if ((oldbits & 1) != (state & 1))
                ToggleShields(0, (state & 1) != 0);

            if ((oldbits & 2) != (state & 2))
                ToggleShields(1, (state & 2) != 0);
                
        }

        private static void ToggleShields(int shieldno, bool go_up)
        {
            if (shieldno == 0)
            {
                if (go_up)
                {
                    //Front Sheild Up Actions
                    MyPlugin.Machine.SetMessage("Front Shield Up");
                }
                else
                {
                    //Front Shield Down Actions
                    MyPlugin.Machine.SetMessage("Front Shield Down");
                }
            }
            else if (shieldno == 1)
            {
                if (go_up)
                {
                    //Back Shield Up Actions
                    MyPlugin.Machine.SetMessage("Back Shield Up");
                }
                else
                {
                    //Back Shield Down Actions
                    MyPlugin.Machine.SetMessage("Back Shield Down");
                }
            }
        }
    }
}
