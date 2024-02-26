namespace GIAC
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this._ConvertAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this._ConvertTab = new System.Windows.Forms.TabPage();
            this._ConvertMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ConvertEditPanel = new System.Windows.Forms.Panel();
            this._ConvertResizeTrackBar = new System.Windows.Forms.TrackBar();
            this._ConvertFrameTrackBar = new System.Windows.Forms.TrackBar();
            this._ConvertToolbar = new System.Windows.Forms.Panel();
            this._ConvertInvert = new System.Windows.Forms.Button();
            this._ConvertHarsh = new System.Windows.Forms.Button();
            this._ConvertColorize = new System.Windows.Forms.Button();
            this._ConvertMono = new System.Windows.Forms.Button();
            this._ConvertMediaToolbar = new System.Windows.Forms.Panel();
            this._ConvertMediaPlay = new System.Windows.Forms.Button();
            this._ConvertMediaPause = new System.Windows.Forms.Button();
            this._ConvertMediaBackFrame = new System.Windows.Forms.Button();
            this._ConvertMediaForwardFrame = new System.Windows.Forms.Button();
            this._ConvertTickRate = new System.Windows.Forms.TextBox();
            this._ConvertLabelWidth = new System.Windows.Forms.Label();
            this._ConvertLabelHeight = new System.Windows.Forms.Label();
            this._ConvertLabelScale = new System.Windows.Forms.Label();
            this._ConvertToolbarPopOut = new System.Windows.Forms.Panel();
            this.@__ConvertPullWindow = new System.Windows.Forms.Button();
            this._ConvertPopOutWidthTbx = new System.Windows.Forms.TextBox();
            this._ConvertPopOutHeightTbx = new System.Windows.Forms.TextBox();
            this._ConvertPopOutWidthLbl = new System.Windows.Forms.Label();
            this._ConvertPopOutHeightLbl = new System.Windows.Forms.Label();
            this._ConvertPopOutMove = new System.Windows.Forms.Button();
            this._ConvertPopOutShowWindowList = new System.Windows.Forms.Button();
            this._ConvertWebBrowser = new System.Windows.Forms.WebBrowser();
            this._ConvertPopOutWindowList = new System.Windows.Forms.ListBox();
            this.OGImageThumb = new System.Windows.Forms.PictureBox();
            this.mainTabC = new System.Windows.Forms.TabControl();
            this._ConvertTab.SuspendLayout();
            this._ConvertMenuStrip.SuspendLayout();
            this._ConvertEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ConvertResizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ConvertFrameTrackBar)).BeginInit();
            this._ConvertToolbar.SuspendLayout();
            this._ConvertMediaToolbar.SuspendLayout();
            this._ConvertToolbarPopOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OGImageThumb)).BeginInit();
            this.mainTabC.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ConvertAnimationTimer
            // 
            this._ConvertAnimationTimer.Interval = 50;
            this._ConvertAnimationTimer.Tick += new System.EventHandler(this._ConvertAnimationTimer_Tick);
            // 
            // _ConvertTab
            // 
            this._ConvertTab.BackColor = System.Drawing.SystemColors.Control;
            this._ConvertTab.Controls.Add(this.OGImageThumb);
            this._ConvertTab.Controls.Add(this._ConvertPopOutWindowList);
            this._ConvertTab.Controls.Add(this._ConvertWebBrowser);
            this._ConvertTab.Controls.Add(this._ConvertEditPanel);
            this._ConvertTab.Controls.Add(this._ConvertMenuStrip);
            this._ConvertTab.Location = new System.Drawing.Point(4, 22);
            this._ConvertTab.Name = "_ConvertTab";
            this._ConvertTab.Padding = new System.Windows.Forms.Padding(3);
            this._ConvertTab.Size = new System.Drawing.Size(1029, 682);
            this._ConvertTab.TabIndex = 0;
            this._ConvertTab.Text = "Convert";
            // 
            // _ConvertMenuStrip
            // 
            this._ConvertMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this._ConvertMenuStrip.Location = new System.Drawing.Point(3, 3);
            this._ConvertMenuStrip.Name = "_ConvertMenuStrip";
            this._ConvertMenuStrip.Size = new System.Drawing.Size(1023, 24);
            this._ConvertMenuStrip.TabIndex = 0;
            this._ConvertMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // _ConvertEditPanel
            // 
            this._ConvertEditPanel.Controls.Add(this._ConvertToolbarPopOut);
            this._ConvertEditPanel.Controls.Add(this._ConvertLabelScale);
            this._ConvertEditPanel.Controls.Add(this._ConvertLabelHeight);
            this._ConvertEditPanel.Controls.Add(this._ConvertLabelWidth);
            this._ConvertEditPanel.Controls.Add(this._ConvertMediaToolbar);
            this._ConvertEditPanel.Controls.Add(this._ConvertToolbar);
            this._ConvertEditPanel.Controls.Add(this._ConvertFrameTrackBar);
            this._ConvertEditPanel.Controls.Add(this._ConvertResizeTrackBar);
            this._ConvertEditPanel.Enabled = false;
            this._ConvertEditPanel.Location = new System.Drawing.Point(8, 30);
            this._ConvertEditPanel.Name = "_ConvertEditPanel";
            this._ConvertEditPanel.Size = new System.Drawing.Size(1013, 90);
            this._ConvertEditPanel.TabIndex = 1;
            // 
            // _ConvertResizeTrackBar
            // 
            this._ConvertResizeTrackBar.Location = new System.Drawing.Point(109, 19);
            this._ConvertResizeTrackBar.Maximum = 2000;
            this._ConvertResizeTrackBar.Minimum = 1;
            this._ConvertResizeTrackBar.Name = "_ConvertResizeTrackBar";
            this._ConvertResizeTrackBar.Size = new System.Drawing.Size(350, 45);
            this._ConvertResizeTrackBar.TabIndex = 1;
            this._ConvertResizeTrackBar.TickFrequency = 100;
            this._ConvertResizeTrackBar.Value = 300;
            this._ConvertResizeTrackBar.ValueChanged += new System.EventHandler(this._ConvertResizeTrackBar_ValueChanged);
            // 
            // _ConvertFrameTrackBar
            // 
            this._ConvertFrameTrackBar.Location = new System.Drawing.Point(465, 19);
            this._ConvertFrameTrackBar.Name = "_ConvertFrameTrackBar";
            this._ConvertFrameTrackBar.Size = new System.Drawing.Size(545, 45);
            this._ConvertFrameTrackBar.TabIndex = 2;
            this._ConvertFrameTrackBar.ValueChanged += new System.EventHandler(this._ConvertFrameTrackBar_ValueChanged);
            // 
            // _ConvertToolbar
            // 
            this._ConvertToolbar.Controls.Add(this._ConvertMono);
            this._ConvertToolbar.Controls.Add(this._ConvertColorize);
            this._ConvertToolbar.Controls.Add(this._ConvertHarsh);
            this._ConvertToolbar.Controls.Add(this._ConvertInvert);
            this._ConvertToolbar.Location = new System.Drawing.Point(109, 57);
            this._ConvertToolbar.Name = "_ConvertToolbar";
            this._ConvertToolbar.Size = new System.Drawing.Size(350, 30);
            this._ConvertToolbar.TabIndex = 3;
            // 
            // _ConvertInvert
            // 
            this._ConvertInvert.Location = new System.Drawing.Point(3, 0);
            this._ConvertInvert.Name = "_ConvertInvert";
            this._ConvertInvert.Size = new System.Drawing.Size(30, 30);
            this._ConvertInvert.TabIndex = 0;
            this._ConvertInvert.UseVisualStyleBackColor = true;
            this._ConvertInvert.Click += new System.EventHandler(this._ConvertInvert_Click);
            // 
            // _ConvertHarsh
            // 
            this._ConvertHarsh.Location = new System.Drawing.Point(39, 0);
            this._ConvertHarsh.Name = "_ConvertHarsh";
            this._ConvertHarsh.Size = new System.Drawing.Size(30, 30);
            this._ConvertHarsh.TabIndex = 1;
            this._ConvertHarsh.UseVisualStyleBackColor = true;
            this._ConvertHarsh.Click += new System.EventHandler(this._ConvertHarsh_Click);
            // 
            // _ConvertColorize
            // 
            this._ConvertColorize.Location = new System.Drawing.Point(75, 0);
            this._ConvertColorize.Name = "_ConvertColorize";
            this._ConvertColorize.Size = new System.Drawing.Size(30, 30);
            this._ConvertColorize.TabIndex = 2;
            this._ConvertColorize.UseVisualStyleBackColor = true;
            this._ConvertColorize.Click += new System.EventHandler(this._ConvertColorize_Click);
            // 
            // _ConvertMono
            // 
            this._ConvertMono.Location = new System.Drawing.Point(111, 0);
            this._ConvertMono.Name = "_ConvertMono";
            this._ConvertMono.Size = new System.Drawing.Size(30, 30);
            this._ConvertMono.TabIndex = 3;
            this._ConvertMono.UseVisualStyleBackColor = true;
            this._ConvertMono.Click += new System.EventHandler(this._ConvertMono_Click);
            // 
            // _ConvertMediaToolbar
            // 
            this._ConvertMediaToolbar.Controls.Add(this._ConvertTickRate);
            this._ConvertMediaToolbar.Controls.Add(this._ConvertMediaForwardFrame);
            this._ConvertMediaToolbar.Controls.Add(this._ConvertMediaBackFrame);
            this._ConvertMediaToolbar.Controls.Add(this._ConvertMediaPause);
            this._ConvertMediaToolbar.Controls.Add(this._ConvertMediaPlay);
            this._ConvertMediaToolbar.Location = new System.Drawing.Point(465, 57);
            this._ConvertMediaToolbar.Name = "_ConvertMediaToolbar";
            this._ConvertMediaToolbar.Size = new System.Drawing.Size(530, 30);
            this._ConvertMediaToolbar.TabIndex = 4;
            // 
            // _ConvertMediaPlay
            // 
            this._ConvertMediaPlay.Location = new System.Drawing.Point(49, 0);
            this._ConvertMediaPlay.Name = "_ConvertMediaPlay";
            this._ConvertMediaPlay.Size = new System.Drawing.Size(30, 30);
            this._ConvertMediaPlay.TabIndex = 0;
            this._ConvertMediaPlay.UseVisualStyleBackColor = true;
            this._ConvertMediaPlay.Click += new System.EventHandler(this._ConvertPlay_Click);
            // 
            // _ConvertMediaPause
            // 
            this._ConvertMediaPause.Enabled = false;
            this._ConvertMediaPause.Location = new System.Drawing.Point(85, 0);
            this._ConvertMediaPause.Name = "_ConvertMediaPause";
            this._ConvertMediaPause.Size = new System.Drawing.Size(30, 30);
            this._ConvertMediaPause.TabIndex = 1;
            this._ConvertMediaPause.UseVisualStyleBackColor = true;
            this._ConvertMediaPause.Click += new System.EventHandler(this._ConvertMediaPause_Click);
            // 
            // _ConvertMediaBackFrame
            // 
            this._ConvertMediaBackFrame.Location = new System.Drawing.Point(13, 0);
            this._ConvertMediaBackFrame.Name = "_ConvertMediaBackFrame";
            this._ConvertMediaBackFrame.Size = new System.Drawing.Size(30, 30);
            this._ConvertMediaBackFrame.TabIndex = 2;
            this._ConvertMediaBackFrame.UseVisualStyleBackColor = true;
            this._ConvertMediaBackFrame.Click += new System.EventHandler(this._ConvertMediaBackFrame_Click);
            // 
            // _ConvertMediaForwardFrame
            // 
            this._ConvertMediaForwardFrame.Location = new System.Drawing.Point(121, 0);
            this._ConvertMediaForwardFrame.Name = "_ConvertMediaForwardFrame";
            this._ConvertMediaForwardFrame.Size = new System.Drawing.Size(30, 30);
            this._ConvertMediaForwardFrame.TabIndex = 3;
            this._ConvertMediaForwardFrame.UseVisualStyleBackColor = true;
            this._ConvertMediaForwardFrame.Click += new System.EventHandler(this._ConvertMediaForwardFrame_Click);
            // 
            // _ConvertTickRate
            // 
            this._ConvertTickRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._ConvertTickRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ConvertTickRate.Location = new System.Drawing.Point(157, 3);
            this._ConvertTickRate.Name = "_ConvertTickRate";
            this._ConvertTickRate.Size = new System.Drawing.Size(75, 22);
            this._ConvertTickRate.TabIndex = 4;
            this._ConvertTickRate.TextChanged += new System.EventHandler(this._ConvertTickRate_TextChanged);
            this._ConvertTickRate.Enter += new System.EventHandler(this._ConvertTickRate_Enter);
            this._ConvertTickRate.Leave += new System.EventHandler(this._ConvertTickRate_Leave);
            // 
            // _ConvertLabelWidth
            // 
            this._ConvertLabelWidth.AutoSize = true;
            this._ConvertLabelWidth.Location = new System.Drawing.Point(110, 3);
            this._ConvertLabelWidth.Name = "_ConvertLabelWidth";
            this._ConvertLabelWidth.Size = new System.Drawing.Size(61, 13);
            this._ConvertLabelWidth.TabIndex = 5;
            this._ConvertLabelWidth.Text = "Width: N/A";
            // 
            // _ConvertLabelHeight
            // 
            this._ConvertLabelHeight.AutoSize = true;
            this._ConvertLabelHeight.Location = new System.Drawing.Point(210, 3);
            this._ConvertLabelHeight.Name = "_ConvertLabelHeight";
            this._ConvertLabelHeight.Size = new System.Drawing.Size(64, 13);
            this._ConvertLabelHeight.TabIndex = 6;
            this._ConvertLabelHeight.Text = "Height: N/A";
            // 
            // _ConvertLabelScale
            // 
            this._ConvertLabelScale.AutoSize = true;
            this._ConvertLabelScale.Location = new System.Drawing.Point(310, 3);
            this._ConvertLabelScale.Name = "_ConvertLabelScale";
            this._ConvertLabelScale.Size = new System.Drawing.Size(60, 13);
            this._ConvertLabelScale.TabIndex = 7;
            this._ConvertLabelScale.Text = "Scale: N/A";
            // 
            // _ConvertToolbarPopOut
            // 
            this._ConvertToolbarPopOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._ConvertToolbarPopOut.Controls.Add(this._ConvertPopOutShowWindowList);
            this._ConvertToolbarPopOut.Controls.Add(this._ConvertPopOutMove);
            this._ConvertToolbarPopOut.Controls.Add(this._ConvertPopOutHeightLbl);
            this._ConvertToolbarPopOut.Controls.Add(this._ConvertPopOutWidthLbl);
            this._ConvertToolbarPopOut.Controls.Add(this._ConvertPopOutHeightTbx);
            this._ConvertToolbarPopOut.Controls.Add(this._ConvertPopOutWidthTbx);
            this._ConvertToolbarPopOut.Controls.Add(this.@__ConvertPullWindow);
            this._ConvertToolbarPopOut.Location = new System.Drawing.Point(3, 3);
            this._ConvertToolbarPopOut.Name = "_ConvertToolbarPopOut";
            this._ConvertToolbarPopOut.Size = new System.Drawing.Size(103, 84);
            this._ConvertToolbarPopOut.TabIndex = 8;
            // 
            // __ConvertPullWindow
            // 
            this.@__ConvertPullWindow.Location = new System.Drawing.Point(0, 54);
            this.@__ConvertPullWindow.Name = "__ConvertPullWindow";
            this.@__ConvertPullWindow.Size = new System.Drawing.Size(30, 30);
            this.@__ConvertPullWindow.TabIndex = 1;
            this.@__ConvertPullWindow.UseVisualStyleBackColor = true;
            this.@__ConvertPullWindow.Click += new System.EventHandler(this.pbxPullWindow_Click);
            // 
            // _ConvertPopOutWidthTbx
            // 
            this._ConvertPopOutWidthTbx.BackColor = System.Drawing.SystemColors.Control;
            this._ConvertPopOutWidthTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._ConvertPopOutWidthTbx.Location = new System.Drawing.Point(44, 0);
            this._ConvertPopOutWidthTbx.Name = "_ConvertPopOutWidthTbx";
            this._ConvertPopOutWidthTbx.Size = new System.Drawing.Size(55, 13);
            this._ConvertPopOutWidthTbx.TabIndex = 2;
            this._ConvertPopOutWidthTbx.Text = "N/A";
            this._ConvertPopOutWidthTbx.WordWrap = false;
            this._ConvertPopOutWidthTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this._ConvertPopOutWidthTbx_KeyDown);
            this._ConvertPopOutWidthTbx.Leave += new System.EventHandler(this._ConvertPopOutWidthTbx_Leave);
            // 
            // _ConvertPopOutHeightTbx
            // 
            this._ConvertPopOutHeightTbx.BackColor = System.Drawing.SystemColors.Control;
            this._ConvertPopOutHeightTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._ConvertPopOutHeightTbx.Enabled = false;
            this._ConvertPopOutHeightTbx.Location = new System.Drawing.Point(44, 27);
            this._ConvertPopOutHeightTbx.Name = "_ConvertPopOutHeightTbx";
            this._ConvertPopOutHeightTbx.Size = new System.Drawing.Size(55, 13);
            this._ConvertPopOutHeightTbx.TabIndex = 3;
            this._ConvertPopOutHeightTbx.Text = "N/A";
            this._ConvertPopOutHeightTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this._ConvertPopOutHeightTbx_KeyDown);
            this._ConvertPopOutHeightTbx.Leave += new System.EventHandler(this._ConvertPopOutHeightTbx_Leave);
            // 
            // _ConvertPopOutWidthLbl
            // 
            this._ConvertPopOutWidthLbl.AutoSize = true;
            this._ConvertPopOutWidthLbl.Location = new System.Drawing.Point(3, 0);
            this._ConvertPopOutWidthLbl.Name = "_ConvertPopOutWidthLbl";
            this._ConvertPopOutWidthLbl.Size = new System.Drawing.Size(38, 13);
            this._ConvertPopOutWidthLbl.TabIndex = 4;
            this._ConvertPopOutWidthLbl.Text = "Width:";
            // 
            // _ConvertPopOutHeightLbl
            // 
            this._ConvertPopOutHeightLbl.AutoSize = true;
            this._ConvertPopOutHeightLbl.Location = new System.Drawing.Point(3, 27);
            this._ConvertPopOutHeightLbl.Name = "_ConvertPopOutHeightLbl";
            this._ConvertPopOutHeightLbl.Size = new System.Drawing.Size(41, 13);
            this._ConvertPopOutHeightLbl.TabIndex = 5;
            this._ConvertPopOutHeightLbl.Text = "Height:";
            // 
            // _ConvertPopOutMove
            // 
            this._ConvertPopOutMove.Location = new System.Drawing.Point(36, 54);
            this._ConvertPopOutMove.Name = "_ConvertPopOutMove";
            this._ConvertPopOutMove.Size = new System.Drawing.Size(30, 30);
            this._ConvertPopOutMove.TabIndex = 6;
            this._ConvertPopOutMove.UseVisualStyleBackColor = true;
            this._ConvertPopOutMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ConvertPopOutMove_MouseDown);
            this._ConvertPopOutMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ConvertPopOutMove_MouseMove);
            this._ConvertPopOutMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ConvertPopOutMove_MouseUp);
            // 
            // _ConvertPopOutShowWindowList
            // 
            this._ConvertPopOutShowWindowList.Location = new System.Drawing.Point(90, 72);
            this._ConvertPopOutShowWindowList.Name = "_ConvertPopOutShowWindowList";
            this._ConvertPopOutShowWindowList.Size = new System.Drawing.Size(12, 12);
            this._ConvertPopOutShowWindowList.TabIndex = 7;
            this._ConvertPopOutShowWindowList.UseVisualStyleBackColor = true;
            this._ConvertPopOutShowWindowList.Click += new System.EventHandler(this._ConvertPopOutShowWindowList_Click);
            // 
            // _ConvertWebBrowser
            // 
            this._ConvertWebBrowser.Location = new System.Drawing.Point(3, 126);
            this._ConvertWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._ConvertWebBrowser.Name = "_ConvertWebBrowser";
            this._ConvertWebBrowser.Size = new System.Drawing.Size(1007, 550);
            this._ConvertWebBrowser.TabIndex = 2;
            // 
            // _ConvertPopOutWindowList
            // 
            this._ConvertPopOutWindowList.FormattingEnabled = true;
            this._ConvertPopOutWindowList.Location = new System.Drawing.Point(8, 123);
            this._ConvertPopOutWindowList.MultiColumn = true;
            this._ConvertPopOutWindowList.Name = "_ConvertPopOutWindowList";
            this._ConvertPopOutWindowList.Size = new System.Drawing.Size(106, 290);
            this._ConvertPopOutWindowList.TabIndex = 7;
            this._ConvertPopOutWindowList.Visible = false;
            this._ConvertPopOutWindowList.SelectedIndexChanged += new System.EventHandler(this._ConvertPopOutWindowList_SelectedIndexChanged);
            this._ConvertPopOutWindowList.KeyDown += new System.Windows.Forms.KeyEventHandler(this._ConvertPopOutWindowList_KeyDown);
            // 
            // OGImageThumb
            // 
            this.OGImageThumb.BackColor = System.Drawing.SystemColors.Control;
            this.OGImageThumb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OGImageThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OGImageThumb.Location = new System.Drawing.Point(540, 255);
            this.OGImageThumb.Name = "OGImageThumb";
            this.OGImageThumb.Size = new System.Drawing.Size(288, 197);
            this.OGImageThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OGImageThumb.TabIndex = 8;
            this.OGImageThumb.TabStop = false;
            this.OGImageThumb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OGImageThumb_MouseDown);
            this.OGImageThumb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OGImageThumb_MouseMove);
            this.OGImageThumb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OGImageThumb_MouseUp);
            // 
            // mainTabC
            // 
            this.mainTabC.Controls.Add(this._ConvertTab);
            this.mainTabC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabC.Location = new System.Drawing.Point(0, 0);
            this.mainTabC.Multiline = true;
            this.mainTabC.Name = "mainTabC";
            this.mainTabC.SelectedIndex = 0;
            this.mainTabC.Size = new System.Drawing.Size(1037, 708);
            this.mainTabC.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 708);
            this.Controls.Add(this.mainTabC);
            this.HelpButton = true;
            this.Name = "MainForm";
            this.Text = "GiAC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this._ConvertTab.ResumeLayout(false);
            this._ConvertTab.PerformLayout();
            this._ConvertMenuStrip.ResumeLayout(false);
            this._ConvertMenuStrip.PerformLayout();
            this._ConvertEditPanel.ResumeLayout(false);
            this._ConvertEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ConvertResizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ConvertFrameTrackBar)).EndInit();
            this._ConvertToolbar.ResumeLayout(false);
            this._ConvertMediaToolbar.ResumeLayout(false);
            this._ConvertMediaToolbar.PerformLayout();
            this._ConvertToolbarPopOut.ResumeLayout(false);
            this._ConvertToolbarPopOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OGImageThumb)).EndInit();
            this.mainTabC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer _ConvertAnimationTimer;
        private System.Windows.Forms.TabPage _ConvertTab;
        private System.Windows.Forms.PictureBox OGImageThumb;
        private System.Windows.Forms.ListBox _ConvertPopOutWindowList;
        private System.Windows.Forms.WebBrowser _ConvertWebBrowser;
        private System.Windows.Forms.Panel _ConvertEditPanel;
        private System.Windows.Forms.Panel _ConvertToolbarPopOut;
        private System.Windows.Forms.Button _ConvertPopOutShowWindowList;
        private System.Windows.Forms.Button _ConvertPopOutMove;
        private System.Windows.Forms.Label _ConvertPopOutHeightLbl;
        private System.Windows.Forms.Label _ConvertPopOutWidthLbl;
        private System.Windows.Forms.TextBox _ConvertPopOutHeightTbx;
        private System.Windows.Forms.TextBox _ConvertPopOutWidthTbx;
        private System.Windows.Forms.Button __ConvertPullWindow;
        private System.Windows.Forms.Label _ConvertLabelScale;
        private System.Windows.Forms.Label _ConvertLabelHeight;
        private System.Windows.Forms.Label _ConvertLabelWidth;
        private System.Windows.Forms.Panel _ConvertMediaToolbar;
        private System.Windows.Forms.TextBox _ConvertTickRate;
        private System.Windows.Forms.Button _ConvertMediaForwardFrame;
        private System.Windows.Forms.Button _ConvertMediaBackFrame;
        private System.Windows.Forms.Button _ConvertMediaPause;
        private System.Windows.Forms.Button _ConvertMediaPlay;
        private System.Windows.Forms.Panel _ConvertToolbar;
        private System.Windows.Forms.Button _ConvertMono;
        private System.Windows.Forms.Button _ConvertColorize;
        private System.Windows.Forms.Button _ConvertHarsh;
        private System.Windows.Forms.Button _ConvertInvert;
        private System.Windows.Forms.TrackBar _ConvertFrameTrackBar;
        private System.Windows.Forms.TrackBar _ConvertResizeTrackBar;
        private System.Windows.Forms.MenuStrip _ConvertMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabC;
    }
}

