using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Timers;
using CristalMiner.library.interfaces;

namespace CristalMiner.player.ship
{
    public class ShipController : Entity, IController
    {

        public List<Entity> bullets = new List<Entity>();
        public Entity shield; 

        public int armor = 12;
        public int maxHealth;
        public int maxEnergy;
        public int energy;

        public bool alive;

        public Animation moveFire;
        public Animation stay;
        public Animation explosion;


        Timer timer = new Timer();

        public ShipController(
            int x, 
            int y, 
            int width, 
            int height, 
            float acceleration, 
            float speedX, 
            float speedY, 
            Image image, 
            int maxHealth, 
            int maxEnergy) : base(x, y, width, height, acceleration, speedX, speedY, image)
        {
            this.shield = new Entity(x - 10, y - 5, width + 20, height + 20, 0, 0, 0, Color.Gray);
            this.maxHealth = maxHealth;
            this.healthPoint = maxHealth;
            this.maxEnergy = maxEnergy;
            this.energy = maxEnergy;
            this.moveFire = new Animation("Resourse/Animations/fire", getRect());
            this.stay = new Animation("Resourse/Animations/stay", getRect());
            this.explosion = new Animation("Resourse/Animations/explosion", new Rectangle());
        }

        private void position()
        {
            this.stay.Play(150);
            // this.image = stay.GetImage();
        }

        public void Update()
        {
            if (healthPoint <= 0)
                alive = false;
            if (alive)
            {
                Move();
                RemoveBullet();
                MoveBullets();

                if (!timer.Enabled && armor == 0)
                    Reload(1000);

                shield.x = x - 10; shield.y = y - 5;

                moveFire.Play(100);
                position();
            }
            else
            {
                if (explosion.Count() - 1 != explosion.Frame())
                    explosion.Play(150);
                else
                    explosion.Stop();
                image = explosion.GetImage();
            }
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(moveFire.GetImage(), new Rectangle(x, y + height - 10, width, width));
            graphics.DrawEllipse(new Pen(shield.color), shield.getRect());

            for (int i = 0; i < bullets.Count(); i++)
            {
                graphics.FillEllipse(new SolidBrush(bullets[i].color), bullets[i].getRect());
            }
            graphics.DrawImage(this.getImage(), this.getRect());
        }

        public void Move()
        {
            if (alive)
            {
                if (Global.Horizontal != 0)
                {
                    speedX += acceleration * Global.Horizontal;

                    if (x + speedX > 0 && x + speedX + width < Global.Width)
                        x += Convert.ToInt32(speedX);
                    else if (x + speedX < 0)
                        x = 0;
                    else if (x + speedX + width > Global.Width)
                        x = Global.Width - width;
                }   // Move on Horizontal
                else
                    speedX = 0;

                if (Global.Vertical != 0)
                {
                    speedY += acceleration * Global.Vertical;

                    if (y + speedY > 0 && y + speedY + height < 800)
                        y += Convert.ToInt32(speedY);
                    else if (y + speedY < 0)
                        y = 0;
                    else if (y + speedY + height < Global.Height)
                        y = Global.Height - height;
                }     // Move on vertical 
                else
                    speedY = 0;
            }
        }

        public void Fire()
        {
            if (armor != 0)
            {
                bullets.Add(new Entity(x + width / 2 - 5, y + height / 2 - 10, 10, 20, -2, 0, -20, Color.Gray)); //Create bullet
                armor -= 1;
            }
        }

        public void Reload(int seconds)
        {
            timer.Interval = seconds;
            timer.Elapsed += Ticker;
            timer.Enabled = true;
        }

        private void Ticker(object sender, EventArgs e)
        {
            armor = 12;
            timer.Stop();
        }

        public void MoveBullets()
        {
            for (int i = 0; i < bullets.Count(); i++)
                bullets[i].y += Convert.ToInt32(bullets[i].speedY);
        }

        public void Damage(int value)
        {
            healthPoint -= value;
        }

        /**
         * Destroy bullet
         */
        public void RemoveBullet()
        {
            for (int i = 0; i < bullets.Count(); i++)
            {
                if (bullets[i].y + bullets[i].height < -5)
                    bullets.RemoveAt(i);
            }
        }   

        public Image getImage()
        { 
            return image;
        }   

         
    }
}
