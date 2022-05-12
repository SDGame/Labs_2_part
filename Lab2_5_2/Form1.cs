using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_5_2
{
    public partial class Form1 : Form
    {
        Point lastPoint;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPoint.X = e.X;
                lastPoint.Y = e.Y;
            }
            Button b = new Button();
            TextBox a = new TextBox();
            if (lastPoint.X <= Width/2)
            {
                b.Parent = this;
                b.Location = new Point(lastPoint.X, lastPoint.Y);
                b.Text = Convert.ToString(lastPoint.X) + "; " + Convert.ToString(lastPoint.Y);
            }
            else
            {
                a.Parent = this;
                a.Location = new Point(lastPoint.X, lastPoint.Y);
                a.Text = "textBox " + Convert.ToString(lastPoint.X) + ";" + Convert.ToString(lastPoint.Y);
            }
        }
    }
}
