using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab14_5_2
{
    public partial class Form1 : Form
    {
        Point lastPoint;
        Point Point;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
            this.textBox1.Text = Convert.ToString(lastPoint.X) + "; " + Convert.ToString(lastPoint.Y);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            TextBox tb = new TextBox();
            Label lb = new Label();
            try
            {
                Point.X = Convert.ToInt32(x_point.Text);
                Point.Y = Convert.ToInt32(y_point.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введены координаты!", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            string type = type_text.Text;
            if (type.Contains("K") || type.Contains("k") || type.Contains("К") || type.Contains("к"))
            {
                b.Parent = this;
                b.Location = new Point(Point.X, Point.Y);
                b.Text = "button";
            }
            else if(type.Contains("П") || type.Contains("п"))
            {
                tb.Parent = this;
                tb.Location = new Point(Point.X, Point.Y);
                tb.Text = "TextBox";
            }
            else if (type.Contains("М") || type.Contains("м") || type.Contains("M") || type.Contains("m"))
            {
                lb.Parent = this;
                lb.Location = new Point(Point.X, Point.Y);
                lb.Text = "Label";
            }
            else
            {
                MessageBox.Show("Нет ни одной подходящей буквы!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void type_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Start_Click(sender, e);
            }
        }

        private void x_point_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Start_Click(sender, e);
            }
        }

        private void y_point_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Start_Click(sender, e);
            }
        }
    }
}
