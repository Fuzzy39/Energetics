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

        private int[] baseReds = { 55, 180 };
        private int[] baseGreens = { 135, 20 };
        private int[] baseBlues = { 55 };
        private const int colorRange = 30;
        private double colorFrame = 0;
        private double colorFrameRate = .03;



        private bool isHovered = false;
        private int hoverFrame =0;
        private const int hoverCap = 50;
        private double hoverspeed = 5;

        static private Random rand = new Random();
        private Point gridLocation;
        private int neighbors;
        private bool revealed;

        public MinesweeperTile(int size, Point gridLocation, Point location, int neighbors)
        {
            baseReds = new int[] { 55, 230, 135 };
            baseGreens = new int[]{ 135, 20, 135};
            baseBlues = new int[] { 55, 20, 135 };
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
            // set colors to their base colors
            int red;
            int green;
            int blue;

            if (!revealed)
            {
                red = baseReds[0];
                green = baseGreens[0];
                blue = baseBlues[0];
            }
            else
            {
                int id = neighbors + 2;
                red = baseReds[id];
                green = baseGreens[id];
                blue = baseBlues[id];

            }

            // make color brighter (or darker) based on hover state
            if(isHovered)
            {
             
                hoverFrame += (int)hoverspeed;
                if (hoverFrame > hoverCap)
                {
                    hoverFrame = hoverCap;
                }

                // add this 'frame's' effect
                red += hoverFrame;
                green += hoverFrame;
                blue += hoverFrame;

                // tween hover effects
                if (hoverFrame <= hoverCap * .5)
                {
                    hoverspeed *= 1.7;
                }
                else
                {
                    hoverspeed *= 1.0/1.7;
                }
            }
           
            // add jitter.
            int jitter = (int)(colorRange*Math.Sin(colorFrame))+colorRange/2;

            if (!revealed)
            {
                green += jitter;
            }
            else
            {
                switch(neighbors)
                {
                    case -1:
                        red += jitter;
                        break;
                    case 0:
                        red += jitter;
                        green += jitter;
                        blue += jitter;

                        break;
                }
            }
            //red += jitter;
          
            //blue += jitter;

            // ensure that the color is not invalid
            if (red > 255) red = 255;
            if (green > 255) green = 255;
            if (blue > 255) blue = 255;

            if (red < 0) red = 0;
            if (green < 0) green = 0;
            if (blue < 0) blue = 0;

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
            hoverspeed = 5;
        }

        private void lblTile_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            hoverFrame = 0;
            hoverspeed = 5;
        }

        private void lblTile_Click(object sender, EventArgs e)
        {
            // can you detect a right click?
            // eh, whatever.
            hoverFrame = -30;
            hoverspeed = 4;
            reveal();
            //MessageBox.Show("You clicked at tile (" + gridLocation.X + ", " + gridLocation.Y + ").");
        }

        private void reveal()
        {
            revealed = true;
            if(neighbors==-1)
            {
                lblTile.Text = "X";
                return;
            }
            if(neighbors==0)
            {
                return;
            }
            lblTile.Text = "" + neighbors;
        }
    }

}
