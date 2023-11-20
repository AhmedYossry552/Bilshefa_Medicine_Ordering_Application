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
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Belshifa
{
    public partial class Form5 : Form
    {
        OracleDataAdapter adapter;
        OrderReport order;
        OracleCommandBuilder builder;
        DataSet ds;
        int idd;
        public Form5(int id)
        {
            this.idd = id;
            InitializeComponent();
            order = new OrderReport();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btn_showInfo_Click(object sender, EventArgs e)
        {
            string constr = "Data Source =orcl;User Id =scott;Password=scott;";
            string cmdstr = "select name,cost from Ordersinfo where id=:idd";
            adapter = new OracleDataAdapter(cmdstr, constr);
            OracleParameter parameter = new OracleParameter(":idd", OracleDbType.Int32);
            parameter.Value = idd;
            adapter.SelectCommand.Parameters.Add(parameter);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);

            Form9 to = new Form9(idd);
            to.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 to1 = new Form1(idd);
            to1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);

            Form9 to = new Form9(idd);
            to.Show();
            this.Hide();
        }
    }
}
