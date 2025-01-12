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
    public partial class Form3 : Form
    {
        public Form3(DataSet1 dst)
        {
            InitializeComponent();
            ds = dst;

        }
        DataSet1 ds;
        DataTable dtu;
        DataTable dtj;
        int rowClick = -1;
        int colClick = -1;
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables["user"];
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2(ds);
            f1.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(ds);
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool usernamevalid = true;
            if(textBox1.Text.Contains(" "))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("1"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("2"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("3"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("4"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("5"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("6"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("7"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("8"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("9"))
            {
                usernamevalid = false;
            }
            else if (textBox1.Text.Contains("0"))
            {
                usernamevalid = false;
            }
            if (usernamevalid == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    DataRow dr = ds.Tables["user"].NewRow();
                    dr["username"] = textBox1.Text;
                    dr["nama"] = textBox2.Text;
                    dr["password"] = balik(textBox1.Text) + textBox1.Text.Length.ToString();
                    dr["id"] = ds.Tables["user"].Rows.Count+1;
                    dr["status"] = "Standby";
                    dr["saldo"] = 0;
                    dr["jobs"] = "-";
                    ds.Tables["user"].Rows.Add(dr);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("ada yang kosong");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("username tidak boleh ada angka atau spasi");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        private string balik(string s)
        {
            char[] charArray = s.ToCharArray();
            for (int i = 0; i < (charArray.Length/2); i++)
            {
                char temp = charArray[i];
                charArray[i] = charArray[Convert.ToInt32(charArray.Length)-1-i];
                charArray[Convert.ToInt32(charArray.Length)-1 - i] = temp;
            }
            return new string(charArray);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowClick = e.RowIndex;
            colClick = e.ColumnIndex;
            if (rowClick > -1)
            {
                button2.Enabled = true;
                textBox1.Text = ds.Tables["user"].Rows[rowClick].ItemArray[2].ToString();
                textBox2.Text = ds.Tables["user"].Rows[rowClick].ItemArray[1].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables["user"].Rows.RemoveAt(rowClick);
            rowClick = -1;
            colClick = -1;
            button2.Enabled = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value.ToString() == "Standby")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (e.Value.ToString() == "Working")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
