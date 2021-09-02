using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Timers;

namespace CristalMiner
{
    class Animator
    {

    }
    class Animation
    {
        private List<string> Timages = new List<string>();
        private List<Bitmap> images = new List<Bitmap>();
        private Bitmap def = new Bitmap(10, 10);
        private Timer timer = new Timer();
        private int number = 0;
        private Rectangle rect;
        public Animation(string path, Rectangle Rect)
        {
            rect = Rect;
            GetImage(path, rect);
            timer.Elapsed += Ticker;
        }

        private void GetImage(string path, Rectangle rect)
        {
            List<string> files = new List<string>();
            foreach (string item in Directory.GetFiles(path))
            {
                if (Path.GetExtension(item) == ".png")
                    images.Add(ShrinkImage(new Bitmap(item), 1));
            }
        }
        private Bitmap SqueezeImage(string path, Rectangle rect)
        {
            //Bitmap orgBitmap = new Bitmap(path);
            Bitmap regBitmap = new Bitmap(rect.Width, rect.Height);
            //using (Graphics g = Graphics.FromImage(regBitmap))
            //{
            //    regBitmap = orgBitmap;
            //}
            //regBitmap = new Bitmap(path);
            return regBitmap;
        }

        private Bitmap ShrinkImage(Bitmap original, int scale)
        {
            Bitmap bmp = new Bitmap(original.Width / scale, original.Height / scale,
                                    original.PixelFormat);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                Rectangle srcRect = new Rectangle(0, 0, original.Width, original.Height);
                Rectangle destRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                G.DrawImage(original, destRect, srcRect, GraphicsUnit.Pixel);
                bmp.SetResolution(original.HorizontalResolution, original.VerticalResolution);
            }
            return (Bitmap)bmp;
        }

        public Image GetImage()
        {
            if (timer.Enabled == true)
            {
                Bitmap b = new Bitmap(images[number]);
                return b;
            }
            else
                return def;
        }

        public void nextFrame()
        {
            if (number != images.Count() - 1)
                number += 1;
            else
                number = 0;
        }

        public void Play(int interval)
        {
            if (timer.Enabled != true)
            {
                timer.Interval = interval;
                timer.Enabled = true;
            }
        }
        public void Stop()
        {
            if (timer.Enabled)
                timer.Stop();
        }

        private void Ticker(object sender, EventArgs e)
        {
            nextFrame();
        }

        public void setDefaultImage(Bitmap image)
        {
        //    def = image;
        }
        public void Update()
        {

        }
        public int Count()
        {
            return images.Count();
        }
        public int Frame()
        {
            return number;
        }
        public Rectangle getRect()
        {
            return rect;
        }
        
    }
}
