using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CristalMiner
{
    public partial class StarMiner : Form
    {
        Ship ship;
        Background background;
        Random rand = new Random();
        List<Bitmap> frames = new List<Bitmap>();
        UI ui;

        int score;

        Asteroid asteroid;

        Animation anim;

        public StarMiner()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Global.setWindow(this.ClientSize.Width, this.ClientSize.Height);
        }
        private Cursor customCursor;
        private void Form1_Load(object sender, EventArgs e)
        {
            background = new Background(Color.Black, 70);
            background.CreateLocation();

            customCursor = new Cursor("Resourse/Cursor.cur");
            this.Cursor = customCursor;

            ship = new Ship(280, 600, 40, 80, 2, 0, 0, Properties.Resources.Roket, 91, 100);
            asteroid = new Asteroid(5, 40, 70);

            ui = new UI(1);
            ui.SetHealthBar(200, 20, 35, Global.Height - 60, Properties.Resources.HealthBar);

            ui.setEnergyBar(20, 200, 35, Global.Height - 300, Properties.Resources.EnergyBar);

            ship.alive = true;

            //anim = new Animation("Resourse/Animations/fire", new Rectangle(0,0, 40, 40));


            //System.Media. sp = new System.Media("Resourse/sounds/music/DJ Artyom - Cooper.wav");
            //sp.
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawImage(anim.GetImage(), new Rectangle(ship.x, ship.y + ship.height - 10, 40, 40));
            background.Draw(sender, e);
            asteroid.Draw(sender, e);
            ship.Draw(sender, e);
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
            if (e.KeyCode == Keys.A)    //Movement
                Global.Horizontal = -1;
            if (e.KeyCode == Keys.D)
                Global.Horizontal = 1;
            if (e.KeyCode == Keys.W)
                Global.Vertical = -1;
            if (e.KeyCode == Keys.S)
                Global.Vertical = 1;
            if (e.KeyCode == Keys.T)
                if (Global.console = true)
                {

                }
                else
                {

                }


            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)        //Movement
                Global.Horizontal = 0;
            else if (e.KeyCode == Keys.D)
                Global.Horizontal = 0;
            if (e.KeyCode == Keys.W)
                Global.Vertical = 0;
            else if (e.KeyCode == Keys.S)
                Global.Vertical = 0;

            if (e.KeyCode == Keys.Space)    //Fire
                ship.Fire();
        }

        private void AnimatorUpdate_Tick(object sender, EventArgs e)
        {
           // ship.moveFire.nextFrame();
        }
    }
}
