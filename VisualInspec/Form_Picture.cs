using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows. Windows.Media.Imaging;

//for camera
using System.Media; // Windows.Media.Capture;


// Important: include the opencvsharp library in your code
using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace VisualInspec
{
 
    public partial class Form_Picture : Form
    {
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Mat frameRaw;    //raw full resolution from camera
        Bitmap image;
        Bitmap imageRaw; //raw image from the camera
        private Thread camera;
        bool isCameraRunning = false;
        bool isCameraPaused = false;
        int[] imgHor = { 640, 1280, 1280 };  //1=all  2=HP max  3=Laptop max
        int[] imgVert = { 480, 960, 720 };   //1=all  2=HP max  3=Laptop max
        const int CamNum = 2;
        const int CV_CAP_PROP_FRAME_WIDTH = 3;
        const int CV_CAP_PROP_FRAME_HEIGHT = 4;

        ConfigDataType ConfigData;


        //
        private ConfigDataType ConfigData_Init()
        {
            //setup a new config data
            ConfigDataType outputRec = new ConfigDataType();
            outputRec.CameraToUse = 0;
            outputRec.isMsgBoxPopUp = true;

            return outputRec;
        }


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            Console.WriteLine("vert=" + imgVert[CamNum]);
            frame = new Mat(imgVert[CamNum], imgHor[CamNum], 0 );  //type 2=16bit unsigned
            frameRaw = new Mat(imgVert[CamNum], imgHor[CamNum], 0);  //type 2=16bit unsigned
            capture = new VideoCapture(0);
            capture.Open(0);
            capture.Set(CV_CAP_PROP_FRAME_HEIGHT, imgVert[CamNum]);
            capture.Set(CV_CAP_PROP_FRAME_WIDTH, imgHor[CamNum]);

            if (capture.IsOpened())
            {
                while (isCameraRunning && !isCameraPaused)
                {
                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    //image = BitM
                    if (pictureBoxScreen.Image != null)
                    {
                        pictureBoxScreen.Image.Dispose();
                    };
                    pictureBoxScreen.Image = image;  //don't need to rescale, picture box does it

                    //raw image to save to disk
                    //capture.Read(frame);
                    imageRaw = BitmapConverter.ToBitmap(frame);
                    if (pictureBoxRaw.Image != null)
                    {
                        pictureBoxRaw.Image.Dispose();
                    }
                    pictureBoxRaw.Image = imageRaw;
                }
            }
        }

        public Form_Picture()
        {
            InitializeComponent();
        }


        public void CameraStop()
        {
            isCameraRunning = false;
            if (capture != null)
            {
                capture.Release();
            };
            bttnStart.Text = "Start";
            isCameraRunning = false;
        }


        public void CameraStart()
        {
            CaptureCamera();
            bttnStart.Text = "Stop";
            isCameraRunning = true;
            isCameraPaused = false;
        }


        public void CameraPause()
        {
            isCameraPaused = true;
            bttnStart.Text = "Paused";
        }


        public void CameraUnPause()
        {
            isCameraPaused = false;
            bttnStart.Text = "Stop";
        }


        private void bttnStart_Click(object sender, EventArgs e)
        {
            if (bttnStart.Text.Equals("Start"))
            {
                CameraStart();
            }
            else
            {
                CameraStop();
            }
        }

        private void Shutdown()
        {
            //shutdown everything
            CameraStop();
            Application.DoEvents();
            pictureBoxScreen.Image.Dispose();
            Application.DoEvents();
            Application.Exit();
        }


        private void bttnSave_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                // Take snapshot of the current image generate by OpenCV in the Picture Box
                CameraPause();
                Bitmap snapshot = new Bitmap(pictureBoxRaw.Image);

                // Save in some directory
                // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                

                snapshot.Save(string.Format(@"C:\Data\Junk\{0}.png", Guid.NewGuid()), ImageFormat.Png);
                Application.DoEvents();
                if (ConfigData.isMsgBoxPopUp)
                {
                    MessageBox.Show("Save successful");
                };
                Application.DoEvents();
                CameraUnPause();
                Application.DoEvents();
                CameraStop();
                Application.DoEvents();
                CameraStart();
            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
        }

        private void Form_Picture_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shutdown();
            Application.DoEvents();
        }

        private void Form_Picture_Load(object sender, EventArgs e)
        {
            ConfigData = ConfigData_Init();
        }
    }

    public class ConfigDataType
    {
        public bool isMsgBoxPopUp { get; set; } //should msg box would pop 
        public int CameraToUse { get; set; }    //which camera, on table 0=back
    }

}
