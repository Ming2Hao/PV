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
    public partial class MenuEmployee : Form
    {
        string uidlogin = "";
        MySqlConnection conn;
        MySqlCommand cmd;
        DataTable dt;
        public MenuEmployee()
        {
            InitializeComponent();
        }
        public MenuEmployee(string uid)
        {
            Koneksi.openConn();
            conn = Koneksi.getConn();
            cmd = new MySqlCommand();
            InitializeComponent();
            uidlogin = uid;
            conn.Open();
            string query = "SELECT us_name FROM users where us_id='" + uid.ToString() + "';";
            cmd = new MySqlCommand(query, conn);
            label2.Text = Convert.ToString(cmd.ExecuteScalar().ToString());
            conn.Close();
        }
        private void MenuEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasterColor f1 = new MasterColor(uidlogin);
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MasterVariant f1 = new MasterVariant(uidlogin);
            this.Hide();
            f1.Show();
        }
    }
}
