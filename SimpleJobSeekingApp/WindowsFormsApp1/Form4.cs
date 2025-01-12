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
    public partial class Form4 : Form
    {
        public Form4(DataSet1 dst,int tempcurrentuser)
        {
            InitializeComponent();
            ds = dst;
            currentuser = tempcurrentuser;
            refresh();
        }
        DataSet1 ds;
        int currentuser;
        int rowClick = -1;
        int colClick = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(ds);
            this.Hide();
            f1.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowClick = e.RowIndex;
            colClick = e.ColumnIndex;
            if (ds.Tables["job"].Rows[rowClick]["status"].ToString() == "Menunggu")
            {
                ds.Tables["job"].Rows[rowClick]["status"] = "Dikerjakan";
                ds.Tables["job"].Rows[rowClick]["worker"] = ds.Tables["user"].Rows[currentuser]["nama"].ToString();
                ds.Tables["user"].Rows[currentuser]["status"] = "Working";
                ds.Tables["user"].Rows[currentuser]["jobs"] = ds.Tables["job"].Rows[rowClick]["description"].ToString();
                refresh();
            }
        }
        private void refresh()
        {
            if (ds.Tables["user"].Rows[currentuser]["status"].ToString() == "Standby")
            {
                dataGridView1.Visible = true;
                label4.Text = ds.Tables["user"].Rows[currentuser]["jobs"].ToString();
                button2.Visible = false;
            }
            else
            {
                dataGridView1.Visible = false;
                label4.Text = ds.Tables["user"].Rows[currentuser]["jobs"].ToString();
                button2.Visible = true;
            }
            label2.Text = ds.Tables["user"].Rows[currentuser]["nama"].ToString();
            label6.Text = ds.Tables["user"].Rows[currentuser]["saldo"].ToString();
            dataGridView1.DataSource = ds.Tables["job"];
            dataGridView1.Columns[4].Visible = false;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["job"].Rows.Count; i++)
            {
                if(ds.Tables["job"].Rows[i]["description"].ToString() == ds.Tables["user"].Rows[currentuser]["jobs"].ToString())
                {
                    ds.Tables["job"].Rows[i]["status"] = "Sudah Selesai";
                    ds.Tables["user"].Rows[currentuser]["status"] = "Standby";
                    ds.Tables["user"].Rows[currentuser]["saldo"] = Convert.ToInt32(ds.Tables["user"].Rows[currentuser]["saldo"])+Convert.ToInt32(ds.Tables["job"].Rows[i]["price"]);
                    ds.Tables["user"].Rows[currentuser]["jobs"] = "-";
                }
            }
            refresh();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value.ToString() == "Teknologi")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (e.Value.ToString() == "Desain")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else if (e.Value.ToString() == "Literasi")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            if (e.ColumnIndex == 5)
            {
                if (e.Value.ToString() == "Dikerjakan")
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else if (e.Value.ToString() == "Menunggu")
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (e.Value.ToString() == "Sudah Selesai")
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
            }
        }
    }
}
