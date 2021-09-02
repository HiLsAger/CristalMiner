using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CristalMiner
{
    class UI
    {
        float scale;
        public Entity healthBar;
        public Entity healths;

        public Entity energyBar;
        public Entity energys;
        int MaxHealthBarSize;
        int MaxEnegryBarSize;
        List<Entity> arrmor = new List<Entity>();

        public UI(float scale)
        {
        }

        public void Draw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(healths.color), healths.getRect());
            g.DrawImage(healthBar.image, healthBar.getRect());

            g.FillRectangle(new SolidBrush(energys.color), energys.getRect());
            g.DrawImage(energyBar.image, energyBar.getRect());
        }

        public void SetHealthBar(int width, int height, int x, int y, Image image)
        {
            healthBar = new Entity(x, y, width, height, 0, 0, 0, image);
            MaxHealthBarSize = width - 18;
            healths = new Entity(x + 9, y, MaxHealthBarSize, height, 0, 0, 0, Color.FromArgb(255, 91, 201, 42));
        }
        public void setEnergyBar(int width, int height, int x, int y, Image image)
        {
            energyBar = new Entity(x, y, width, height, 0, 0, 0, image);
            MaxEnegryBarSize = energyBar.width - 20;
            energys = new Entity(x, y, width, height, 0, 0, 0, Color.FromArgb(255, 70, 88, 255));
            
        }

        public string str(int maxhealth, int health)
        {
            return Convert.ToString(MaxHealthBarSize) + "    " + Convert.ToString(health * (MaxHealthBarSize/maxhealth));
        }

        public void Update(int health, int maxhealth, int energy, int maxenergy)
        {
            double coefficient = MaxHealthBarSize/maxhealth;
            healths.width = Convert.ToInt16(health*coefficient);

            coefficient = MaxEnegryBarSize / maxenergy;
            energys.height = Convert.ToInt16(energy * coefficient);
        }
    }
}
