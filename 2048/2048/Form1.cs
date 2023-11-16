using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public class square
        {
            public int i;
            public int j;
            public int dir;
            public int val;
            public Label lbl;

            public square(int pi, int pj, int value)
            {
                i = pi;
                j = pj;
                val = value;

                lbl = new Label();
                lbl.Height = l;
                lbl.Width = l;
                lbl.BackColor = Color.Gray;
                lbl.Margin = new Padding(p, p, p, p);
                lbl.Font = new Font("Arial", 40, FontStyle.Regular);
            }
        }

        Random rnd;
        square[] s = new square[20];
        static int l=50;
        static int p=5;
        int[] posibility = { 2, 4 };
        int poz1, val1, poz2, val2,i,j; //the first two random positions and values of squares

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='W' || e.KeyValue =='w')
            {
                //spre directia "in sus"
                for(i = 0; i < 16; i++)
                {
                    if (s[i].i < 3)
                    {
                        s[i].val = s[i + 4].val;
                        s[i].lbl.Text = s[i + 4].lbl.Text;
                    }
                    else
                    {
                        s[i].val = 0;
                        s[i].lbl.Text = null;
                    }
                }
            }
            else
            {
                if (e.KeyValue == 'A' || e.KeyValue == 'a')
                {
                    //spre stanga
                    for (i = 0; i < 16; i++)
                    {
                        if (s[i].j < 3)
                        {
                            s[i].val = s[i + 1].val;
                            s[i].lbl.Text = s[i + 1].lbl.Text;
                        }
                        else
                        {
                            s[i].val = 0;
                            s[i].lbl.Text = null;
                        }
                    }

                }
                else
                {
                    if (e.KeyValue == 'S' || e.KeyValue == 's')
                    {
                        //in jos
                        for (i = 15; i >= 0; i--)
                        {
                            if (s[i].i > 0)
                            {
                                s[i].val = s[i - 4].val;
                                s[i].lbl.Text = s[i - 4].lbl.Text;
                            }
                            else
                            {
                                s[i].val = 0;
                                s[i].lbl.Text = null;
                            }
                        }
                    }
                    else
                    {
                        if (e.KeyValue == 'D' || e.KeyValue == 'd')
                        {
                            //in dreapta
                            for (i = 15; i >=0; i--)
                            {
                                if (s[i].j > 0)
                                {
                                    s[i].val = s[i - 1].val;
                                    s[i].lbl.Text = s[i - 1].lbl.Text;
                                }
                                else
                                {
                                    s[i].val = 0;
                                    s[i].lbl.Text = null;
                                }
                            }
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //generate play area(4*4) and 2 randomvalues {2,4} to start
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Location = new System.Drawing.Point(50, 50);
            panel.Width = 4 * l + 9 * p;
            panel.Height = 4 * l + 9 * p;
            panel.BackColor = Color.DarkGray;
            panel.Padding = new Padding(0, 0, 0, 0);
            Form1.ActiveForm.Controls.Add(panel);

            rnd = new Random();
            poz1 = rnd.Next(0, 16);
            val1 = posibility[rnd.Next(0, 2)];
            poz2 = rnd.Next(0, 16);
            val2 = posibility[rnd.Next(0, 2)];

            for(i=0; i<16; i++)
            {
                square aux = new square(i / 4, i % 4, 0);
                s[i] = aux;
                panel.Controls.Add(s[i].lbl);
            }

            s[poz1].val = val1;
            s[poz2].val = val2;

            s[poz1].lbl.Text=val1.ToString();
            s[poz2].lbl.Text = val2.ToString();
        }
    }
}
