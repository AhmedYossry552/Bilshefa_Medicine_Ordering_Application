using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using CrystalDecisions.Shared;
using Oracle.DataAccess.Types;
namespace Belshifa
{
    public partial class Form10 : Form
    {
        Medicines medicines;
        string ordb = "Data source=orcl;User Id=scott; Password=scott;";
        OracleConnection conn;
        public Form10()
        {
            InitializeComponent();
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            medicines = new Medicines();
            crystalReportViewer1.ReportSource = medicines;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 to1 = new Form6();
            to1.Show();
            this.Hide();
        }
    }
}
