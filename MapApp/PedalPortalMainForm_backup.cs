using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Maps.MapControl.WPF;
using AxWMPLib;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Media;
using System.Runtime.Serialization;

namespace MapApp
{
    public partial class PedalPortalMainForm : Form
    {
        //serializable object to save
        private RideSet rideSet;

        //video and timing variables
        private Timer scrollTimer;
        private bool scrollPlaying;
        private DateTime frontVideoTimecode;
        private DateTime faceVideoTimecode;
        private double faceVideoOffset;
        private DateTime backVideoTimecode;
        private double backVideoOffset;
        //gps timing for video sync
        private DateTime gpsOffsetRef;
        private long gpsOffset;

        //gps variables
        ////private LocationCollection gpxRoutePoints;
        private List<List<double>> gpxRoutePoints;
        private List<DateTime> gpsTimes;
        private List<double> speed;
        private List<double> acceleration;

        //map variables
        private MapLayer mRouteLayer;
        private MapLayer mMapLayer;
        private MapLayer mSurfaceLayer;
        private MapLayer mBehaviorLayer;
        private MapLayer mErrorLayer;
        private Pushpin mMarkerPin;

        

        //timer to ensure gps sync
        private Timer mRoutePlaybackTimer;

        //startup initialization
        public PedalPortalMainForm()
        {
            InitializeComponent();
            rideBox.Hide();

            //initialize media players
            leftVideoButton.Hide();
            rightVideoButton.Hide();
            frontVideo.uiMode = "none";
            faceVideo.uiMode = "none";
            backVideo.uiMode = "none";
            frontVideo.settings.autoStart = false;
            faceVideo.settings.autoStart = false;
            backVideo.settings.autoStart = false;
            //set up video timing events
            frontVideo.PositionChange += frontVideo_PositionChange;
            trackBar.MouseDown += TrackBar_MouseDown;
            trackBar.MouseUp += TrackBar_MouseUp;

            
        }


        private void PedalPortalMainForm_Load(object sender, EventArgs e)
        {
            //init timer and tick event
            scrollTimer = new Timer();
            scrollTimer.Interval = 1000;
            scrollTimer.Tick += new EventHandler(scrollTimer_Tick);
        } 

        private void mainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //stop timer before form closes to avoid errors
        private void PedalPortalMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mRoutePlaybackTimer.Dispose();
                scrollTimer.Dispose();
            }
            catch { }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //IMPORT DATA FROM RIDE_FILE ON USB DRIVE
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get the path
            OpenFileDialog rideFileDialog = new OpenFileDialog();
            rideFileDialog.Title = "Import ride_file.txt";
            DialogResult rideFileResult = rideFileDialog.ShowDialog();

