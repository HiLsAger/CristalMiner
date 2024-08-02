using CristalMiner.library.classes;
using System.Drawing;

namespace CristalMiner
{
    public abstract class EntityParent
    {
        public Point position;

        public int width;

        public int height;

        public int x {
            get { return this.position.X; }
            set { this.position.X = value;}
        }

        public int y
        {
            get { return this.position.Y; }
            set { this.position.Y = value; }
        }

        public EntityParent(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;

            this.position = new Point(x, y);
        }
    }
}
