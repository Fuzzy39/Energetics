using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Energetics
{
    public class MinesweeperTile : Label
    {
        // 'settings'
        private const int size = 80;
        private const int baseRed = 100;
        private const int baseGreen = 150;
        private const int baseBlue = 100;
        private const int colorJitterRange = 40;

        static private Random rand = new Random();
        private Point gridLocation;
        private int neighbors;
        private bool revealed;

        public MinesweeperTile(Point gridLocation, Point location, int neighbors)
        {
           
            this.gridLocation = gridLocation;
            this.Location = location;
            this.neighbors = neighbors;
            revealed = false;

            // style the tile all fancylike
            this.Size = new Size(80, 80);

            this.BackColor = determineColor();
            this.ForeColor = Color.White;
            this.Text = "?";
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Bold);

        }

        private Color determineColor()
        {
            int red = baseRed;
            int green = baseGreen;
            int blue = baseBlue;

           
            int jitter = rand.Next(-1 * (colorJitterRange / 2), colorJitterRange / 2);
            green += jitter;
            return Color.FromArgb(255, red, green, blue);
        }
    }
}
