using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CristalMiner
{
    public class Entity : EntityParent
    {
        public float acceleration;

        public float speedX, speedY;

        public int healthPoint;

        public Color color;

        public Image image;

        public string tag { get; set; }

        public Entity(int x, int y, int width, int height, float acceleration, float speedX, float speedY , Color color)
            :base(x, y, width, height)
        {
            this.color = color;
            this.acceleration = acceleration;
            this.speedX = speedX;
            this.speedY = speedY;
            this.healthPoint = 20;
        }

        public Entity(int x, int y, int width, int height, float acceleration, float speedX, float speedY, Image image)
            : base(x, y, width, height)
        {
            this.image = image;
            this.acceleration = acceleration;
            this.speedX = speedX;
            this.speedY = speedY;
            this.healthPoint = 20;
        }

        public Rectangle getRect()
        {
            return new Rectangle(
                this.x, 
                this.y, 
                this.width, 
                this.height
            );
        }

        public void setImage(Image image)
        {
            this.image = image;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }
    }
}
