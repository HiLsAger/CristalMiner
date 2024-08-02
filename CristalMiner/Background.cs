using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CristalMiner
{
    public class Background
    {
        public Color Back_Color;
        public List<Entity> stars = new List<Entity>();
        public int starsLimit;
        private List<Color> colorsStars = new List<Color>();

        public Background( Color background, int StarsLimit)
        {
            colorsStars.Add(Color.White);
            colorsStars.Add(Color.Yellow);
            colorsStars.Add(Color.Red);
            colorsStars.Add(Color.Blue);

            Back_Color = background;

            starsLimit = 70;
        }

        public void Update()
        {
            RemoveStars();
            MoveStar();
            CreateStars();
        }

        public void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < stars.Count(); i++)  //draw stars
                g.FillEllipse(new SolidBrush(stars[i].color), stars[i].getRect());
        }

        public void MoveStar()
        {
            for (int i = 0; i < stars.Count(); i++)
            {
                stars[i].y = stars[i].y + Convert.ToInt32(stars[i].speedY);
                stars[i].x += Convert.ToInt32(stars[i].speedX);
            }
        }
        public void RemoveStars()
        {
            for (int i = 0; i < stars.Count(); i++)
            {
                if (stars[i].y > Global.Height)
                    stars.RemoveAt(i);
            }
        }

        public void CreateStars()
        {
            if (stars.Count() < starsLimit)
            {
                Random rand = new Random();
                for (int i = stars.Count(); i < starsLimit; i++)
                {
                    int size = rand.Next(2, 8);
                    stars.Add(new Entity(rand.Next(0, Global.Width), -15, size, size, 0, rand.Next(-3, 3), rand.Next(4, 12), colorsStars[rand.Next(0, 3)]));
                }
            }
        }
        public void CreateLocation()
        {
            Random rand = new Random();
            for (int i = stars.Count(); i < starsLimit; i++)
            {
                int size = rand.Next(2, 8);
                stars.Add(new Entity(rand.Next(0, Global.Width), rand.Next(0, Global.Height), size, size, 0, rand.Next(-3, 3), rand.Next(4, 12), colorsStars[rand.Next(0, 3)]));
            }
        }
    }
}
