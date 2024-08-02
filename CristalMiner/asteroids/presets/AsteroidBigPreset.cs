using CristalMiner.asteroids.storage;
using System;
using System.Drawing;

namespace CristalMiner.asteroids.presets
{
    public class AsteroidBigPreset
    {
        private Random random = new Random();

        private float acceleration = 0;

        private Size size;

        private Point position;

        public AsteroidBigPreset() {
            resetSize();
            resetPosition();
        }

        public Asteroid init()
        {
            int material = AsteroidStorage.getRandomMaterial();

            return new Asteroid(
                    this.position.X,
                    this.position.Y,
                    this.size.Width,
                    this.size.Height,
                    this.acceleration,
                    this.getSpeedX(),
                    this.getSpeedY(),
                    AsteroidStorage.getAsteroidRandomImageByMaterial(material),
                    AsteroidStorage.ASTEROID_TAG_BIG,
                    material
                );
        }

        private void resetSize()
        {
            int sizeWH = this.random.Next(
                AsteroidStorage.minAsteroidSize, 
                AsteroidStorage.maxAsteroidSize
                );

            this.size = new Size(sizeWH, sizeWH);
        }

        private void resetPosition()
        {
            this.position = new Point(
                this.random.Next(0 - this.size.Width / 2, Global.Width - this.size.Width / 2),
                0
            );

        }

        private int getSpeedX()
        {
            return AsteroidPresetsStorage.instanceBigAsteroidHorizontalRange.randomNumber();
        }

        private int getSpeedY()
        {
            return AsteroidPresetsStorage.instanceBigAsteroidVerticalRange.randomNumber();
        }
    }
}
