namespace MapApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zoomin = new System.Windows.Forms.Button();
            this.zoomout = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.mapUserControl1 = new MapApp.MapUserControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPSDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importgpxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importKMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrontvideoDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.behindVideoDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportBehindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faceVideoDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestRouteViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeMapViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aerialViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aerialViewWithLablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roadViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoFastFWDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoSlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roadwaySurfaceTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSurfaceType1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSurfaceType2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSurfaceType3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSurfaceType4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSurfaceType5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastSurfaceTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSurfaceTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riderBehaviorTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBehaviorType1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBehaviorType2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBehaviorType3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBehaviorType4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBehaviorType5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastBehaviorTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBehaviorTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.riderErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addErrorType1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addErrorType2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addErrorType3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addErrorType4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addErrorType5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastErrorTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearErrorTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.surfaceTypeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.behaviorDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combinedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumebutton = new System.Windows.Forms.Button();
            this.stopbutton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.playpausebutton = new System.Windows.Forms.Button();
            this.CameraView = new System.Windows.Forms.TabControl();
            this.FrontView = new System.Windows.Forms.TabPage();
            this.FrontVideo1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.BehindView = new System.Windows.Forms.TabPage();
            this.BehindVideo1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.FaceView = new System.Windows.Forms.TabPage();
            this.FaceVideo1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.ViewAll = new System.Windows.Forms.TabPage();
            this.AllVideo = new System.Windows.Forms.TableLayoutPanel();
            this.FrontVideo3 = new AxWMPLib.AxWindowsMediaPlayer();
            this.BehindVideo3 = new AxWMPLib.AxWindowsMediaPlayer();
            this.FaceVideo3 = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gpsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.CameraView.SuspendLayout();
            this.FrontView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrontVideo1)).BeginInit();
            this.BehindView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BehindVideo1)).BeginInit();
            this.FaceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FaceVideo1)).BeginInit();
            this.ViewAll.SuspendLayout();
            this.AllVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrontVideo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BehindVideo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceVideo3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            this.openFileDialog3.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog3_FileOk);
            // 
            // openFileDialog4
            // 
            this.openFileDialog4.FileName = "openFileDialog3";
            this.openFileDialog4.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog4_FileOk);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpsLabel);
            this.splitContainer1.Panel1.Controls.Add(this.zoomin);
            this.splitContainer1.Panel1.Controls.Add(this.zoomout);
            this.splitContainer1.Panel1.Controls.Add(this.elementHost1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.volumebutton);
            this.splitContainer1.Panel2.Controls.Add(this.stopbutton);
            this.splitContainer1.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel2.Controls.Add(this.playpausebutton);
            this.splitContainer1.Panel2.Controls.Add(this.CameraView);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1395, 821);
            this.splitContainer1.SplitterDistance = 677;
            this.splitContainer1.TabIndex = 0;
            // 
            // zoomin
            // 
            this.zoomin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomin.Location = new System.Drawing.Point(462, 770);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(26, 39);
            this.zoomin.TabIndex = 5;
            this.zoomin.Text = "+";
            this.zoomin.UseVisualStyleBackColor = true;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            // 
            // zoomout
            // 
            this.zoomout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomout.Location = new System.Drawing.Point(430, 770);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(26, 39);
            this.zoomout.TabIndex = 4;
            this.zoomout.Text = "-";
            this.zoomout.UseVisualStyleBackColor = true;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 24);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(677, 797);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.elementHost1_ChildChanged);
            this.elementHost1.Child = this.mapUserControl1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.roadwaySurfaceTypeToolStripMenuItem,
            this.riderBehaviorTypeToolStripMenuItem,
            this.riderErrorToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(677, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gPSDataToolStripMenuItem,
            this.FrontvideoDataToolStripMenuItem,
            this.behindVideoDataToolStripMenuItem,
            this.faceVideoDataToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // gPSDataToolStripMenuItem
            // 
            this.gPSDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importgpxToolStripMenuItem,
            this.importKMLToolStripMenuItem});
            this.gPSDataToolStripMenuItem.Name = "gPSDataToolStripMenuItem";
            this.gPSDataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.gPSDataToolStripMenuItem.Text = "GPS data";
            // 
            // importgpxToolStripMenuItem
            // 
            this.importgpxToolStripMenuItem.Name = "importgpxToolStripMenuItem";
            this.importgpxToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.importgpxToolStripMenuItem.Text = "KML";
            this.importgpxToolStripMenuItem.Click += new System.EventHandler(this.importgpxToolStripMenuItem_Click);
            // 
            // importKMLToolStripMenuItem
            // 
            this.importKMLToolStripMenuItem.Name = "importKMLToolStripMenuItem";
            this.importKMLToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.importKMLToolStripMenuItem.Text = "GPX";
            this.importKMLToolStripMenuItem.Click += new System.EventHandler(this.importKMLToolStripMenuItem_Click);
            // 
            // FrontvideoDataToolStripMenuItem
            // 
            this.FrontvideoDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportFrontToolStripMenuItem});
            this.FrontvideoDataToolStripMenuItem.Name = "FrontvideoDataToolStripMenuItem";
            this.FrontvideoDataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.FrontvideoDataToolStripMenuItem.Text = "Front Video data";
            // 
            // ImportFrontToolStripMenuItem
            // 
            this.ImportFrontToolStripMenuItem.Name = "ImportFrontToolStripMenuItem";
            this.ImportFrontToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ImportFrontToolStripMenuItem.Text = "Video...";
            this.ImportFrontToolStripMenuItem.Click += new System.EventHandler(this.wmvToolStripMenuItem_Click);
            // 
            // behindVideoDataToolStripMenuItem
            // 
            this.behindVideoDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportBehindToolStripMenuItem});
            this.behindVideoDataToolStripMenuItem.Name = "behindVideoDataToolStripMenuItem";
            this.behindVideoDataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.behindVideoDataToolStripMenuItem.Text = "Behind Video data";
            // 
            // ImportBehindToolStripMenuItem
            // 
            this.ImportBehindToolStripMenuItem.Name = "ImportBehindToolStripMenuItem";
            this.ImportBehindToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ImportBehindToolStripMenuItem.Text = "Video...";
            this.ImportBehindToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // faceVideoDataToolStripMenuItem
            // 
            this.faceVideoDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportFaceToolStripMenuItem1});
            this.faceVideoDataToolStripMenuItem.Name = "faceVideoDataToolStripMenuItem";
            this.faceVideoDataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.faceVideoDataToolStripMenuItem.Text = "Face Video data";
            // 
            // ImportFaceToolStripMenuItem1
            // 
            this.ImportFaceToolStripMenuItem1.Name = "ImportFaceToolStripMenuItem1";
            this.ImportFaceToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.ImportFaceToolStripMenuItem1.Text = "Video...";
            this.ImportFaceToolStripMenuItem1.Click += new System.EventHandler(this.videoToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestRouteViewToolStripMenuItem,
            this.changeMapViewToolStripMenuItem,
            this.routeDataToolStripMenuItem,
            this.clearMapToolStripMenuItem,
            this.videoPauseToolStripMenuItem,
            this.videoFastFWDToolStripMenuItem,
            this.videoSlowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.viewToolStripMenuItem.Text = "Map";
            // 
            // bestRouteViewToolStripMenuItem
            // 
            this.bestRouteViewToolStripMenuItem.Name = "bestRouteViewToolStripMenuItem";
            this.bestRouteViewToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.bestRouteViewToolStripMenuItem.Text = "Center on Route";
            this.bestRouteViewToolStripMenuItem.Click += new System.EventHandler(this.bestRouteViewToolStripMenuItem_Click);
            // 
            // changeMapViewToolStripMenuItem
            // 
            this.changeMapViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aerialViewToolStripMenuItem,
            this.aerialViewWithLablesToolStripMenuItem,
            this.roadViewToolStripMenuItem});
            this.changeMapViewToolStripMenuItem.Name = "changeMapViewToolStripMenuItem";
            this.changeMapViewToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.changeMapViewToolStripMenuItem.Text = "Change Map View";
            // 
            // aerialViewToolStripMenuItem
            // 
            this.aerialViewToolStripMenuItem.Name = "aerialViewToolStripMenuItem";
            this.aerialViewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aerialViewToolStripMenuItem.Text = "Aerial View";
            this.aerialViewToolStripMenuItem.Click += new System.EventHandler(this.aerialViewToolStripMenuItem_Click);
            // 
            // aerialViewWithLablesToolStripMenuItem
            // 
            this.aerialViewWithLablesToolStripMenuItem.Name = "aerialViewWithLablesToolStripMenuItem";
            this.aerialViewWithLablesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aerialViewWithLablesToolStripMenuItem.Text = "Aerial View with Labels";
            this.aerialViewWithLablesToolStripMenuItem.Click += new System.EventHandler(this.aerialViewWithLablesToolStripMenuItem_Click);
            // 
            // roadViewToolStripMenuItem
            // 
            this.roadViewToolStripMenuItem.Name = "roadViewToolStripMenuItem";
            this.roadViewToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.roadViewToolStripMenuItem.Text = "Road View";
            this.roadViewToolStripMenuItem.Click += new System.EventHandler(this.roadViewToolStripMenuItem_Click);
            // 
            // routeDataToolStripMenuItem
            // 
            this.routeDataToolStripMenuItem.Name = "routeDataToolStripMenuItem";
            this.routeDataToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.routeDataToolStripMenuItem.Text = "Refresh Map";
            this.routeDataToolStripMenuItem.Click += new System.EventHandler(this.routeDataToolStripMenuItem_Click);
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.clearMapToolStripMenuItem.Text = "Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // videoPauseToolStripMenuItem
            // 
            this.videoPauseToolStripMenuItem.Name = "videoPauseToolStripMenuItem";
            this.videoPauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.videoPauseToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.videoPauseToolStripMenuItem.Text = "Video Pause";
            this.videoPauseToolStripMenuItem.Visible = false;
            this.videoPauseToolStripMenuItem.Click += new System.EventHandler(this.videoPauseToolStripMenuItem_Click);
            // 
            // videoFastFWDToolStripMenuItem
            // 
            this.videoFastFWDToolStripMenuItem.CheckOnClick = true;
            this.videoFastFWDToolStripMenuItem.Name = "videoFastFWDToolStripMenuItem";
            this.videoFastFWDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.videoFastFWDToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.videoFastFWDToolStripMenuItem.Text = "Video Fast FWD";
            this.videoFastFWDToolStripMenuItem.Click += new System.EventHandler(this.videoFastFWDToolStripMenuItem_Click);
            // 
            // videoSlowToolStripMenuItem
            // 
            this.videoSlowToolStripMenuItem.CheckOnClick = true;
            this.videoSlowToolStripMenuItem.Name = "videoSlowToolStripMenuItem";
            this.videoSlowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.videoSlowToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.videoSlowToolStripMenuItem.Text = "Video Slow";
            this.videoSlowToolStripMenuItem.Visible = false;
            this.videoSlowToolStripMenuItem.Click += new System.EventHandler(this.videoSlowToolStripMenuItem_Click);
            // 
            // roadwaySurfaceTypeToolStripMenuItem
            // 
            this.roadwaySurfaceTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSurfaceType1ToolStripMenuItem,
            this.addSurfaceType2ToolStripMenuItem,
            this.addSurfaceType3ToolStripMenuItem,
            this.addSurfaceType4ToolStripMenuItem,
            this.addSurfaceType5ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.removeLastSurfaceTypeToolStripMenuItem,
            this.clearSurfaceTypesToolStripMenuItem,
            this.renameToolStripMenuItem});
            this.roadwaySurfaceTypeToolStripMenuItem.Name = "roadwaySurfaceTypeToolStripMenuItem";
            this.roadwaySurfaceTypeToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.roadwaySurfaceTypeToolStripMenuItem.Text = "Roadway/Surface Type";
            // 
            // addSurfaceType1ToolStripMenuItem
            // 
            this.addSurfaceType1ToolStripMenuItem.Name = "addSurfaceType1ToolStripMenuItem";
            this.addSurfaceType1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.addSurfaceType1ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addSurfaceType1ToolStripMenuItem.Text = "Surface Type 1";
            this.addSurfaceType1ToolStripMenuItem.Click += new System.EventHandler(this.addSurfaceType1ToolStripMenuItem_Click);
            // 
            // addSurfaceType2ToolStripMenuItem
            // 
            this.addSurfaceType2ToolStripMenuItem.Name = "addSurfaceType2ToolStripMenuItem";
            this.addSurfaceType2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.addSurfaceType2ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addSurfaceType2ToolStripMenuItem.Text = "Surface Type 2";
            this.addSurfaceType2ToolStripMenuItem.Click += new System.EventHandler(this.addSurfaceType2ToolStripMenuItem_Click);
            // 
            // addSurfaceType3ToolStripMenuItem
            // 
            this.addSurfaceType3ToolStripMenuItem.Name = "addSurfaceType3ToolStripMenuItem";
            this.addSurfaceType3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.addSurfaceType3ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addSurfaceType3ToolStripMenuItem.Text = "Surface Type 3";
            this.addSurfaceType3ToolStripMenuItem.Click += new System.EventHandler(this.addSurfaceType3ToolStripMenuItem_Click);
            // 
            // addSurfaceType4ToolStripMenuItem
            // 
            this.addSurfaceType4ToolStripMenuItem.Name = "addSurfaceType4ToolStripMenuItem";
            this.addSurfaceType4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.addSurfaceType4ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addSurfaceType4ToolStripMenuItem.Text = "Surface Type 4";
            this.addSurfaceType4ToolStripMenuItem.Click += new System.EventHandler(this.addSurfaceType4ToolStripMenuItem_Click);
            // 
            // addSurfaceType5ToolStripMenuItem
            // 
            this.addSurfaceType5ToolStripMenuItem.Name = "addSurfaceType5ToolStripMenuItem";
            this.addSurfaceType5ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.addSurfaceType5ToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addSurfaceType5ToolStripMenuItem.Text = "Surface Type 5";
            this.addSurfaceType5ToolStripMenuItem.Click += new System.EventHandler(this.addSurfaceType5ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem2.Text = "Surface Type 6";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem3.Text = "Surface Type 7";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // removeLastSurfaceTypeToolStripMenuItem
            // 
            this.removeLastSurfaceTypeToolStripMenuItem.Name = "removeLastSurfaceTypeToolStripMenuItem";
            this.removeLastSurfaceTypeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.removeLastSurfaceTypeToolStripMenuItem.Text = "Remove Last Surface Type";
            this.removeLastSurfaceTypeToolStripMenuItem.Click += new System.EventHandler(this.removeLastSurfaceTypeToolStripMenuItem_Click);
            // 
            // clearSurfaceTypesToolStripMenuItem
            // 
            this.clearSurfaceTypesToolStripMenuItem.Name = "clearSurfaceTypesToolStripMenuItem";
            this.clearSurfaceTypesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.clearSurfaceTypesToolStripMenuItem.Text = "Clear Surface Types";
            this.clearSurfaceTypesToolStripMenuItem.Click += new System.EventHandler(this.clearSurfaceTypesToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // riderBehaviorTypeToolStripMenuItem
            // 
            this.riderBehaviorTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBehaviorType1ToolStripMenuItem,
            this.addBehaviorType2ToolStripMenuItem,
            this.addBehaviorType3ToolStripMenuItem,
            this.addBehaviorType4ToolStripMenuItem,
            this.addBehaviorType5ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.removeLastBehaviorTypeToolStripMenuItem,
            this.clearBehaviorTypesToolStripMenuItem,
            this.renameToolStripMenuItem1});
            this.riderBehaviorTypeToolStripMenuItem.Name = "riderBehaviorTypeToolStripMenuItem";
            this.riderBehaviorTypeToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.riderBehaviorTypeToolStripMenuItem.Text = "Rider Behavior Type";
            // 
            // addBehaviorType1ToolStripMenuItem
            // 
            this.addBehaviorType1ToolStripMenuItem.Name = "addBehaviorType1ToolStripMenuItem";
            this.addBehaviorType1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.addBehaviorType1ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addBehaviorType1ToolStripMenuItem.Text = "Behavior Type A";
            this.addBehaviorType1ToolStripMenuItem.Click += new System.EventHandler(this.addBehaviorType1ToolStripMenuItem_Click);
            // 
            // addBehaviorType2ToolStripMenuItem
            // 
            this.addBehaviorType2ToolStripMenuItem.Name = "addBehaviorType2ToolStripMenuItem";
            this.addBehaviorType2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.addBehaviorType2ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addBehaviorType2ToolStripMenuItem.Text = "Behavior Type B";
            this.addBehaviorType2ToolStripMenuItem.Click += new System.EventHandler(this.addBehaviorType2ToolStripMenuItem_Click);
            // 
            // addBehaviorType3ToolStripMenuItem
            // 
            this.addBehaviorType3ToolStripMenuItem.Name = "addBehaviorType3ToolStripMenuItem";
            this.addBehaviorType3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.addBehaviorType3ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addBehaviorType3ToolStripMenuItem.Text = "Behavior Type C";
            this.addBehaviorType3ToolStripMenuItem.Click += new System.EventHandler(this.addBehaviorType3ToolStripMenuItem_Click);
            // 
            // addBehaviorType4ToolStripMenuItem
            // 
            this.addBehaviorType4ToolStripMenuItem.Name = "addBehaviorType4ToolStripMenuItem";
            this.addBehaviorType4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.addBehaviorType4ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addBehaviorType4ToolStripMenuItem.Text = "Behavior Type D";
            this.addBehaviorType4ToolStripMenuItem.Click += new System.EventHandler(this.addBehaviorType4ToolStripMenuItem_Click);
            // 
            // addBehaviorType5ToolStripMenuItem
            // 
            this.addBehaviorType5ToolStripMenuItem.Name = "addBehaviorType5ToolStripMenuItem";
            this.addBehaviorType5ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.addBehaviorType5ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.addBehaviorType5ToolStripMenuItem.Text = "Behavior Type E";
            this.addBehaviorType5ToolStripMenuItem.Click += new System.EventHandler(this.addBehaviorType5ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItem4.Text = "Behavior Type F";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItem5.Text = "Behavior Type G";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // removeLastBehaviorTypeToolStripMenuItem
            // 
            this.removeLastBehaviorTypeToolStripMenuItem.Name = "removeLastBehaviorTypeToolStripMenuItem";
            this.removeLastBehaviorTypeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.removeLastBehaviorTypeToolStripMenuItem.Text = "Remove Last Behavior Type";
            this.removeLastBehaviorTypeToolStripMenuItem.Click += new System.EventHandler(this.removeLastBehaviorTypeToolStripMenuItem_Click);
            // 
            // clearBehaviorTypesToolStripMenuItem
            // 
            this.clearBehaviorTypesToolStripMenuItem.Name = "clearBehaviorTypesToolStripMenuItem";
            this.clearBehaviorTypesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.clearBehaviorTypesToolStripMenuItem.Text = "Clear Behavior Types";
            this.clearBehaviorTypesToolStripMenuItem.Click += new System.EventHandler(this.clearBehaviorTypesToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem1
            // 
            this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
            this.renameToolStripMenuItem1.Size = new System.Drawing.Size(218, 22);
            this.renameToolStripMenuItem1.Text = "Rename";
            this.renameToolStripMenuItem1.Click += new System.EventHandler(this.renameToolStripMenuItem1_Click);
            // 
            // riderErrorToolStripMenuItem
            // 
            this.riderErrorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addErrorType1ToolStripMenuItem,
            this.addErrorType2ToolStripMenuItem,
            this.addErrorType3ToolStripMenuItem,
            this.addErrorType4ToolStripMenuItem,
            this.addErrorType5ToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.removeLastErrorTypeToolStripMenuItem,
            this.clearErrorTypesToolStripMenuItem,
            this.renameToolStripMenuItem2});
            this.riderErrorToolStripMenuItem.Name = "riderErrorToolStripMenuItem";
            this.riderErrorToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.riderErrorToolStripMenuItem.Text = "Rider Error";
            // 
            // addErrorType1ToolStripMenuItem
            // 
            this.addErrorType1ToolStripMenuItem.Name = "addErrorType1ToolStripMenuItem";
            this.addErrorType1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.addErrorType1ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addErrorType1ToolStripMenuItem.Text = "Error Type 1";
            this.addErrorType1ToolStripMenuItem.Click += new System.EventHandler(this.addErrorType1ToolStripMenuItem_Click);
            // 
            // addErrorType2ToolStripMenuItem
            // 
            this.addErrorType2ToolStripMenuItem.Name = "addErrorType2ToolStripMenuItem";
            this.addErrorType2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.addErrorType2ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addErrorType2ToolStripMenuItem.Text = "Error Type 2";
            this.addErrorType2ToolStripMenuItem.Click += new System.EventHandler(this.addErrorType2ToolStripMenuItem_Click);
            // 
            // addErrorType3ToolStripMenuItem
            // 
            this.addErrorType3ToolStripMenuItem.Name = "addErrorType3ToolStripMenuItem";
            this.addErrorType3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.addErrorType3ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addErrorType3ToolStripMenuItem.Text = "Error Type 3";
            this.addErrorType3ToolStripMenuItem.Click += new System.EventHandler(this.addErrorType3ToolStripMenuItem_Click);
            // 
            // addErrorType4ToolStripMenuItem
            // 
            this.addErrorType4ToolStripMenuItem.Name = "addErrorType4ToolStripMenuItem";
            this.addErrorType4ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.addErrorType4ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addErrorType4ToolStripMenuItem.Text = "Error Type 4";
            this.addErrorType4ToolStripMenuItem.Click += new System.EventHandler(this.addErrorType4ToolStripMenuItem_Click);
            // 
            // addErrorType5ToolStripMenuItem
            // 
            this.addErrorType5ToolStripMenuItem.Name = "addErrorType5ToolStripMenuItem";
            this.addErrorType5ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.addErrorType5ToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addErrorType5ToolStripMenuItem.Text = "Error Type 5";
            this.addErrorType5ToolStripMenuItem.Click += new System.EventHandler(this.addErrorType5ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem6.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem6.Text = "Error Type 6";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.toolStripMenuItem7.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem7.Text = "Error Type 7";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // removeLastErrorTypeToolStripMenuItem
            // 
            this.removeLastErrorTypeToolStripMenuItem.Name = "removeLastErrorTypeToolStripMenuItem";
            this.removeLastErrorTypeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.removeLastErrorTypeToolStripMenuItem.Text = "Remove Last Error Type";
            this.removeLastErrorTypeToolStripMenuItem.Click += new System.EventHandler(this.removeLastErrorTypeToolStripMenuItem_Click);
            // 
            // clearErrorTypesToolStripMenuItem
            // 
            this.clearErrorTypesToolStripMenuItem.Name = "clearErrorTypesToolStripMenuItem";
            this.clearErrorTypesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.clearErrorTypesToolStripMenuItem.Text = "Clear Error Types";
            this.clearErrorTypesToolStripMenuItem.Click += new System.EventHandler(this.clearErrorTypesToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem2
            // 
            this.renameToolStripMenuItem2.Name = "renameToolStripMenuItem2";
            this.renameToolStripMenuItem2.Size = new System.Drawing.Size(197, 22);
            this.renameToolStripMenuItem2.Text = "Rename";
            this.renameToolStripMenuItem2.Click += new System.EventHandler(this.renameToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.surfaceTypeDataToolStripMenuItem,
            this.behaviorDataToolStripMenuItem,
            this.errorDataToolStripMenuItem,
            this.combinedDataToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.toolStripMenuItem1.Text = "Export";
            // 
            // surfaceTypeDataToolStripMenuItem
            // 
            this.surfaceTypeDataToolStripMenuItem.Name = "surfaceTypeDataToolStripMenuItem";
            this.surfaceTypeDataToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.surfaceTypeDataToolStripMenuItem.Text = "Surface Type Data";
            this.surfaceTypeDataToolStripMenuItem.Click += new System.EventHandler(this.surfaceTypeDataToolStripMenuItem_Click);
            // 
            // behaviorDataToolStripMenuItem
            // 
            this.behaviorDataToolStripMenuItem.Name = "behaviorDataToolStripMenuItem";
            this.behaviorDataToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.behaviorDataToolStripMenuItem.Text = "Behavior Data";
            this.behaviorDataToolStripMenuItem.Click += new System.EventHandler(this.behaviorDataToolStripMenuItem_Click);
            // 
            // errorDataToolStripMenuItem
            // 
            this.errorDataToolStripMenuItem.Name = "errorDataToolStripMenuItem";
            this.errorDataToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.errorDataToolStripMenuItem.Text = "Error Data";
            this.errorDataToolStripMenuItem.Click += new System.EventHandler(this.errorDataToolStripMenuItem_Click);
            // 
            // combinedDataToolStripMenuItem
            // 
            this.combinedDataToolStripMenuItem.Name = "combinedDataToolStripMenuItem";
            this.combinedDataToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.combinedDataToolStripMenuItem.Text = "Combined Data";
            this.combinedDataToolStripMenuItem.Click += new System.EventHandler(this.combinedDataToolStripMenuItem_Click);
            // 
            // volumebutton
            // 
            this.volumebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.volumebutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.volumebutton.BackColor = System.Drawing.SystemColors.Control;
            this.volumebutton.Image = global::MapApp.Properties.Resources.novolumebutton;
            this.volumebutton.Location = new System.Drawing.Point(530, 783);
            this.volumebutton.Name = "volumebutton";
            this.volumebutton.Size = new System.Drawing.Size(40, 38);
            this.volumebutton.TabIndex = 6;
            this.volumebutton.UseVisualStyleBackColor = false;
            this.volumebutton.Click += new System.EventHandler(this.volumebutton_Click);
            // 
            // stopbutton
            // 
            this.stopbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.stopbutton.BackColor = System.Drawing.SystemColors.Control;
            this.stopbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopbutton.Image = global::MapApp.Properties.Resources.Stop_button;
            this.stopbutton.Location = new System.Drawing.Point(56, 784);
            this.stopbutton.Name = "stopbutton";
            this.stopbutton.Size = new System.Drawing.Size(40, 38);
            this.stopbutton.TabIndex = 4;
            this.stopbutton.UseVisualStyleBackColor = false;
            this.stopbutton.Click += new System.EventHandler(this.stopbutton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.Location = new System.Drawing.Point(115, 786);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(398, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // playpausebutton
            // 
            this.playpausebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playpausebutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playpausebutton.BackColor = System.Drawing.SystemColors.Control;
            this.playpausebutton.Image = global::MapApp.Properties.Resources.Play_button;
            this.playpausebutton.Location = new System.Drawing.Point(10, 784);
            this.playpausebutton.Name = "playpausebutton";
            this.playpausebutton.Size = new System.Drawing.Size(40, 38);
            this.playpausebutton.TabIndex = 2;
            this.playpausebutton.UseVisualStyleBackColor = false;
            this.playpausebutton.Click += new System.EventHandler(this.playpausebutton_Click);
            // 
            // CameraView
            // 
            this.CameraView.AccessibleName = "";
            this.CameraView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraView.Controls.Add(this.FrontView);
            this.CameraView.Controls.Add(this.BehindView);
            this.CameraView.Controls.Add(this.FaceView);
            this.CameraView.Controls.Add(this.ViewAll);
            this.CameraView.Location = new System.Drawing.Point(0, 39);
            this.CameraView.Name = "CameraView";
            this.CameraView.SelectedIndex = 0;
            this.CameraView.Size = new System.Drawing.Size(711, 745);
            this.CameraView.TabIndex = 1;
            // 
            // FrontView
            // 
            this.FrontView.Controls.Add(this.FrontVideo1);
            this.FrontView.Location = new System.Drawing.Point(4, 22);
            this.FrontView.Name = "FrontView";
            this.FrontView.Padding = new System.Windows.Forms.Padding(3);
            this.FrontView.Size = new System.Drawing.Size(703, 719);
            this.FrontView.TabIndex = 0;
            this.FrontView.Text = "Front View";
            this.FrontView.UseVisualStyleBackColor = true;
            // 
            // FrontVideo1
            // 
            this.FrontVideo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrontVideo1.Enabled = true;
            this.FrontVideo1.Location = new System.Drawing.Point(3, 3);
            this.FrontVideo1.Name = "FrontVideo1";
            this.FrontVideo1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FrontVideo1.OcxState")));
            this.FrontVideo1.Size = new System.Drawing.Size(697, 713);
            this.FrontVideo1.TabIndex = 1;
            this.FrontVideo1.Enter += new System.EventHandler(this.FrontVideo1_Enter);
            // 
            // BehindView
            // 
            this.BehindView.Controls.Add(this.BehindVideo1);
            this.BehindView.Location = new System.Drawing.Point(4, 22);
            this.BehindView.Name = "BehindView";
            this.BehindView.Padding = new System.Windows.Forms.Padding(3);
            this.BehindView.Size = new System.Drawing.Size(703, 719);
            this.BehindView.TabIndex = 1;
            this.BehindView.Text = "Behind View";
            this.BehindView.UseVisualStyleBackColor = true;
            // 
            // BehindVideo1
            // 
            this.BehindVideo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BehindVideo1.Enabled = true;
            this.BehindVideo1.Location = new System.Drawing.Point(3, 3);
            this.BehindVideo1.Name = "BehindVideo1";
            this.BehindVideo1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BehindVideo1.OcxState")));
            this.BehindVideo1.Size = new System.Drawing.Size(697, 713);
            this.BehindVideo1.TabIndex = 1;
            // 
            // FaceView
            // 
            this.FaceView.Controls.Add(this.FaceVideo1);
            this.FaceView.Location = new System.Drawing.Point(4, 22);
            this.FaceView.Name = "FaceView";
            this.FaceView.Size = new System.Drawing.Size(703, 719);
            this.FaceView.TabIndex = 2;
            this.FaceView.Text = "Face View";
            this.FaceView.UseVisualStyleBackColor = true;
            // 
            // FaceVideo1
            // 
            this.FaceVideo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceVideo1.Enabled = true;
            this.FaceVideo1.Location = new System.Drawing.Point(0, 0);
            this.FaceVideo1.Name = "FaceVideo1";
            this.FaceVideo1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FaceVideo1.OcxState")));
            this.FaceVideo1.Size = new System.Drawing.Size(703, 719);
            this.FaceVideo1.TabIndex = 1;
            // 
            // ViewAll
            // 
            this.ViewAll.Controls.Add(this.AllVideo);
            this.ViewAll.Location = new System.Drawing.Point(4, 22);
            this.ViewAll.Name = "ViewAll";
            this.ViewAll.Size = new System.Drawing.Size(703, 719);
            this.ViewAll.TabIndex = 3;
            this.ViewAll.Text = "View All";
            this.ViewAll.UseVisualStyleBackColor = true;
            this.ViewAll.Click += new System.EventHandler(this.ViewAll_Click);
            // 
            // AllVideo
            // 
            this.AllVideo.AutoSize = true;
            this.AllVideo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AllVideo.ColumnCount = 1;
            this.AllVideo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AllVideo.Controls.Add(this.FrontVideo3, 0, 0);
            this.AllVideo.Controls.Add(this.BehindVideo3, 0, 1);
            this.AllVideo.Controls.Add(this.FaceVideo3, 0, 2);
            this.AllVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllVideo.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.AllVideo.Location = new System.Drawing.Point(0, 0);
            this.AllVideo.Name = "AllVideo";
            this.AllVideo.RowCount = 3;
            this.AllVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33453F));
            this.AllVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33123F));
            this.AllVideo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33423F));
            this.AllVideo.Size = new System.Drawing.Size(703, 719);
            this.AllVideo.TabIndex = 0;
            // 
            // FrontVideo3
            // 
            this.FrontVideo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrontVideo3.Enabled = true;
            this.FrontVideo3.Location = new System.Drawing.Point(3, 3);
            this.FrontVideo3.Name = "FrontVideo3";
            this.FrontVideo3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FrontVideo3.OcxState")));
            this.FrontVideo3.Size = new System.Drawing.Size(697, 233);
            this.FrontVideo3.TabIndex = 2;
            // 
            // BehindVideo3
            // 
            this.BehindVideo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BehindVideo3.Enabled = true;
            this.BehindVideo3.Location = new System.Drawing.Point(3, 242);
            this.BehindVideo3.Name = "BehindVideo3";
            this.BehindVideo3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BehindVideo3.OcxState")));
            this.BehindVideo3.Size = new System.Drawing.Size(697, 233);
            this.BehindVideo3.TabIndex = 4;
            // 
            // FaceVideo3
            // 
            this.FaceVideo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceVideo3.Enabled = true;
            this.FaceVideo3.Location = new System.Drawing.Point(3, 481);
            this.FaceVideo3.Name = "FaceVideo3";
            this.FaceVideo3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FaceVideo3.OcxState")));
            this.FaceVideo3.Size = new System.Drawing.Size(697, 235);
            this.FaceVideo3.TabIndex = 3;
            this.FaceVideo3.Enter += new System.EventHandler(this.FaceVideo3_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 43);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Route Data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Location = new System.Drawing.Point(517, 14);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(56, 20);
            this.textBox8.TabIndex = 7;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Location = new System.Drawing.Point(452, 17);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(66, 13);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "Acceleration:";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Location = new System.Drawing.Point(294, 14);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(154, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(245, 17);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(51, 13);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "Location:";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(168, 14);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(71, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(131, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(40, 13);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Speed:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.Location = new System.Drawing.Point(60, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(61, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(6, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(48, 13);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Trip Time:";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // gpsLabel
            // 
            this.gpsLabel.AutoSize = true;
            this.gpsLabel.Location = new System.Drawing.Point(13, 747);
            this.gpsLabel.Name = "gpsLabel";
            this.gpsLabel.Size = new System.Drawing.Size(58, 13);
            this.gpsLabel.TabIndex = 6;
            this.gpsLabel.Text = "GPS Data:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 821);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PortAL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.CameraView.ResumeLayout(false);
            this.FrontView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FrontVideo1)).EndInit();
            this.BehindView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BehindVideo1)).EndInit();
            this.FaceView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FaceVideo1)).EndInit();
            this.ViewAll.ResumeLayout(false);
            this.ViewAll.PerformLayout();
            this.AllVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FrontVideo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BehindVideo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceVideo3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private MapUserControl mapUserControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPSDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importgpxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importKMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrontvideoDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFrontToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestRouteViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeMapViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aerialViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aerialViewWithLablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roadViewToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.ToolStripMenuItem routeDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roadwaySurfaceTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSurfaceType1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSurfaceType2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSurfaceType3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSurfaceType4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSurfaceType5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riderBehaviorTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBehaviorType1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBehaviorType2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBehaviorType3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBehaviorType4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBehaviorType5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem riderErrorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addErrorType1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addErrorType2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addErrorType3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addErrorType4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addErrorType5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastSurfaceTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastBehaviorTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastErrorTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem surfaceTypeDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem behaviorDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinedDataToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSurfaceTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearBehaviorTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearErrorTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.Button zoomout;
        private System.Windows.Forms.Button zoomin;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem videoPauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoFastFWDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoSlowToolStripMenuItem;
        private System.Windows.Forms.TabControl CameraView;
        private System.Windows.Forms.TabPage FrontView;
        private AxWMPLib.AxWindowsMediaPlayer FrontVideo1;
        private System.Windows.Forms.TabPage BehindView;
        private AxWMPLib.AxWindowsMediaPlayer BehindVideo1;
        private System.Windows.Forms.TabPage FaceView;
        private AxWMPLib.AxWindowsMediaPlayer FaceVideo1;
        private System.Windows.Forms.TabPage ViewAll;
        private System.Windows.Forms.TableLayoutPanel AllVideo;
        private AxWMPLib.AxWindowsMediaPlayer FaceVideo3;
        private AxWMPLib.AxWindowsMediaPlayer FrontVideo3;
        private AxWMPLib.AxWindowsMediaPlayer BehindVideo3;
        private System.Windows.Forms.ToolStripMenuItem behindVideoDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportBehindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faceVideoDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFaceToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.OpenFileDialog openFileDialog4;
        private System.Windows.Forms.Button stopbutton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button playpausebutton;
        private System.Windows.Forms.Button volumebutton;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label gpsLabel;
    }
}

