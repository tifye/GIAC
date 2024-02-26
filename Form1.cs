using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;

namespace GIAC
{
    public partial class MainForm : Form
    {
        ConvertToAscii ConvertToAscii_Class;
        ConvertToAscii ConvertToAscii_Save;
        string frame;
        string path = "";
        BackgroundWorker _saveFileBW = new BackgroundWorker();
        bool saveButtonPressed = false;
        bool saveAsButtonPressed = false;
        DialogResult dr;
        SaveFileDialog sfd;
        //
        //
        ImageWindow imgWin;
        //
        int curFrameIndex = 0;
        Process pro = new Process();

        Image ogImage;
        Image[] ogImageArray;
        FrameDimension ogImageDimension;

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        
        //
        // Form On Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            saveFileBW();
            //
            //
            //
            this.UseWaitCursor = false;
            this.WindowState = FormWindowState.Maximized;
            _ConvertTab.Height = mainTabC.Height;

            _ConvertEditPanel.Width = _ConvertTab.Width;
            _ConvertFrameTrackBar.Width = _ConvertEditPanel.Width - 480;

            _ConvertWebBrowser.Width = _ConvertTab.Width - 11;
            _ConvertWebBrowser.Height = _ConvertTab.Height - _ConvertEditPanel.Height - 41;
            //
            //
            //
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            ImageList imgList = new ImageList();
            imgList.Images.Add(new Bitmap((basePath + "\\Resources\\BackButton.png")));

            _ConvertMediaBackFrame.Image = new Bitmap(imgList.Images[0]);
            _ConvertMediaForwardFrame.Image = new Bitmap((basePath + "\\Resources\\ForwardButton.png"));
            _ConvertMediaPlay.Image = new Bitmap((basePath + "\\Resources\\PlayButton.png"));
            _ConvertMediaPause.Image = new Bitmap((basePath + "\\Resources\\PauseButton.png"));

            _ConvertInvert.Image = new Bitmap((basePath + "\\Resources\\InvertButton.png"));
            _ConvertHarsh.Image = new Bitmap((basePath + "\\Resources\\HarshButton.png"));
            _ConvertColorize.Image = new Bitmap((basePath + "\\Resources\\ColorizeButton.png"));
            _ConvertMono.Image = new Bitmap((basePath + "\\Resources\\MonoButton.png"));

            //IntPtr Hicon = (new Bitmap((basePath + "\\Resources\\IconLogo.png"))).GetHicon();
            //this.Icon = Icon.FromHandle(Hicon);

            __ConvertPullWindow.Image = new Bitmap((basePath + "\\Resources\\PopOutButton.png"));
            _ConvertPopOutMove.Image = new Bitmap((basePath + "\\Resources\\MovePop.png"));

            
            //
            //
            //
            Point p = new Point();
            p.X = _ConvertWebBrowser.Location.X + _ConvertWebBrowser.Width - OGImageThumb.Width - 50;
            p.Y = _ConvertWebBrowser.Location.Y + _ConvertWebBrowser.Height - OGImageThumb.Height - 50;
            OGImageThumb.Location = p;
            //
            //
            //
            _ConvertTickRate.BackColor = _ConvertTickRate.Parent.BackColor;
            _ConvertTickRate.Text = _ConvertAnimationTimer.Interval.ToString() + "ms";
        }

        //
        // Resize
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //
            // _Convert Tab Controls Resizing
            //
            _ConvertTab.Height = mainTabC.Height;

            _ConvertEditPanel.Width = _ConvertTab.Width;
            _ConvertFrameTrackBar.Width = _ConvertEditPanel.Width - 480;

