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
namespace Belshifa
{
    public partial class Form7 : Form
    {
        int id;
        string orcl = "Data Source=orcl; user Id=scott; password=scott;";
        OracleConnection conn;
        public Form7(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            OracleCommand command = new OracleCommand();
            command.Connection = conn;
            if (textBrand.Text == "")
            {
                MessageBox.Show("Please enter Brand name");
            }
            else
            {
                command.CommandText = "GETITEMS";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Brand", textBrand.Text);
                command.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);

                OracleDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Text = dr[0].ToString();
                    comboBox1.Items.Add(dr[0]);
                }
                dr.Close();
            }

           
           
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(orcl);
            conn.Open();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                Form6 to11 = new Form6();
                to11.Show();
                this.Hide();
            }
            else
            {
                Form8 to1 = new Form8(id);
                to1.Show();
                this.Hide();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            OracleCommand command = new OracleCommand();
            command.Connection = conn;
            if (textBrand.Text == "")
            {
                MessageBox.Show("Please enter Brand name");
            }
            else
            {
                command.CommandText = "GETITEMS";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("Brand", textBrand.Text);
                command.Parameters.Add("name", OracleDbType.RefCursor, ParameterDirection.Output);

                OracleDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Text = dr[0].ToString();
                    comboBox1.Items.Add(dr[0]);
                }
                dr.Close();
            }

        }

        private void textBrand_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
