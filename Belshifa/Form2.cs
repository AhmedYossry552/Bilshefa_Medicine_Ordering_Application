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
    public partial class Form2 : Form
    {
        string orcl = "Data Source=orcl; user Id=scott; password=scott;";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(orcl);
            conn.Open();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int maxId = 0, newID = 0;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            int ava = 1;
            cmd.CommandText = "insert into Medicines values(:id,:name,:brand,:discription,:price,:ava)";
            string query = $"SELECT MAX(ID) FROM Medicines";
            using (OracleCommand command = new OracleCommand(query, conn))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxId = Convert.ToInt32(result);
                    newID = maxId + 1;
                }
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("fill all attributes");
            }
            else
            {
                cmd.Parameters.Add("id", newID);
                cmd.Parameters.Add("name", textBox1.Text);
                cmd.Parameters.Add("brand", textBox2.Text);
                cmd.Parameters.Add("discription", textBox3.Text);
                cmd.Parameters.Add("price", textBox4.Text);
                cmd.Parameters.Add("ava", ava);

                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("New Item is added");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form6 to1 = new Form6();
            to1.Show();
            this.Hide();
        }
    }
}
