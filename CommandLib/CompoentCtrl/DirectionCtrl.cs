using System;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using WIFIRobotCMDEngineV2;

namespace CommandLib
{
    public class DirectionCtrl
    {
       static string CMD_Forward = "",
            CMD_Backward = "",
            CMD_TurnLeft = "",
            CMD_TurnRight = "",
            CMD_Stop = "",
            CMD_XwCarTurbo = string.Empty,
            CMD_XwCarDecelerate = string.Empty;

        public static void Init()
        {
            CMD_Forward = Utilities.ReadIni("Forward", "forward", "");
            CMD_Backward = Utilities.ReadIni("Backward", "backward", "");
            CMD_TurnLeft = Utilities.ReadIni("Left", "left", "");
            CMD_TurnRight = Utilities.ReadIni("Right", "right", "");
            CMD_Stop = Utilities.ReadIni("Stop", "stop", "");
            CMD_TurnRight = Utilities.ReadIni("XwCarTurbo", "xwCarTurbo", "");
            CMD_Stop = Utilities.ReadIni("XwCarDecelerate", "xwCarDecelerate", "");
        }

        /// <summary>
        /// forward 
        /// 往前走
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="RobotEngine2"></param>
        /// <param name="Send_status"></param>
        /// <param name="ctrlType"></param>
        /// <param name="cmd"></param>
        /// <param name="comm"></param>
        public static void OnUp(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(ctrlType, CMD_Forward, comm);
                Send_status = false;
            }
        }

        /// <summary>
        /// Backward 
        /// 往后走
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="RobotEngine2"></param>
        /// <param name="Send_status"></param>
        /// <param name="ctrlType"></param>
        /// <param name="cmd"></param>
        /// <param name="comm"></param>
        public static void OnDown(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(ctrlType, CMD_Backward, comm);
                Send_status = false;
            }
        }

        /// <summary>
        /// 往左走
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="RobotEngine2"></param>
        /// <param name="Send_status"></param>
        /// <param name="ctrlType"></param>
        /// <param name="cmd"></param>
        /// <param name="comm"></param>
        public static void OnLeft(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(ctrlType, CMD_TurnLeft, comm);
                Send_status = false;
            }
        }

        public static void OnStop(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            Send_status = true;
            RobotEngine2.SendCMD(ctrlType, CMD_Stop, comm);
        }

        /// <summary>
        /// 往右走
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="RobotEngine2"></param>
        /// <param name="Send_status"></param>
        /// <param name="ctrlType"></param>
        /// <param name="cmd"></param>
        /// <param name="comm"></param>
        public static void OnRight(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(ctrlType, CMD_TurnRight, comm);
                Send_status = false;
            }
        }

        public static void OnDecelerate(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwCarDecelerate,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnTurbe(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwCarTurbo,
                    comm: comm);
                Send_status = false;
            }
        }


    }
}
