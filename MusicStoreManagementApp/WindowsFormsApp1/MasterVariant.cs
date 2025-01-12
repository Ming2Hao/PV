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
    public partial class MasterVariant : Form
    {
        string uidlogin = "";
        DataRow tempdr;
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        int selectedIdx = -1;
        
        public MasterVariant()
        {
            InitializeComponent();
        }
        public MasterVariant(string uid)
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            uidlogin = uid;
            comboBox1.SelectedIndex=0;
            apdet(@"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;");
            comboBox2.Enabled = false;
            apdetcbx();
        }
        public MasterVariant(string uid,DataRow dr)
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            uidlogin = uid;
            tempdr = dr;
            comboBox1.SelectedIndex = 0;
            apdet(@"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;");
            textBox2.Text = dr[0].ToString();
            textBox3.Text = dr[1].ToString();
            textBox4.Text = dr[3].ToString();
            conn.Open();
            string query = "SELECT in_name FROM instrument where in_id='" + dr[7].ToString() + "';";
            cmd = new MySqlCommand(query, conn);
            string tempinstrument = Convert.ToString(cmd.ExecuteScalar().ToString());
            conn.Close();
            textBox5.Text = tempinstrument;
            conn.Open();
            string query2 = "SELECT br_name FROM brand where br_id='" + dr[6].ToString() + "';";
            cmd = new MySqlCommand(query2, conn);
            string tempbrand = Convert.ToString(cmd.ExecuteScalar().ToString());
            conn.Close();
            textBox6.Text = tempbrand;
            comboBox2.Enabled = true;
            apdetcbx();
            comboBox2.SelectedIndex = 0;
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

        private void MasterVariant_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuEmployee me = new MenuEmployee(uidlogin);
            this.Hide();
            me.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(uidlogin);
            this.Hide();
            f2.Show();
        }
        public void apdetcbx()
        {
            comboBox2.DataSource = null;
            cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM color";
            cmd.Connection = conn;

            MySqlDataAdapter das = new MySqlDataAdapter(cmd);

            DataTable dts = new DataTable();

            das.Fill(dts);
            comboBox2.DataSource = dts;
            comboBox2.DisplayMember = "co_name";
            comboBox2.ValueMember = "co_id";
            comboBox2.Enabled = true;
            //comboBox2.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || comboBox2.SelectedValue == "")
            {
                MessageBox.Show("ada yang belom diisi");
            }
            else
            {

                conn.Open();
                string query3 = "select substring(max(va_id),3) from variant;";
                cmd = new MySqlCommand(query3, conn);
                string tempid = Convert.ToString(cmd.ExecuteScalar().ToString());
                conn.Close();
                int inttempid = Convert.ToInt32(tempid)+1;
                string idbaru = $"VA{inttempid.ToString().PadLeft(3, '0')}";
                conn.Open();
                string query4 = $"INSERT INTO `variant`(`va_id`, `va_al_id`, `va_co_id`) VALUES ('{idbaru}','{tempdr[0]}','{comboBox2.SelectedValue.ToString()}')";
                //MessageBox.Show(query4);
                //MessageBox.Show(idbaru);
                //MessageBox.Show(tempdr[0].ToString());
                //MessageBox.Show(comboBox2.SelectedValue.ToString());
                cmd = new MySqlCommand(query4, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                apdet(@"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;");
                button3.PerformClick();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox2.SelectedIndex = 0;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIdx = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[selectedIdx].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selectedIdx].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[selectedIdx].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[selectedIdx].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[selectedIdx].Cells[5].Value.ToString();
            apdetcbx();
            cmd = new MySqlCommand();
            cmd.CommandText = $"SELECT co_id FROM color WHERE co_name = '{dataGridView1.Rows[selectedIdx].Cells[6].Value}'";
            cmd.Connection = conn;

            conn.Open();
            comboBox2.SelectedValue = cmd.ExecuteScalar().ToString();
            conn.Close();
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button2.Enabled = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedIdx == -1)
            {
                MessageBox.Show("Belum ada yang dipilih");
            }
            else
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"DELETE FROM variant WHERE va_id = '{dataGridView1.Rows[selectedIdx].Cells[0].Value.ToString()}'";

                conn.Open();
                //MessageBox.Show(dataGridView1.Rows[selectedIdx].Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil Hapus");
                apdet(@"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;");
                button3.PerformClick();
                selectedIdx = -1;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedIdx == -1)
            {

            }
            else
            {
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE variant SET va_co_id=@coidbaru WHERE va_id = @vacoid";
                cmd.Parameters.Add(new MySqlParameter("@coidbaru", comboBox2.SelectedValue));
                cmd.Parameters.Add(new MySqlParameter("@vacoid", dataGridView1.Rows[selectedIdx].Cells[0].Value.ToString()));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                apdet(@"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;");
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = true;
                button2.Enabled = true;
                button3.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string basedon = "";
            if (comboBox1.Text == "Nama")
            {
                basedon = "a.al_name";
            }
            else if (comboBox1.Text == "Instrument")
            {
                basedon = "i.in_name";
            }
            else if (comboBox1.Text == "Brand")
            {
                basedon = "b.br_name";
            }
            else if (comboBox1.Text == "Color")
            {
                basedon = "c.co_name";
            }
            string str = textBox1.Text;
            string tempqw = "";
            if (str == "")
            {
                tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id;";
            }
            else
            {
                tempqw = @"SELECT v.va_id, v.va_al_id, a.al_name, i.in_name, a.al_price, b.br_name ,c.co_name FROM variant v LEFT OUTER JOIN alatmusik a ON v.va_al_id=a.al_id LEFT OUTER JOIN brand b ON a.al_br_id=b.br_id LEFT OUTER JOIN instrument i ON a.al_in_id=i.in_id LEFT OUTER JOIN color c ON v.va_co_id=c.co_id WHERE " + basedon + " LIKE '%" + str + "%';";
            }
            apdet(tempqw);
        }
    }
}
