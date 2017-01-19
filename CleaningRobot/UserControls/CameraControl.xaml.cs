﻿using CommandLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CleaningRobot.UserControls
{
    /// <summary>
    /// Interaction logic for CameraControl.xaml
    /// </summary>
    public partial class CameraControl : UserControl
    {
        public static WebCam webCam;
        public static Image ImageVideo;

        public CameraControl()
        {
            InitializeComponent();

            webCam = new WebCam();
            webCam.InitializeWebCam(ref imgVideo);
            ImageVideo = imgVideo;
        }
    }
}
