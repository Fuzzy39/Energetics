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


            Label test = new Label();
            test.ForeColor = Color.Black;
            // test.BackColor = Color.Black;
            test.Location = new Point(100, 100);
            test.Text = "Fart sandwich";
            test.Size = new Size(100, 100);
            test.Visible = true;
            //this.PerformLayout();
            // this.Text = "why u no work?";
            this.Controls.Add(test);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // mainForm.Visible = true;
            mainForm.Close();
        }
    }
}
