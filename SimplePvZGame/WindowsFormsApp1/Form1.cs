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
        public Form1()
        {
            InitializeComponent();
            
        }
        int ctrwaktu = 0;
        List<Button> sunflower;
        List<ProgressBar> peashooter;
        List<Panel> listbullet;
        Point[,] petak = new Point[3, 4];
        int panelx = 15;
        int panely = 13;
        Button[,] bt = new Button[3, 4];
        int sun;
        List<Panel> listzombie;
        int sekor;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            sunflower = new List<Button>();
            peashooter = new List<ProgressBar>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    petak[j,i] = new Point(panelx+(j*90),panely+(i*90));
                }
            }
            ctrwaktu = 0;
            sun = 100;
            sekor = 0;
            hideorshow(true);
            listzombie = new List<Panel>();
            listbullet = new List<Panel>();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By : 221116962 - Ivan Cahyadi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Apakah ingin Exit?", "Yakin?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ctrwaktu++;
            updatewaktu();
            updatepeashooter();
            updatesunflower();
            zombiejalan();
            bulletjalan();
            if (ctrwaktu >= 10)
            {
                if (ctrwaktu % 10 == 0)
                {
                    spawnzombie();
                }
            }
        }

        private void updatewaktu()
        {
            if (ctrwaktu / 60 < 10)
            {
                label3.Text = "0";
                label3.Text += (ctrwaktu / 60).ToString();
            }
            else
            {
                label3.Text = (ctrwaktu / 60).ToString();
            }
            if (ctrwaktu % 60 < 10)
            {
                label5.Text = "0";
                label5.Text += (ctrwaktu % 60).ToString();
            }
            else
            {
                label5.Text = (ctrwaktu % 60).ToString();
            }
        }
        private void hideorshow(bool status)
        {
            panel2.Visible = status;
            button4.Visible = status;
            button5.Visible = status;
            label3.Visible = status;
            label4.Visible = status;
            label5.Visible = status;
            label6.Visible = status;
            label7.Visible = status;
            label8.Visible = status;
            label9.Visible = status;
            label10.Visible = status;
            label11.Visible = status;
            label12.Visible = status;
            label11.Text = sekor.ToString();
            label12.Text = sun.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sun >= 50)
            {
                if (button4.BackColor == SystemColors.Control&&button5.BackColor==SystemColors.Control)
                {
                    button4.BackColor = SystemColors.ControlDark;
                    bt = new Button[3, 4];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            bool sudahada = false;
                            for (int k = 0; k < sunflower.Count; k++)
                            {
                                if (sunflower[k].Location == petak[i, j])
                                {
                                    sudahada = true;
                                }
                            }
                            for (int k = 0; k < peashooter.Count; k++)
                            {
                                if (peashooter[k].Location == petak[i, j])
                                {
                                    sudahada = true;
                                }
                            }
                            if (sudahada == false)
                            {
                                bt[i, j] = new Button();
                                bt[i, j].Top = panelx;
                                bt[i, j].Left = panely;
                                bt[i, j].Location = petak[i, j];
                                bt[i, j].Text = bt[i,j].Location.X+" "+ bt[i, j].Location.Y;
                                bt[i, j].Size = new Size(70, 70);
                                bt[i, j].FlatStyle = FlatStyle.Flat;
                                bt[i, j].BackColor = SystemColors.Control;
                                bt[i, j].Click += new EventHandler(tanamsunflower);
                                panel1.Controls.Add(bt[i,j]);
                            }
                        }
                    }
                }
                else if(button5.BackColor != SystemColors.Control)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (bt[j, i] != null)
                            {
                                bt[j, i].Visible = false;
                            }
                        }
                    }
                    button5.BackColor = SystemColors.Control;
                    button4.PerformClick();
                }
            }
        }
        public void tanampeashooter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ProgressBar temp = new ProgressBar();
            temp.Location = btn.Location;
            temp.Size = btn.Size;
            temp.Minimum = 0;
            temp.Maximum = 7;
            temp.Step = 1;
            temp.Tag = ctrwaktu;
            peashooter.Add(temp);
            panel1.Controls.Add(temp);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bt[j, i] != null)
                    {
                        bt[j, i].Visible = false;
                    }
                }
            }
            button5.BackColor = SystemColors.Control;
            sun -= 200;
            hideorshow(true);
        }
        public void tanamsunflower(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Button temp = new Button();
            temp.Location = btn.Location;
            temp.Size = btn.Size;
            temp.Enabled = false;
            temp.BackColor = Color.Brown;
            temp.Tag = 5;
            temp.Click += new EventHandler(kliksunflower);
            sunflower.Add(temp);
            panel1.Controls.Add(temp);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bt[j, i] != null)
                    {
                        bt[j, i].Visible = false;
                    }
                }
            }
            button4.BackColor = SystemColors.Control;
            sun -= 50;
            hideorshow(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sun >= 200)
            {

                if (button4.BackColor == SystemColors.Control && button5.BackColor == SystemColors.Control)
                {
                    button5.BackColor = SystemColors.ControlDark;
                    bt = new Button[3, 4];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            bool sudahada = false;
                            for (int k = 0; k < sunflower.Count; k++)
                            {
                                if (sunflower[k].Location == petak[i, j])
                                {
                                    sudahada = true;
                                }
                            }
                            for (int k = 0; k < peashooter.Count; k++)
                            {
                                if (peashooter[k].Location == petak[i, j])
                                {
                                    sudahada = true;
                                }
                            }
                            if (sudahada == false)
                            {
                                bt[i, j] = new Button();
                                bt[i, j].Top = panelx;
                                bt[i, j].Left = panely;
                                bt[i, j].Text = i.ToString() + j.ToString();
                                bt[i, j].Location = petak[i, j];
                                bt[i, j].Size = new Size(70, 70);
                                bt[i, j].FlatStyle = FlatStyle.Flat;
                                bt[i, j].BackColor = SystemColors.Control;
                                bt[i, j].Click += new EventHandler(tanampeashooter);
                                panel1.Controls.Add(bt[i, j]);
                            }
                        }
                    }
                }
                else if(button4.BackColor != SystemColors.Control)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (bt[j, i] != null)
                            {
                                bt[j, i].Visible = false;
                            }
                        }
                    }
                    button4.BackColor = SystemColors.Control;
                    button5.PerformClick();
                }
            }
        }
        private void updatesunflower()
        {
            foreach (Button x in sunflower)
            {
                if (Convert.ToInt32(x.Tag) > 0)
                {
                    x.Tag = Convert.ToInt32(x.Tag) - 1;
                }
                if (Convert.ToInt32(x.Tag) <= 0)
                {
                    x.Enabled = true;
                    x.BackColor = Color.Yellow;
                }
            }
        }
        private void updatepeashooter()
        {
            foreach (ProgressBar x in peashooter)
            {
                if (x.Value < x.Maximum)
                {
                    x.Value = x.Value + 1;
                }
                if (x.Value >= x.Maximum)
                {
                    foreach (Panel y in listzombie)
                    {
                        if (x.Location.Y == y.Location.Y)
                        {
                            Panel tempo = new Panel();
                            tempo.Location = x.Location;
                            tempo.Size = new Size(35, 35);
                            tempo.BackColor = Color.White;
                            listbullet.Add(tempo);
                            panel1.Controls.Add(tempo);
                            x.Value = x.Minimum;
                        }
                    }
                }
            }
        }
        public void kliksunflower(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            sun += 50;
            btn.BackColor = Color.Brown;
            btn.Tag = 5;
            hideorshow(true);
        }
        private void nyerang(ProgressBar x)
        {
            //scanning zombie
            

            //nyerang jika ada zombie
        }
        Random rnd = new Random();
        private void spawnzombie()
        {
            var temptempat = rnd.Next(4);
            Panel tempzombie = new Panel();
            tempzombie.BackColor = Color.Gray;
            tempzombie.Size = new Size(70, 70);
            tempzombie.Tag = 3;
            if (temptempat == 0)
            {
                tempzombie.Location = new Point(0, 13);
                tempzombie.Left = 635;
            }
            else if (temptempat == 1)
            {
                tempzombie.Location = new Point(0, 103);
                tempzombie.Left = 635;
            }
            else if (temptempat == 2)
            {
                tempzombie.Location = new Point(0, 193);
                tempzombie.Left = 635;
            }
            else
            {
                tempzombie.Location = new Point(0, 283);
                tempzombie.Left = 635;
            }
            listzombie.Add(tempzombie);
            panel1.Controls.Add(tempzombie);
        }
        private void zombiejalan()
        {
            foreach (Panel x in listzombie)
            {
                x.Location = new Point(x.Location.X - 10, x.Location.Y);
                foreach (ProgressBar y in peashooter.ToList())
                {
                    if (x.Bounds.IntersectsWith(y.Bounds))
                    {
                        y.Visible = false;
                        panel1.Controls.Remove(y);
                        peashooter.Remove(y);
                    }
                }
                foreach (Button y in sunflower.ToList())
                {
                    if (x.Bounds.IntersectsWith(y.Bounds))
                    {
                        y.Visible = false;
                        panel1.Controls.Remove(y);
                        sunflower.Remove(y);
                    }
                }
                if (x.Location.X <= 0)
                {
                    timer1.Stop();
                    hideorshow(false);
                    var tempbtn1 = button1;
                    var tempbtn2 = button2;
                    var tempbtn3 = button3;
                    panel1.Controls.Clear();
                    panel1.Controls.Add(tempbtn1);
                    panel1.Controls.Add(tempbtn2);
                    panel1.Controls.Add(tempbtn3);
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;

                }
            }
        }
        private void bulletjalan()
        {
            foreach (Panel x in listbullet.ToList())
            {
                x.Location = new Point(x.Location.X + 20, x.Location.Y);
                foreach (Panel y in listzombie.ToList())
                {
                    if (x.Bounds.IntersectsWith(y.Bounds))
                    {
                        y.Tag = Convert.ToInt32(y.Tag) - 1;
                        if (Convert.ToInt32(y.Tag) <= 0)
                        {
                            y.Visible = false;
                            panel1.Controls.Remove(y);
                            listzombie.Remove(y);
                            sekor += 100;
                        }
                        x.Visible = false;
                        panel1.Controls.Remove(x);
                        listbullet.Remove(x);
                        break;
                    }
                }
            }
        }

        private void label2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ctrwaktu != 0)
            {
                sun += 200;
                hideorshow(true);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && label13.Visible == false) {
                timer1.Stop();
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label13.Visible = true;
            }
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && label13.Visible == false) {
                timer1.Stop();
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label13.Visible = true;
            }
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && label13.Visible == false) {
                timer1.Stop();
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label13.Visible = true;
            }
        }

        private void label13_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label13.Visible = false;
                timer1.Start();
            }
        }
    }
}
