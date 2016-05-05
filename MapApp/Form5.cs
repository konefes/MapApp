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
    public partial class Form5 : Form
    {
        public string error1;
        public string error2;
        public string error3;
        public string error4;
        public string error5;
        public string error6;
        public string error7;

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            error1 = textBox14.Text;
            error2 = textBox13.Text;
            error3 = textBox12.Text;
            error4 = textBox11.Text;
            error5 = textBox10.Text;
            error6 = textBox9.Text;
            error7 = textBox8.Text;
            this.Close();
        }
    }
}
