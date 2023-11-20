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
    public partial class Form11 : Form
    {
        string ordb = "Data Source = orcl; User Id = scott; Password = scott;";
        OracleConnection conn;
        public Form11()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int maxId = 0, newID = 0;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Users values(:id,:email,:password,:phonenumber,:name)";
            string query = $"SELECT MAX(ID) FROM Users";
            using (OracleCommand command = new OracleCommand(query, conn))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxId = Convert.ToInt32(result);
                    newID = maxId + 1;
                }
            }
            //MessageBox.Show(""+newID);
            cmd.Parameters.Add("id", newID);
            cmd.Parameters.Add("email", email_txtbox.Text);
            cmd.Parameters.Add("password", pass_txtbox.Text);
            cmd.Parameters.Add("phonenumber", phone_txtbox.Text);
            cmd.Parameters.Add("name", user_name_txtbox.Text);

            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Register successfully");
            }
            Form4 to1 = new Form4();
            to1.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form4 to1 = new Form4();
            to1.Show();
            this.Hide();
        }

        private void phone_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (user_name_txtbox.Text == "" || pass_txtbox.Text == "" || phone_txtbox.Text == "" || email_txtbox.Text == "")
            {
                MessageBox.Show("fill all Attributes");
            }
            else
            {
                int flag = checkUser();
                if (flag == 1)
                {
                    int maxId = 0, newID = 0;
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into Users values(:id,:email,:password,:phonenumber,:name)";
                    string query = $"SELECT MAX(ID) FROM Users";
                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            maxId = Convert.ToInt32(result);
                            newID = maxId + 1;
                        }
                    }
                    cmd.Parameters.Add("id", newID);
                    cmd.Parameters.Add("email", email_txtbox.Text);
                    cmd.Parameters.Add("password", pass_txtbox.Text);
                    cmd.Parameters.Add("phonenumber", phone_txtbox.Text);
                    cmd.Parameters.Add("name", user_name_txtbox.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != -1)
                    {
                        MessageBox.Show("Register successfully");
                    }
                    Form4 to1 = new Form4();
                    to1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Not valid!\nEnter another user name");
                }


            
            }
                
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 to1 = new Form4();
            to1.Show();
            this.Hide();
        }

        private void show_pass_btn_Click(object sender, EventArgs e)
        {
            bool cur_state = pass_txtbox.UseSystemPasswordChar;
            pass_txtbox.UseSystemPasswordChar = !cur_state;
        }

        private int checkUser()
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "checkUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("un", user_name_txtbox.Text);
            cmd.Parameters.Add("res", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();
            if (cmd.Parameters["res"].Value.ToString() == "0")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
