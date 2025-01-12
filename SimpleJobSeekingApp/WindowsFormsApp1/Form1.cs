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
        public Form1(DataSet1 dst)
        {
            InitializeComponent();
            ds = dst;
        }
        public Form1()
        {
            InitializeComponent();
            ds = new DataSet1();
            dtu = ds.Tables["user"];
            dtj = ds.Tables["job"];

        }
        DataSet1 ds;
        DataTable dtu;
        DataTable dtj;
        int currentuser;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin"&& textBox2.Text == "admin")
            {
                Form2 formadmin = new Form2(ds);
                formadmin.Show();
                this.Hide();
            }
            else
            {
                bool userada = false;
                for (int i = 0; i < ds.Tables["user"].Rows.Count; i++)
                {
                    if (ds.Tables["user"].Rows[i]["username"].ToString() == textBox1.Text)
                    {
                        userada = true;
                        if(ds.Tables["user"].Rows[i]["password"].ToString() == textBox2.Text)
                        {
                            currentuser = i;
                            Form4 f4 = new Form4(ds, currentuser);
                            f4.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Password salah");
                            button1.PerformClick();
                        }
                    }
                }
                if (userada == false)
                {
                    MessageBox.Show("user tidak ditemukkan");
                    button1.PerformClick();
                }
                //foreach (DataRow x in ds.Tables["user"].Rows)
                //{
                //    if(x["username"].ToString()==textBox1.Text&& x["password"].ToString() == textBox2.Text)
                //    {
                //        currentuser = x["username"].ToString();
                //        Form4 f4 = new Form4(ds,currentuser);
                //        f4.Show();
                //        this.Hide();
                //    }
                //}
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
