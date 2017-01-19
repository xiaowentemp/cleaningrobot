using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using WIFIRobotCMDEngineV2;

namespace CommandLib
{
    public class WiperCtrl
    {
        static string
         CMD_XwWiperOpen = string.Empty,
         CMD_XwWiperClose = string.Empty,
         CMD_XwWiperTurbo = string.Empty,
         CMD_XwWiperDecelerate = string.Empty;
        public static void Init()
        {
            CMD_XwWiperOpen = Utilities.ReadIni("XwWiperOpen", "xwWiperOpen", "");
            CMD_XwWiperClose = Utilities.ReadIni("XwWiperClose", "xwWiperClose", "");
            CMD_XwWiperTurbo = Utilities.ReadIni("XwWiperTurbo", "xwWiperTurbo", "");
            CMD_XwWiperDecelerate = Utilities.ReadIni("XwWiperDecelerate", "xwWiperDecelerate", "");
        }

        public static void OnWiperDecelerateFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwWiperDecelerate,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnWiperTurbeFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwWiperTurbo,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnWiperFunc(object obj, bool isChecked, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
                if (isChecked)
                {
                    RobotEngine2.SendCMD(
                        controlType: ctrlType,
                        CMD_Custom: CMD_XwWiperOpen,
                        comm: comm);
                    Send_status = false;
                }
                else
                {
                    RobotEngine2.SendCMD(
                        controlType: ctrlType,
                        CMD_Custom: CMD_XwWiperClose,
                        comm: comm);
                    Send_status = false;
                }
        }
    }
}
