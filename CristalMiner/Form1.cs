using CristalMiner.Asteroids;
using CristalMiner.player.ship;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CristalMiner
{
    public partial class StarMiner : Form
    {
        public ShipController ship;
        public Background background;
        public Random rand = new Random();
        public List<Bitmap> frames = new List<Bitmap>();
        public UI ui;

        public int score;

        public AsteroidsController asteroid;

        public Animation anim;

        private Cursor customCursor;

        public StarMiner()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Global.setWindow(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.background = new Background(Color.Black, 70);
            this.background.CreateLocation();

            using (MemoryStream cursorStream = new MemoryStream(Properties.Resources.Cursor))
            {
                this.Cursor = new Cursor(cursorStream);
            }

            this.ship = new ShipController(280, 600, 40, 80, 2, 0, 0, Properties.Resources.Roket, 91, 100);

            this.asteroid = new AsteroidsController(5, 40, 70);

            this.ui = new UI(1);
            this.ui.SetHealthBar(200, 20, 35, Global.Height - 60, Properties.Resources.HealthBar);

            this.ui.setEnergyBar(20, 200, 35, Global.Height - 300, Properties.Resources.EnergyBar);

            this.ship.alive = true;

            this.anim = new Animation("Resourse/Animations/fire", new Rectangle(0,0, 40, 40));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //g.DrawImage(anim.GetImage(), new Rectangle(ship.x, ship.y + ship.height - 10, 40, 40));
            background.Draw(sender, e);
            asteroid.Draw(graphics);
            ship.Draw(graphics);
            ui.Draw(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            label2.Text = Convert.ToString(ship.maxHealth) + "    " + ui.str(ship.maxHealth, ship.healthPoint);

            background.Update();    //Generation Background

            asteroid.Update();

            ship.Update();

            Collision();

            ui.Update(ship.healthPoint, ship.maxHealth, ship.energy, ship.maxEnergy);

            Refresh();
        }

        private void Collision()
        {
            for (int j = 0; j < asteroid.asteroids.Count(); j++)
                for (int i = 0; i < ship.bullets.Count(); i++)
                    if (Global.Collision(asteroid.asteroids[j], ship.bullets[i]))
                    {
                        ship.bullets.RemoveAt(i);
                        asteroid.asteroids[j].healthPoint -= 11;
                    }
            for (int i = 0; i < asteroid.asteroids.Count(); i++)
                if ((Global.Collision(ship, asteroid.asteroids[i]) || Global.Collision(asteroid.asteroids[i], ship)))
                {
                    if (asteroid.asteroids[i].tag == "Big")
                    {
                        ship.healthPoint -= 5;
                    }
                    asteroid.asteroids[i].healthPoint = 0;    
                }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    Global.Horizontal = -1;
                    break;
                case Keys.D:
                    Global.Horizontal = 1;
                    break;
                case Keys.W:
                    Global.Vertical = -1;
                    break;
                case Keys.S:
                    Global.Vertical = 1;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    Global.Horizontal = 0;
                    break;
                case Keys.D:
                    Global.Horizontal = 0;
                    break;
                case Keys.W:
                    Global.Vertical = 0;
                    break;
                case Keys.S:
                    Global.Vertical = 0;
                    break;
                case Keys.Space:
                    ship.Fire();
                    break;

            }
        }

        private void AnimatorUpdate_Tick(object sender, EventArgs e)
        {
           // ship.moveFire.nextFrame();
        }
    }
}
