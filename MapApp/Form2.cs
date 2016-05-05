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

    public partial class Form2 : Form
    {
        public string tripID;
        public Form2()
        {
            InitializeComponent();
            tripID = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tripID = textBox2.Text;
            this.Close();
        }
    }
}
