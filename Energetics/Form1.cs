using System;
using System.Windows.Forms;

namespace Energetics
{
    public partial class Form1 : Form
    {
        public Form2 formNuclear;
        public Form3 formSolar;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formNuclear = new Form2(this);
            formSolar = new Form3(this);
        }

        private void btnSolar_Click(object sender, EventArgs e)
        {
            formSolar.Visible = true;
            this.Visible = false;
        }

        private void btnNuclear_Click(object sender, EventArgs e)
        {
            formNuclear.Visible = true;
            this.Visible = false;
        }
    }
}
