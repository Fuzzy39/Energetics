using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Energetics
{
    // January 13th, 2022 - Mason Hill
    // This code governs the buttons in the minesweeper game.
    // it is fairly directly coppied from the earlier minesweeper button code, which isn't exactly good practice.
    public partial class minesweeperButton : UserControl
    {
        // should minesweeper tile inherit from this?
        // you bet.
        // will it?
        // only if it's easy

        int baseRed;
        int baseGreen;
        int baseBlue;

        private const int colorRange = 30;
        private double colorFrame = 0;
        private double colorFrameRate = .03;

        private bool isHovered = false;
        private int brightness = 0;
        private const int hoverBrightnessTarget = 40;
        private int brightnessChange = 0;

        public bool[] jitters = new bool[] { true, true, true };

        public minesweeperButton()
        {
            InitializeComponent();
        }

        private void minesweeperButton_Load(object sender, EventArgs e)
        {
            baseRed = lblTile.BackColor.R;
            baseGreen = lblTile.BackColor.G;
            baseBlue = lblTile.BackColor.B;

            

        }

        public void update()
        {
            // totally not directly copied from Minesweeper tile.
            // What? who said I had to write good code?
            colorFrame += colorFrameRate + (Form2.panelOn?.1:0);
           
            lblTile.BackColor = determineColor(colorFrame);
            
        }

        private Color determineColor(double colorFrame)
        {
            // do initial color setting
            int red= baseRed;
            int green = baseGreen;
            int blue = baseBlue;

            

            determineBrightness();
            //int panelModifier = (int)((((double)Form2.messageOpacity) / 100.0) * 255);
            red += brightness;
            green += brightness;
            blue += brightness;


            // add jitter.
            int jitter = (int)(colorRange * Math.Sin(colorFrame)) + colorRange / 2;

            if(jitters[0])
                red += jitter;
            if (jitters[1])
                green += jitter;
            if (jitters[2])
                blue += jitter;


            // ensure that the color is valid
            if (red > 255) red = 255;
            if (green > 255) green = 255;
            if (blue > 255) blue = 255;

            if (red < 0) red = 0;
            if (green < 0) green = 0;
            if (blue < 0) blue = 0;

            // return the color
            return Color.FromArgb(255, red, green, blue);

        }

        private void determineBrightness()
        {
            // Okay, I've been a bit silly.
            // first, the tile determines it's target brightness, and how far away it is from that
            // brightness.
            // There are 3 phases of speed, ease in, steady, and ease out.
            // make color brighter (or darker) based on hover state

            int steadySpeed = 16;
            int easeRate = 4;

            int target;
            int distance;

            if (isHovered)
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
            if (darkening)
            {
                if (brightnessChange > steadySpeed * -1)
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
            if (darkening)
            {
                if (brightness <= target)
                {
                    brightnessChange = 0;
                    brightness = target;
                }
            }
            else
            {
                if (brightness >= target)
                {
                    brightnessChange = 0;
                    brightness = target;
                }
            }

        }

        private void lblTile_Click(object sender, EventArgs e)
        {
            brightness = -50;
            this.OnClick(e);
        }

        private void lblTile_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
        }

        private void lblTile_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
        }
    }
}
