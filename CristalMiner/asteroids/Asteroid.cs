using System;
using System.Drawing;

namespace CristalMiner.asteroids
{
    public class Asteroid : Entity
    {
        public int material;

        public Asteroid(int x, int y, int width, int height, float acceleration, float speedX, float speedY, Image image, string tag, int material)
            : base(x, y, width, height, acceleration, speedX, speedY, image)
        {
            this.tag = tag;
            this.material = material;
        }

        public void Move()
        {
            this.y += Convert.ToInt32(this.speedY);
            this.x += Convert.ToInt32(this.speedX);
        }

        public bool isTag(string tag)
        {
            return this.tag == tag;
        }

        public bool isHealthLessZero()
        {
            return this.healthPoint <= 0;
        }
    }
}
