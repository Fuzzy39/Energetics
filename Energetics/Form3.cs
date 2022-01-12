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
        Form1 mainForm;

        private Label lblCount;

        public Form3(Form1 creator)
        {
            InitializeComponent();
            mainForm = creator;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 20; x++)
            {
                lblCount = new Label();
            }

        }
    }
}
