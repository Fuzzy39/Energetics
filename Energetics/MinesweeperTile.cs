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
        private double colorFrameRate = .03;



        private bool isHovered = false;
        private int hoverFrame =0;
        private const int hoverCap = 50;
        private double hoverspeed = 7;

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
            lblTile.Font = new Font("Arial Black", (int)(.3*(size-4)), FontStyle.Bold);
            colorFrameRate += .01*rand.Next(0, 4);

        }

        public void MinesweeperTile_Load(object sender, EventArgs e)
        {

        }
        private Color determineColor(double colorFrame)
        {
            int red = baseRed;
            int green = baseGreen;
            int blue = baseBlue;

            if(isHovered)
            {
             
                hoverFrame += (int)hoverspeed;
                if (hoverFrame > hoverCap)
                {
                    hoverFrame = hoverCap;
                }
                red += hoverFrame;
                green += hoverFrame;
                blue += hoverFrame;
                if (hoverFrame <= hoverCap * .5)
                {
                    hoverspeed *= 1.7;
                }
                else
                {
                    hoverspeed *= 1.0/1.7;
                }
            }
           
            int jitter = (int)(colorRange*Math.Sin(colorFrame));
            green += jitter;

            if (red > 255) red = 255;
            if (green > 255) green = 255;
            if (blue > 255) blue = 255;

            return Color.FromArgb(255, red, green, blue);
        }

        public void update()
        {
            colorFrame += colorFrameRate;
          // MessageBox.Show(this.BackColor.ToString());
            lblTile.BackColor=determineColor(colorFrame);
        }

        private void lblTile_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            hoverFrame = 10;
        }

        private void lblTile_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            hoverFrame = 0;
            hoverspeed = 1;
        }

        private void lblTile_Click(object sender, EventArgs e)
        {
            // can you detect a right click?
            // eh, whatever.
            MessageBox.Show("You clicked at tile (" + gridLocation.X + ", " + gridLocation.Y + ").");
        }
    }

}
