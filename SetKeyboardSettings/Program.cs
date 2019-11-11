using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SetKeyboardSettings
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        const int SPI_SETKEYBOARDSPEED = 0x000B;
        const int SPI_SETKEYBOARDDELAY = 0x0017;

        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 2)
                {
                    uint number = Convert.ToUInt32(args[1]);
                    switch (args[0].ToLowerInvariant())
                    {
                        case "-speed":
                            SystemParametersInfo(SPI_SETKEYBOARDSPEED, number, 0, 0);
                            break;
                        case "-delay":
                            SystemParametersInfo(SPI_SETKEYBOARDDELAY, number, 0, 0);
                            break;
                    }
                    Environment.Exit(0);
                }
            }
            catch { }
            PrintHelpAndExit();
        }

        static void PrintHelpAndExit()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Program to change keyboard repeat delay and rate");
            str.AppendLine();
            str.AppendLine("  -speed [0-31]          - changes the repeat rate from slow (0) to fast (31)");
            str.AppendLine("  -delay [0-3]           - changes the delay from slow (3) to fast (0)");
            Console.Write(str.ToString());
            Environment.Exit(0);
        }
    }
}
