using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubnetToBit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text=  "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            if (textBox2.Text.Length > 0)
            {
                string[] sm = textBox2.Text.Split('.');
                if(sm.Length==1)
                {
                    textBox3.Text=sm[0];
                }
                else
                {
                    int MaskSize = 0;
                    for (int i = 0; i < sm.Length; i++)
                    {
                        sm[i] = Convert.ToString(Int32.Parse(sm[i]), 2);
                    }
                    foreach (string s in sm)
                    {
                        foreach (char c in s)
                        {
                            if (c == '1')
                            {
                                MaskSize++;
                            }
                        }
                    }
                    this.textBox3.Text = Convert.ToString(MaskSize);
                }

            }
            if (textBox1.Text.Length > 0)
            {
                string[] ip=textBox1.Text.Split('.');
                string[] ipBinary = new string[ip.Length];
                for (int i = 0; i < ip.Length; i++)
                {
                    int octet = Int32.Parse(ip[i]);
                    for(int j = 0; j < 8; j++)
                    {
                        ipBinary[i] = Convert.ToString(octet % 2)+ipBinary[i];
                        octet /= 2;
                    }
                }

                this.textBox7.Text = ipBinary[0]+'.'+ipBinary[1]+'.'+ipBinary[2]+'.'+ipBinary[3];
                if (Int32.Parse(ip[0]) < 128) textBox8.Text = "A-8";
                if (Int32.Parse(ip[0]) >= 128 && Int32.Parse(ip[0]) < 192) textBox8.Text = "B-16";
                if (Int32.Parse(ip[0]) >= 192 && Int32.Parse(ip[0]) < 224) textBox8.Text = "C-24";
                if (Int32.Parse(ip[0]) >= 224 && Int32.Parse(ip[0]) < 240) textBox8.Text = "D-32";
                if (Int32.Parse(ip[0]) >= 240 && Int32.Parse(ip[0]) < 248) textBox8.Text = "E";
                if (Int32.Parse(ip[0]) >= 248 && Int32.Parse(ip[0]) < 252) textBox8.Text = "F";
                if (Int32.Parse(ip[0]) >= 252 && Int32.Parse(ip[0]) < 254) textBox8.Text = "G";
                if (Int32.Parse(ip[0]) >= 254 && Int32.Parse(ip[0]) < 255) textBox8.Text = "H";
            }
            if ((textBox8.Text.Length >0)&&(textBox3.Text.Length>0))
            {

            }
        }
    }
}
