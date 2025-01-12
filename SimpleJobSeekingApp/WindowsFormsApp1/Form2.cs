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
        public Form2(DataSet1 dst)
        {
            InitializeComponent();
            ds = dst;

        }
        DataSet1 ds;
        DataTable dtu;
        DataTable dtj;
        int rowClick = -1;
        int colClick = -1;

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables["job"];
            dataGridView1.Columns[5].Visible = false;
            numericUpDown1.Maximum = decimal.MaxValue;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Increment = 500;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && numericUpDown1.Value != 0 && textBox2.Text != "")
            {
                DataRow dr = ds.Tables["job"].NewRow();
                dr["applicant"] = textBox1.Text;
                dr["category"] = comboBox1.Text;
                dr["price"] = numericUpDown1.Value;
                dr["description"] = textBox2.Text;
                dr["worker"] = "-";
                dr["status"] = "Menunggu";

                ds.Tables["job"].Rows.Add(dr);
                button4.PerformClick();
            }
            else
            {
                MessageBox.Show("ada yang kosong");
            }
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(ds);
            f1.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables["job"].Rows.RemoveAt(rowClick);
            rowClick = -1;
            colClick = -1;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            button4.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            numericUpDown1.Value = 0;
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && numericUpDown1.Value != 0 && textBox2.Text != "")
            {
                ds.Tables["job"].Rows[rowClick]["applicant"] = textBox1.Text;
                ds.Tables["job"].Rows[rowClick]["category"] = comboBox1.Text;
                ds.Tables["job"].Rows[rowClick]["price"] = numericUpDown1.Value;
                ds.Tables["job"].Rows[rowClick]["description"] = textBox2.Text;

                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;

                button4.PerformClick();
            }
            else
            {
                MessageBox.Show("ada yang kosong");
            }


            
            rowClick = -1;
            colClick = -1;
            button4.PerformClick();
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f1 = new Form3(ds);
            f1.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
                else if(e.Value.ToString() == "Desain")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else if(e.Value.ToString() == "Literasi")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rowClick = e.RowIndex;
            colClick = e.ColumnIndex;
            if (rowClick > -1)
            {
                if (ds.Tables["job"].Rows[rowClick].ItemArray[5].ToString() != "Dikerjakan")
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;

                    textBox1.Text = ds.Tables["job"].Rows[rowClick].ItemArray[0].ToString();
                    comboBox1.Text = ds.Tables["job"].Rows[rowClick].ItemArray[1].ToString();
                    numericUpDown1.Value = Convert.ToInt32(ds.Tables["job"].Rows[rowClick].ItemArray[3]);
                    textBox2.Text = ds.Tables["job"].Rows[rowClick].ItemArray[2].ToString();
                }
                else
                {
                    MessageBox.Show("job yang dikerjakan tidak dapat di edit!");
                }
            }
        }
    }
}
