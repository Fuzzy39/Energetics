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
    public partial class Form3 : Form
    {
        //form stuff
        Form1 mainForm;
        private Label lblCount;

        //variables
        bool moveLeft;
        bool moveRigt;
        bool gameOver;
        bool firstTimeOnPage = true;

        int score;
        int ballX;
        int ballyY;
        int playerSpeed;

        Random rand = new Random();

        public Form3(Form1 creator)
        {
            InitializeComponent();
            mainForm = creator;
        }

        private void setupGame()
        {
            //sets speeds and score
            score = 0;
            ballX = 5;
            ballyY = 5;
            playerSpeed = 12;
            lbl_Score.Text = "You have: " + score.ToString();

            
           

            foreach (Control x in this.Controls) //runs code for each control
            {
                if (x is PictureBox && (string)x.Tag == "blocks") //runs if x is a picturebox with a blocks tag
                {

                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

        }

        private void keyisup(object sender, KeyEventArgs e)
        {

        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                timer.Start();
                if (firstTimeOnPage == true)
                {
                    MessageBox.Show("Hi", "Welcome to the solar game", MessageBoxButtons.OK);
                    firstTimeOnPage = false;
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
            this.Hide();
            mainForm.Visible = true;
        }
    }
}
