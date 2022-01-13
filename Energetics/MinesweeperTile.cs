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
    public partial class MinesweeperTile : UserControl
    {
        // 'settings'
       // private const int size = 80;
        private const int baseRed = 100;
        private const int baseGreen = 160;
        private const int baseBlue = 100;
        private const int colorRange = 20;
        private double colorFrame = 0;
        private double colorFrameRate = .01;

        static private Random rand = new Random();
        private Point gridLocation;
        private int neighbors;
        private bool revealed;

        public MinesweeperTile(int size, Point gridLocation, Point location, int neighbors)
        {
           
            this.gridLocation = gridLocation;
            this.Location = location;
            this.neighbors = neighbors;
            revealed = false;

            
            InitializeComponent();
            colorFrame = rand.NextDouble() * 6.28;
            lblTile.BackColor = determineColor(colorFrame);
            this.Size = new Size(size, size);
            lblTile.Size = new Size(size - 4, size - 4);

            colorFrameRate += .01*rand.Next(0, 6);

        }

        public void MinesweeperTile_Load(object sender, EventArgs e)
        {

        }
        private Color determineColor(double colorFrame)
        {
            int red = baseRed;
            int green = baseGreen;
            int blue = baseBlue;

           
            int jitter = (int)(colorRange*Math.Sin(colorFrame));
            green += jitter;
            return Color.FromArgb(255, red, green, blue);
        }

        public void update()
        {
            colorFrame += colorFrameRate;
          // MessageBox.Show(this.BackColor.ToString());
            lblTile.BackColor=determineColor(colorFrame);
        }
    }
}
