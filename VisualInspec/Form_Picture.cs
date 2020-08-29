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
using System.Text.RegularExpressions;

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
        int CamNumRes;  //for resolution
        const int CV_CAP_PROP_FRAME_WIDTH = 3;
        const int CV_CAP_PROP_FRAME_HEIGHT = 4;
        const int CV_CAP_FPS = 5;
        const int CV_CAP_EXPOSURE = 15;

        ConfigDataType ConfigData;
        List<PicSetDescripType> PicSetDescrip_table;
        JobType CurrJob;

        int CameraSkipFrame = 5;
        int CameraFrameNum = 5;

        //
        public ConfigDataType ConfigData_Init()
        {
            //setup a new config data
            ConfigDataType outputRec = new ConfigDataType();
            outputRec.CameraToUse = 0;
            outputRec.isMsgBoxPopUp = true;
            outputRec.SavePath = "C:\\Data\\Pics";
            outputRec.CamNumRes = 1;
            outputRec.CamFPS = (double)20.0;

            return outputRec;
        }


        public List<PicSetDescripType> PicSetDescrip_Init()
        {
            List<PicSetDescripType> outRecs = new List<PicSetDescripType>();

            PicSetDescripType outRec = new PicSetDescripType();
            outRec.PicTypeCode = 10;
            outRec.Description = "Front Side";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 11;
            outRec.Description = "Right Side";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 12;
            outRec.Description = "Back Side";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 13;
            outRec.Description = "Left Side";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 14;
            outRec.Description = "Gap - Front";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 15;
            outRec.Description = "Top View of Bushings";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 16;
            outRec.Description = "Bottom View of Bushings";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 17;
            outRec.Description = "Core (top) - all cavities";
            outRecs.Add(outRec);

            outRec = new PicSetDescripType();
            outRec.PicTypeCode = 18;
            outRec.Description = "Cavity (bottom) - all cavities";
            outRecs.Add(outRec);

            return outRecs;
        }


        public JobType Job_Init()
        {
            JobType output = new JobType();

            output.JobNumStr = "MP20942";
            output.SerialChar = "S";
            output.SerialStart = 471;
            output.SerialEnd = 488;
            output.SerialCurr = output.SerialStart;
            output.SerialNumDigits = 3;
            output.SerialCurr = output.SerialStart;
            output.PictSet = 1;
            output.PictCurrNum = 0;
            return output;
        }


        //string functions missing from Visual C
        public string LeftStr(string _strIn, int _length)
        {
            int iStart = 0;
            //string result = _strIn.Substring( iStart, _length);
            return _strIn.Substring(iStart, _length);
        }


        public string RightStr(string _strIn, int _length)
        {
            int iStart = _strIn.Length - _length;
            //string result = _strIn.Substring( iStart, _length);
            return _strIn.Substring(iStart, _length);
        }


        public string PadZeroesStr(int _NumIn, int _NumZeroes)
        {
            string NumZeroStr = _NumZeroes.ToString().Trim();
            string FormatStr = "D" + NumZeroStr;

            string OutStr = _NumIn.ToString(FormatStr).Trim();
            return OutStr;
        }


        public string CreateFullSerialNumString( string _Prefix, int _SerialNum, int _NumDig)
        {
            string outString;
            string SerialNumStr = PadZeroesStr(_SerialNum, _NumDig);
            outString = _Prefix.ToUpper().Trim() + SerialNumStr;
            return outString;
        }


        public void JobScreenRefresh()
        {
            //send job data to screen
            tbJobNumStr.Text = CurrJob.JobNumStr;
            tbSerialChar.Text = CurrJob.SerialChar;
            tbSerialStart.Text = CurrJob.SerialStart.ToString();
            tbSerialEnd.Text = CurrJob.SerialEnd.ToString();
            tbSerialCurr.Text = CurrJob.SerialCurr.ToString();
            tbPictCurrNum.Text = CurrJob.PictCurrNum.ToString();
            tbOutputPath.Text = ConfigData.SavePath;
            cbCameraRes.SelectedIndex = ConfigData.CamNumRes;
            tbCameraFPS.Text = ConfigData.CamFPS.ToString().Trim();
        }


        public void JobScreenSave()
        {
            //save job screen data to variables
            CurrJob.JobNumStr = tbJobNumStr.Text ;
            CurrJob.SerialChar = tbSerialChar.Text;
            CurrJob.SerialStart = int.Parse(tbSerialStart.Text);
            CurrJob.SerialEnd = int.Parse(tbSerialEnd.Text);
            CurrJob.SerialCurr = int.Parse(tbSerialCurr.Text);
            CurrJob.PictCurrNum = int.Parse(tbPictCurrNum.Text);
            ConfigData.CamNumRes = cbCameraRes.SelectedIndex;
            ConfigData.CamFPS = double.Parse(tbCameraFPS.Text.Trim());
            //tbOutputPath.Text = ConfigData.SavePath;

            //now check to see if the start or end values affected the current serial number
            if (CurrJob.SerialStart > CurrJob.SerialEnd)
            {
                int TempInt = CurrJob.SerialEnd;
                CurrJob.SerialEnd = CurrJob.SerialStart;
                CurrJob.SerialStart = TempInt;
                CurrJob.PictCurrNum = 0;
            };

            if (CurrJob.SerialCurr < CurrJob.SerialStart)
            {
                CurrJob.SerialCurr = CurrJob.SerialStart;
                CurrJob.PictCurrNum = 0;
            };

            if (CurrJob.SerialCurr > CurrJob.SerialEnd)
            {
                CurrJob.SerialCurr = CurrJob.SerialEnd;
                CurrJob.PictCurrNum = 0;
            };

            JobScreenRefresh();
            ScreenRefresh(false);
        }


        public void ScreenRefresh( bool _IsIncNext)
        {
            if (_IsIncNext)
            {
                //increment pic number first
                CurrJob.PictCurrNum = CurrJob.PictCurrNum + 1;
                if (CurrJob.PictCurrNum >= PicSetDescrip_table.Count())
                {
                    //new plate or end of job
                    CurrJob.SerialCurr = CurrJob.SerialCurr + 1;
                    if (CurrJob.SerialCurr > CurrJob.SerialEnd)
                    {
                        MessageBox.Show("\nNo More Plates\n");
                        CurrJob.PictCurrNum = 0;
                        bttnSave.Enabled = false;
                    }
                    else
                    {
                        string MessageString = "\n******  Next Plate ********\nSerial #" + CreateFullSerialNumString(CurrJob.SerialChar, CurrJob.SerialCurr, CurrJob.SerialNumDigits);
                        MessageBox.Show(MessageString);
                        CurrJob.PictCurrNum = 0;
                    };
                };
            } else
            {
                //not incrementing just update
            };
            lbCurrSerialNum.Text = CreateFullSerialNumString(CurrJob.SerialChar, CurrJob.SerialCurr, CurrJob.SerialNumDigits);
            lbCurrPicNum.Text = CurrJob.PictCurrNum.ToString().Trim();
            lbDescrip.Text = PicSetDescrip_table[CurrJob.PictCurrNum].Description;
            //cbCameraRes.SelectedValue = ConfigData.CamNumRes;
            cbCameraRes.SelectedIndex = ConfigData.CamNumRes;
            JobScreenRefresh();
        }


        // Declare required methods
        private void CaptureCamera()
        {
            CameraFrameNum = CameraSkipFrame;  //reset to the init value
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            //Console.WriteLine("Hit the Camera Callback");
            CamNumRes = ConfigData.CamNumRes;
            frame = new Mat(imgVert[CamNumRes], imgHor[CamNumRes], 0);  //type 2=16bit unsigned
            //frameRaw = new Mat(imgVert[CamNum], imgHor[CamNum], 0);  //type 2=16bit unsigned
            capture = new VideoCapture(0);
            //capture = new Capture(0);
            //capture.Fps = (double)0.10;
            capture.Open(0);
            capture.Set(CV_CAP_PROP_FRAME_HEIGHT, imgVert[CamNumRes]);
            capture.Set(CV_CAP_PROP_FRAME_WIDTH, imgHor[CamNumRes]);
            capture.Set(CV_CAP_FPS, (double)ConfigData.CamFPS);

            if (capture.IsOpened())
            {
                while (isCameraRunning && !isCameraPaused)
                {

                    try
                    {
                        if (capture.Read(frame))
                        {
                            //a frame has been captured
                            image = BitmapConverter.ToBitmap(frame);

                            try
                            {
                                if (pictureBoxScreen.Image != null)
                                {
                                    pictureBoxScreen.Image = image;
                                    pictureBoxScreen.Invalidate();
                                };
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Couldn't clear pictureBoxScreen");
                            };

                        };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("capture error");
                    };

                }
            };
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
                //Bitmap snapshot = new Bitmap(pictureBoxRaw.Image);
                Bitmap snapshot = new Bitmap(pictureBoxScreen.Image);

                // Save in some directory

                string FileNameString = ConfigData.SavePath + "\\" + CurrJob.JobNumStr.ToUpper().Trim() + "-";
                FileNameString = FileNameString + CreateFullSerialNumString(CurrJob.SerialChar, CurrJob.SerialCurr, CurrJob.SerialNumDigits);
                FileNameString = FileNameString + "-" + PadZeroesStr(CurrJob.PictSet, 2);
                FileNameString = FileNameString + "-" + PadZeroesStr(CurrJob.PictCurrNum, 2);
                FileNameString = FileNameString + ".png";
                snapshot.Save(FileNameString, ImageFormat.Png);

                Application.DoEvents();
                if (ConfigData.isMsgBoxPopUp)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult MessageResult =  MessageBox.Show("Continue (Y)  or Retake (N)", "Picture Saved", buttons);
                    if (MessageResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        //increment here
                        ScreenRefresh(true);
                    } else
                    {
                        ScreenRefresh(false);
                    };
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
            frame = new Mat(imgVert[CamNumRes], imgHor[CamNumRes], 0);  //type 2=16bit unsigned
            pictureBoxScreen.Image = BitmapConverter.ToBitmap(frame);

            ConfigData = ConfigData_Init();
            PicSetDescrip_table = PicSetDescrip_Init();
            CurrJob = Job_Init();
            ScreenRefresh(false);
        }

        private void bttnQuit_Click(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void bttnUpdate_Click(object sender, EventArgs e)
        {
            JobScreenSave();
        }

        private void Form_Picture_Paint(object sender, PaintEventArgs e)
        {
            /*
            */
        }

        private void bttnBrightUp_Click(object sender, EventArgs e)
        {
            capture.Brightness = capture.Brightness + (double)(1.0);
        }

        private void bttnBrightDwn_Click(object sender, EventArgs e)
        {
            capture.Brightness = capture.Brightness - (double)(1.0);
        }

        private void bttnExpUp_Click(object sender, EventArgs e)
        {
            capture.Exposure = capture.Exposure + (double)(1.0);
        }

        private void bttnExpDown_Click(object sender, EventArgs e)
        {
            capture.Exposure = capture.Exposure - (double)(1.0);
        }

        private void bttnManExposure_Click(object sender, EventArgs e)
        {
            capture.Set(CV_CAP_EXPOSURE, (double)(0.250));  //manual iris
        }
    }


    public class ConfigDataType
    {
        public bool isMsgBoxPopUp { get; set; } //should msg box would pop 
        public int CameraToUse { get; set; }    //which camera, on table 0=back
        public string SavePath { get; set; }    //where to store the pictures
        public int CamNumRes { get; set; }      //camera number to use for resolution (0=VGA, 1=HP, 2=Laptop)
        public double CamFPS { get; set; }      //camera FPS
    }


    public class PicSetDescripType
    { 
        public int PicTypeCode { get; set; }        //type of pictures
        public string Description { get; set; }     //description on the screen
    }


    public class JobType
    {
        public string JobNumStr { get; set; }       //job number
        public string SerialChar { get; set; }      //use for S, M, L
        public int SerialStart { get; set; }        //starting serial number
        public int SerialEnd { get; set; }          //ending serial number
        public int SerialCurr { get; set; }         //current serial number
        public int SerialNumDigits { get; set; }    //number of digits
        public int PictSet { get; set; }            //which picture set to use
        public int PictCurrNum { get; set; }       //what current picture is
    }

}
