using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace GIAC
{
    public class ConvertToAscii
    {
        public List<string> renderedFrames = new List<string>();
        string _path;
        Image MainImage;
        Image curImage;
        FrameDimension frameDimension;
        public string[] asciiFrames;
        private int numFrames;
        public int scaleNum = 200;
        //
        //
        BackgroundWorker gifArray_bw = new BackgroundWorker();
        bool gifArray_bwComplete = false;
        //
        //
        bool lineBreak = false;
        Bitmap bmp;      
        private int _ArraySize = 10;
        bool isHarsh = false;
        bool isInvert = false;
        bool isColor = false;
        bool isMono = false;
        private string[] _AsciiChars_Default = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };
        private string[] _AsciiChars_Harsh = { "█", "▓", "▒", "░", "@", "$", "%", "®", "-", ".", "&nbsp;" };
        private string[] _AsciiCharsSelected;
        //
        //
        string resizeAlg = "ByWidth";
        //
        //

        // Main 
        public ConvertToAscii(string path)
        {
            _path = path;
            if(checkFileFormat(_path) != null)
            {
                MainImage = Image.FromFile(_path);             
                frameDimension = new FrameDimension(MainImage.FrameDimensionsList[0]);
                numFrames = MainImage.GetFrameCount(frameDimension);
            }          
        }
        //
        //
        //

        //
        //// Adjust for Web Format
        //
        private string asciiWebBrowser(string content)
        {
            return "<pre>" + "<Font size=0>" + content + "</Font></pre>";
        }

        //
        //// Ascii From Image
        //
        private string asciiFromFrame1(int index)
        {
            string content = "";
            MainImage.SelectActiveFrame(frameDimension, index);
            Image img = new Bitmap(MainImage);
            img = imageScale(img, scaleNum, resizeAlg);

           
            content = asciiConversion(img);

            return content;
        }

        //
        //// Ascii From Image
        //
        private string asciiFromFrame(int index)
        {
            string content = "";

            if (renderedFrames[index] == "")
            {
                MainImage.SelectActiveFrame(frameDimension, index);
                Image img = new Bitmap(MainImage);
                img = imageScale(img, scaleNum, resizeAlg);

                content = asciiConversion(img);
                renderedFrames.Insert(index, content);

                curImage = img;
                return content;
            }
            else
            {
                content = renderedFrames[index];
                return content;
            }
        }

        //
        //// Ascci From Image Convert Method
        //
        //bool extraLB = false;
        private string asciiConversion(Image image)
        {   
    
            StringBuilder sb = new StringBuilder();
            bmp = new Bitmap(image);
            lineBreak = false;
            //
            //
            Color pxColor;
            Color pxColorGray;
            int red;
            int green;
            int blue;
            //
            // 
            int index;
            //
            //

            if (isHarsh)
            { _AsciiCharsSelected = _AsciiChars_Harsh; }
            else { _AsciiCharsSelected = _AsciiChars_Default; }

            // r = Row
            // p = Pixel
            for(int r = 0; r < image.Height; r++)
            {
                for(int p = 0; p < image.Width; p++)
                {
                    // Read The Current Pixels Color
                    // Desaturate
                    pxColor = bmp.GetPixel(p, r);
                    red = (pxColor.R + pxColor.G + pxColor.B) / 3;
                    green = red;
                    blue = red;
                    pxColorGray = Color.FromArgb(red, green, blue);

                    // Append Character to String
                    if (!lineBreak)
                    {
                        if (isMono)
                        {
                            sb.Append("<font color='rgb(" + pxColor.R + "," + pxColor.G + "," + pxColor.B + ")'>");
                            sb.Append("█");
                            sb.Append("</font>");
                        }
                        else
                        {
                            if (isColor)
                            {
                                sb.Append("<font color='rgb(" + pxColor.R + "," + pxColor.G + "," + pxColor.B + ")'>");

                                _ArraySize = _AsciiCharsSelected.Length - 1;
                                index = (pxColorGray.R * _ArraySize) / 255;

                                if (isInvert)
                                { sb.Append(_AsciiCharsSelected[10 - index]); }
                                else { sb.Append(_AsciiCharsSelected[index]); }

                                sb.Append("</font>");
                            }
                            else
                            {
                                _ArraySize = _AsciiCharsSelected.Length - 1;
                                index = (pxColorGray.R * _ArraySize) / 255;

                                if (isInvert)
                                { sb.Append(_AsciiCharsSelected[10 - index]); }
                                else { sb.Append(_AsciiCharsSelected[index]); }
                            }
                        }
                    }
                }

                // Append <BR> (New Line)
                if(!lineBreak)
                {
                    sb.Append("<BR>");
                    lineBreak = true;                  
                }
                else 
                { 
                    lineBreak = false;
                }
            }
            return sb.ToString();
        }

        //
        //// Image Scaling
        //
        private Bitmap imageScale(Image img, int value, string algorithm)
        {
            int width = 0;
            int height = 0;

            switch (algorithm)
            {
                case "ByWidth":
                    width = value;
                    height = (int)(Math.Ceiling((double)img.Height * width / img.Width));
                    break;

                case "Procent":
                    //width = (int)(Math.Ceiling((double)img.Width * (value / 100)));
                    //height = (int)(Math.Ceiling((double)img.Height * (value / 100)));
                    break;

                default:
                    width = value;
                    height = (int)(Math.Ceiling((double)img.Height * width / img.Width));
                    break;
            }

            // CREATE NEW IMAGE WITH NEW HEIGHT AND WIDTH
            Bitmap result = new Bitmap(width, height);

            // DRAW  THE NEWLY RESIZE IMAGE
            Graphics g = Graphics.FromImage((Image)(result));
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();
            return result;
        }

        //
        //// Fill Ascii Gif Array
        //
        private void fillGifFrameArray()
        {
            int numFrames = MainImage.GetFrameCount(frameDimension);
            asciiFrames = new string[numFrames];

            for(int i = 0; i < numFrames; i++)
            {
                MainImage.SelectActiveFrame(frameDimension, i);
                asciiFrames[i] = asciiWebBrowser(asciiConversion(MainImage));
            }
            
        }

        //
        //// Check File Format
        //
        public string checkFileFormat(string path)
        {
            string fileExtention = Path.GetExtension(path);
            string[] ExtentionArray = { ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".PNG", ".JPG"};
            if(ExtentionArray.Contains(fileExtention))
            {
                return fileExtention;
            }
            return null;
        }


        public string postFrame(int index)
        {
            return asciiWebBrowser(asciiFromFrame(index));
        }

        //
        //// BAckground Worker
        //
        private void gifArrayDoWork()
        {
            gifArray_bw.DoWork += new DoWorkEventHandler(delegate(object o, DoWorkEventArgs args)
            {
                //BackgroundWorker prg = o as BackgroundWorker;
                fillGifFrameArray();
            });

            gifArray_bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate(object o, RunWorkerCompletedEventArgs args)
            {
                gifArray_bwComplete = true;
            });
        }

        //
        //
        //
        // Get / Set
        public int _scaleNum
        {
            get { return scaleNum; }
            set { scaleNum = value; }
        }

        public int _numFrames
        {
            get { return numFrames; }
        }

        public int _arraySize
        {
            get { return _ArraySize; }
        }

        public string _resizeAlg
        {
            get { return resizeAlg; }
            set { resizeAlg = value; }
        }

        public string[] _asciiChars
        {
            get { return _AsciiCharsSelected; }
            set { _AsciiCharsSelected = value; }
        }

        public bool _gifArray_bsComplete
        {
            get { return gifArray_bwComplete; }
        }

        public bool _isHarsh
        {
            get { return isHarsh; }
            set { isHarsh = value; }
        }
        public bool _isInvert
        {
            get { return isInvert; }
            set { isInvert = value; }
        }
        public bool _isColor
        {
            get { return isColor; }
            set { isColor = value; }
        }
        public bool _isMono
        {
            get { return isMono; }
            set { isMono = value; }
        }

        public Image _curImage
        {
            get { return curImage; }
        }

        public Image _MainImage
        {
            get { return MainImage; }
        }
      
    }
}
