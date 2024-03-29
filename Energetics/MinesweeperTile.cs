﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Energetics
{
    // January 13th, Mason Hill
    // This code makes the tiles in the minesweeper game behave, and gives them color.
    // It's a bit of a mess.
    public partial class MinesweeperTile : UserControl
    {
        // 'settings'

        private int[] baseReds;
        private int[] baseGreens;
        private int[] baseBlues;
        private const int colorRange = 25;
        private double colorFrame = 0;
        private double colorFrameRate = .03;


        private bool interactable = true;
        private bool isHovered = false;
        private int brightness = 0;
        private const int hoverBrightnessTarget = 50;
        private int brightnessChange = 0;


        static private Random rand = new Random();
        private Point gridLocation;
        public int neighbors;
        private bool revealed;
        private bool flagged;

        private Form2 parent;

        public MinesweeperTile(int size, Point gridLocation, Point location, int neighbors, Form2 parent)
        {

            //                      u    X    0    1    2    3    4    5    6    7    8
            //baseReds = new int[]  { 55,  230, 135, 40,  70,  100, 130, 160, 160, 160, 160};
            //baseGreens = new int[]{ 135, 20,  135, 40,  70,  100, 130, 160, 120, 80,  40};
            //baseBlues = new int[] { 55,  20,  135, 160, 130, 100, 70,  40,  40,  40,  40};
            baseReds = new int[] { 110, 230, 150, 40, 40, 160, 160, 160, 120, 80, 20 };
            baseGreens = new int[] { 170, 20, 150, 40, 160, 160, 120, 40, 40, 30, 20 };
            baseBlues = new int[] { 110, 20, 150, 160, 40, 40, 40, 40, 40, 30, 20 };
            this.gridLocation = gridLocation;
            this.Location = location;
            this.neighbors = neighbors;
            revealed = false;
            flagged = false;

            this.parent = parent;
            InitializeComponent();
            colorFrame = rand.NextDouble() * 6.28;
            lblTile.BackColor = determineColor(colorFrame);
            this.Size = new Size(size, size);
            lblTile.Size = new Size(size - 4, size - 4);
            lblTile.Font = new Font("Arial Black", (int)(.4 * (size - 4)), FontStyle.Bold);
            colorFrameRate += .01 * rand.Next(0, 4);

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
            int jitter = (int)(colorRange * Math.Sin(colorFrame)) + colorRange / 2;

            if (!revealed)
            {
                green += (int)(jitter);
                // red += jitter/2;
                //blue += jitter/2;
            }
            else
            {
                switch (neighbors)
                {
                    case -1:
                    case 5:
                    case 7:
                    case 6:
                        red += 2 * jitter;
                        break;
                    case 0:
                        red += jitter;
                        green += jitter;
                        blue += jitter;
                        break;
                    case 1:

                        blue += 2 * jitter;
                        break;
                    case 2:
                        green += jitter;
                        break;
                    case 3:
                        green += jitter;
                        red += jitter;
                        break;
                    case 4:

                        green += (int)(.5 * jitter);
                        red += (int)(1.5 * jitter);
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

            return opacityDarken(Color.FromArgb(255, red, green, blue));
        }


        private Color opacityDarken(Color c)
        {
            double red = c.R;
            double blue = c.B;
            double green = c.G;

            double red2 = 115;
            double green2 = 130;
            double blue2 = 115;

            double darkenBy = ((double)Form2.messageOpacity) / 100.0;

            red = red * (1 - darkenBy) + red2 * darkenBy;
            green = green * (1 - darkenBy) + green2 * darkenBy;
            blue = blue * (1 - darkenBy) + blue2 * darkenBy;

            // ensure that the color is not invalid
            if (red > 255) red = 255;
            if (green > 255) green = 255;
            if (blue > 255) blue = 255;

            if (red < 0) red = 0;
            if (green < 0) green = 0;
            if (blue < 0) blue = 0;

            return Color.FromArgb(255, (int)red, (int)green, (int)blue);
        }
        public void reset()
        {
            revealed = false;
            flagged = false;
            neighbors = 0;
            lblTile.Text = "";
            determineColor(colorFrame);


        }

        public void update()
        {
            colorFrame += colorFrameRate;
            // MessageBox.Show(this.BackColor.ToString());
            lblTile.BackColor = determineColor(colorFrame);
            lblTile.ForeColor = opacityDarken(Color.White);
            this.BackColor = opacityDarken(Color.White);
            if (Form2.panelOn)
            {
                interactable = false;
            }
            else
            {
                interactable = true;
            }
        }

        private void lblTile_MouseEnter(object sender, EventArgs e)
        {
            if (interactable)
                isHovered = true;

        }

        private void lblTile_MouseLeave(object sender, EventArgs e)
        {

            isHovered = false;

        }

        private void lblTile_Click(object sender, EventArgs e)
        {
            // can you detect a right click?
            // yes!
            if (!interactable)
            {
                return;
            }

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right)
            {
                if (!revealed)
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
                    reveal(false);
                }
            }

            //MessageBox.Show("You clicked at tile (" + gridLocation.X + ", " + gridLocation.Y + ").");
        }

        // isBomb: has the player already lost?
        public void reveal(bool isBomb)
        {

            if (revealed)
            {
                return;
            }

            // make sure there are no bombs in the vicinity
            if(!Form2.gameStarted)
            {
                Form2.startGame(gridLocation.X, gridLocation.Y);


            }

            brightness = 150;
            brightnessChange = 0;
            revealed = true;

            if (neighbors == -1)
            {
                lblTile.Text = "💣";
                if (!isBomb)
                    parent.revealAll();
                return;
            }
            if (!isBomb)
            {
                parent.checkForWin();
            }
            if (neighbors == 0)
            {
                Form2.revealAdjacent(gridLocation.X, gridLocation.Y);
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

    }

}
