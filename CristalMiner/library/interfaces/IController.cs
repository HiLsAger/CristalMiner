using System.Drawing;
using System.Windows.Forms;

namespace CristalMiner.library.interfaces
{
    public interface IController
    {
        void Update();

        void Draw(Graphics graphics);
    }
}
