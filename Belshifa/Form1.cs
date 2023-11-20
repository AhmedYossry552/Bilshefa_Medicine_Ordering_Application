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
    public partial class Form1 : Form
    {
        string orcl = "Data Source=orcl; user Id=scott; password=scott;";
        OracleConnection conn;
        int id;
        int maxId=0, newId=0;
        public Form1(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conn = new OracleConnection(orcl);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select name from medicines";
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comb_id.Items.Add(dr[0]);
            }
           
            
        }

        private void comb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd =new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "select brand,discription,price, avaliable from medicines where name =:name";
            cmd.Parameters.Add("name", comb_id.SelectedItem.ToString());
            OracleDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_Brand.Text=dr[0].ToString();
                txt_dis.Text=dr[1].ToString();
                txt_price.Text=dr[2].ToString();    
                txt_available.Text=dr[3].ToString();
            }
         
           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* Form5 to = new Form5();
            to.Show();
            this.Hide();*/
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8 to = new Form8(id);
            to.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            cmd.CommandText = "insert into Ordersinfo values(:orderid,:id,:cost,:name)";
            string query = $"SELECT MAX(order_id) FROM Ordersinfo";
            using (OracleCommand command = new OracleCommand(query, conn))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxId = Convert.ToInt32(result);
                    newId = maxId + 1;
                }
            }
            if (txt_Brand.Text.ToString() == "")
            {
                MessageBox.Show("Please choose medicine from list");
            }
            else
            {
                cmd.Parameters.Add("orderid", newId);
                cmd.Parameters.Add("id", id);
                cmd.Parameters.Add("cost", Convert.ToInt32(txt_price.Text.ToString()));
                cmd.Parameters.Add("name", comb_id.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item added successfully");
            }
            //conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 to1 = new Form5(id);
            to1.Show();
            this.Hide();
        }

        
        
    }
}
