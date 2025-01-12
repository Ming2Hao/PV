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
    public partial class CustomerHome : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        public CustomerHome()
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            apdet(@"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = "";
        }
        public void apdet(string qw)
        {
            conn.Open();
            string query = qw;
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteReader();
            conn.Close();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%';";
                }
                apdet(tempqw);
            }
            else if (radioButton1.Checked == true)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id order by a.al_name ASC;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%' order by a.al_name ASC;";
                }
                apdet(tempqw);
            }
            else if (radioButton2.Checked == true)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id order by a.al_name DESC;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%' order by a.al_name DESC;";
                }
                apdet(tempqw);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%';";
                }
                apdet(tempqw);
            }
            else if (radioButton1.Checked == true)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id order by a.al_name ASC;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%' order by a.al_name ASC;";
                }
                apdet(tempqw);
            }
            else if (radioButton2.Checked == true)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id order by a.al_name DESC;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%' order by a.al_name DESC;";
                }
                apdet(tempqw);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%';";
                }
                apdet(tempqw);
            }
            else if (radioButton1.Checked == true)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id order by a.al_name ASC;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%' order by a.al_name ASC;";
                }
                apdet(tempqw);
            }
            else if (radioButton2.Checked == true)
            {
                string str = textBox1.Text;
                string tempqw = "";
                if (str == "")
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id order by a.al_name DESC;";
                }
                else
                {
                    tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE a.al_name LIKE '%" + str + "%' or i.in_name LIKE '%" + str + "%' or b.br_name LIKE '%" + str + "%' or c.co_name LIKE '%" + str + "%' order by a.al_name DESC;";
                }
                apdet(tempqw);
            }
        }
    }
}
