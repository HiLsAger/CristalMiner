using System.Drawing;

namespace CristalMiner.player.ship
{
    public class Ship : Entity
    {
        public Ship(int x, int y, int width, int height, float acceleration, float speedX, float speedY, Image image) : base(x, y, width, height, acceleration, speedX, speedY, image)
        {
        }
    }
}
