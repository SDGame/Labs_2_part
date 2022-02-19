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


namespace Lab2_5_1
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
            b.Parent = this;
            b.Location = new Point(lastPoint.X, lastPoint.Y);
            b.Text = Convert.ToString(lastPoint.X) + "; " + Convert.ToString(lastPoint.Y);
        }
        private void TopText_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            TopText_MouseDown(sender, e);
            this.textBox1.Text = Convert.ToString(lastPoint.X) + "; " + Convert.ToString(lastPoint.Y);
        }
    }
}