            //check for correct file
            if (Path.GetFileName(rideFileDialog.FileName) == "ride_file.txt")
            {
                //get output directory
                FolderBrowserDialog outputDialog = new FolderBrowserDialog();
                outputDialog.Description = "Select output folder";
                DialogResult outputResult = outputDialog.ShowDialog();
                //check directory dialog result
                if (outputResult == DialogResult.OK)
                {
                    //init rideSet object
                    rideSet = new RideSet();

                    //get path from dialog
                    rideSet.ProjectPath = outputDialog.SelectedPath;

                    //read the file and count chars to get number of rides
                    StreamReader rideFile = new StreamReader(rideFileDialog.FileName);
                    rideSet.NumRides = rideFile.ReadLine().Length;

                    //get path of ride_file
                    string inputPath = Path.GetDirectoryName(rideFileDialog.FileName);

                    //open form to convert data and show progress
                    ImportForm importForm = new ImportForm(rideSet, inputPath);
                    importForm.ShowDialog(this);

                    newRides();
                }
            }
            else
            {
                if(rideFileResult == DialogResult.OK)
                {
                    MessageBox.Show("Invalid file.  Please import ride_file.");
                }   
            }
                        
        }

        void newRides()
        {
            //set up combobox for individual rides
            rideBox.Items.Clear();
            for (int i = 0; i < rideSet.NumRides; i++)
            {
                //set up ride info string
                string rideInfo = "Ride " + (i + 1).ToString();
                //append time and date data

                //initialize surface, behavior, and error variables
                ////rideSet.SurfaceTypePoints = new LocationCollection();
                rideSet.SurfaceTypePoints = new List<List<double>>();
                rideSet.SurfaceType = new List<string>();
                ////rideSet.BehaviorTypePoints = new LocationCollection();
                rideSet.BehaviorTypePoints = new List<List<double>>();
                rideSet.BehaviorType = new List<string>();
                ////rideSet.ErrorTypePoints = new LocationCollection();
                rideSet.ErrorTypePoints = new List<List<double>>();
                rideSet.ErrorType = new List<string>();

                //add to combobox
                rideBox.Items.Add(rideInfo);
            }
            rideBox.SelectedIndex = 0;
            rideBox.Show();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //LOADING RIDE-SPECIFIC DATA
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //load info when ride is chosen from dropdown
        private void rideBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update rideSet
            rideSet.CurrentRide = rideBox.SelectedIndex;

            //load video and gps data for selected ride
            frontVideo.URL = rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\pi1\\videoOut1.mp4";
            topVideoLabel.Text = "Front Cam";
            faceVideo.URL = rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\pi2\\videoOut1.mp4";
            leftVideoLabel.Text = "Rider Cam";
            backVideo.URL = rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\pi3\\videoOut1.mp4";
            rightVideoLabel.Text = "Back Cam";
            //make video placement buttons visible
            leftVideoButton.Show();
            rightVideoButton.Show();

            //set trackbar max to length of video
            trackBar.Maximum = (int)frontVideo.Ctlcontrols.currentItem.duration;

            //load gps offset reference and video timecode files
            StreamReader file = new StreamReader(rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\gps_time_ref.txt");
            gpsOffsetRef = Convert.ToDateTime(file.ReadLine());
            file.Close();
            file = new StreamReader(rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\pi1\\timecode.txt");
            frontVideoTimecode = Convert.ToDateTime(file.ReadLine().Substring(2));
            file.Close();
            file = new StreamReader(rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\pi2\\timecode.txt");
            faceVideoTimecode = Convert.ToDateTime(file.ReadLine().Substring(2));
            file.Close();
            file = new StreamReader(rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\pi3\\timecode.txt");
            backVideoTimecode = Convert.ToDateTime(file.ReadLine().Substring(2));
            file.Close();

            faceVideoOffset = frontVideoTimecode.Ticks - faceVideoTimecode.Ticks;
            Console.WriteLine("face offset: " + faceVideoOffset);
            backVideoOffset = frontVideoTimecode.Ticks - backVideoTimecode.Ticks;
            Console.WriteLine("back offset: " + backVideoOffset);


            //clear map of previous route layers
            mapUserControl1.map.Children.Clear();

            //reinitialize map layers and pins
            mRouteLayer = new MapLayer();
            mMapLayer = new MapLayer();

            //surface marking elements
            mSurfaceLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mSurfaceLayer);

            //behavior marking elements
            mBehaviorLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mBehaviorLayer);


            //error marking elements
            mErrorLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mErrorLayer);

            //current route position marker
            mMarkerPin = new Pushpin();

            //initialize map timer for location placement
            mRoutePlaybackTimer = new Timer();
            mRoutePlaybackTimer.Interval = 200;
            mRoutePlaybackTimer.Tick += mRoutePlaybackTimer_Tick;

            //load gpx doc and convert to nodeList
            XmlDocument gpxDoc = new XmlDocument();
            gpxDoc.Load(rideSet.ProjectPath + "\\ride" + rideSet.CurrentRide + "\\gps.gpx");
            XmlNodeList pointNodes = gpxDoc.GetElementsByTagName("trkpt");
            //init LocationCollection for pointNodes
            gpxRoutePoints = new LocationCollection();
            double[] time = new double[gpxRoutePoints.Count];

            //init variable for to store gps data
            gpsTimes = new List<DateTime>();
            speed = new List<double>();
            acceleration = new List<double>();
            double PreviousSpeed = 0;
            double PrevMediaTime = 0;

            //iterate through gps nodes
            foreach (XmlNode node in pointNodes)
            {
                XmlNamedNodeMap attributes = node.Attributes;

                try
                {
                    //get latitude gpx
                    XmlNode lattitudeAttribute = attributes.GetNamedItem("lat");
                    double latitude = double.Parse(lattitudeAttribute.InnerText);

                    //get longitude from gpx
                    XmlNode longitudeAttribute = attributes.GetNamedItem("lon");
                    double longitude = double.Parse(longitudeAttribute.InnerText);

                    //add lat lon data to locations collection
                    gpxRoutePoints.Add(new Location(latitude, longitude));

                    //get time from gpx
                    DateTime gpsDateTime = Convert.ToDateTime(node["time"].InnerText);
                    gpsTimes.Add(gpsDateTime);

                    //get speed data from gpx and calculate accel
                    string speedString = node["speed"].InnerText;
                    double CurrentSpeed = Convert.ToDouble(speedString);
                    speed.Add(CurrentSpeed);
                    //convert ticks to seconds and calculate accel
                    double CurrentAcceleration = Math.Round(((CurrentSpeed - PreviousSpeed) / (gpsDateTime.Ticks / 10000000 - PrevMediaTime / 10000000)), 1);
                    acceleration.Add(CurrentAcceleration);
                    //for calculating accel
                    PreviousSpeed = CurrentSpeed;
                    PrevMediaTime = gpsDateTime.Ticks;

                }
                catch
                {
                    //error importing gpx file
                    string errorText = "GPX file is corrupt or not formatted correctly";
                    string errorCaptionText = "GPX formatting error";
                    MessageBoxButtons okButton1 = MessageBoxButtons.OK;
                    MessageBox.Show(errorText, errorCaptionText, okButton1);
                }
            }

            if (gpsTimes.Count > 0)
            {
                displayGPSRoute();
            }
            else
            {
                //error importing gpx file
                string errorText = "No GPS data exists for this ride.";
                string errorCaptionText = "GPS Data";
                MessageBoxButtons okButton1 = MessageBoxButtons.OK;
                MessageBox.Show(errorText, errorCaptionText, okButton1);
            }
        }

        void displayGPSRoute()
        { 
        
            //calculate gpsOffset 
            gpsOffset = gpsTimes[0].Ticks - gpsOffsetRef.Ticks;

            //add gps route to the map
            MapPolyline route = new MapPolyline();
            route.Locations = gpxRoutePoints;
            route.StrokeThickness = 5;
            route.Opacity = .5;
            route.Stroke = new SolidColorBrush(Colors.Blue);
            mRouteLayer.Children.Add(route);
         
            //add pushpin to gps starting location
            Pushpin startPin = new Pushpin();
            startPin.Content = "Start";
            mMapLayer.Children.Add(startPin);
            MapLayer.SetPosition(startPin, gpxRoutePoints[0]);

            //add pushpin to gps ending location
            Pushpin endPin = new Pushpin();
            endPin.Content = "End";
            mMapLayer.Children.Add(endPin);
            MapLayer.SetPosition(endPin, gpxRoutePoints[gpxRoutePoints.Count - 1]);

            //add surface pins from rideset
            for (int i = 0; i < rideSet.SurfacePins.Count; i++)
            {
                ((MapLayer) rideSet.SurfacePins[i].Parent).Children.Remove(rideSet.SurfacePins[i]);
                mSurfaceLayer.Children.Add(rideSet.SurfacePins[i]);
                MapLayer.SetPosition(rideSet.SurfacePins[i], rideSet.SurfaceTypePoints[i]);
            }

            //add behavior pins from rideset
            for (int i = 0; i < rideSet.BehaviorPins.Count; i++)
            {
                ((MapLayer)rideSet.BehaviorPins[i].Parent).Children.Remove(rideSet.BehaviorPins[i]);
                mBehaviorLayer.Children.Add(rideSet.BehaviorPins[i]);
                MapLayer.SetPosition(rideSet.BehaviorPins[i], rideSet.BehaviorTypePoints[i]);
            }

            //add error pins from rideset
            for (int i = 0; i < rideSet.ErrorPins.Count; i++)
            {
                ((MapLayer)rideSet.ErrorPins[i].Parent).Children.Remove(rideSet.ErrorPins[i]);
                mErrorLayer.Children.Add(rideSet.ErrorPins[i]);
                MapLayer.SetPosition(rideSet.ErrorPins[i], rideSet.ErrorTypePoints[i]);
            }

            //set initial view based on gps points
            LocationRect bestRouteView = new LocationRect(gpxRoutePoints);
            mapUserControl1.map.SetView(bestRouteView);

            mMarkerPin.Visibility = System.Windows.Visibility.Collapsed;
            mMapLayer.Children.Add(mMarkerPin);

            mapUserControl1.map.Children.Add(mRouteLayer);
            mapUserControl1.map.Children.Add(mMapLayer);

            mRoutePlaybackTimer.Start();
            refreshRoute();            
        }

        private void mRoutePlaybackTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //get converted current time to line up video and gps
                long currentTime = gpsOffset + frontVideoTimecode.Ticks + (long)(frontVideo.Ctlcontrols.currentPosition * 10000000);

                //check if gps data is available for current video position
                if (currentTime < gpsTimes[0].Ticks)
                {
                    gpsLabel.Text = "No GPS data yet";
                    roadwaySurfaceTypeToolStripMenuItem.Enabled = false;
                    riderBehaviorTypeToolStripMenuItem.Enabled = false;
                    riderErrorToolStripMenuItem.Enabled = false;
                    mMarkerPin.Visibility = System.Windows.Visibility.Hidden;
                }
                //get gps data and display
                else
                {
                    //set marker visible
                    mMarkerPin.Visibility = System.Windows.Visibility.Visible;
                    //find closest gps node time
                    int i = gpsTimes.Count - 1;
                    double time = gpsTimes[i].Ticks;
                    while (time > currentTime)
                    {
                        i--;
                        time = gpsTimes[i].Ticks;
                    }
                    //set marker position
                    MapLayer.SetPosition(mMarkerPin, gpxRoutePoints[i]);

                    //get lat, lon, time, speed, and accel data from current gps node and display
                    double lat = gpxRoutePoints[i].Latitude;
                    double lon = gpxRoutePoints[i].Longitude;
                    gpsLabel.Text = string.Format("Lat: {0}, Lon: {1}", Convert.ToString(lat), Convert.ToString(lon));
                    gpsTimeLabel.Text = "Time: " + gpsTimes[i].ToString();
                    gpsSpeedLabel.Text = string.Format("Speed: {0} m/s", Convert.ToString(speed[i]));
                    gpsAccelLabel.Text = string.Format("Accel: {0} m/s^2", Convert.ToString(acceleration[i]));

                    //enable marker menu items
                    roadwaySurfaceTypeToolStripMenuItem.Enabled = true;
                    riderBehaviorTypeToolStripMenuItem.Enabled = true;
                    riderErrorToolStripMenuItem.Enabled = true;
                }
            }
            catch { }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //VIDEO FUNCTIONS
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //switch video placement
        private void leftVideoButton_Click(object sender, EventArgs e)
        {
            if (topVideoLabel.Text == "Front Cam")
            {
                //rearrange video placement
                splitContainer4.Panel1.Controls.Remove(frontVideo);
                splitContainer3.Panel1.Controls.Remove(faceVideo);
                splitContainer4.Panel1.Controls.Add(faceVideo);
                splitContainer3.Panel1.Controls.Add(frontVideo);
                //change video labels
                topVideoLabel.Text = "Rider Cam";
                leftVideoLabel.Text = "Front Cam";

            }
            else if(topVideoLabel.Text == "Rider Cam")
            {
                //rearrange video placement
                splitContainer4.Panel1.Controls.Remove(faceVideo);
                splitContainer3.Panel1.Controls.Remove(frontVideo);
                splitContainer4.Panel1.Controls.Add(frontVideo);
                splitContainer3.Panel1.Controls.Add(faceVideo);
                //change video labels
                leftVideoLabel.Text = "Rider Cam";
                topVideoLabel.Text = "Front Cam";

            }
            else if (topVideoLabel.Text == "Back Cam")
            {
                //rearrange video placement
                splitContainer4.Panel1.Controls.Remove(backVideo);
                splitContainer3.Panel1.Controls.Remove(frontVideo);
                splitContainer3.Panel2.Controls.Remove(faceVideo);
                splitContainer4.Panel1.Controls.Add(frontVideo);
                splitContainer3.Panel1.Controls.Add(faceVideo);
                splitContainer3.Panel2.Controls.Add(backVideo);
                //change video labels
                topVideoLabel.Text = "Front Cam";
                leftVideoLabel.Text = "Rider Cam";
                rightVideoLabel.Text = "Back Cam";
            }
        }

        //switch video placement
        private void rightVideoButton_Click(object sender, EventArgs e)
        {
            if (topVideoLabel.Text == "Front Cam")
            {
                //rearrange video placement
                splitContainer4.Panel1.Controls.Remove(frontVideo);
                splitContainer3.Panel1.Controls.Remove(faceVideo);
                splitContainer3.Panel2.Controls.Remove(backVideo);
                splitContainer4.Panel1.Controls.Add(backVideo);
                splitContainer3.Panel1.Controls.Add(frontVideo);
                splitContainer3.Panel2.Controls.Add(faceVideo);
                //change video labels
                topVideoLabel.Text = "Back Cam";
                leftVideoLabel.Text = "Front Cam";
                rightVideoLabel.Text = "Rider Cam";
            }
            else if (topVideoLabel.Text == "Rider Cam")
            {
                //rearrange video placement
                splitContainer4.Panel1.Controls.Remove(faceVideo);
                splitContainer3.Panel2.Controls.Remove(backVideo);
                splitContainer4.Panel1.Controls.Add(backVideo);
                splitContainer3.Panel2.Controls.Add(faceVideo);
                //change video labels
                rightVideoLabel.Text = "Rider Cam";
                topVideoLabel.Text = "Back Cam";
            }
            else if (topVideoLabel.Text == "Back Cam")
            {
                //rearrange video placement
                splitContainer4.Panel1.Controls.Remove(backVideo);
                splitContainer3.Panel2.Controls.Remove(faceVideo);
                splitContainer4.Panel1.Controls.Add(faceVideo);
                splitContainer3.Panel2.Controls.Add(backVideo);
                //change video labels
                topVideoLabel.Text = "Rider Cam";
                rightVideoLabel.Text = "Back Cam";
            }
        }
       


        //clicking play button event
        private void playButton_Click(object sender, EventArgs e)
        {
            //toggle pause/play
            if (frontVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                frontVideo.Ctlcontrols.pause();
                faceVideo.Ctlcontrols.pause();
                backVideo.Ctlcontrols.pause();
                playButton.Image = Properties.Resources.Play_button;
                //stop timer
                scrollTimer.Stop();
            }
            else if ((frontVideo.playState == WMPLib.WMPPlayState.wmppsPaused) || (frontVideo.playState == WMPLib.WMPPlayState.wmppsStopped) || (frontVideo.playState == WMPLib.WMPPlayState.wmppsReady))
            {
                frontVideo.Ctlcontrols.play();
                faceVideo.Ctlcontrols.play();
                backVideo.Ctlcontrols.play();
                playButton.Image = Properties.Resources.pause_button;
                //start timer
                scrollTimer.Start();

                //listen for play state change events
                frontVideo.PlayStateChange += frontVideo_PlayStateChange;
            }
        }

        //play state changed event
        private void frontVideo_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (frontVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trackBar.Maximum = (int)frontVideo.Ctlcontrols.currentItem.duration;
                scrollTimer.Start();
            }
            else if (frontVideo.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                scrollTimer.Stop();
            }
            else if (frontVideo.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                scrollTimer.Stop();
                trackBar.Value = 0;
            }
        }

        //clicking stop button event 
        private void stopButton_Click(object sender, EventArgs e)
        {
            //stop videos
            frontVideo.Ctlcontrols.stop();
            faceVideo.Ctlcontrols.stop();
            backVideo.Ctlcontrols.stop();
            //update UI
            playButton.Image = Properties.Resources.Play_button;
            trackBar.Value = 0;
            //stop timer
            scrollTimer.Stop();
        }

        
        //press mouse on trackbar to begin scrolling
        private void TrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (frontVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                frontVideo.Ctlcontrols.pause();
                faceVideo.Ctlcontrols.pause();
                backVideo.Ctlcontrols.pause();
                scrollTimer.Stop();
                scrollPlaying = true;
            }
            else
            {
                scrollPlaying = false;
            }
        }
        //release mouse after scrolling trackbar
        private void TrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            frontVideo.Ctlcontrols.currentPosition = trackBar.Value;
            faceVideo.Ctlcontrols.currentPosition = trackBar.Value + faceVideoOffset / 100000000;
            backVideo.Ctlcontrols.currentPosition = trackBar.Value + backVideoOffset / 100000000;
            Console.WriteLine(frontVideo.Ctlcontrols.currentPosition);
            Console.WriteLine(trackBar.Value);
            Console.WriteLine(faceVideoOffset);
            Console.WriteLine(trackBar.Value + faceVideoOffset / 100000000);
            //check if video was playing when scroll started
            if (scrollPlaying)
            {
                frontVideo.Ctlcontrols.play();
                faceVideo.Ctlcontrols.play();
                backVideo.Ctlcontrols.play();
                scrollTimer.Start();
            }
        }


        //front video position change event
        void frontVideo_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
            //line up other videos
            faceVideo.Ctlcontrols.currentPosition = frontVideo.Ctlcontrols.currentPosition + faceVideoOffset / 100000000;
            backVideo.Ctlcontrols.currentPosition = frontVideo.Ctlcontrols.currentPosition + backVideoOffset / 100000000;
        }

        //scroll timer tick event
        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //update trackbar
                if (frontVideo.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    trackBar.Value = (int)frontVideo.Ctlcontrols.currentPosition;
                }
            }
            catch { }
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //SURFACE MENU FUNCTIONS
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        //SURFACE TYPE 1
        private void addSurface(Color color, string text, int num)
        {
            //create new marker for surface type
            Pushpin pin = new Pushpin();

            //double currentTime = frontVideo.Ctlcontrols.currentPosition;
            long currentTime = gpsOffset + frontVideoTimecode.Ticks + (long)(frontVideo.Ctlcontrols.currentPosition * 10000000);

            int i = gpsTimes.Count - 1;
            long time = gpsTimes[i].Ticks;

            while (time > currentTime)
            {
                i--;
                time = gpsTimes[i].Ticks;
            }

            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            rideSet.SurfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Content = num;
            pin.Background = new SolidColorBrush(color);
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);

            //add pin to rideSet var
            rideSet.SurfacePins.Add(pin);

            rideSet.SurfaceType.Add(text);
            refreshRoute();
        }

        private void addSurfaceType1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.Blue, addSurfaceType1ToolStripMenuItem.Text, 1);
        }

        private void addSurfaceType2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.Green, addSurfaceType2ToolStripMenuItem.Text, 2);
        }

        private void addSurfaceType3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.Yellow, addSurfaceType3ToolStripMenuItem.Text, 3);
        }

        private void addSurfaceType4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.Orchid, addSurfaceType4ToolStripMenuItem.Text, 4);
        }

        private void addSurfaceType5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.Red, addSurfaceType5ToolStripMenuItem.Text, 5);
        }

        private void addSurfaceType6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.Cyan, addSurfaceType6ToolStripMenuItem.Text, 6);
        }

        private void addSurfaceType7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSurface(Colors.LawnGreen, addSurfaceType7ToolStripMenuItem.Text, 7);
        }

        
        //redraw gps route line to show surface type colors
        private void refreshRoute()
        {
            //get count of surface type markers
            int i = rideSet.SurfaceType.Count - 1;
            //get count of gpx location points
            int j = gpxRoutePoints.Count - 1;

            LocationCollection tempTypePoints = new LocationCollection();
            List<string> tempType = new List<string>();

            LocationCollection route = new LocationCollection();
            mRouteLayer.Children.Clear();

            MapPolyline routeLine = new MapPolyline();

            Color typeColor = new Color();
            typeColor = Colors.Orchid;

            //iterate through gps points
            for (int k = 0; k < gpxRoutePoints.Count; k++)
            {
                for (int l = 0; l < rideSet.SurfaceTypePoints.Count; l++)
                {
                    if (rideSet.SurfaceTypePoints[l] == gpxRoutePoints[k])
                    {
                        tempTypePoints.Add(rideSet.SurfaceTypePoints[l]);
                        tempType.Add(rideSet.SurfaceType[l]);
                    }
                }
            }

            while (i >= 0)
            {
                Console.WriteLine("tempType " + tempType[i] + " text " + addSurfaceType1ToolStripMenuItem.Text);
                if (tempType[i] == addSurfaceType1ToolStripMenuItem.Text)
                {
                    typeColor = Colors.Blue;
                }
                if (tempType[i] == addSurfaceType2ToolStripMenuItem.Text)
                {
                    typeColor = Colors.Green;
                }
                if (tempType[i] == addSurfaceType3ToolStripMenuItem.Text)
                {
                    typeColor = Colors.Yellow;
                }
                if (tempType[i] == addSurfaceType4ToolStripMenuItem.Text)
                {
                    typeColor = Colors.Orchid;
                }
                if (tempType[i] == addSurfaceType5ToolStripMenuItem.Text)
                {
                    typeColor = Colors.Red;
                }
                if (tempType[i] == addSurfaceType6ToolStripMenuItem.Text)
                {
                    typeColor = Colors.Cyan;
                }
                if (tempType[i] == addSurfaceType7ToolStripMenuItem.Text)
                {
                    typeColor = Colors.LawnGreen;
                }

                while (gpxRoutePoints[j] != tempTypePoints[i])
                {
                    route.Add(gpxRoutePoints[j]);
                    j--;
                }
                route.Add(gpxRoutePoints[j]);

                routeLine = new MapPolyline();
                routeLine.Locations = route;
                routeLine.StrokeThickness = 5;
                routeLine.Opacity = .5;
                routeLine.Stroke = new SolidColorBrush(typeColor);
                routeLine.Visibility = System.Windows.Visibility.Visible;
                mRouteLayer.Children.Add(routeLine);
                route = new LocationCollection();
                i--;
            }

            while (j >= 0)
            {
                route.Add(gpxRoutePoints[j]);
                j--;
            }

            routeLine = new MapPolyline();
            routeLine.Locations = route;
            routeLine.StrokeThickness = 5;
            routeLine.Opacity = .5;
            routeLine.Stroke = new SolidColorBrush(Colors.Blue);
            routeLine.Visibility = System.Windows.Visibility.Visible;
            mRouteLayer.Children.Add(routeLine);

        }

        private void removeLastSurfaceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove Last surface Type

            if (mSurfaceLayer.Children.Count > 0)
            {
                mSurfaceLayer.Children.RemoveAt(mSurfaceLayer.Children.Count - 1);
            }
            if (rideSet.SurfaceType.Count > 0)
            {
                rideSet.SurfaceType.RemoveAt(rideSet.SurfaceType.Count - 1);
                rideSet.SurfaceTypePoints.RemoveAt(rideSet.SurfaceTypePoints.Count - 1);
                rideSet.SurfacePins.RemoveAt(rideSet.SurfacePins.Count - 1);
                refreshRoute();
            }
        }

        private void clearSurfaceTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear Surface Types

            rideSet.SurfaceType.Clear();
            rideSet.SurfaceTypePoints.Clear();
            rideSet.SurfacePins.Clear();
            mSurfaceLayer.Children.Clear();

            refreshRoute();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Rename Surface
            Form3 f = new Form3();
            f.ShowDialog();
            addSurfaceType1ToolStripMenuItem.Text = f.surface1;
            addSurfaceType2ToolStripMenuItem.Text = f.surface2;
            addSurfaceType3ToolStripMenuItem.Text = f.surface3;
            addSurfaceType4ToolStripMenuItem.Text = f.surface4;
            addSurfaceType5ToolStripMenuItem.Text = f.surface5;
            addSurfaceType6ToolStripMenuItem.Text = f.surface6;
            addSurfaceType7ToolStripMenuItem.Text = f.surface7;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //BEHAVIOR MENU FUNCTIONS
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        private void addBehavior(string type, Color color, string text)
        {
            //create new marker for surface type
            Pushpin pin = new Pushpin();

            //double currentTime = frontVideo.Ctlcontrols.currentPosition;
            long currentTime = gpsOffset + frontVideoTimecode.Ticks + (long)(frontVideo.Ctlcontrols.currentPosition * 10000000);

            int i = gpsTimes.Count - 1;
            long time = gpsTimes[i].Ticks;

            while (time > currentTime)
            {
                i--;
                time = gpsTimes[i].Ticks;
            }

            pin.Content = type;                                
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            rideSet.BehaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(color); 
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);

            //add pin to rideSet var
            rideSet.BehaviorPins.Add(pin);

            rideSet.BehaviorType.Add(text);
        }

        private void addBehaviorType1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("A", Colors.Blue, addBehaviorType1ToolStripMenuItem.Text);
        }

        private void addBehaviorType2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("B", Colors.Green, addBehaviorType2ToolStripMenuItem.Text);
        }

        private void addBehaviorType3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("C", Colors.Yellow, addBehaviorType3ToolStripMenuItem.Text);
        }

        private void addBehaviorType4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("D", Colors.Orchid, addBehaviorType4ToolStripMenuItem.Text);
        }

        private void addBehaviorType5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("E", Colors.Red, addBehaviorType5ToolStripMenuItem.Text);
        }

        private void addBehaviorType6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("F", Colors.Cyan, addBehaviorType6ToolStripMenuItem.Text);
        }

        private void addBehaviorType7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBehavior("G", Colors.LawnGreen, addBehaviorType7ToolStripMenuItem.Text);
        }

        private void removeLastBehaviorTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mBehaviorLayer.Children.Count > 0)
            {
                mBehaviorLayer.Children.RemoveAt(mBehaviorLayer.Children.Count - 1);
            }
            if (rideSet.BehaviorType.Count > 0)
            {
                rideSet.BehaviorType.RemoveAt(rideSet.BehaviorType.Count - 1);
                rideSet.BehaviorTypePoints.RemoveAt(rideSet.BehaviorTypePoints.Count - 1);
                rideSet.BehaviorPins.RemoveAt(rideSet.BehaviorPins.Count - 1);
            }
        }

        private void clearBehaviorTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rideSet.BehaviorType.Clear();
            rideSet.BehaviorTypePoints.Clear();
            rideSet.BehaviorPins.Clear();
            mBehaviorLayer.Children.Clear();
        }

        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
            addBehaviorType1ToolStripMenuItem.Text = f.behavior1;
            addBehaviorType2ToolStripMenuItem.Text = f.behavior2;
            addBehaviorType3ToolStripMenuItem.Text = f.behavior3;
            addBehaviorType4ToolStripMenuItem.Text = f.behavior4;
            addBehaviorType5ToolStripMenuItem.Text = f.behavior5;
            addBehaviorType6ToolStripMenuItem.Text = f.behavior6;
            addBehaviorType7ToolStripMenuItem.Text = f.behavior7;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //RIDER ERROR MENU FUNCTIONS
        //--------------------------------------------------------------------------------------------------------------------------------------------------

        private void addError(string type, Color color, string text)
        {
            //create new marker for surface type
            Pushpin pin = new Pushpin();

            //double currentTime = frontVideo.Ctlcontrols.currentPosition;
            long currentTime = gpsOffset + frontVideoTimecode.Ticks + (long)(frontVideo.Ctlcontrols.currentPosition * 10000000);

            int i = gpsTimes.Count - 1;
            long time = gpsTimes[i].Ticks;

            while (time > currentTime)
            {
                i--;
                time = gpsTimes[i].Ticks;
            }

            pin.Content = type;
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            rideSet.ErrorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(color);
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);

            //add pin to rideSet var
            rideSet.ErrorPins.Add(pin);

            rideSet.ErrorType.Add(text);
        }

        private void addErrorType1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e1", Colors.Crimson, addErrorType1ToolStripMenuItem.Text);
        }

        private void addErrorType2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e2", Colors.Crimson, addErrorType2ToolStripMenuItem.Text);
        }

        private void addErrorType3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e3", Colors.Crimson, addErrorType3ToolStripMenuItem.Text);
        }

        private void addErrorType4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e4", Colors.Crimson, addErrorType4ToolStripMenuItem.Text);
        }

        private void addErrorType5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e5", Colors.Crimson, addErrorType5ToolStripMenuItem.Text);
        }

        private void addErrorType6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e6", Colors.Crimson, addErrorType6ToolStripMenuItem.Text);
        }

        private void addErrorType7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addError("e7", Colors.Crimson, addErrorType7ToolStripMenuItem.Text);
        }

        private void removeLastErrorTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mErrorLayer.Children.Count > 0)
            {
                mErrorLayer.Children.RemoveAt(mErrorLayer.Children.Count - 1);
            }
            if (rideSet.ErrorType.Count > 0)
            {
                rideSet.ErrorType.RemoveAt(rideSet.ErrorType.Count - 1);
                rideSet.ErrorTypePoints.RemoveAt(rideSet.ErrorTypePoints.Count - 1);
                rideSet.ErrorPins.RemoveAt(rideSet.ErrorPins.Count - 1);
            }
        }

        private void clearErrorTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rideSet.ErrorType.Clear();
            rideSet.ErrorTypePoints.Clear();
            rideSet.ErrorPins.Clear();
            mErrorLayer.Children.Clear();
        }

        private void renameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.ShowDialog();
            addErrorType1ToolStripMenuItem.Text = f.error1;
            addErrorType2ToolStripMenuItem.Text = f.error2;
            addErrorType3ToolStripMenuItem.Text = f.error3;
            addErrorType4ToolStripMenuItem.Text = f.error4;
            addErrorType5ToolStripMenuItem.Text = f.error5;
            addErrorType6ToolStripMenuItem.Text = f.error6;
            addErrorType7ToolStripMenuItem.Text = f.error7;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open up a save file dialog box
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save RideSet as...";
            saveFileDialog.Filter = "RideSet|*.rs";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                //open file stream
                Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create);

                Pushpin testObj = new Pushpin();

                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, testObj);
                /*
                //init binary formatter and write rideSet to file
                DataContractSerializer serializer = new DataContractSerializer(typeof(RideSet));
                XmlDictionaryWriter binaryDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(stream);
                serializer.WriteObject(binaryDictionaryWriter, rideSet);
                binaryDictionaryWriter.Flush();
                */

                //serializer.WriteObject(stream, rideSet);
                stream.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open up a save file dialog box
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Save RideSet as...";
            openFileDialog.Filter = "RideSet|*.rs";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                Stream stream = File.Open(openFileDialog.FileName, FileMode.Open);

                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                rideSet = (RideSet)binaryFormatter.Deserialize(stream);
                /*
                DataContractSerializer deserializer = new DataContractSerializer(typeof(RideSet));
                XmlDictionaryReader binaryDictionaryReader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max);
                rideSet = (RideSet) deserializer.ReadObject(binaryDictionaryReader);
                Console.WriteLine("numRides" + rideSet.NumRides + rideSet.ProjectPath);

                */
                newRides();
            }
        }
    }
}

