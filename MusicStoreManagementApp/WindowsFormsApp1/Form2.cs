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
    public partial class Form2 : Form
    {
        string uidlogin = "";
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        DataRow dr;

        public Form2()
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            apdet("");
        }
        public Form2(string uid)
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            uidlogin = uid;
            string querys = @"select * from alatmusik;";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            apdet(querys);
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
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            dr = (dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            MasterVariant mv = new MasterVariant(uidlogin, dr);
            this.Hide();
            mv.Show();

        }
    }
}
