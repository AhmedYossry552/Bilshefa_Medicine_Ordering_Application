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
    public partial class welcome : Form
    {
        private string s1 = "";
        private int len = 0;
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        { 
            s1 = label1.Text;
            label1.Text = "";
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (len < s1.Length)
            {
                label1.Text += s1.ElementAt(len);
                len++;
            }
            else
            {
                timer1.Stop();
                Form4 to1 = new Form4();
                to1.Show();
                this.Hide();
            }
        }

    }
}
