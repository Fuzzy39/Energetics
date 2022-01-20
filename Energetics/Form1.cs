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
    // January 20th, Mason Hill
    // this code governs the primary form which selects between games.
    public partial class Form1 : Form
    {
        public Form2 formNuclear;
        public Form3 formSolar;

        public Form1()
        {
            InitializeComponent();
            btnKinetic.lblTile.Size = new System.Drawing.Size(550, 180);
            btnKinetic.lblTile.Location = new Point(5, 5);
            btnKinetic.lblTile.Text = "Kinetics";
            btnKinetic.lblTile.BackColor = Color.FromArgb(255, 100, 150, 150);
            btnKinetic.jitters = new bool[] { false, true, true };
            btnKinetic.reactive = false;
            btnKinetic.colorRange = 15;

            btnNuclear.lblTile.Location = new Point(5, 5);
            btnNuclear.lblTile.Size = new System.Drawing.Size(550, 180);
            btnNuclear.lblTile.Text = "Nuclear";
            btnNuclear.lblTile.BackColor = Color.FromArgb(255, 100, 150, 100);
            btnNuclear.jitters = new bool[] { false, true, false };
            btnNuclear.reactive = false;
            btnNuclear.colorRange = 15;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formNuclear = new Form2(this);
            formSolar = new Form3(this);

           
            timer1.Start();

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            btnNuclear.update();
            btnKinetic.update();
        }

        private void lblTemporary_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void btnKinetic_Click(object sender, EventArgs e)
        {
            formSolar.Visible = true;
            this.Visible = false;
        }

        private void btnNuclear_Click_1(object sender, EventArgs e)
        {
            formNuclear.Visible = true;
            this.Visible = false;
        }
    }
}
