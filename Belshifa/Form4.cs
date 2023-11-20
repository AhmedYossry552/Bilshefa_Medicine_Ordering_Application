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
    public partial class Form4 : Form
    {
        string ordb = "Data Source = orcl; User Id = scott; Password = scott;";
        OracleConnection conn;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            

        }

        private int check_password2()
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("un", user_name_text_box.Text);
            cmd.Parameters.Add("up", password_text_box.Text);
            cmd.Parameters.Add("res", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            if (cmd.Parameters["res"].Value.ToString() == "0")
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32( cmd.Parameters["id"].Value.ToString());
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Form11 to1 = new Form11();
            to1.Show();
            this.Hide();
        }
        private void label5_Click_1(object sender, EventArgs e)
        {
            Form11 to1 = new Form11();
            to1.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool cur_state = password_text_box.UseSystemPasswordChar;
            password_text_box.UseSystemPasswordChar = !cur_state;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user_name_text_box.Text == "admin" &&
                  password_text_box.Text == "admin")
            {
                Form6 to1 = new Form6();
                to1.Show();
                this.Hide();
            }
            else
            {
                int flag = check_password2();
                if (flag != -1)
                {
                    // go to main screen
                    MessageBox.Show("Successful Login");
                    Form8 to1 = new Form8(flag);
                    to1.Show();
                    this.Hide();
                }
                else
                {
                    Error_label.Visible = true;
                }
            }
        }
    }
}
