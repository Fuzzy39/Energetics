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
    // January 13th, Matthew Lewis
    public partial class Form3 : Form
    {
        //form stuff
        Form1 mainForm;
        private Label lblCount;

        //variables
        bool moveLeft;
        bool moveRigt;
        bool isgameOver;
        bool firstTimeOnPage = true;

        int score;
        int ballX;
        int ballyY;
        int playerSpeed;

        Random rand = new Random();

        PictureBox[] blockArray;

        public Form3(Form1 creator)
        {
            InitializeComponent();
            mainForm = creator;

            PlaceBlocks();
        }

        private void setupGame()
        {
            //sets speeds and score
            isgameOver = false;
            score = 0;
            ballX = 5;
            ballyY = 5;
            playerSpeed = 15;

            ball.Left = 413;
            ball.Top = 374;

            player.Left = 361;
            player.Top = 400;


            //timer.Start();


            foreach (Control x in this.Controls) //runs code for each control
            {
                if (x is PictureBox && (string)x.Tag == "blocks") //runs if x is a picturebox with a blocks tag
                {
                    x.BackColor = Color.FromArgb(rand.Next(0), rand.Next(100,256), rand.Next(100,256));
                }
            }
        }

        private void gameOver(string message)
        {
            isgameOver = true;
            timer.Stop();
            if (score == 1)
            {
                lblWinOrLose.Text = message;
            }
            else if (score != 1)
            {
                lblWinOrLose.Text = message;
            }

            btnReturn.Visible = true;
            lblWinOrLose.Visible = true;
            btnReset.Visible = true;
        }

        private void PlaceBlocks()
        {
            blockArray = new PictureBox[32];
            int a = 0;
            int top = 50;
            int left = 8;

            for (int i = 0; i < blockArray.Length; i++)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 99;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.Yellow;

                if (a == 8)
                {
                    top = top + 35;
                    left = 8;
                    a = 0;
                }

                if (a < 8)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left = left + 104;
                }
            }

            setupGame();
        }

        private void removeBlocks()
        {
            foreach(PictureBox x in blockArray)
            {
                this.Controls.Remove(x);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            if (score ==1)
            {
                lbl_Score.Text = "You have made " + score + " collision!";
            }
            else if (score != 1)
            {
                lbl_Score.Text = "You have made " + score + " collisions!";
            }
            //keyisup();
            //keyisup();

            if (moveLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if (moveRigt == true && player.Left < 722)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballX;
            ball.Top += ballyY;

            if (ball.Left < 0 || ball.Left > 822)
            {
                ballX = -ballX;
            }
            if (ball.Top < 0)
            {
                ballyY = -ballyY;
            }
            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                ballyY = rand.Next(5, 12) * -1;

                if (ballX < 0)
                {
                    ballX = rand.Next(5, 12) * -1;
                }
                else
                {
                    ballX = rand.Next(5, 12);
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        ballyY = -ballyY;
                        this.Controls.Remove(x);
                    }
                }
            }

            if (score == 32)
            {
                lbl_Score.Text = "You have made 32 collision!";
                gameOver("You Win!!");
            }
            if (ball.Top > 500)
            {
                gameOver("You lost :(");
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRigt = true;
            }
          
           
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRigt = false;
            }
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                
                if (firstTimeOnPage == true)
                {
                    timer2.Start();


                    MessageBox.Show("In this game, you have a particle and you want to make as many collisions as possible. Use the left and right arrow keys to move a paddle and stop the particle from bouncing away. Hit blocks to increase your total numbr of collisions and produce energy", "Welcome to the kinetic game", MessageBoxButtons.OK);
                    firstTimeOnPage = false;
                    
                }
            }
            else
            {
                timer.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            removeBlocks();
            PlaceBlocks();

            btnReturn.Visible = false;
            btnStart.Visible = true;
            btnReset.Visible = false;
            
            this.Hide();
            mainForm.Visible = true;

            lblWinOrLose.Visible = false;
            lbl_Score.Text = "";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            btnStart.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            removeBlocks();
            PlaceBlocks();

            btnReturn.Visible = false;
            btnStart.Visible = true;

            lblWinOrLose.Visible = false;
            lbl_Score.Text = "";
            btnReset.Visible = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
    }
}
