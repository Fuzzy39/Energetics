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
    // Mason Hill, January 13th, 2022 
    // This code governs how the minesweeper game works, at least in part.
    // It was written poorly, without careful consideration to any part in particular.
    // Apolgies in advance to whoever reads this.
    
    public partial class Form2 : Form
    {
        Form1 mainForm;
        Random rand = new Random();
        static MinesweeperTile[,] gameSpace;
       

        // 2:3 240
        // scale 3 easy
        // med 4
        // hard 5
        static int scale = 3; // higher values cause the minesweeper grid to be bigger.
        static int gridHeight = 2*scale;
        static int gridWidth = 3*scale;
        static int tileSize = 240/scale;
        static int tiles = gridHeight * gridWidth;
        static int revealed = 0;
        static int bombs = 0;
        static public bool gameStarted = false;

        // this is a workaround to a workaround's workaround, at this point.
        // this is silly
        static public int messageOpacity = 0; // from 1 to 100, with a max normal value of 40 
        static int maxOpacity = 70;
        static int opacityRate = 10;
        static public bool panelOn = true;

        public Form2(Form1 creator)
        {
            
            InitializeComponent();

            // set the text for all of my fake buttons
            btnBack.lblTile.BackColor = Color.FromArgb(255, 130, 80, 80);
            btnBack.lblTile.Text = "Back";
            btnBack.jitters = new bool[] { true, false, false };

            btnEasy.lblTile.BackColor = Color.FromArgb(255, 80, 130, 80);
            btnEasy.lblTile.Text = "Easy";
            btnEasy.jitters = new bool[] { false, true, false };

            btnMedium.lblTile.BackColor = Color.FromArgb(255, 130, 130, 80);
            btnMedium.lblTile.Text = "Medium";
            btnMedium.jitters = new bool[] { true, true, false };

            btnHard.lblTile.BackColor = Color.FromArgb(255, 130, 80, 80);
            btnHard.lblTile.Text = "Hard";
            btnHard.jitters = new bool[] { true, false, false };

            mainForm = creator;



            // add 'message panel'. it describes the game initially, and announces your victory (or failur
            //
           // why didn't it work?

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // Example code to set up a control programmatically
            /*
            test =new MinesweeperTile(80,new Point(), new Point(200, 100), 0);
            this.Controls.Add(test);
            */
           



            generateMap();
         
            //lblMessage.BackColor = Color.FromArgb(50, 0, 0, 0);

            /*foreground = new MessagePanel();
            foreground.BackColor = Color.Black;
            foreground.Opacity = 0;
            foreground.Top = 85;
            foreground.Left = 25;
            foreground.Size = new Size(730, 490);
            this.Controls.Add(foreground);
            foreground.BringToFront();
            foreground.Enabled = false;*/

        }

        private void generateMap()
        {
            // remove old tiles
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    if (gameSpace == null)
                    {
                        break;
                    }
                    this.Controls.Remove(gameSpace[x, y]);
                }
            }

            // set variables
            gridHeight = 2 * scale;
            gridWidth = 3 * scale;
            tileSize = 240 / scale;
            tiles = gridHeight * gridWidth;
            revealed = 0;

            int startX = (800 - tileSize * gridWidth) / 2 - 10; // should always be about 30
            int startY = 90;

            gameSpace = new MinesweeperTile[gridWidth, gridHeight];

            // loop through all of the tiles and make new ones

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    // create a tile at the appropriate location
                    MinesweeperTile tile = new MinesweeperTile(
                         tileSize,
                         new Point(x, y), // position on grid
                         new Point((tileSize * x) + startX, +(tileSize * y) + startY), // position in pixels
                         0/*((x + y) % 10) - 1*/ // number of neighbors that are bombs, which we will worry about later
                     );

                    // add it to the array and to the controls
                    this.Controls.Add(tile);
                    gameSpace[x, y] = tile;
                }
            }

            // create the mines

            
            
            int mines = (scale*scale*6)/5;
            bombs = mines;
            for (int i = 0; i < mines; i++)
            {
                int xCoord = rand.Next(0, gridWidth);
                int yCoord = rand.Next(0, gridHeight);

                if (gameSpace[xCoord, yCoord].neighbors == -1)
                {
                    i--;
                    continue;
                }
                gameSpace[xCoord, yCoord].neighbors = -1;

            }

            // fill in the other tiles

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    gameSpace[x,y].neighbors= neighbors(x, y);
                }
            }
        }
        public static void checkForWin()
        {
            revealed++;
            if(revealed+bombs==tiles)
            {
                // victory achived!
                panelOn = true;
            }
        }

        public static void startGame(int x, int y)
        {
            // okay, this is going to be the worst code yet, I'm pretty sure
            // remove bombs from this tile and it's neighbors, then recalculate.
            gameStarted = true;
            if (isBomb(x , y))
            {
                gameSpace[x, y].neighbors = 0;
                bombs--;
            }
            if (x != 0 & y != 0)
            {
                // top left
                if (isBomb(x - 1, y - 1))
                {
                    gameSpace[x - 1, y - 1].neighbors = 0;
                    bombs--;
                }

            }

            if (x != 0)
            {
                // left
                if (isBomb(x - 1, y))
                {
                    gameSpace[x - 1, y].neighbors = 0;
                    bombs--;
                }

            }

            if (x != 0 & y < gridHeight - 1)
            {
                // bottom left
                if (isBomb(x - 1, y + 1))
                {

                    bombs--;
                    gameSpace[x - 1, y + 1].neighbors = 0;
                }

            }

            if (y != 0)
            {
                // top
                if (isBomb(x, y - 1))
                {
                    bombs--;
                    gameSpace[x, y - 1].neighbors = 0;
                }
            }

            if (y < gridHeight - 1)
            {
                // bottom

                if (isBomb(x, y + 1))
                {
                    bombs--;

                    gameSpace[x, y + 1].neighbors = 0;
                }
                

            }

            if (x < gridWidth - 1 & y != 0)
            {
                // Top right
                if (isBomb(x + 1, y - 1))
                {

                    bombs--;
                    gameSpace[x + 1, y - 1].neighbors = 0;
                }
            }

            if (x < gridWidth - 1)
            {
                // right
                if (isBomb(x + 1, y))
                {
                    bombs--;
                    gameSpace[x + 1, y].neighbors = 0;
                }


            }

            if (x < gridWidth - 1 & y < gridHeight - 1)
            {
                //Bottom right
                if (isBomb(x + 1, y + 1))
                {
                    bombs--;

                    gameSpace[x + 1, y + 1].neighbors = 0;
                }

            }
            // recalculate (should be a method, yeah?)
            for (int x2 = 0; x2 < gridWidth; x2++)
            {
                for (int y2 = 0; y2 < gridHeight; y2++)
                {
                    gameSpace[x2, y2].neighbors = neighbors(x2, y2);
                }
            }
        }

        private static int neighbors(int x, int y)
        {
            // awful code
            // As long as I don't have to edit it again, it's fine, right?
            // look in each of the 8 directions for neigbors
            if(isBomb(x,y))
            {
                return -1;
            }

            int toReturn = 0;
            if(x!=0&y!=0)
            {
                // top left
                if(isBomb(x-1,y-1))
                {
                    toReturn++;
                }
            }

            if(x!=0)
            {
                // left
                if (isBomb(x - 1, y))
                {
                    toReturn++;
                }
            }

            if(x!=0 & y<gridHeight-1)
            {
                // bottom left
                if (isBomb(x - 1, y + 1))
                {
                    toReturn++;
                }
            }

            if(y!=0)
            {
                // top
                if (isBomb(x , y - 1))
                {
                    toReturn++;
                }
            }

            if (y < gridHeight - 1)
            {
                // bottom
                if (isBomb(x, y +1))
                {
                    toReturn++;
                }
            }

            if(x<gridWidth-1 & y!=0)
            {
                // Top right
                if (isBomb(x + 1, y - 1))
                {
                    toReturn++;
                }
            }

            if(x<gridWidth-1)
            {
                // right
                if (isBomb(x + 1, y))
                {
                    toReturn++;
                }

            }

            if (x<gridWidth-1 & y<gridHeight-1)
            {
                //Bottom right
                if (isBomb(x + 1, y + 1))
                {
                    toReturn++;
                }
            }

            return toReturn;

        }

       
        private static bool isBomb(int x, int y)
        {
            return gameSpace[x, y].neighbors == -1;
        }


        public static void revealAll()
        {
            // this code is called when the player causes a meltdown.
              
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    gameSpace[x, y].reveal(true);
                }
            }
            panelOn = true;
        }

        public static void revealAdjacent(int x, int y)
        {
           
            // again, terrible code.
            // This is a short project though, so eh.
            int toReturn = 0;
            if (x != 0 & y != 0)
            {
                // top left
                gameSpace[x - 1, y - 1].reveal(false);
              
            }

            if (x != 0)
            {
                // left
                gameSpace[x - 1, y].reveal(false);

            }

            if (x != 0 & y < gridHeight - 1)
            {
                // bottom left
                gameSpace[x - 1, y + 1].reveal(false);

            }

            if (y != 0)
            {
                // top
                gameSpace[x, y - 1].reveal(false);
            }

            if (y < gridHeight - 1)
            {
                // bottom
                gameSpace[x, y + 1].reveal(false);

            }

            if (x < gridWidth - 1 & y != 0)
            {
                // Top right
                gameSpace[x + 1, y - 1].reveal(false);

            }

            if (x < gridWidth - 1)
            {
                // right
                gameSpace[x + 1, y].reveal(false);


            }

            if (x < gridWidth - 1 & y < gridHeight - 1)
            {
                //Bottom right
                gameSpace[x + 1, y + 1].reveal(false);

            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //mainForm.Visible = true;
            mainForm.Close();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // This timer ticks every 32 ms, about 30 times a second

            // adjust the panel, if so required.

            if (panelOn)
            {
                //foreground.Enabled = true; // any time the panel is even slightly visible, we disable interactivity with the game.
                if (messageOpacity < maxOpacity)
                {
                    messageOpacity += opacityRate;
                    if (messageOpacity > maxOpacity)
                    {
                        messageOpacity = maxOpacity;
                    }
                }
            }
            else
            {
                if(messageOpacity==0)
                {
                   // foreground.Enabled = false;
                    
                }
                else
                {
                    messageOpacity -= opacityRate;
                    if(messageOpacity<0)
                    {
                        messageOpacity = 0;
                    }
                }
            }

            //foreground.Opacity = messageOpacity;

            // update every tile.
            for (int x = 0; x < gridWidth; x++)
            {
                 for (int y = 0; y < gridHeight; y++)
                 {

                     gameSpace[x,y].update();
                 }
            }
            btnBack.update();
            btnEasy.update();
            btnHard.update();
            btnMedium.update();

            
            
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            // We only want the game's timer running when the game is.
            if (this.Visible)
            {
                timer1.Start();
                return;
            }

            timer1.Stop();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // almost certainly temporary code
            mainForm.Visible = true;
            mainForm.Focus();
            this.Visible = false;
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            panelOn = false;
            gameStarted = false;
            scale = 3;
            generateMap();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            panelOn = false;
            gameStarted = false;
            scale = 4;
            generateMap();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            panelOn = false ;
            gameStarted = false;
            scale = 5;
            generateMap();
        }
    }
}
