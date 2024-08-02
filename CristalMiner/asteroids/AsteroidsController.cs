using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using CristalMiner.asteroids;
using CristalMiner.asteroids.storage;
using CristalMiner.library.interfaces;

namespace CristalMiner.Asteroids
{
    public class AsteroidsController : IController
    {
        private Random random = new Random();

        private AsteroidFactory factory = new AsteroidFactory();

        public List<Asteroid> asteroids = new List<Asteroid>();

        private List<Animation> boom = new List<Animation>();

        public AsteroidsController(int maxAsteroid, int minAsteroidSize, int maxAsteroidSize)
        {
            AsteroidStorage.maxAsteroid = maxAsteroid;
            AsteroidStorage.minAsteroidSize = minAsteroidSize;
            AsteroidStorage.maxAsteroidSize = maxAsteroidSize;
        }

        public void Update()
        {
            this.CreateAsteroid(AsteroidStorage.ASTEROID_TAG_BIG);
            this.Destroy();
            foreach (Asteroid asteroid in this.asteroids)
            {
                asteroid.Move();
            }
            for (int i = 0; i < boom.Count(); i++)
            {
                boom[i].Play(70);
                if (boom[i].Count() - 1 == boom[i].Frame())
                {
                    boom.RemoveAt(i);
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (Asteroid asteroid in this.asteroids)
            {
                graphics.DrawImage(asteroid.image, asteroid.getRect());
            }
            foreach (Animation animBoom in this.boom)
            {
                graphics.DrawImage(animBoom.GetImage(), animBoom.getRect());
            }
        }

        public void CreateAsteroid(string tag)
        {
            if (this.isMaxAsteroidByTag(AsteroidStorage.ASTEROID_TAG_BIG))
            {
                return;
            }

            this.asteroids.Add((Asteroid)this.factory.Build(tag));
        }

        public void Destroy()
        {
            for (int i = 0; i < this.asteroids.Count(); i++)
            {
                if (!asteroids[i].isHealthLessZero())
                {
                    continue;
                }

                if (asteroids[i].isTag(AsteroidStorage.ASTEROID_TAG_BIG))
                {
                    this.createSmallAsteroids(asteroids[i]);
                    continue;
                }

                this.boom.Add(new Animation("Resourse/Animations/explosion", asteroids[i].getRect()));
                this.asteroids.RemoveAt(i);
            }
            this.RemoveAsteroid();
        }

        private void createSmallAsteroids(Asteroid asteroid)
        {
            int countFragments = this.random.Next(3, 5);
            for (int j = 0; j < countFragments; j++)
            {
                this.boom.Add(new Animation("Resourse/Animations/explosion", asteroid.getRect()));
                this.factory.setBigAsteroid(asteroid).setCountFragments(countFragments);
                this.asteroids.Add((Asteroid)this.factory.Build(AsteroidStorage.ASTEROID_TAG_SMALL));

                asteroid.healthPoint = 10;
            }
            asteroid.healthPoint = 0;
        }

        public void RemoveAsteroid()
        {
            if (this.asteroids.Count < 0)
            {
                return;
            }

            for (int i = 0; i < this.asteroids.Count(); i++)
            {
                if (asteroids[i].y > Global.Height || asteroids[i].healthPoint <= 0)
                {
                    this.asteroids.RemoveAt(i);
                    break;
                }
            }
        }

        private bool isMaxAsteroidByTag(string tag)
        {
            int bigAsteroidsCount = 0;

            foreach (Asteroid asteroid in this.asteroids)
            {
                bigAsteroidsCount += asteroid.tag == tag ? 1 : 0;
            }

            return bigAsteroidsCount >= AsteroidStorage.maxAsteroid;
        }
    }
}