            _ConvertWebBrowser.Width = _ConvertTab.Width - 11;
            _ConvertWebBrowser.Height = _ConvertTab.Height - _ConvertEditPanel.Height - 41;
            //
            //
            //
        }

        //
        // _Convert Open File
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ConvertAnimationTimer.Stop();
            _ConvertMediaPlay.Enabled = true;
            _ConvertMediaPause.Enabled = false;

            OpenFileDialog fd = new OpenFileDialog();
            //fd.InitialDirectory = @"F\Gallery\";
            DialogResult dr = fd.ShowDialog();

            if(dr == DialogResult.OK)
            {
                if(isValidType(fd.FileName))
                {
                    curFrameIndex = 0;

                    path = fd.FileName;

                    OGImage(path);
                    OGImageThumb.BackgroundImage = ogImageArray[curFrameIndex];
                    OGImageThumb.Size = ogImageArray[curFrameIndex].Size;

                    ConvertToAscii_Class = new ConvertToAscii(fd.FileName);
                    ConvertToAscii_Class._scaleNum = _ConvertResizeTrackBar.Value;

                    clearFrameCache(ConvertToAscii_Class);

                    _ConvertFrameTrackBar.Maximum = ConvertToAscii_Class._numFrames - 1;
                    _ConvertFrameTrackBar.Value = 0;

                    frame = ConvertToAscii_Class.postFrame(curFrameIndex);
                    _ConvertWebBrowser.DocumentText = frame;

                    _ConvertLabelWidth.Text = "Width: " + ConvertToAscii_Class._curImage.Width.ToString() + "px";
                    _ConvertLabelHeight.Text = "Height: " + ConvertToAscii_Class._curImage.Height.ToString() + "px";

                    double width = ConvertToAscii_Class._curImage.Width + 0.0;
                    double mWidth = ConvertToAscii_Class._MainImage.Width;
                    decimal scale = Math.Round((decimal)((width / mWidth) * 100 + 0.0));
                    _ConvertLabelScale.Text = "Scale: " + scale.ToString() + "%";

                    _ConvertEditPanel.Enabled = true;

                }

            }

        }

        //
        //
        // Check File Type
        private bool isValidType(string path)
        {
            bool isValid = false;
            string ext = Path.GetExtension(path);
            if (ext == ".jpeg" ||
                ext == ".jpg" ||
                ext == ".png" ||
                ext == ".gif" ||
                ext == ".bmp" ||
                ext == ".JPG" ||
                ext == ".PNG" )
            {               
                Image img = Image.FromFile(path);
                if( ImageFormat.Bmp.Equals(img.RawFormat) ||
                    ImageFormat.Jpeg.Equals(img.RawFormat) ||
                    ImageFormat.Png.Equals(img.RawFormat) ||
                    ImageFormat.Gif.Equals(img.RawFormat))
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        //
        //
        // Set OG Image
        private void OGImage(string path)
        {
            ogImage = Image.FromFile(path);
            ogImageDimension = new FrameDimension(ogImage.FrameDimensionsList[0]);
            ogImageArray = new Image[ogImage.GetFrameCount(ogImageDimension)];

            for (int i = 0; i < ogImage.GetFrameCount(ogImageDimension); i++)
            {
                ogImage.SelectActiveFrame(ogImageDimension, i);
                ogImageArray[i] = new Bitmap(ogImage);
            }
        }

        //
        // Select Preview Frame
        private void _ConvertFrameTrackBar_ValueChanged(object sender, EventArgs e)
        {
            curFrameIndex = _ConvertFrameTrackBar.Value;
            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);

            OGImageThumb.BackgroundImage = ogImageArray[curFrameIndex];
        }

        //
        // Resize Frame
        private void _ConvertResizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            //
            clearFrameCache(ConvertToAscii_Class);
            ConvertToAscii_Class._scaleNum = _ConvertResizeTrackBar.Value;

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);

            _ConvertLabelWidth.Text = "Width: " + ConvertToAscii_Class._curImage.Width.ToString() + "px";
            _ConvertLabelHeight.Text = "Height: " + ConvertToAscii_Class._curImage.Height.ToString() + "px";

            double width = ConvertToAscii_Class._curImage.Width + 0.0;
            double mWidth = ConvertToAscii_Class._MainImage.Width;
            decimal scale = Math.Round((decimal)((width / mWidth) * 100 + 0.0));
            _ConvertLabelScale.Text = "Scale: " + scale.ToString() + "%";
            
        }

        //
        // Clear Frame Cache List
        private void clearFrameCache(ConvertToAscii CRA)
        {
            //CRA.renderedFrames.Clear();
            for (int i = 0; i < CRA._numFrames; i++)
            {
                CRA.renderedFrames.Insert(i, "");
            }
        }

        //
        // Task 
        private void tk()
        {
            // New Task
            Task t = Task.Factory.StartNew(() =>
                {
                    int count = 1;
                    // Loop Untill FInnished Loading
                    do
                    {
                        if (ConvertToAscii_Class._gifArray_bsComplete)
                        {
                            //
                            if (this._ConvertFrameTrackBar.InvokeRequired)
                            {
                                this._ConvertFrameTrackBar.BeginInvoke((MethodInvoker)delegate()
                                {
                                    _ConvertFrameTrackBar.Enabled = true;
                                    _ConvertResizeTrackBar.Enabled = true;
                                    count = 0;
                                });
                            }
                            else
                            {
                                _ConvertFrameTrackBar.Enabled = false;
                                _ConvertResizeTrackBar.Enabled = false;
                            }
                            //
                        }
                    } while (count != 0);
            });
         }


        // Toolbar Items
        // Invert
        private void _ConvertInvert_Click(object sender, EventArgs e)
        {
            //
            clearFrameCache(ConvertToAscii_Class);
            if(ConvertToAscii_Class._isInvert)
            { ConvertToAscii_Class._isInvert = false; }
            else { ConvertToAscii_Class._isInvert = true; }

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);           
        }
        // Harsh
        private void _ConvertHarsh_Click(object sender, EventArgs e)
        {
            //
            clearFrameCache(ConvertToAscii_Class);
            if (ConvertToAscii_Class._isHarsh)
            { ConvertToAscii_Class._isHarsh = false; }
            else { ConvertToAscii_Class._isHarsh = true; }

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);
        }
        // Colorize
        private void _ConvertColorize_Click(object sender, EventArgs e)
        {
            //
            clearFrameCache(ConvertToAscii_Class);
            if(ConvertToAscii_Class._isColor)
            { ConvertToAscii_Class._isColor = false; }
            else { ConvertToAscii_Class._isColor = true; }

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);
        }
        // Mono character 
        private void _ConvertMono_Click(object sender, EventArgs e)
        {
            clearFrameCache(ConvertToAscii_Class);
            if(ConvertToAscii_Class._isMono)
            { ConvertToAscii_Class._isMono = false; }
            else { ConvertToAscii_Class._isMono = true; }

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);
        }

        ///
        ///
        // Media Toolbar
        // Play
        private void _ConvertPlay_Click(object sender, EventArgs e)
        {
            if (ConvertToAscii_Class._numFrames > 1)
            {
                _ConvertAnimationTimer.Start();

                // Play/Pause
                _ConvertMediaPlay.Enabled = false;
                _ConvertMediaPause.Enabled = true;
                // Forward/Back
                _ConvertMediaBackFrame.Enabled = false;
                _ConvertMediaForwardFrame.Enabled = false;
            }
        }
        // Pause
        private void _ConvertMediaPause_Click(object sender, EventArgs e)
        {
            _ConvertAnimationTimer.Stop();

            // Play/Pause 
            _ConvertMediaPlay.Enabled = true;
            _ConvertMediaPause.Enabled = false;
            // Forward/Back
            _ConvertMediaBackFrame.Enabled = true;
            _ConvertMediaForwardFrame.Enabled = true;
        }
        // Timer
        private void _ConvertAnimationTimer_Tick(object sender, EventArgs e)
        {
            if(curFrameIndex == ConvertToAscii_Class._numFrames)
            { curFrameIndex = 0; }
            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);

            OGImageThumb.BackgroundImage = ogImageArray[curFrameIndex];           

            curFrameIndex++;
        }
        // Back One Frame
        private void _ConvertMediaBackFrame_Click(object sender, EventArgs e)
        {
            if(curFrameIndex != 0)
            {
                curFrameIndex -= 1;               
            }
            else
            {
                curFrameIndex = ConvertToAscii_Class._numFrames - 1;
            }

            _ConvertFrameTrackBar.Value = curFrameIndex;

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);

            OGImageThumb.BackgroundImage = ogImageArray[curFrameIndex];
        }
        // Forward One Frame
        private void _ConvertMediaForwardFrame_Click(object sender, EventArgs e)
        {
            if (curFrameIndex != ConvertToAscii_Class._numFrames - 1)
            { 
                curFrameIndex += 1;              
            }
            else
            {
                curFrameIndex = 0;
            }
            _ConvertFrameTrackBar.Value = curFrameIndex;

            _ConvertWebBrowser.DocumentText =
                ConvertToAscii_Class.postFrame(curFrameIndex);

            OGImageThumb.BackgroundImage = ogImageArray[curFrameIndex];
        }
        // Tbx Tickrate
        private void _ConvertTickRate_TextChanged(object sender, EventArgs e)
        {
            int tr = 0;
            if(Int32.TryParse(_ConvertTickRate.Text,out tr))
            {
                if (tr != 0)
                { _ConvertAnimationTimer.Interval = tr; }
            }
        }
        private void _ConvertTickRate_Leave(object sender, EventArgs e)
        {
            _ConvertTickRate.Text += "ms";
        }
        private void _ConvertTickRate_Enter(object sender, EventArgs e)
        {
            _ConvertTickRate.Text = _ConvertAnimationTimer.Interval.ToString();
        }

        // MenuStip
        // Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveButtonPressed = true;

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;

            _saveFileBW.RunWorkerAsync();
            _saveFileBW.Dispose();
        }
        // Save As
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {                     
            sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetDirectoryName(path);
            sfd.CheckPathExists = true;
            sfd.FileName = Path.GetFileNameWithoutExtension(path);
            dr = sfd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                saveAsButtonPressed = true;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;

                _saveFileBW.RunWorkerAsync();
                _saveFileBW.Dispose();
            }            
        }
        // Save Background Worker
        private void savingBackgroundWorker()
        {
            if (saveButtonPressed)
            { SaveMethod(); }
            else if (saveAsButtonPressed)
            { SaveAs(); }
        }
        // Save File BackgroundWorker Iniatlizer
        private void saveFileBW()
        {
            _saveFileBW.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
            {
                savingBackgroundWorker();
            });

            _saveFileBW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate(object o, RunWorkerCompletedEventArgs args)
            {
                MessageBox.Show("Save Complete");
                saveToolStripMenuItem.Enabled = true;
                saveButtonPressed = false;

                saveAsToolStripMenuItem.Enabled = true;
                saveAsButtonPressed = false;
            });
        }

        // Save Method
        // Save As Method
        private void SaveMethod()
        {
            if (path != "")
            {
                ConvertToAscii_Save = ConvertToAscii_Class;
                ConvertToAscii_Save._isColor = false;
                ConvertToAscii_Save._scaleNum = ConvertToAscii_Class._scaleNum;
                clearFrameCache(ConvertToAscii_Save);

                string folderPath = Path.GetDirectoryName(path) + "\\"
                    + Path.GetFileNameWithoutExtension(path)
                    + "_Ascii" + "\\";
                string fileName = Path.GetFileNameWithoutExtension(path);

                sfd = new SaveFileDialog();

                SaveToFolder(ConvertToAscii_Save, folderPath, fileName, sfd);
            }
            else
            {
                saveButtonPressed = false;
            }
        }       
        private void SaveAs()
        {
            if (path != "")
            {
                ConvertToAscii_Save = ConvertToAscii_Class;
                ConvertToAscii_Save._isColor = false;
                ConvertToAscii_Save._scaleNum = ConvertToAscii_Class._scaleNum;
                clearFrameCache(ConvertToAscii_Save);

                string folderPath = Path.GetDirectoryName(sfd.FileName) + "\\";
                    //+ Path.GetFileNameWithoutExtension(sfd.FileName)
                   // + "_Ascii" + "\\";
                string fileName = Path.GetFileNameWithoutExtension(sfd.FileName);

                SaveToFolder(ConvertToAscii_Save, folderPath, fileName, sfd);
            }
        }
        private void SaveToFolder(ConvertToAscii CRS, string folderPath, string fileName, SaveFileDialog sfd)
        {
            StreamWriter sw = null;

            for (int i = 0; i <= CRS._numFrames - 1; i++)
            {
                string frame = CRS.postFrame(i)
                    .Replace("&nbsp;", " ")
                    .Replace("<BR>", "\r\n")
                    .Replace("<pre><Font size=0>", "")
                    .Replace("</Font></pre>", "");

                Directory.CreateDirectory(folderPath);
                Console.WriteLine(folderPath);
                sfd.FileName = folderPath
                    + fileName
                    + "-" + i.ToString()
                    + ".txt";
                Console.WriteLine(sfd.FileName);
                sw = new StreamWriter(sfd.FileName);
                sw.Write(frame);
                sw.Flush();
                sw.Close();
            }
        }

        //
        //
        //
        // Pull Window
        List<ImageWindow> imgWinList = new List<ImageWindow>();
        List<string> animationFrames = new List<string>();

        int winCounter = 0;
        int curPopWindow = 0;
        Size popOutSize = new Size();
        int popWidth = 0;
        int popHeight = 0;

        private void pbxPullWindow_Click(object sender, EventArgs e)
        {

            animationFrames.Clear();
            for(int i = 0; i < ConvertToAscii_Class._numFrames -1; i++)
            {
                animationFrames.Add(ConvertToAscii_Class.postFrame(i));
            }
            string aniName = Path.GetFileNameWithoutExtension(path);

            imgWin = new ImageWindow(animationFrames);
            imgWin.Name = aniName;           
            imgWinList.Add(imgWin);

            //
            //
            //PopOutWIndowStats pop = new PopOutWIndowStats(imgWin);
            //pop.Show();
            //
            //

            _ConvertPopOutWindowList.Items.Clear();
            int count = 0;
            foreach(ImageWindow win in imgWinList)
            {

                _ConvertPopOutWindowList.Items.Add(win.Name);
                count++;
            }

            popOutSize.Width = imgWinList[winCounter].Width;
            popOutSize.Height = imgWinList[winCounter].Width;
            _ConvertPopOutWidthTbx.Text = imgWinList[winCounter].Width + "px";
            _ConvertPopOutHeightTbx.Text = imgWinList[winCounter].Height + "px";

            winCounter++;
        }

        // Resizing Selected Pop Out Window
        private void _ConvertPopOutWidthTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (imgWinList.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Int32.TryParse(_ConvertPopOutWidthTbx.Text, out popWidth))
                    {
                        popOutSize.Width = popWidth;
                        imgWinList[curPopWindow].Width = popOutSize.Width;
                    }
                }

                PopOutSizeKeyPress(e);
            }
        }
        private void _ConvertPopOutWidthTbx_Leave(object sender, EventArgs e)
        {
            if (imgWinList.Count > 0)
            {
                _ConvertPopOutWidthTbx.Text = popOutSize.Width + "px";
            }
        }

        private void _ConvertPopOutHeightTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (imgWinList.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Int32.TryParse(_ConvertPopOutHeightTbx.Text, out popHeight))
                    {
                        popOutSize.Height = popHeight;
                        imgWinList[curPopWindow].Width = popOutSize.Width;
                    }
                }

                PopOutSizeKeyPress(e);
            }
        }
        private void _ConvertPopOutHeightTbx_Leave(object sender, EventArgs e)
        {
            if (imgWinList.Count > 0)
            {
                _ConvertPopOutWidthTbx.Text = popOutSize.Width + "px";
            }
        }

        private void PopOutSizeKeyPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                popOutSize.Width -= 5;
                imgWinList[curPopWindow].Width = popOutSize.Width;
                _ConvertPopOutWidthTbx.Text = popOutSize.Width.ToString() +"px";
            }

            if (e.KeyCode == Keys.Right)
            {
                popOutSize.Width += 5;
                imgWinList[curPopWindow].Width = popOutSize.Width;
                _ConvertPopOutWidthTbx.Text = popOutSize.Width.ToString() + "px";
            }

            if (e.KeyCode == Keys.Up)
            {
                popOutSize.Height -= 5;
                imgWinList[curPopWindow].Height = popOutSize.Height;
                _ConvertPopOutHeightTbx.Text = popOutSize.Height.ToString() + "px";
            }

            if (e.KeyCode == Keys.Down)
            {
                popOutSize.Height += 5;
                imgWinList[curPopWindow].Height = popOutSize.Height;
                _ConvertPopOutHeightTbx.Text = popOutSize.Height.ToString() + "px";
            }
        }

        // Moving Selected Pop Out Window
        bool moving = false;
        Point moveOffset = Point.Empty;
        private void _ConvertPopOutMove_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            _ConvertPopOutMove.Image = null;
            Cursor.Current = new Cursor("Resources\\Aim.cur");
        }
        private void _ConvertPopOutMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (imgWinList.Count > 0 && moving == true)
            {
                /*
                Point p = new Point();
                if (moveOffset == Point.Empty)
                {
                    moveOffset.X = Cursor.Position.X - imgWinList[curPopWindow].Location.X;
                    moveOffset.Y = Cursor.Position.Y - imgWinList[curPopWindow].Location.Y;
                }
                p.X = Cursor.Position.X - moveOffset.X;
                p.Y = Cursor.Position.Y - moveOffset.Y;
                */
                imgWinList[curPopWindow].Location = Cursor.Position;
            }
        }
        private void _ConvertPopOutMove_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            _ConvertPopOutMove.Image = new Bitmap(("Resources\\MovePop.png"));
        }

        // Pop Out Window List
        private void _ConvertPopOutShowWindowList_Click(object sender, EventArgs e)
        {
            if(_ConvertPopOutWindowList.Visible == false)
            {
                _ConvertPopOutWindowList.Visible = true;
            }else
            {
                _ConvertPopOutWindowList.Visible = false;
            }
        }
        private void _ConvertPopOutWindowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            curPopWindow = _ConvertPopOutWindowList.SelectedIndex;
        }
        private void _ConvertPopOutWindowList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (_ConvertPopOutWindowList.SelectedIndex <= imgWinList.Count)
                {
                    curPopWindow = _ConvertPopOutWindowList.SelectedIndex;
                    imgWinList[curPopWindow].Close();
                    imgWinList[curPopWindow].Dispose();
                    imgWinList.RemoveAt(curPopWindow);

                    int count = 0;
                    _ConvertPopOutWindowList.Items.Clear();
                    foreach (ImageWindow win in imgWinList)
                    {
                        _ConvertPopOutWindowList.Items.Add(win.Name);
                        count++;
                    }
                }
            }
        }

        // Clone
        public static ConvertToAscii Clone(ConvertToAscii source)
        {
            if(!typeof(ConvertToAscii).IsSerializable)
            {
                throw new ArgumentException("Type Aint Serializable.", "source");
            }
            if(Object.ReferenceEquals(source, null))
            {
                return default(ConvertToAscii);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using(stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (ConvertToAscii)formatter.Deserialize(stream);
            }
        }

        //
        //
        //
        // OG Image PBX
        bool ogResizing = false;

        Point orion = new Point();
        bool orion_set = false;
        int ogWidth = 0;
        int ogHeight = 0;

        bool ogMoving = false;
        Point p = new Point();
        private void OGImageThumb_MouseUp(object sender, MouseEventArgs e)
        {
            ogMoving = false;
            ogResizing = false;
            orion_set = false;
            
            //OGImageThumb.BackgroundImage = ogImageArray[curFrameIndex];
            /* if (OGImageThumb.BackgroundImage != null)
            {
                Image img = OGImageThumb.BackgroundImage;
                Graphics g = Graphics.FromImage(img);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, OGImageThumb.Width, OGImageThumb.Height);
                g.Dispose();
                OGImageThumb.BackgroundImage = img;
            } */
        }
        private void OGImageThumb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ogResizing = true;
                ogWidth = OGImageThumb.Width;
                ogHeight = OGImageThumb.Height;
            }
            
            if(e.Button == MouseButtons.Left)
            {
                ogMoving = true;
                //OGImageThumb.BackgroundImage = null;
            }
        } 
        private void OGImageThumb_MouseMove(object sender, MouseEventArgs e)
        {
            if(ogMoving)
            {
                if(!orion_set)
                {
                    orion.X = Cursor.Position.X - OGImageThumb.Location.X;
                    orion.Y = Cursor.Position.Y - OGImageThumb.Location.Y;
                    orion_set = true;
                }
                p.X = Cursor.Position.X - orion.X;
                p.Y = Cursor.Position.Y - orion.Y;
                OGImageThumb.Location = p;
            }

            if (ogResizing)
            {
                if(!orion_set)
                {
                    orion.X = e.Location.X;
                    orion.Y = e.Location.Y;
                    orion_set = true;
                }

                if((e.X - orion.X) % 3 == 0)
                {
                    OGImageThumb.Width = ogWidth + (e.X - orion.X);

                    OGImageThumb.Height = (int)Math.Ceiling((double)(ogHeight * OGImageThumb.Width / ogWidth));
                }
                /*if ((e.Y - orion.Y) % 3 == 0)
                {
                    OGPanel.Height = ogHeight + (e.Y - orion.Y);
                    OGImageThumb.Height = OGPanel.Height;
                } */

            }
        }

    }
}
