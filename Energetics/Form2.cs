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
        Label test;
        double pos;

        public Form2(Form1 creator)
        {
            InitializeComponent();


            mainForm = creator;
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            test = new Label();
            test.ForeColor = Color.White;
            test.BackColor = Color.FromArgb(255, 200, 80, 0);
            test.TextAlign = ContentAlignment.MiddleCenter;
            test.Location = new Point(100, 100);
            test.Text = "DON'T CLICK ME!!";
            test.Font = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Bold);
            test.Size = new Size(100, 100);
            test.Click += test_Click;

            pos = 0;
            this.Controls.Add(test);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Visible = true;
           // mainForm.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Point Center = new Point(350, 200);
            double speed = .06; // in radians
            int size = 200; // in pixels
            pos += speed;


            // I know, trig is scary
            test.Location = new Point(
                (int)(size * Math.Cos(pos)) + Center.X,
                (int)(size * Math.Sin(pos)) + Center.Y
            );
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                timer1.Start();
                return;
            }

            timer1.Stop();
        }


        private void test_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            test.BackColor = Color.Red;
            MessageBox.Show("You blew up the reactor!\nIt's going to cost so much to fix...", "YOU IDIOT!");
            this.Close();
        }
    }
}
