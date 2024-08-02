using CristalMiner.library.classes;

namespace CristalMiner.asteroids.storage
{
    public static class AsteroidPresetsStorage
    {
        public static Range instanceBigAsteroidVerticalRange = new Range(3, 6);
        public static Range instanceBigAsteroidHorizontalRange = new Range(-3, 3);

        public static Range instanceSmallAsteroidHorizontalRange = new Range(-5, 5);
        public static Range instanceSmallAsteroidVerticalRange = new Range(4, 8);
    }
}
