using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CristalMiner
{
    class Entity
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public float acceleration;
        public float speedX, speedY;
        public int healthPoint;
        public Color color;
        public Image image;
        public string tag;

        public Entity(int X, int Y, int Width, int Height, float Acceleration, float SpeedX, float SpeedY , Color colour)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
            color = colour;
            acceleration = Acceleration;
            speedX = SpeedX;
            speedY = SpeedY;
            healthPoint = 20;
        }
        public Entity(int X, int Y, int Width, int Height, float Acceleration, float SpeedX, float SpeedY, Image Image)
        {
            x = X;
            y = Y;
            width = Width;
            height = Height;
            image = Image;
            acceleration = Acceleration;
            speedX = SpeedX;
            speedY = SpeedY;
            healthPoint = 20;
        }

        public Rectangle getRect()
        {
            return new Rectangle(x, y, width, height);
        }

        public void setImage(Image Image)
        {
            image = Image;
        }

        public void setColor(Color colour)
        {
            color = colour;
        }
    }
}
