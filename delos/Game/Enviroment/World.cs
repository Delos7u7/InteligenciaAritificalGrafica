using delos.Game.Player;
using System.Drawing;
using System.Windows.Forms;

namespace delos.Game.Enviroment
{
    public class World : Panel
    {
        public Actor player;
        private Timer Animation = new Timer();
        string directory = System.Environment.CurrentDirectory;
        public World(int width, int heigth) 
        {
            this.Width = width;
            this.Height = heigth;
            this.DoubleBuffered = true;
            Bitmap back = new Bitmap(directory + @"\\images\\Background\Back.png");
            this.BackgroundImage = back;
            this.Paint += World_Paint;
            Animation.Interval = 20;
            Animation.Tick += Animation_Tick;
            Animation.Start();
        }

        private void Animation_Tick(object sender, System.EventArgs e)
        {
            player.X++;
            player.NextTexture();
            //this.Refresh();
            this.Invalidate(new Rectangle(player.X, player.Y, player.texture.Width, player.texture.Height));
        }

        private void World_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            //canvas.FillRectangle(Brushes.Red, 50, 450, 80, 40);
            if (player.texture != null)
            {
            canvas.DrawImage(player.texture, player.X, player.Y);
            }
        }
    }
}
