using CristalMiner.asteroids.presets;
using CristalMiner.asteroids.storage;
using CristalMiner.library.interfaces;

namespace CristalMiner.asteroids
{
    public class AsteroidFactory : IEntityFactory
    {
        private Asteroid bigAsteroid;

        private int countFragments = 0;

        public Entity Build(string tag)
        {
            switch (tag)
            {
                case AsteroidStorage.ASTEROID_TAG_BIG:
                    AsteroidBigPreset asteroidBigPreset = new AsteroidBigPreset();
                    return asteroidBigPreset.init();
                case AsteroidStorage.ASTEROID_TAG_SMALL:
                    AsteroidSmallPreset asteroidSmallPreset = new AsteroidSmallPreset(this.bigAsteroid, this.countFragments);
                    this.clearData();
                    return asteroidSmallPreset.init();
            }
            return null;
        }

        public AsteroidFactory setBigAsteroid(Asteroid asteroid)
        {
            this.bigAsteroid = asteroid;

            return this;
        }

        public AsteroidFactory setCountFragments(int countFragments)
        {
            this.countFragments = countFragments;

            return this;
        }

        private void clearData()
        {
            this.bigAsteroid = null;
            this.countFragments = 0;
        }
    }
}
