using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIAC
{
    public partial class ImageWindow : Form
    {
        List<string> animationFrames;
        int curFrame = 0;
        //
        //
        bool moving = false;
        bool isOffset = false;
        Point offset = new Point();
        Size size = new Size();

        public ImageWindow(List<string> animationFramesList)
        {
            InitializeComponent();
            _Field.DocumentText = "";

            animationFrames = animationFramesList;
            this.Show();
        }

        private void ImageWindow_Load(object o, EventArgs args)
        {
            _Field.Location = new Point(0, 0);
            _Field.Font = new Font(FontFamily.GenericMonospace, _Field.Font.Size);
            aniTimer.Start();
            //this.TopMost = true;
            Point p = new Point(1000, 500);
            this.Location = p;
            this.TransparencyKey = Color.White;
            this.TopMost = true;
        }

        // Timer
        private void aniTimer_Tick(object o, EventArgs args)
        {
            if (curFrame == animationFrames.Count - 1)
            { curFrame = 0; }

            _Field.DocumentText = animationFrames[curFrame];

            curFrame++;
        }
        // Resize
        private Size resizeToContent()
        {
            Graphics g = CreateGraphics();
            size.Width = TextRenderer.MeasureText(_Field.Text, _Field.Font).Width;
            size.Height = TextRenderer.MeasureText(_Field.Text, _Field.Font).Height;

            g.Dispose();

            return size;
        }

        // Mouse Down/Up/Move 
        private void Move_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            aniTimer.Stop();
        }

        private void Move_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            isOffset = false;
            aniTimer.Start();
        }

        private void Move_MouseMove(object sender, MouseEventArgs e)
        {           
            if (moving == true)
            {
                Point p = new Point();
                if (!isOffset)
                {
                    offset.X = Cursor.Position.X - this.Location.X;
                    offset.Y = Cursor.Position.Y - this.Location.Y;
                    isOffset = true;
                }
                p.X = Cursor.Position.X - offset.X;
                p.Y = Cursor.Position.Y - offset.Y;
                this.Location = p;
            }
        }
    }
}
