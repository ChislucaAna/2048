using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _2048thegame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        Label[,] lbl = new Label[100,100];
        int i, j,cnt;
        int l = 50;
        int p = 5;
        int poz1, poz2, val1, val2;
        int move = 0,pierdut=0;
        int[] posibility = { 2, 4, 2 };
        Random rnd;

        public void pretty_colors()
        {
            for (i = 1; i <= 4; i++)
            {
                for (j = 1; j <= 4; j++)
                {
                    if (lbl[i, j].Text != "")
                    {
                        if (Convert.ToInt32(lbl[i, j].Text) == 2)
                        {
                            lbl[i, j].BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (Convert.ToInt32(lbl[i, j].Text) == 4)
                            {
                                lbl[i, j].BackColor = Color.Orange;
                            }
                            else
                            {
                                if (Convert.ToInt32(lbl[i, j].Text) == 8)
                                {
                                    lbl[i, j].BackColor = Color.Red;
                                }
                                else
                                {
                                    if (Convert.ToInt32(lbl[i, j].Text) == 16)
                                    {
                                        lbl[i, j].BackColor = Color.Blue;
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(lbl[i, j].Text) == 32)
                                        {
                                            lbl[i, j].BackColor = Color.Cyan;
                                        }
                                        else
                                        {
                                            if (Convert.ToInt32(lbl[i, j].Text) == 64)
                                            {
                                                lbl[i, j].BackColor = Color.Crimson;
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(lbl[i, j].Text) == 128)
                                                {
                                                    lbl[i, j].BackColor = Color.Pink;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lbl[i, j].BackColor = Color.Gray;
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            move = 0;
            if (e.KeyValue == 'W' || e.KeyValue == 'w')
            {
                //spre directia "in sus"
                for(j=1; j<=4; j++)
                {
                    for(i=2; i<=4; i++)
                    { 
                         cnt = i;
                         while (cnt>=2 && lbl[cnt - 1, j].Text == "")
                         {
                                lbl[cnt-1, j].Text = lbl[cnt, j].Text;
                                lbl[cnt, j].Text = "";
                                cnt--;
                                move = 1;
                         }
                        if (cnt >= 2 && String.Equals(lbl[cnt - 1, j].Text,lbl[cnt,j].Text))
                        {
                            lbl[cnt - 1, j].Text = (Convert.ToInt32(lbl[cnt - 1, j].Text)*2).ToString();
                            move = 1;
                        }
                    }
                }

            }
            else
            {
                if (e.KeyValue == 'A' || e.KeyValue == 'a')
                {
                    //spre stanga
                    for(i=1; i<=4; i++)
                    {
                        for(j=2; j<=4; j++)
                        {
                            cnt = j;
                            while (cnt >= 2 && lbl[i, cnt-1].Text == "")
                            {
                                lbl[i,cnt-1].Text = lbl[i,cnt].Text;
                                lbl[i,cnt].Text = "";
                                cnt--;
                                move = 1;
                            }
                            if (cnt >= 2 && String.Equals(lbl[i, cnt - 1].Text, lbl[i, cnt].Text))
                            {
                                lbl[i, cnt - 1].Text = (Convert.ToInt32(lbl[i, cnt - 1].Text) * 2).ToString();
                                move = 1;
                            }
                        }
                    }
                }
                else
                {
                    if (e.KeyValue == 'S' || e.KeyValue == 's')
                    {
                        //in jos
                        for (j = 1; j <=4; j++)
                        {
                            for (i = 3; i >=1; i--)
                            {
                                cnt = i;
                                while (cnt <=3  && lbl[cnt + 1, j].Text == "")
                                {
                                    lbl[cnt + 1, j].Text = lbl[cnt, j].Text;
                                    lbl[cnt, j].Text = "";
                                    cnt++;
                                    move = 1;
                                }
                                if (cnt <= 3 && String.Equals(lbl[cnt + 1, j].Text, lbl[cnt, j].Text))
                                {
                                    lbl[cnt + 1, j].Text = (Convert.ToInt32(lbl[cnt + 1, j].Text) * 2).ToString();
                                    move = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (e.KeyValue == 'D' || e.KeyValue == 'd')
                        {
                            //in dreapta
                            for (i = 1; i <= 4; i++)
                            {
                                for (j = 4; j >=1; j--)
                                {
                                    cnt = j;
                                    while (cnt <=3 && lbl[i, cnt + 1].Text == "")
                                    {
                                        lbl[i, cnt + 1].Text = lbl[i, cnt].Text;
                                        lbl[i, cnt].Text = "";
                                        cnt++;
                                        move = 1;
                                    }
                                    if (cnt <= 3 && String.Equals(lbl[i, cnt + 1].Text, lbl[i, cnt].Text))
                                    {
                                        lbl[i, cnt + 1].Text = (Convert.ToInt32(lbl[i, cnt + 1].Text) * 2).ToString();
                                        move = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //verifica daca tabla este plina si in acest caz, inchide aplicatia
            pierdut = 1;
            for(i=1; i<=4; i++)
            {
                for (j = 1; j<=4; j++)
                {
                    if (lbl[i, j].Text =="")
                        pierdut = 0;
                    else
                        if (Convert.ToInt32(lbl[i, j].Text) == 2048)
                        pierdut = 3;

                }
            }
            if(pierdut==1)
            {
                MessageBox.Show("ai pierdut!");
                Application.Exit();
            }
            if(pierdut==3)
            {
                MessageBox.Show("ai castigat!");
                Application.Exit();
            }

            //generate new square
            if (move == 1)
            {
                val1 = posibility[rnd.Next(0, 2)];
                while (lbl[poz1, poz2].Text != "")
                {
                    rnd = new Random();
                    poz1 = rnd.Next(1, 5);
                    poz2 = rnd.Next(1, 5);
                    Thread.Sleep(20);
                    //MessageBox.Show("loop!");
                }
                lbl[poz1, poz2].Text = val1.ToString();
            }

            pretty_colors();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Location = new System.Drawing.Point(50, 50);
            panel.Width = 4 * l + 9 * p;
            panel.Height = 4 * l + 9 * p;
            panel.BackColor = Color.DarkGray;
            panel.Padding = new Padding(0, 0, 0, 0);
            Form1.ActiveForm.Controls.Add(panel);

            for (i=1; i<=4; i++)
            {
                for(j=1; j<=4; j++)
                {
                    lbl[i, j] = new Label();
                    lbl[i,j].Height = l;
                    lbl[i, j].Width = l;
                    lbl[i, j].BackColor = Color.Gray;
                    lbl[i, j].Margin = new Padding(p, p, p, p);
                    lbl[i, j].Font = new Font("Arial", 20, FontStyle.Regular);
                    lbl[i, j].Text = "";

                    panel.Controls.Add(lbl[i,j]);
                }
            }

            rnd = new Random();
            poz1 = rnd.Next(1, 5);
            val1 = posibility[rnd.Next(0, 2)];
            poz2 = rnd.Next(1, 5);
            lbl[poz1, poz2].Text = val1.ToString();

            while(lbl[poz1, poz2].Text != "")
            {
                rnd = new Random();
                poz1 = rnd.Next(1, 5);
                val1 = posibility[rnd.Next(0, 2)];
                poz2 = rnd.Next(1, 5);
            }
            val2 = posibility[rnd.Next(0, 2)];
            lbl[poz1, poz2].Text = val2.ToString();
            pretty_colors();

            //MessageBox.Show(poz1.ToString());
            //MessageBox.Show(poz2.ToString());
            //MessageBox.Show(val1.ToString());
            //MessageBox.Show(val2.ToString());
        }
    }
}
