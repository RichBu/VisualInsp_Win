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
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;


        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }

        public Form_Picture()
        {
            InitializeComponent();
        }

        private void bttnStart_Click(object sender, EventArgs e)
        {
            if (bttnStart.Text.Equals("Start"))
            {
                CaptureCamera();
                bttnStart.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                if (capture!=null)
                {
                    capture.Release();
                };
                bttnStart.Text = "Start";
                isCameraRunning = false;
            }
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                // Take snapshot of the current image generate by OpenCV in the Picture Box
                Bitmap snapshot = new Bitmap(pictureBox1.Image);

                // Save in some directory
                // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                snapshot.Save(string.Format(@"C:\Data\Junk\{0}.png", Guid.NewGuid()), ImageFormat.Png);
            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
        }

    }
}
