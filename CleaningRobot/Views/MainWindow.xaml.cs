using CommandLib;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CleaningRobot.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //public static WebCam webCam;
        //public static Image ImageVideo;
        public static CameraView.CameraWindow CameraWindow;
        public static System.Windows.Controls.Button VideoRecord;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //webCam = new WebCam();
            //webCam.InitializeWebCam(ref imgVideo);
            //ImageVideo = imgVideo;
            CameraWindow = cameraWindow;
            VideoRecord = videoRecord;
        }
    }
}
