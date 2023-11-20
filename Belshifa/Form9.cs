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
using CrystalDecisions.CrystalReports.Engine;

namespace Belshifa
{
    
    public partial class Form9 : Form
    {
        int id;
        CrystalOrderReport orderinfo;
        string ordb = "Data source=orcl;User Id=scott; Password=scott;";
        OracleConnection conn;
        public Form9(int id)
        {
            this.id = id;
            InitializeComponent();
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            orderinfo = new CrystalOrderReport();
            orderinfo.SetParameterValue("id", id);
            crystalReportViewer1.ReportSource = orderinfo;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = conn;
                command.CommandText = "Delete_order";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("id", id);
                command.ExecuteNonQuery();
            Form8 to1 = new Form8(id);
            to1.Show();
            this.Hide();
        }
    }
}
