using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapApp
{
    public partial class ImportForm : Form
    {
        private RideSet rideSet;
        private string inputPath;
        private int vidCount;
        private BackgroundWorker bw = new BackgroundWorker();

        public ImportForm(RideSet rs, string ip)
        {
            InitializeComponent();

            //set global variables
            rideSet = rs;
            inputPath = ip;
            vidCount = 1;

            //initialize label
            convertingLabel.Text = "Converting video 1 of " + rideSet.NumRides*3;

            //initialize progress bar
            progressBar.Maximum = rideSet.NumRides * 3;
            progressBar.Value = 0;

        }

        // This event handler updates the progress bar and label
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (vidCount < rideSet.NumRides * 3)
                vidCount++;
            convertingLabel.Text = "Converting video " + vidCount + " of " + rideSet.NumRides * 3;
            progressBar.Increment(1);
        }

        // do conversion work on background thread
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //convert and store files
            for (int i = 0; i < rideSet.NumRides; i++)
            {
                //construct path for video
                string ridePath = "\\ride" + i.ToString();

                //convert data from pi1, pi2, pi3
                for (int j = 1; j < 4; j++)
                {
                    //create output directory in chosen path
                    string writePath = rideSet.ProjectPath + ridePath + "\\pi" + j.ToString();
                    Console.WriteLine(writePath);
                    Directory.CreateDirectory(writePath);

                    //copy timecode data with Copy(input path, output path, overwrite)
                    File.Copy(inputPath + ridePath + "\\pi" + j.ToString() + "\\timecode.txt", writePath + "\\timecode.txt", true);
                    //Console.WriteLine("Copy From: " + inputPath + ridePath + "\\pi" + j.ToString() + "\\timecode.txt");
                    //Console.WriteLine("To: " + writePath + "\\timecode.txt");

                    try
                    {
                        //convert video file
                        //var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                        //ffMpeg.ConvertMedia(inputPath + ridePath + "\\pi" + j.ToString() + "\\video1.h264", writePath + "\\videoOut1.mp4", Format.mp4);
                    }
                    catch { }

                    bw.ReportProgress(0, "placeholder");
                }

                //copy safety event data if it exists and gps time reference data
                try
                {
                    try
                    {
                        File.Copy(inputPath + ridePath + "\\events.txt", rideSet.ProjectPath + ridePath + "\\events.txt", true);
                    }
                    catch { }
                    try
                    {
                        File.Copy(inputPath + ridePath + "\\gps.log", rideSet.ProjectPath + ridePath + "\\gps.log", true);
                    }
                    catch { }
                    File.Copy(inputPath + ridePath + "\\gps_time_ref.txt", rideSet.ProjectPath + ridePath + "\\gps_time_ref.txt", true);
                    Console.WriteLine(inputPath + ridePath + "\\gps_time_ref.txt");
                    Console.WriteLine(rideSet.ProjectPath + ridePath + "\\gps_time_ref.txt");
                }
                catch { } //catch error if file not found (no events.txt if no button presses occurred during ride)

                //convert gps data
                //set up path and arguments
                string babelPath = Environment.CurrentDirectory + "\\gpsbabel\\gpsbabel.exe";
                string cmdArgs = "-i nmea -f " + inputPath + ridePath + "\\gps.log -o gpx -F " + rideSet.ProjectPath + ridePath + "\\gps.gpx";
                //for console output
                StringBuilder output = new StringBuilder();
                //construct process
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = @babelPath;
                start.Arguments = string.Format("{0}", cmdArgs);
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                //run gpsbabel process and output to console
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string tmp = reader.ReadToEnd();
                        output.Append(tmp);
                    }
                }
                Console.WriteLine(output.ToString());
                Console.WriteLine("\nDone... ");
                Console.ReadLine();

                

            }
        }

        // close form when thread completes
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        //start work on background thread once form loads
        private void ImportForm_Load(object sender, EventArgs e)
        {
            //set up video conversion as background thread
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            //set up progress changed event for background thread
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.WorkerReportsProgress = true;
            //set up completion event for background thread
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }
    }
}
