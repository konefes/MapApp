using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapApp
{
    public partial class Form4 : Form
    {
        public string behavior1;
        public string behavior2;
        public string behavior3;
        public string behavior4;
        public string behavior5;
        public string behavior6;
        public string behavior7;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            behavior1 = textBox14.Text;
            behavior2 = textBox13.Text;
            behavior3 = textBox12.Text;
            behavior4 = textBox11.Text;
            behavior5 = textBox10.Text;
            behavior6 = textBox9.Text;
            behavior7 = textBox8.Text;
            this.Close();
        }
    }
}
