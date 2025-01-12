using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            awalan();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            foreach (Button x in buttons)
            {
                x.Enabled = false;
                x.Visible = false;
            }
        }
        Button[,] buttons;
        Color[] warnabutton = { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Black };
        List <Button> jawaban;
        List <Sekor> hs;
        int counter;
        int skorr;
        private void awalan()
        {
            
            skorr = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            buttons = new Button[4,10];
            Random rnd = new Random();
            jawaban = new List<Button>();
            hs = new List<Sekor>();

            counter = 1;
            label3.Text = skorr.ToString();
            for (int i = 0; i < 8; i++)
            {
                Button btn = new Button();
                btn.Parent = groupBox2;
                /*btn.Tag = warna;*/
                btn.Enabled = false;
                btn.BackColor = Color.White;
                btn.Left = 6 + 41 * i;
                btn.Top = 17;
                btn.Width = 35;
                btn.Height = 35;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Tag = "";
                /*btn.Click += new EventHandler(this.button1_Click);*/
                this.groupBox2.Controls.Add(btn);
                jawaban.Add(btn);
            }
            for (int k = 0; k < 10; k++)
            {
                /*// Looping untuk 3 kolom
                for (int j = 0; j < 3; j++)
                {*/
                // 3 button dempet
                for (int i = 0; i < 4; i++)
                    {
                        var bom = rnd.Next(10);
                        int warna;
                        if (bom == 0)
                        {
                            warna = 4;
                        }
                        else
                        {
                            warna = rnd.Next(4);
                        }
                        Button btn = new Button();
                        //i-x k-y
                        btn.Tag = i + "" + k;
                        btn.BackColor = warnabutton[warna];
                        btn.Left = 12 + 36 * i;
                        btn.Top = 41 + 36 * k;
                        btn.Width = 35;
                        btn.Height = 35;
                        btn.Click += new EventHandler(this.diklik);
                        this.Controls.Add(btn);
                        buttons[i, k] = btn;
                        btn.Enabled = true;
                        btn.FlatStyle = FlatStyle.Flat;
                }
                /*}*/
            }
        }
        private void diklik(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.White)
            {

            }
            else
            {
                if (counter <= 8)
                {
                    int ctr = 0;
                    foreach (Button x in jawaban)
                    {
                        if (x.BackColor != Color.White)
                        {
                            ctr++;
                        }
                    }
                    bool sudahada=false;
                    foreach (Button x in jawaban)
                    {
                        if (btn.Tag.Equals(x.Tag))
                        {
                            sudahada = true;
                        }
                    }
                    if (sudahada == false)
                    {
                        bool pertama = false;
                        if (ctr == 0)
                        {
                            pertama = true;
                        }
                        else
                        {

                        }
                        if (pertama == true)
                        {
                            btn.Text = Convert.ToString(counter);
                            jawaban[ctr].Tag = btn.Tag;
                            jawaban[ctr].BackColor = btn.BackColor;
                            if (btn.BackColor == Color.Black)
                            {
                                btn.ForeColor = Color.White; 
                            }
                            counter++;
                        }
                        else
                        {
                            string temp=jawaban[ctr-1].Tag.ToString();
                            int asalx=temp[0]-'0';
                            int asaly=temp[1]-'0';

                            temp = btn.Tag.ToString();
                            int tujuanx = temp[0] - '0';
                            int tujuany = temp[1] - '0';
                            if ((tujuanx == asalx && tujuany == asaly + 1) || (tujuanx == asalx && tujuany == asaly - 1)|| (tujuanx == asalx + 1 && tujuany == asaly)|| (tujuanx == asalx - 1 && tujuany == asaly))
                            {
                                btn.Text = Convert.ToString(counter);
                                jawaban[ctr].Tag = btn.Tag;
                                jawaban[ctr].BackColor = btn.BackColor;
                                if (btn.BackColor == Color.Black)
                                {
                                    btn.ForeColor = Color.White;
                                }
                                counter++;
                            }
                            else
                            {
                                MessageBox.Show("tidak bersebelahan");
                            }
                        }
                    }
                    else
                    {
                        if (btn.Tag.Equals(jawaban[ctr - 1].Tag))
                        {
                            counter--;
                            foreach(Button x in buttons)
                            {
                                if (x.Tag.Equals(jawaban[ctr - 1].Tag))
                                {
                                    x.Text = "";
                                }
                            }
                            jawaban[ctr - 1].Tag = "";
                            jawaban[ctr - 1].BackColor = Color.White;
                        }
                        /*MessageBox.Show("button sudah dipencet");*/
                    }
                }
                else
                {
                    if (counter == 9)
                    {
                        int ctr = 0;
                        foreach (Button x in jawaban)
                        {
                            if (x.BackColor != Color.White)
                            {
                                ctr++;
                            }
                        }
                        if (btn.Tag.Equals(jawaban[ctr - 1].Tag))
                        {
                            counter--;
                            foreach (Button x in buttons)
                            {
                                if (x.Tag.Equals(jawaban[ctr - 1].Tag))
                                {
                                    x.Text = "";
                                }
                            }
                            jawaban[ctr - 1].Tag = "";
                            jawaban[ctr - 1].BackColor = Color.White;
                        }
                        else
                        {
                            MessageBox.Show("kotak jawaban full");
                        }
                    }
                    else
                    {
                        MessageBox.Show("kotak jawaban full");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> warnajawaban;
            warnajawaban = new List<int>();
            foreach (Button x in jawaban)
            {
                if (x.BackColor == Color.Red)
                {
                    warnajawaban.Add(1);
                }
                else if(x.BackColor == Color.Yellow)
                {
                    warnajawaban.Add(2);
                }
                else if(x.BackColor == Color.Green)
                {
                    warnajawaban.Add(3);
                }
                else if(x.BackColor == Color.Blue)
                {
                    warnajawaban.Add(4);
                }
            }
            bool valid = true;
            for (int i = 0; i < warnajawaban.Count/2; i++)
            {
                if(warnajawaban[i]!=warnajawaban[warnajawaban.Count - 1 - i])
                {
                    valid = false;
                }
            }
            if (valid == true)
            {

                int ctr = 0;
                foreach (Button x in jawaban)
                {
                    if (x.BackColor != Color.White)
                    {
                        ctr++;
                    }
                }
                int tempskor = counter-1;
                /*MessageBox.Show(tempskor.ToString());*/
                if (ctr > 1)
                {
                    for (int i = 0; i < ctr-1; i++)
                    {
                        if (jawaban[i].BackColor == jawaban[i + 1].BackColor)
                        {

                        }
                        else
                        {
                            /*MessageBox.Show("test");*/
                            tempskor = tempskor + 5;
                        }
                    }
                }
                for (int i = 0; i < ctr+1; i++)
                {
                    foreach (Button x in buttons)
                    {
                        if (x.Tag.Equals(jawaban[i].Tag))
                        {
                            x.Text = "";
                            if (x.BackColor != Color.Black)
                            {
                                x.BackColor = Color.White;
                            }
                            jawaban[i].Tag = "";
                            jawaban[i].BackColor = Color.White;
                            if (x.BackColor == Color.Black)
                            {
                                string temp = x.Tag.ToString();
                                int asalx = temp[0] - '0';
                                int asaly = temp[1] - '0';
                                if (asalx + 1 < 4 && buttons[asalx + 1, asaly].BackColor != Color.White)
                                {
                                    buttons[asalx + 1, asaly].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asalx - 1 >= 0 && buttons[asalx - 1, asaly].BackColor != Color.White)
                                {
                                    buttons[asalx-1,asaly].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asaly + 1 < 10 && buttons[asalx, asaly + 1].BackColor != Color.White)
                                {
                                    buttons[asalx,asaly+1].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asaly - 1 >= 0 && buttons[asalx, asaly - 1].BackColor != Color.White)
                                {
                                    buttons[asalx,asaly-1].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asalx + 1 < 4 && asaly + 1 < 10 && buttons[asalx + 1, asaly + 1].BackColor != Color.White)
                                {
                                    buttons[asalx + 1, asaly + 1].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asalx - 1 >= 0 && asaly - 1 >= 0 && buttons[asalx - 1, asaly - 1].BackColor != Color.White)
                                {
                                    buttons[asalx - 1, asaly - 1].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asalx + 1 < 4 && asaly - 1 >= 0 && buttons[asalx + 1, asaly - 1].BackColor != Color.White)
                                {
                                    buttons[asalx + 1, asaly - 1].BackColor = Color.White;
                                    tempskor++;
                                }
                                if (asalx - 1 >= 0 && asaly + 1 < 10 && buttons[asalx - 1, asaly + 1].BackColor != Color.White)
                                {
                                    buttons[asalx - 1, asaly + 1].BackColor = Color.White;
                                    tempskor++;
                                }
                            }
                            if (x.BackColor == Color.Black)
                            {
                                x.BackColor = Color.White;
                                /*tempskor--;*/
                            }
                            
                            //counter==1;
                        }
                    }
                }
                skorr = skorr + tempskor;
                label3.Text = skorr.ToString();
                counter = 1;

                for (int i = 0; i < 4; i++)
                {
                    List<Button> temp = new List<Button>();
                    for (int j = 0; j < 10; j++)
                    {
                        Button temp2 = new Button();
                        if (buttons[i, j].BackColor == Color.White)
                        {
                            temp2.BackColor = buttons[i, j].BackColor;
                            temp.Add(temp2);
                        }
                    }
                    int tempcounter;
                    tempcounter = temp.Count;
                    for (int j = 0; j < 10; j++)
                    {
                        Button temp2 = new Button();
                        if (buttons[i, j].BackColor != Color.White)
                        {
                            temp2.BackColor = buttons[i, j].BackColor;
                            temp.Add(temp2);
                        }
                    }
                    /*for (int j = 0; j < 10; j++)
                    {
                        MessageBox.Show(temp[j].BackColor.ToString());
                    }*/
                    for (int j = 0; j < 10; j++)
                    {
                        buttons[i, j].BackColor = temp[j].BackColor;
                        buttons[i, j].ForeColor = Color.Black;
                    }
                }

                bool menang = true;
                foreach (Button x in buttons)
                {
                    if (x.BackColor != Color.White)
                    {
                        menang = false;
                    }
                }

                if (menang == true)
                {
                    /*randomulang();
                    foreach (Button x in buttons)
                    {
                        x.Enabled = false;
                    }*/
                    /*button1.Enabled = false;*/
                    /*button2.Enabled = false;
                    button3.Enabled = false;*/
                    //buttons semua putih
                    hs.Add(new Sekor(textBox1.Text, skorr));
                    listBox1.Items.Clear();
                    foreach (var x in hs)
                    {
                        listBox1.Items.Add(x);
                    }
                    button1.PerformClick();
                }

               /* MessageBox.Show("Palindrom");*/
            }
            else
            {
                MessageBox.Show("bukan palindrom");
                for (int i = 0; i < 8; i++)
                {
                    jawaban[i].Tag = "";
                    jawaban[i].BackColor = Color.White;
                }
                foreach (Button x in buttons)
                {
                    x.Text = "";
                }
                counter = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tombol restart
            randomulang();
            
        }

        private void randomulang()
        {
            Random rnd = new Random();
            foreach (Button x in buttons)
            {
                var bom = rnd.Next(10);
                int warna;
                if (bom == 0)
                {
                    warna = 4;
                }
                else
                {
                    warna = rnd.Next(4);
                }
                x.BackColor = warnabutton[warna];
            }
            foreach(Button x in jawaban)
            {
                x.BackColor = Color.White;
                x.Tag = "";
            }
            skorr = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Start"))
            {
                button1.Text = "Exit";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                textBox1.Enabled = false;
                skorr = 0;
                label3.Text = skorr.ToString();
                foreach (Button x in buttons)
                {
                    x.Enabled = true;
                    x.Visible = true;
                }
                randomulang();
            }
            else
            {
                button1.Text = "Start";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = true;
                textBox1.Text = "";
                skorr = 0;
                label3.Text = skorr.ToString();
                foreach (Button x in buttons)
                {
                    x.Enabled = false;
                    x.Visible = false;
                }
                randomulang();
            }
        }
    }
}
