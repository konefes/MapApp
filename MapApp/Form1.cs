using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XmlConfiguration;
using System.Xaml;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Core;
using Microsoft.Maps.MapControl.WPF.Design;
using Microsoft.Maps.MapControl.WPF.Overlays;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace MapApp
{
    public partial class Form1 : Form
    {
        private MapLayer mRouteLayer;
        private MapLayer mMapLayer;
        private MapLayer mSurfaceLayer;
        private MapLayer mBehaviorLayer;
        private MapLayer mErrorLayer;
        private Pushpin mMarkerPin;
        private Timer mRoutePlaybackTimer;
        private LocationCollection gpxRoutePoints;
        private List<double> mediaTimes;
        private List<double> speed;
        private List<double> acceleration;
        private LocationCollection surfaceTypePoints;
        private List<string> surfaceType;
        private LocationCollection behaviorTypePoints;
        private List<string> behaviorType;
        private LocationCollection errorTypePoints;
        private List<string> errorType;
        private bool play = true;
        private int mRouteLocationIndex;
        private Timer mediatime;
        

        public Form1()
        {
            InitializeComponent();

            mRoutePlaybackTimer = new Timer();
            mRoutePlaybackTimer.Interval = 200;
            mRoutePlaybackTimer.Tick += mRoutePlaybackTimer_Tick;
            

            mRouteLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mRouteLayer);

            mMapLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mMapLayer);

            mSurfaceLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mSurfaceLayer);

            mBehaviorLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mBehaviorLayer);

            mErrorLayer = new MapLayer();
            mapUserControl1.map.Children.Add(mErrorLayer);

            mMarkerPin = new Pushpin();

            surfaceTypePoints = new LocationCollection();
            surfaceType = new List<string>();

            behaviorTypePoints = new LocationCollection();
            behaviorType = new List<string>();

            errorTypePoints = new LocationCollection();
            errorType = new List<string>();

            openFileDialog2.Filter = "GPX Files (*.gpx)|*.gpx|All Files (*.*)|*.*";

            openFileDialog1.Filter = "Video Files (*.asf;*.asx;*.avi;*.wav;*.wma;*.wax;*.wm;*.wmv;*.wvx;*.mpg;*.mp4;*.m1v;*.mp2;*.mpa;*.mpe;*.mov)|*.asf;*.asx;*.avi;*.wav;*.wma;*.wax;*.wm;*.wmv;*.wvx;*.mpg;*.mpeg;*.m1v;*.mp2;*.mpa;*.mpe;*.mov|All Files (*.*)|*.*";

            openFileDialog3.Filter = "Video Files (*.asf;*.asx;*.avi;*.wav;*.wma;*.wax;*.wm;*.wmv;*.wvx;*.mpg;*.mp4;*.m1v;*.mp2;*.mpa;*.mpe;*.mov)|*.asf;*.asx;*.avi;*.wav;*.wma;*.wax;*.wm;*.wmv;*.wvx;*.mpg;*.mpeg;*.m1v;*.mp2;*.mpa;*.mpe;*.mov|All Files (*.*)|*.*";

            openFileDialog4.Filter = "Video Files (*.asf;*.asx;*.avi;*.wav;*.wma;*.wax;*.wm;*.wmv;*.wvx;*.mpg;*.mp4;*.m1v;*.mp2;*.mpa;*.mpe;*.mov)|*.asf;*.asx;*.avi;*.wav;*.wma;*.wax;*.wm;*.wmv;*.wvx;*.mpg;*.mpeg;*.m1v;*.mp2;*.mpa;*.mpe;*.mov|All Files (*.*)|*.*";

            FrontVideo1.uiMode = "none";
            FrontVideo3.uiMode = "none";
            BehindVideo1.uiMode = "none";
            BehindVideo3.uiMode = "none";
            FaceVideo1.uiMode = "none";
            FaceVideo3.uiMode = "none";

            FrontVideo1.settings.autoStart = false;
            FrontVideo3.settings.autoStart = false;
            BehindVideo1.settings.autoStart = false;
            BehindVideo3.settings.autoStart = false;
            FaceVideo1.settings.autoStart = false;
            FaceVideo3.settings.autoStart = false;


        }

        void mRoutePlaybackTimer_Tick(object sender, EventArgs e)
        {
            string media = FrontVideo1.URL;
            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            /*
            if (currentTime < mediaTimes[0])
            {
                textBox6.Text = "No GPS data yet";
            }

            else
            {
                mMarkerPin.Visibility = System.Windows.Visibility.Visible;
                int i = mediaTimes.Count - 1;
                double time = mediaTimes[i];
                while (time > currentTime)
                {
                    i--;
                    time = mediaTimes[i];
                }

                MapLayer.SetPosition(mMarkerPin, gpxRoutePoints[i]);

                textBox2.Text = string.Format("{0} sec", Math.Round(currentTime,2));
                textBox4.Text = string.Format("{0} m/s", Convert.ToString(speed[i]));
                textBox8.Text = string.Format("{0} m/s^2", Convert.ToString(acceleration[i]));

                double lat = gpxRoutePoints[i].Latitude;
                double lon = gpxRoutePoints[i].Longitude;
                textBox6.Text = string.Format("{0}, {1}", Convert.ToString(lat), Convert.ToString(lon));
            } */

            //throw new NotImplementedException();
        }


        void FrontVideo1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
                throw new NotImplementedException();
        }

        private void FrontVideo1_Enter(object sender, EventArgs e)
        {
            
        }

        private void loadGPX()
        { 
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                XmlDocument gpxDoc = new XmlDocument();
                gpxDoc.Load(openFileDialog2.FileName);
                XmlNodeList pointNodes = gpxDoc.GetElementsByTagName("trkpt");
                //XmlNodeList mediaTimeNodes = gpxDoc.GetElementsByTagName("extensions");    delete later!!
                
                //LocationCollection gpxRoutePoints = new LocationCollection();
                gpxRoutePoints = new LocationCollection();
                double[] time = new double[gpxRoutePoints.Count];

                mediaTimes = new List<double>();
                speed = new List<double>();
                acceleration = new List<double>();
                double PreviousSpeed = 0;
                double PrevMediaTime = 0;

                foreach (XmlNode node in pointNodes)
                {
                    XmlNamedNodeMap attributes = node.Attributes;

                    try
                    {
                        
                        XmlNode lattitudeAttribute = attributes.GetNamedItem("lat");
                        double latitude = double.Parse(lattitudeAttribute.InnerText);

                        XmlNode longitudeAttribute = attributes.GetNamedItem("lon");
                        double longitude = double.Parse(longitudeAttribute.InnerText);

                        gpxRoutePoints.Add(new Microsoft.Maps.MapControl.WPF.Location(latitude, longitude));
                        
                        //string mediaScale = node["extensions"]["qtmediatimescale"].InnerText;
                        //string mediaValue = node["extensions"]["qtmediatimevalue"].InnerText;
                        //double scale = Convert.ToDouble(mediaScale);
                        //double value = Convert.ToDouble(mediaValue);
                        //double mediaTime = value / scale;
                        //mediaTimes.Add(mediaTime);
                        
                        string speedString = node["speed"].InnerText;
                        double CurrentSpeed = Convert.ToDouble(speedString);
                        speed.Add(CurrentSpeed);
                        //double CurrentAcceleration = Math.Round(((CurrentSpeed - PreviousSpeed) / (mediaTime - PrevMediaTime)), 1);
                        //acceleration.Add(CurrentAcceleration);

                        //PreviousSpeed = CurrentSpeed;
                        //PrevMediaTime = mediaTime; 
                        
                    }
                    catch
                    {
                        string errorText = "GPX file is corrupt or not formatted correctly";
                        string errorCaptionText = "GPX formatting error";
                        MessageBoxButtons okButton1 = MessageBoxButtons.OK;
                        MessageBox.Show(errorText, errorCaptionText, okButton1);
                    }
                }

                
                    MapPolyline route = new MapPolyline();
                    route.Locations = gpxRoutePoints;
                    route.StrokeThickness = 5;
                    route.Opacity = .5;
                    route.Stroke = new SolidColorBrush(Colors.Blue);
                    mRouteLayer.Children.Add(route);
                    
                    Pushpin startPin = new Pushpin();
                    startPin.Content = "Start";
                    mMapLayer.Children.Add(startPin);
                    MapLayer.SetPosition(startPin, gpxRoutePoints[0]);

                    Pushpin endPin = new Pushpin();
                    endPin.Content = "End";
                    mMapLayer.Children.Add(endPin);
                    MapLayer.SetPosition(endPin, gpxRoutePoints[gpxRoutePoints.Count - 1]);

                    LocationRect bestRouteView = new LocationRect(gpxRoutePoints);
                    mapUserControl1.map.SetView(bestRouteView);

                    mMarkerPin.Visibility = System.Windows.Visibility.Collapsed;
                    mMapLayer.Children.Add(mMarkerPin);

                    mRoutePlaybackTimer.Start();

                //initialize lists
                    surfaceTypePoints = new LocationCollection();
                    surfaceType = new List<string>();

                    behaviorTypePoints = new LocationCollection();
                    behaviorType = new List<string>();

                    errorTypePoints = new LocationCollection();
                    errorType = new List<string>();

                string messageText = "Successfully Loaded GPS data!";
                string caption = "Success!";
                MessageBoxButtons okButton = MessageBoxButtons.OK;
                MessageBox.Show(messageText, caption, okButton);

                
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            mediatime = new Timer();
            mediatime.Interval = 1000;
            mediatime.Tick += new EventHandler(mediatime_Tick);
        }

        private void importgpxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Load KML
            //string caption = "Sorry :(";
            //string message = "This version of the program can't import KML yet.\nContact Zach Noonan about getting that fixed!";
            //MessageBoxButtons buttons = MessageBoxButtons.OK;

            //MessageBox.Show(message, caption, buttons);
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            
        }   

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void wmvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FrontVideo1.URL = openFileDialog1.FileName;
                FrontVideo3.URL = openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                BehindVideo1.URL = openFileDialog3.FileName;
                BehindVideo3.URL = openFileDialog3.FileName;
            }
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void videoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                FaceVideo1.URL = openFileDialog4.FileName;
                FaceVideo3.URL = openFileDialog4.FileName;
            }
        }
       
        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void importKMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Actually GPX, NOT KML!!!!!!
            mMapLayer.Children.Clear();
            mRouteLayer.Children.Clear();
            mSurfaceLayer.Children.Clear();
            mBehaviorLayer.Children.Clear();
            mErrorLayer.Children.Clear();
            loadGPX();
        }

        private void bestRouteViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocationRect bestRouteView = new LocationRect(gpxRoutePoints);
            mapUserControl1.map.SetView(bestRouteView);
        }

        private void aerialViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapUserControl1.map.Mode = new AerialMode();
        }

        private void aerialViewWithLablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapUserControl1.map.Mode = new AerialMode(true);
        }

        private void roadViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapUserControl1.map.Mode = new RoadMode();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void addSurfaceType1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SURFACE TYPE 1
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Content = "1";
            pin.Background = new SolidColorBrush(Colors.Blue); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //surfaceType.Add("1");                                //different for each type!
            surfaceType.Add(addSurfaceType1ToolStripMenuItem.Text);
            refreshRoute();
        }

        private void addSurfaceType2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SURFACE TYPE 2
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "2";
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Green); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //surfaceType.Add("2");                                //different for each type!
            surfaceType.Add(addSurfaceType2ToolStripMenuItem.Text);
            refreshRoute();
        }

        private void addSurfaceType3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SURFACE TYPE 3
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "3";
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Yellow); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //surfaceType.Add("3");                                //different for each type!
            surfaceType.Add(addSurfaceType3ToolStripMenuItem.Text);
            refreshRoute();
        }

        private void addSurfaceType4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SURFACE TYPE 4
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "4";
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Orchid); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //surfaceType.Add("4");                                //different for each type!
            surfaceType.Add(addSurfaceType4ToolStripMenuItem.Text);
            refreshRoute();
        }

        private void addSurfaceType5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SURFACE TYPE 5
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "5";
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Red); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);
  
            //surfaceType.Add("5");                                //different for each type!
            surfaceType.Add(addSurfaceType5ToolStripMenuItem.Text);
            refreshRoute();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Surface Type 6
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "6";
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Cyan); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //surfaceType.Add("6");                                //different for each type!
            surfaceType.Add(toolStripMenuItem2.Text);
            refreshRoute();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Surface Type 7
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "7";
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            surfaceTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.LawnGreen); //different for each type!
            pin.Visibility = System.Windows.Visibility.Visible;
            mSurfaceLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //surfaceType.Add("7");                                //different for each type!
            surfaceType.Add(toolStripMenuItem3.Text);
            refreshRoute();
        }

        private void addBehaviorType1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Behavior Type A
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "A";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Blue); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("A");                                //different for each type!
            behaviorType.Add(addBehaviorType1ToolStripMenuItem.Text);
        }

        private void addBehaviorType2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Behavior Type B
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "B";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Green); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("B");                                //different for each type!
            behaviorType.Add(addBehaviorType2ToolStripMenuItem.Text);
        }

        private void addBehaviorType3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Behavior Type C
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "C";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Yellow); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("C");                                //different for each type!
            behaviorType.Add(addBehaviorType3ToolStripMenuItem.Text);
        }

        private void addBehaviorType4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Behavior Type D
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "D";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Orchid); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("D");                                //different for each type!
            behaviorType.Add(addBehaviorType4ToolStripMenuItem.Text);
        }

        private void addBehaviorType5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Behavior Type E
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "E";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Red); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("E");                                //different for each type!
            behaviorType.Add(addBehaviorType5ToolStripMenuItem.Text);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //Behavior Type F
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "F";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Cyan); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("F");                                //different for each type!
            behaviorType.Add(toolStripMenuItem4.Text);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //Behavior Type G
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "G";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            behaviorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.LawnGreen); //different for each type!
            pin.Opacity = .75;
            pin.Visibility = System.Windows.Visibility.Visible;
            mBehaviorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //behaviorType.Add("G");                                //different for each type!
            behaviorType.Add(toolStripMenuItem5.Text);
        }

        private void addErrorType1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Error Type 1
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e1";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e1");                                //different for each type!
            errorType.Add(addErrorType1ToolStripMenuItem.Text);
        }

        private void addErrorType2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Error Type 2
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e2";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e2");                                //different for each type!
            errorType.Add(addErrorType2ToolStripMenuItem.Text);
        }

        private void addErrorType3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Error Type 3
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e3";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e3");                                //different for each type!
            errorType.Add(addErrorType3ToolStripMenuItem.Text);
        }

        private void addErrorType4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Error Type 4
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e4";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e4");                                //different for each type!
            errorType.Add(addErrorType4ToolStripMenuItem.Text);
        }

        private void addErrorType5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Error Type 5
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e5";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e5");                                //different for each type!
            errorType.Add(addErrorType5ToolStripMenuItem.Text);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //Error Type 6
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e6";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e6");                                //different for each type!
            errorType.Add(toolStripMenuItem6.Text);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //Error Type 7
            Pushpin pin = new Pushpin();

            double currentTime = FrontVideo1.Ctlcontrols.currentPosition;

            int i = mediaTimes.Count - 1;
            double time = mediaTimes[i];
            while (time > currentTime)
            {
                i--;
                time = mediaTimes[i];
            }

            pin.Content = "e7";                                //different for each type!
            pin.Location = gpxRoutePoints[i];
            MapLayer.SetPosition(pin, gpxRoutePoints[i]);
            errorTypePoints.Add(gpxRoutePoints[i]);

            pin.Background = new SolidColorBrush(Colors.Crimson);
            pin.Visibility = System.Windows.Visibility.Visible;
            mErrorLayer.Children.Add(pin);
            //mMapLayer.Children.Add(pin);

            //errorType.Add("e7");                                //different for each type!
            errorType.Add(toolStripMenuItem7.Text);
        }

        private void refreshRoute()
        {
            //Refresh Route dummy

            int i = surfaceType.Count - 1;
            int j = gpxRoutePoints.Count - 1;

            LocationCollection tempTypePoints = new LocationCollection();
            List<string> tempType = new List<string>();

            LocationCollection route = new LocationCollection();
            mRouteLayer.Children.Clear();

            MapPolyline routeLine = new MapPolyline();

            System.Windows.Media.Color typeColor = new System.Windows.Media.Color();
            typeColor = Colors.Orchid;

            for (int k = 0; k < gpxRoutePoints.Count; k++)
            {
                for(int l = 0; l < surfaceTypePoints.Count; l++)
                {
                    if(surfaceTypePoints[l] == gpxRoutePoints[k])
                    {
                        tempTypePoints.Add(surfaceTypePoints[l]);
                        tempType.Add(surfaceType[l]);
                    }
                }
            }

            while (i >= 0)
            {
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
                if (tempType[i] == toolStripMenuItem2.Text)
                {
                    typeColor = Colors.Cyan;
                }
                if (tempType[i] == toolStripMenuItem3.Text)
                {
                    typeColor = Colors.LawnGreen;
                }

                while (gpxRoutePoints[j] != tempTypePoints[i])
                {
                    route.Add(gpxRoutePoints[j]);
                    j--;
                }

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

            while (j > 0)
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

        private void surfaceTypeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Surface output

            List<string> surfaceTypeNames = new List<string>();
            string currentSurfaceType = "Default";

            Form2 f = new Form2();
            f.ShowDialog();
            string tripID = f.tripID;

            //Export Surface Type
            for (int i = 0; i < gpxRoutePoints.Count; i++)
            {
                for (int j = 0; j < surfaceType.Count; j++)
                {
                    if (surfaceTypePoints[j] == gpxRoutePoints[i])
                    {
                        currentSurfaceType = surfaceType[j].ToString();
                    }
                }
                surfaceTypeNames.Add(currentSurfaceType);
            }

            saveFileDialog1.Filter = "csv Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string delimiter = ",";

                string[] headers = new string[] { "TripID","Lat", "Lon", "Time_sec", "Speed_Ms", "SurfType", "Acceleration" };
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Join(delimiter,headers));
                for(int i = 0;i< gpxRoutePoints.Count-1;i++)
                {
                    sb.AppendLine(string.Join(delimiter, tripID, gpxRoutePoints[i].Latitude.ToString(),gpxRoutePoints[i].Longitude.ToString(),mediaTimes[i].ToString(),speed[i].ToString(),surfaceTypeNames[i], acceleration[i].ToString()));
                }
                File.WriteAllText(filePath, sb.ToString());
            }

        }

        private void behaviorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Behavior output

            List<string> behaviorTypeNames = new List<string>();
            string currentBehaviorType = "Default";

            Form2 f = new Form2();
            f.ShowDialog();
            string tripID = f.tripID;

            //Export Behavior Type
            for (int i = 0; i < gpxRoutePoints.Count; i++)
            {
                for (int j = 0; j < behaviorType.Count; j++)
                {
                    if (behaviorTypePoints[j] == gpxRoutePoints[i])
                    {
                        currentBehaviorType = behaviorType[j];
                    }
                }
                behaviorTypeNames.Add(currentBehaviorType);
            }

            saveFileDialog1.Filter = "csv Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string delimiter = ",";

                string[] headers = new string[] { "TripID","Lat", "Lon", "Time_sec", "Speed_Ms", "BehavType", "Acceleration" };
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Join(delimiter, headers));
                for (int i = 0; i < gpxRoutePoints.Count - 1; i++)
                {
                    sb.AppendLine(string.Join(delimiter, tripID,gpxRoutePoints[i].Latitude.ToString(), gpxRoutePoints[i].Longitude.ToString(), mediaTimes[i].ToString(), speed[i].ToString(), behaviorTypeNames[i], acceleration[i].ToString()));
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }

        private void errorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Error output

            List<string> errorTypeNames = new List<string>();
            string currentErrorType = "";

            Form2 f = new Form2();
            f.ShowDialog();
            string tripID = f.tripID;

            //Export Error Type
            for (int i = 0; i < gpxRoutePoints.Count; i++)
            {
                for (int j = 0; j < errorType.Count; j++)
                {
                    if (errorTypePoints[j] == gpxRoutePoints[i])
                    {
                        currentErrorType = errorType[j];
                        j = errorType.Count-1;
                    }
                    else
                    {
                        currentErrorType = "";
                    }
                }
                errorTypeNames.Add(currentErrorType);
            }

            saveFileDialog1.Filter = "csv Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string delimiter = ",";

                string[] headers = new string[] { "TripID", "Lat", "Lon", "Time_sec", "Speed_Ms", "ErrorType", "Acceleration" };
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Join(delimiter, headers));
                for (int i = 0; i < gpxRoutePoints.Count - 1; i++)
                {
                    sb.AppendLine(string.Join(delimiter, tripID, gpxRoutePoints[i].Latitude.ToString(), gpxRoutePoints[i].Longitude.ToString(), mediaTimes[i].ToString(), speed[i].ToString(), errorTypeNames[i], acceleration[i].ToString()));
                }
                File.WriteAllText(filePath, sb.ToString());
            }
        }

        private void combinedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Combined output

            List<string> surfaceTypeNames = new List<string>();
            string currentSurfaceType = "Default";

            List<string> behaviorTypeNames = new List<string>();
            string currentBehaviorType = "Default";

            List<string> errorTypeNames = new List<string>();
            string currentErrorType = "";

            Form2 f = new Form2();
            f.ShowDialog();
            string tripID = f.tripID;

            for (int i = 0; i < gpxRoutePoints.Count; i++)
            {
                for (int j = 0; j < surfaceType.Count; j++)
                {
                    if (surfaceTypePoints[j] == gpxRoutePoints[i])
                    {
                        currentSurfaceType = surfaceType[j].ToString();
                    }
                }
                for (int j = 0; j < behaviorType.Count; j++)
                {
                    if (behaviorTypePoints[j] == gpxRoutePoints[i])
                    {
                        currentBehaviorType = behaviorType[j];
                    }
                }
                for (int j = 0; j < errorType.Count; j++)
                {
                    if (errorTypePoints[j] == gpxRoutePoints[i])
                    {
                        currentErrorType = errorType[j];
                        j = errorType.Count - 1;
                    }
                    else
                    {
                        currentErrorType = "";
                    }
                }
                surfaceTypeNames.Add(currentSurfaceType);
                behaviorTypeNames.Add(currentBehaviorType);
                errorTypeNames.Add(currentErrorType);
            }

            saveFileDialog1.Filter = "csv Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string delimiter = ",";

                string[] headers = new string[] { "TripID", "Lat", "Lon", "Time_Sec","Speed_Ms","SurfType","BehavType", "ErrorType", "Acceleration" };
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(string.Join(delimiter, headers));
                for (int i = 0; i < gpxRoutePoints.Count - 1; i++)
                {
                    sb.AppendLine(string.Join(delimiter, tripID, gpxRoutePoints[i].Latitude.ToString(), gpxRoutePoints[i].Longitude.ToString(), mediaTimes[i].ToString(), speed[i].ToString(), surfaceTypeNames[i],behaviorTypeNames[i],errorTypeNames[i], acceleration[i].ToString()));
                }
                File.WriteAllText(filePath, sb.ToString());
            }

        }

        private void removeLastSurfaceTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove Last surface Type

            if (mSurfaceLayer.Children.Count > 0)
            {
                mSurfaceLayer.Children.RemoveAt(mSurfaceLayer.Children.Count - 1);
            }
            if (surfaceType.Count > 0)
            {
                surfaceType.RemoveAt(surfaceType.Count - 1);
                surfaceTypePoints.RemoveAt(surfaceTypePoints.Count - 1);
                refreshRoute();
            }
        }

        private void removeLastBehaviorTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove Last behavior type

            if (mBehaviorLayer.Children.Count > 0)
            {
                mBehaviorLayer.Children.RemoveAt(mBehaviorLayer.Children.Count - 1);
            }
            if (behaviorType.Count > 0)
            {
                behaviorType.RemoveAt(behaviorType.Count - 1);
                behaviorTypePoints.RemoveAt(behaviorTypePoints.Count - 1);
            }
        }

        private void removeLastErrorTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove Last error

            if (mErrorLayer.Children.Count > 0)
            {
                mErrorLayer.Children.RemoveAt(mErrorLayer.Children.Count - 1);
            }
            if (errorType.Count > 0)
            {
                errorType.RemoveAt(errorType.Count - 1);
                errorTypePoints.RemoveAt(errorTypePoints.Count - 1);
            }
        }

        private void clearMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear Map
            surfaceType.Clear();
            surfaceTypePoints.Clear();
            mSurfaceLayer.Children.Clear();

            behaviorType.Clear();
            behaviorTypePoints.Clear();
            mBehaviorLayer.Children.Clear();

            errorType.Clear();
            errorTypePoints.Clear();
            mErrorLayer.Children.Clear();

            refreshRoute();
        }

        private void routeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Refresh Map
            refreshRoute();

        }

        private void clearSurfaceTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear Surface Types

            surfaceType.Clear();
            surfaceTypePoints.Clear();
            mSurfaceLayer.Children.Clear();

            refreshRoute();
        }

        private void clearBehaviorTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear Behavior Types

            behaviorType.Clear();
            behaviorTypePoints.Clear();
            mBehaviorLayer.Children.Clear();

        }

        private void clearErrorTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear Error Types

            errorType.Clear();
            errorTypePoints.Clear();
            mErrorLayer.Children.Clear();

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
            toolStripMenuItem2.Text = f.surface6;
            toolStripMenuItem3.Text = f.surface7;
        }

        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Rename Behavior
            Form4 f = new Form4();
            f.ShowDialog();
            addBehaviorType1ToolStripMenuItem.Text = f.behavior1;
            addBehaviorType2ToolStripMenuItem.Text = f.behavior2;
            addBehaviorType3ToolStripMenuItem.Text = f.behavior3;
            addBehaviorType4ToolStripMenuItem.Text = f.behavior4;
            addBehaviorType5ToolStripMenuItem.Text = f.behavior5;
            toolStripMenuItem4.Text = f.behavior6;
            toolStripMenuItem5.Text = f.behavior7;
        }

        private void renameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Rename Error
            Form5 f = new Form5();
            f.ShowDialog();
            addErrorType1ToolStripMenuItem.Text = f.error1;
            addErrorType2ToolStripMenuItem.Text = f.error2;
            addErrorType3ToolStripMenuItem.Text = f.error3;
            addErrorType4ToolStripMenuItem.Text = f.error4;
            addErrorType5ToolStripMenuItem.Text = f.error5;
            toolStripMenuItem6.Text = f.error6;
            toolStripMenuItem7.Text = f.error7;
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            mapUserControl1.map.ZoomLevel = mapUserControl1.map.ZoomLevel - .5;
        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            mapUserControl1.map.ZoomLevel = mapUserControl1.map.ZoomLevel + .5;
        }

        private void videoPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pause Video
            if ((FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying) || (BehindVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying) || (FaceVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying) || (FrontVideo3.playState == WMPLib.WMPPlayState.wmppsPlaying) || (BehindVideo3.playState == WMPLib.WMPPlayState.wmppsPlaying) || (FaceVideo3.playState == WMPLib.WMPPlayState.wmppsPlaying))
            {
                FrontVideo1.Ctlcontrols.pause();
                BehindVideo1.Ctlcontrols.pause();
                FaceVideo1.Ctlcontrols.pause();
                FrontVideo3.Ctlcontrols.pause();
                BehindVideo3.Ctlcontrols.pause();
                FaceVideo3.Ctlcontrols.pause();
                playpausebutton.Image = Properties.Resources.Play_button;
                mediatime.Stop();
            }
            else if ((FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPaused) || (BehindVideo1.playState == WMPLib.WMPPlayState.wmppsPaused) || (FaceVideo1.playState == WMPLib.WMPPlayState.wmppsPaused) || (FrontVideo3.playState == WMPLib.WMPPlayState.wmppsPaused) || (BehindVideo3.playState == WMPLib.WMPPlayState.wmppsPaused) || (FaceVideo3.playState == WMPLib.WMPPlayState.wmppsPaused))
            {
                FrontVideo1.Ctlcontrols.play();
                BehindVideo1.Ctlcontrols.play();
                FaceVideo1.Ctlcontrols.play();
                FrontVideo3.Ctlcontrols.play();
                BehindVideo3.Ctlcontrols.play();
                FaceVideo3.Ctlcontrols.play();
                playpausebutton.Image = Properties.Resources.pause_button;
                mediatime.Start();
            }
        }

        private void videoFastFWDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Increase Video Playspeed
            if (videoFastFWDToolStripMenuItem.Checked == false)
            {
                FrontVideo1.Ctlcontrols.fastForward();
                BehindVideo1.Ctlcontrols.fastForward();
                FaceVideo1.Ctlcontrols.fastForward();
                FrontVideo3.Ctlcontrols.fastForward();
                BehindVideo3.Ctlcontrols.fastForward();
                FaceVideo3.Ctlcontrols.fastForward();
            }
            if (videoFastFWDToolStripMenuItem.Checked == true)
            {
                FrontVideo1.Ctlcontrols.play();               
                BehindVideo1.Ctlcontrols.play();
                FaceVideo1.Ctlcontrols.play();
                FrontVideo3.Ctlcontrols.play();
                BehindVideo3.Ctlcontrols.play();
                FaceVideo3.Ctlcontrols.play();
            }

        }

        private void videoSlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Decrease Video Playspeed
            if (videoSlowToolStripMenuItem.Checked == false)
            {
                
            }
        }
        private void ViewAll_Click(object sender, EventArgs e)
        {

        }

        private void FaceVideo3_Enter(object sender, EventArgs e)
        {

        }

        private void playpausebutton_Click(object sender, EventArgs e)
        {
            //Pause Video
            if ((FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying) || (BehindVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying) || (FaceVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying) || (FrontVideo3.playState == WMPLib.WMPPlayState.wmppsPlaying) || (BehindVideo3.playState == WMPLib.WMPPlayState.wmppsPlaying) || (FaceVideo3.playState == WMPLib.WMPPlayState.wmppsPlaying))
            {
                FrontVideo1.Ctlcontrols.pause();
                BehindVideo1.Ctlcontrols.pause();
                FaceVideo1.Ctlcontrols.pause();
                FrontVideo3.Ctlcontrols.pause();
                BehindVideo3.Ctlcontrols.pause();
                FaceVideo3.Ctlcontrols.pause();
                playpausebutton.Image = Properties.Resources.Play_button;
                mediatime.Stop();
            }
            else if ((FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPaused) || (BehindVideo1.playState == WMPLib.WMPPlayState.wmppsPaused) || (FaceVideo1.playState == WMPLib.WMPPlayState.wmppsPaused) || (FrontVideo3.playState == WMPLib.WMPPlayState.wmppsPaused) || (BehindVideo3.playState == WMPLib.WMPPlayState.wmppsPaused) || (FaceVideo3.playState == WMPLib.WMPPlayState.wmppsPaused) || (FrontVideo1.playState == WMPLib.WMPPlayState.wmppsStopped) || (FrontVideo1.playState == WMPLib.WMPPlayState.wmppsReady))
            {
                FrontVideo1.Ctlcontrols.play();
                BehindVideo1.Ctlcontrols.play();
                FaceVideo1.Ctlcontrols.play();
                FrontVideo3.Ctlcontrols.play();
                BehindVideo3.Ctlcontrols.play();
                FaceVideo3.Ctlcontrols.play();
                playpausebutton.Image = Properties.Resources.pause_button;

                FrontVideo1.PlayStateChange += FrontVideo1_PlayStateChange;

            }
        }

        void FrontVideo1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                trackBar1.Maximum = (int)FrontVideo1.Ctlcontrols.currentItem.duration;
                mediatime.Start();
            }
            else if (FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                mediatime.Stop();
            }
            else if (FrontVideo1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                mediatime.Stop();
                trackBar1.Value = 0;
            }            
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            FrontVideo1.Ctlcontrols.stop();
            BehindVideo1.Ctlcontrols.stop();
            FaceVideo1.Ctlcontrols.stop();
            FrontVideo3.Ctlcontrols.stop();
            BehindVideo3.Ctlcontrols.stop();
            FaceVideo3.Ctlcontrols.stop();

            playpausebutton.Image = Properties.Resources.Play_button;
            trackBar1.Value = 0;
            mediatime.Stop();
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            FrontVideo1.Ctlcontrols.pause();
            BehindVideo1.Ctlcontrols.pause();
            FaceVideo1.Ctlcontrols.pause();
            FrontVideo3.Ctlcontrols.pause();
            BehindVideo3.Ctlcontrols.pause();
            FaceVideo3.Ctlcontrols.pause();

            FrontVideo1.Ctlcontrols.currentPosition = trackBar1.Value;
            BehindVideo1.Ctlcontrols.currentPosition = trackBar1.Value;
            FaceVideo1.Ctlcontrols.currentPosition = trackBar1.Value;
            FrontVideo1.Ctlcontrols.currentPosition = trackBar1.Value;
            FrontVideo3.Ctlcontrols.currentPosition = trackBar1.Value;
            BehindVideo3.Ctlcontrols.currentPosition = trackBar1.Value;
            FaceVideo3.Ctlcontrols.currentPosition = trackBar1.Value;

            FrontVideo1.Ctlcontrols.play();
            BehindVideo1.Ctlcontrols.play();
            FaceVideo1.Ctlcontrols.play();
            FrontVideo3.Ctlcontrols.play();
            BehindVideo3.Ctlcontrols.play();
            FaceVideo3.Ctlcontrols.play();
        }

        private void mediatime_Tick(object sender, EventArgs e)
        {
            try
            {
                if (FrontVideo1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    trackBar1.Value = (int)FrontVideo1.Ctlcontrols.currentPosition;
                }
            }
            catch { }
        }

        private void volumebutton_Click(object sender, EventArgs e)
        {
            if (FrontVideo1.settings.mute == false)
            {
                FrontVideo1.settings.mute = true; 
                FrontVideo3.settings.mute = true;
                BehindVideo1.settings.mute = true;
                BehindVideo3.settings.mute = true;
                FaceVideo1.settings.mute = true;
                FaceVideo3.settings.mute = true;
                volumebutton.Image = Properties.Resources.volumebutton;
            }
            else if (FrontVideo1.settings.mute == true)
            {
                FrontVideo1.settings.mute = false;
                FrontVideo3.settings.mute = false;
                BehindVideo1.settings.mute = false;
                BehindVideo3.settings.mute = false;
                FaceVideo1.settings.mute = false;
                FaceVideo3.settings.mute = false;
                volumebutton.Image = Properties.Resources.novolumebutton;
            }
        }
    }
}
