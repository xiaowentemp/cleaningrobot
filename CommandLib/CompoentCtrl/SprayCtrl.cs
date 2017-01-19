using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using WIFIRobotCMDEngineV2;

namespace CommandLib
{
    public class SprayCtrl
    {
        static string
              CMD_XwSprayOpen = string.Empty,
         CMD_XwSprayClose = string.Empty,
         CMD_XwSprayTurbo = string.Empty,
         CMD_XwSprayDecelerate = string.Empty;
        public static void Init()
        {
            CMD_XwSprayOpen = Utilities.ReadIni("XwSprayOpen", "xwSprayOpen", "");
            CMD_XwSprayClose = Utilities.ReadIni("XwSprayClose", "xwSprayClose", "");
            CMD_XwSprayTurbo = Utilities.ReadIni("XwSprayTurbo", "xwSprayTurbo", "");
            CMD_XwSprayDecelerate = Utilities.ReadIni("XwSprayDecelerate", "xwSprayDecelerate", "");
        }

        public static void OnSprayDecelerateFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwSprayDecelerate,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnSprayTurbeFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwSprayTurbo,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnSprayFunc(object obj, bool isChecked, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
                if (isChecked)
                {
                    RobotEngine2.SendCMD(
                        controlType: ctrlType,
                        CMD_Custom: CMD_XwSprayOpen,
                        comm: comm);
                    Send_status = false;
                }
                else
                {
                    RobotEngine2.SendCMD(
                        controlType: ctrlType,
                        CMD_Custom: CMD_XwSprayClose,
                        comm: comm);
                    Send_status = false;
                }
        }
    }
}
