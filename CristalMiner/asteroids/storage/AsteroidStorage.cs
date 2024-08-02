using System;
using System.Collections.Generic;
using System.Drawing;

namespace CristalMiner.asteroids.storage
{
    public static class AsteroidStorage
    {
        public const string ASTEROID_TAG_BIG = "Big";
        public const string ASTEROID_TAG_SMALL = "Small";

        public const int ASTEROID_MATERIAL_IRON = 1;
        public const int ASTEROID_MATERIAL_GOLD = 2;
        public const int ASTEROID_MATERIAL_PLATINA = 3;

        public static int maxAsteroid;
        public static int minAsteroidSize, maxAsteroidSize;

        public static readonly Image asteroidDefaultImage = Properties.Resources.CametaIron;

        public static readonly Dictionary<int, List<Image>> asteroidImages = new Dictionary<int, List<Image>>
    {
        { ASTEROID_MATERIAL_IRON, new List<Image> { 
            Properties.Resources.CametaIron, 
            Properties.Resources.CametaIron2 
        } },
        { ASTEROID_MATERIAL_GOLD, new List<Image> { 
            Properties.Resources.CametaGold, 
            Properties.Resources.CametaGold2 
        } },
        { ASTEROID_MATERIAL_PLATINA, new List<Image> { 
            Properties.Resources.CametaPlatina, 
            Properties.Resources.CametaPlatina2
        } }
    };

        public static int getRandomAsteroidSize()
        {
            Random random = new Random();
            return random.Next(AsteroidStorage.minAsteroidSize, AsteroidStorage.maxAsteroidSize);
        }

        public static Image getAsteroidRandomImage()
        {
            Random random = new Random();

            var keys = new List<int>(asteroidImages.Keys);

            int randomKeyIndex = random.Next(keys.Count);
            int randomKey = keys[randomKeyIndex];

            var images = asteroidImages[randomKey];
            int imageIndex = random.Next(images.Count);

            return images[imageIndex];
        }

        public static Image getAsteroidRandomImageByMaterial(int materialIndex)
        {
            Random random = new Random();

            if (asteroidImages.ContainsKey(materialIndex))
            {
                int imageIndex = random.Next(asteroidImages[materialIndex].Count);
                return asteroidImages[materialIndex][imageIndex];
            }
            return null;
        }

        public static Image getAsteroidImage(int material, int imageIndex)
        {
            if(imageIndex < 0 || material > AsteroidStorage.asteroidImages.Count - 1)
            {
                return AsteroidStorage.asteroidDefaultImage;
            }

            return AsteroidStorage.asteroidImages[material][imageIndex];
        }

        public static int getRandomMaterial() {
            Random random = new Random();
            switch (random.Next(4))
            {
                case AsteroidStorage.ASTEROID_MATERIAL_IRON:
                    return AsteroidStorage.ASTEROID_MATERIAL_IRON;
                case AsteroidStorage.ASTEROID_MATERIAL_GOLD:
                    return AsteroidStorage.ASTEROID_MATERIAL_GOLD;
                case AsteroidStorage.ASTEROID_MATERIAL_PLATINA:
                    return AsteroidStorage.ASTEROID_MATERIAL_PLATINA;
                default:
                    return AsteroidStorage.ASTEROID_MATERIAL_IRON;
            }
        }
    }
}
