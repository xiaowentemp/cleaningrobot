using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using WIFIRobotCMDEngineV2;

namespace CommandLib
{
    public class FanCtrl
    {
        static string
         CMD_XwFanOpen = string.Empty,
         CMD_XwFanClose = string.Empty,
         CMD_XwFanTurbo = string.Empty,
         CMD_XwFanDecelerate = string.Empty;
        public static void Init()
        {
            CMD_XwFanOpen = Utilities.ReadIni("XwFanOpen", "xwFanOpen", "");
            CMD_XwFanClose = Utilities.ReadIni("XwFanClose", "xwFanClose", "");
            CMD_XwFanTurbo = Utilities.ReadIni("XwFanTurbo", "xwFanTurbo", "");
            CMD_XwFanDecelerate = Utilities.ReadIni("XwFanDecelerate", "xwFanDecelerate", "");
        }

        public static void OnFanDecelerateFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwFanDecelerate,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnFanTurboFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwFanDecelerate,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnFanFunc(object obj, bool isChecked, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
                if (isChecked)
                {
                    RobotEngine2.SendCMD(
                        controlType: ctrlType,
                        CMD_Custom: CMD_XwFanOpen,
                        comm: comm);
                }
                else
                {
                    RobotEngine2.SendCMD(
                        controlType: ctrlType,
                        CMD_Custom: CMD_XwFanOpen,
                        comm: comm);
                }
        }
    }
}
