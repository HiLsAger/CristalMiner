using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalMiner
{
    static class Global
    {
        public static int Width;
        public static int Height;

        public static int Horizontal;
        public static int Vertical;

        public static bool console;
        public static bool gameover;

        public static void setWindow(int width, int height)
        {
            Width = width;
            Height = height;
        }

        static public bool Collision(Entity object1, Entity object2)
        {
            if ((object1.x < object2.x && object1.x + object1.width > object2.x && object1.y < object2.y && object1.y + object1.height > object2.y) ||
                (object1.x < object2.x + object2.width && object1.x + object1.width > object2.x + object2.width && object1.y < object2.y && object1.y + object1.height > object2.y) ||
                (object1.x < object2.x && object1.x + object1.width > object2.x && object1.y < object2.y + object2.height && object1.y + object1.height > object2.y + object2.height) ||
                (object1.x < object2.x + object2.width && object1.x + object1.width > object2.x + object2.width && object1.y < object2.y + object2.height && object1.y + object1.height > object2.y + object2.height))
            {
                return true;
            }
            return false;
        }

    }
}
