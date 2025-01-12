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
    public partial class MasterColor : Form
    {
        string uidlogin = "";
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        int selectedIdx=-1;

        public MasterColor()
        {
            InitializeComponent();
        }

        bool def = true;
        public MasterColor(string uid)
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            uidlogin = uid;
            apdet();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (label3.Text == ""||textBox1.Text=="")
            {
                MessageBox.Show("warna belum dipilih");
            }
            else
            {
                conn.Open();
                string query3 = "select substring(max(co_id),3) from color;";
                cmd = new MySqlCommand(query3, conn);
                string tempid = Convert.ToString(cmd.ExecuteScalar().ToString());
                conn.Close();
                int inttempid = Convert.ToInt32(tempid) + 1;
                string idbaru = $"CO{inttempid.ToString().PadLeft(3, '0')}";
                conn.Open();
                string query4 = $"INSERT INTO `color`(`co_id`, `co_name`, `co_hex`) VALUES ('{idbaru}','{textBox1.Text}','{label3.Text}')";
                cmd = new MySqlCommand(query4, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                apdet();
                label3.Text = "";
                textBox1.Text = "";
                button2.BackColor= SystemColors.Control;
            }
        }
        public void apdet()
        {
            conn.Open();
            string query = @"SELECT * FROM color";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteReader();
            conn.Close();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuEmployee me = new MenuEmployee(uidlogin);
            this.Hide();
            me.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedIdx = -1;
            def = false;
            colorDialog1.ShowDialog();
            Color clr = colorDialog1.Color;
            button2.BackColor = clr;
            string hex = clr.R.ToString("X2") + clr.G.ToString("X2") + clr.B.ToString("X2");
            label2.Text = "color: #";
            label3.Text = hex;
            button3.Enabled = true;
            button4.Enabled = false;
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
                cmd.CommandText = $"DELETE FROM color WHERE co_id = '{dataGridView1.Rows[selectedIdx].Cells[0].Value.ToString()}'";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Berhasil Hapus");
                apdet();
                label3.Text = "";
                textBox1.Text = "";
                button2.BackColor = SystemColors.Control;
                selectedIdx = -1;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIdx = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[selectedIdx].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[selectedIdx].Cells[2].Value.ToString();
            string temphex = "#" + dataGridView1.Rows[selectedIdx].Cells[2].Value.ToString();
            Color clr = System.Drawing.ColorTranslator.FromHtml(temphex);
            button2.BackColor = clr;
            button3.Enabled = false;
            button4.Enabled = true;
        }
    }
}
