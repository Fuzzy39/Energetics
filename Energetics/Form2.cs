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
            
        }
    }
}
