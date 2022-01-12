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
    public partial class Form1 : Form
    {
        public Form2 formMineSweeper;
        public Form3 formBreakOut;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formMineSweeper = new Form2(this);
            formBreakOut = new Form3(this);
        }
    }
}
