using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belshifa
{
    public partial class Form8 : Form
    {
        int id;
        public Form8(int id )
        {
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Form1 to = new Form1(id);
            to.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 to = new Form7(id);
            to.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
