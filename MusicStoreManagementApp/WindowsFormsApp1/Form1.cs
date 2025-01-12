using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        public Form1()
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM `users`";
            cmd = new MySqlCommand(query, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool ada = false;
            string uid="";
            string pass="";
            int priv=-1;
            while (reader.Read())
            {
                if (reader.GetString(2) == textBox1.Text)
                {
                    ada = true;
                    uid = reader.GetString(0);
                    pass = reader.GetString(3);
                    priv = Convert.ToInt32(reader.GetString(6));

                }
            }
            conn.Close();
            if (ada == false)
            {
                MessageBox.Show("user tidak ada");
            }
            else
            {
                conn.Open();
                query = "SELECT us_password FROM users where us_id=" + uid;
                cmd = new MySqlCommand("SELECT us_password FROM users where us_id='"+uid.ToString()+"';", conn);
                string passseharusnya= Convert.ToString(cmd.ExecuteScalar().ToString());
                if (passseharusnya == textBox2.Text)
                {
                    if (priv == 0)
                    {
                        CustomerHome ch = new CustomerHome();
                        this.Hide();
                        ch.Show();
                    }
                    else if (priv == 1)
                    {
                        MenuEmployee me = new MenuEmployee(uid);
                        this.Hide();
                        me.Show();
                    }
                    else
                    {
                        MessageBox.Show("something went wrong");
                    }
                }
                else
                {
                    MessageBox.Show("password salah");
                }
                conn.Close();
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
