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
        private int brightness =0;
        private const int hoverBrightnessTarget = 50;
        private int brightnessChange = 0;
       

        static private Random rand = new Random();
        private Point gridLocation;
        private int neighbors;
        private bool revealed;
        private bool flagged;

        public MinesweeperTile(int size, Point gridLocation, Point location, int neighbors)
        {

            //                      u    X    0    1    2    3    4    5    6    7    8
            baseReds = new int[]  { 55,  230, 135, 40,  70,  100, 130, 160, 160, 160, 160};
            baseGreens = new int[]{ 135, 20,  135, 40,  70,  100, 130, 160, 120, 80,  40};
            baseBlues = new int[] { 55,  20,  135, 160, 130, 100, 70,  40,  40,  40,  40};
            this.gridLocation = gridLocation;
            this.Location = location;
            this.neighbors = neighbors;
            revealed = false;
            flagged = false;

            
            InitializeComponent();
            colorFrame = rand.NextDouble() * 6.28;
            lblTile.BackColor = determineColor(colorFrame);
            this.Size = new Size(size, size);
            lblTile.Size = new Size(size - 4, size - 4);
            lblTile.Font = new Font("Arial Black", (int)(.4*(size-4)), FontStyle.Bold);
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

            determineBrightness();
            red += brightness;
            green += brightness;
            blue += brightness;


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
                    case 6:
                    case 7:
                    case 8:
                        red += 2*jitter;
                        break;
                    case 0:
                        red += jitter;
                        green += jitter;
                        blue += jitter;
                        break;
                   case 1:
                    case 2:
                        blue += 2*jitter;
                        break;
                    
                    case 4:
                    case 5:
                   
                        green += jitter;
                        red += jitter;
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
           // hoverFrame = 10;
            //hoverspeed = 5;
        }

        private void lblTile_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
           // hoverFrame = 0;
          // hoverspeed = 5;
        }

        private void lblTile_Click(object sender, EventArgs e)
        {
            // can you detect a right click?
            // yes!
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            { 
                if(!revealed)
                {
                    brightness = 90;
                    flagged = !flagged;
                    if (flagged)
                    {
                        lblTile.Text = "⚑";
                        
                    }
                    else
                    {
                        lblTile.Text = "";
                    }

                }
            }
            if (me.Button == MouseButtons.Left) 
            {
                if (!revealed & !flagged)
                {
                    reveal();
                }
            }
            
            //MessageBox.Show("You clicked at tile (" + gridLocation.X + ", " + gridLocation.Y + ").");
        }

        private void reveal()
        {
            
            brightness = 150;
            brightnessChange = 0;
            revealed = true;
           
            if(neighbors==-1)
            {
                lblTile.Text = "💣";
                return;
            }
            if(neighbors==0)
            {
                return;
            }
            lblTile.Text = "" + neighbors;
        }

        private void determineBrightness()
        {
            // Okay, I've been a bit silly.
            // first, the tile determines it's target brightness, and how far away it is from that
            // brightness.
            // There are 3 phases of speed, ease in, steady, and ease out.
            // make color brighter (or darker) based on hover state

            int steadySpeed = 15;
            int easeRate = 3;

            int target;
            int distance;

            if(isHovered)
            {
                target = hoverBrightnessTarget;
              
            }
            else
            {
                target = 0;
            }

            distance = target - brightness;
            bool darkening = distance < 0;
            // if nothing needs to be done, do nothing
            if (distance == 0) return;

            // determine the change to be made.
            if(darkening)
            {
                if(brightnessChange > steadySpeed*-1)
                {
                    brightnessChange -= easeRate;
                }
                else
                {
                    brightnessChange = steadySpeed * -1;
                }
            }
            else
            {
                if (brightnessChange < steadySpeed)
                {
                    brightnessChange += easeRate;
                }
                else
                {
                    brightnessChange = steadySpeed;
                }
            }

            // change the brightness!
            brightness += brightnessChange;
            if(darkening)
            {
                if (brightness<=target)
                {
                    brightnessChange = 0;
                    brightness = target;
                }
            }
            else
            {
                if(brightness>=target)
                {
                    brightnessChange = 0;
                    brightness = target;
                }
            }

        }   
            
    }

}
