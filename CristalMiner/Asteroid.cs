using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CristalMiner
{
    class Asteroid
    {
        public List<Entity> asteroids = new List<Entity>();
        List<Image> images = new List<Image>();

        public int maxAsteroids = 0, minSize = 0, maxSize = 0;
        private List<Animation> boom = new List<Animation>();


        public Asteroid(int MaxAsteroids, int MinSize, int MaxSize)
        {
            maxAsteroids = MaxAsteroids;
            minSize = MinSize;
            maxSize = MaxSize;

            images.Add(Properties.Resources.CametaIron);
            images.Add(Properties.Resources.CametaIron2);

        }
        public void Update()
        {
            CreateAsteroid("Big");
            Destroy();
            Move();
            for (int i = 0; i < boom.Count(); i++)
            {
                boom[i].Play(70);
                if (boom[i].Count()-1 == boom[i].Frame())
                    boom.RemoveAt(i);
            }
        }

        public void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < asteroids.Count(); i++)     //draw asteroids
                g.DrawImage(asteroids[i].image, asteroids[i].getRect());
            for (int i = 0; i < boom.Count(); i++)
                g.DrawImage(boom[i].GetImage(), boom[i].getRect());
        }
        public void CreateAsteroid(string tag)
        {
            Random rand = new Random();
            int n = 0;
            for (int i = 0; i < asteroids.Count(); i++)
                if (asteroids[i].tag == "Big")
                    n += 1;
            if (n < maxAsteroids)
            {
                int size = rand.Next(minSize, maxSize);
                asteroids.Add(new Entity(rand.Next(0 - size / 2, Global.Width - size/2), 0, size, size, 0, rand.Next(-3, 3), rand.Next(3, 6), images[0]));
                asteroids[asteroids.Count() - 1].tag = tag;
            }
        }

        public void Destroy()
        {
            Random rand = new Random();
            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (asteroids[i].healthPoint <= 0 && asteroids[i].tag == "Big")
                {
                    int elements = rand.Next(3, 5);
                    for (int j = 0; j < elements; j++)
                    {
                        boom.Add(new Animation("Resourse/Animations/explosion", asteroids[i].getRect()));
                        asteroids.Add(new Entity(asteroids[i].x + asteroids[i].width / 2, asteroids[i].y + asteroids[i].height / 2, Convert.ToInt16(asteroids[i].width / elements * 2), Convert.ToInt16(asteroids[i].width / elements * 2), 0, rand.Next(-5, 5), rand.Next(4, 8), images[0]));
                        asteroids[i].healthPoint = 10;
                    }
                    asteroids[i].healthPoint = 0;
                }
                else if (asteroids[i].healthPoint <= 0)
                {
                    boom.Add(new Animation("Resourse/Animations/explosion", asteroids[i].getRect()));
                    asteroids.RemoveAt(i);
                }
            }
            RemoveAsteroid();
        }

        public void RemoveAsteroid()
        {
            if (asteroids.Count > 0)
            {
                for (int i = 0; i < asteroids.Count(); i++)
                {
                    if (asteroids[i].y > Global.Height || asteroids[i].healthPoint <= 0)
                    {
                        asteroids.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        public void Move()
        {
            for (int i = 0; i < asteroids.Count(); i++)
            {
                asteroids[i].y += Convert.ToInt32(asteroids[i].speedY);
                asteroids[i].x += Convert.ToInt32(asteroids[i].speedX);
            }
        }
    }
}
