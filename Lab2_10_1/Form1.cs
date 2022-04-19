using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_10_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen MyPen0 = new Pen(Brushes.Black, 2);
            MyPen0.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Pen MyPen1 = new Pen(Brushes.Blue, 3);
            MyPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            Pen MyPen2 = new Pen(Brushes.Gray, 4);
            MyPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawLine(MyPen0, 10, 20, 870, 20);
            g.DrawEllipse(MyPen1, 40, 40, 100, 100);
            g.DrawArc(MyPen2, 150, 40, 100, 100, 0, -180);
            g.FillRectangle(Brushes.Black, 280, 40, 100, 100);
            g.FillEllipse(Brushes.BlueViolet, 400, 40, 100, 100);
        }
    }
}
