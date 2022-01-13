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
    public partial class Form2 : Form
    {
        Form1 mainForm;
       

        public Form2(Form1 creator)
        {
            InitializeComponent();


            mainForm = creator;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            // Example code to set up a control programmatically
            this.Controls.Add( new MinesweeperTile(new Point(), new Point(200, 100), 0));
            this.Controls.Add(new MinesweeperTile(new Point(), new Point(200, 180), 0));
            this.Controls.Add(new MinesweeperTile(new Point(), new Point(280, 100), 0));
            this.Controls.Add(new MinesweeperTile(new Point(), new Point(280, 180), 0));

            /*  MinesweeperTile test = new MinesweeperTile();
              test.ForeColor = Color.White;
              test.BackColor = Color.FromArgb(255, 200, 80, 0);
              test.TextAlign = ContentAlignment.MiddleCenter;
              test.Location = new Point(100, 100);
              test.Text = "DON'T CLICK ME!!";
              test.Font = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Bold);
              test.Size = new Size(100, 100);
              //test.Click += test_Click;
              this.Controls.Add(test);*/



        }



        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Visible = true;
            // mainForm.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // This timer ticks every 32 ms, about 30 times a second

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


      
    }
}
