
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using WIFIRobotCMDEngineV2;

namespace CommandLib
{
    /// <summary>
    /// 摄像头操作
    /// </summary>
    public class CameraCtrl
    {
        static string
             CMD_XwCameraLeft = string.Empty,
             CMD_XwCameraRight = string.Empty;

        public static void Init()
        {
            CMD_XwCameraLeft = Utilities.ReadIni("XwCameraLeft", "xwCameraLeft", "");
            CMD_XwCameraRight = Utilities.ReadIni("XwCameraRight", "xwCameraRight", "");
        }

        public static void OnOpsCamera(object obj, bool isChecked, WebCam webCan)
        {
            if (isChecked)
                Open(webCan);
            else
                Stop(webCan);
        }

        static string CameraIp = "";
        static void Open(WebCam webCan)
        {
            webCan.Start();
        }

        static void Stop(WebCam webCan)
        {
            webCan.Stop();
        }

        public static void OnCameraRightFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            if (Send_status)
            {
                RobotEngine2.SendCMD(
                    controlType: ctrlType,
                    CMD_Custom: CMD_XwCameraRight,
                    comm: comm);
                Send_status = false;
            }
        }

        public static void OnCameraLeftFunc(object obj, WifiRobotCMDEngineV2 RobotEngine2, ref bool Send_status, int ctrlType, SerialPort comm)
        {
            RobotEngine2.SendCMD(
                controlType: ctrlType,
                CMD_Custom: CMD_XwCameraLeft,
                comm: comm);
        }

        //public static void OnScreenshot(object obj, Image ImageVideo, ref bool isSaved)
        //{
        //    string str = ImageVideo.Source.ToString();
        //    Image im = new Image();
        //    im.Source = ImageVideo.Source;
        //    if (ImageVideo.Source != null)
        //    {
        //        isSaved = true;
        //    }
        //}

        //public static void OnVideotape(object obj)
        //{
        //    MessageBox.Show("OnVideotape");
        //}

    }
}
