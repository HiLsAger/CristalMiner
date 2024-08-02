using CristalMiner.asteroids.storage;
using CristalMiner.library.interfaces;
using System;
using System.Drawing;
using System.Xml.Linq;

namespace CristalMiner.asteroids.presets
{
    public class AsteroidSmallPreset : IPreset
    {
        private Asteroid bigAsterioid;

        private int countFragments;

        private float acceleration = 0;

        private Size size;

        private Point position;

        public AsteroidSmallPreset(Asteroid bigAsterioid, int countFragments) { 
            this.bigAsterioid = bigAsterioid;
            this.countFragments = countFragments;
            resetSize();
            resetPosition();
        }

        public Entity init()
        {
            return new Asteroid(
                    this.position.X,
                    this.position.Y,
                    this.size.Width,
                    this.size.Height,
                    this.acceleration,
                    this.getSpeedX(),
                    this.getSpeedY(),
                    AsteroidStorage.getAsteroidRandomImageByMaterial(this.bigAsterioid.material),
                    AsteroidStorage.ASTEROID_TAG_SMALL,
                    this.bigAsterioid.material
                );
        }

        private void resetSize()
        {
            this.size = new Size(
                    Convert.ToInt16(this.bigAsterioid.width / this.countFragments * 2),
                    Convert.ToInt16(this.bigAsterioid.width / this.countFragments * 2)
                );
        }

        private void resetPosition()
        {
            this.position = new Point(
                this.bigAsterioid.x + (this.bigAsterioid.width / 2),
                this.bigAsterioid.y + (this.bigAsterioid.height / 2)
            );

        }

        private int getSpeedX()
        {
            return AsteroidPresetsStorage.instanceSmallAsteroidHorizontalRange.randomNumber();
        }

        private int getSpeedY()
        {
            return AsteroidPresetsStorage.instanceSmallAsteroidVerticalRange.randomNumber();
        }
    }
}
