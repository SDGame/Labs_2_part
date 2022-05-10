using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_5_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Button b = new Button();        //Динамическое создание кнопки
            b.Parent = panel2;              //Родитель для этой кнопки (где она расположена)
            b.Location = new Point(0, 0);   //Расположение кнопки
            b.Text = "Button";              //Текст в кнопке
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            TextBox b = new TextBox();
            b.Parent = panel3;
            b.Location = new Point(0, 0);
            b.Text = "TextBox";
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Label b = new Label();
            b.Parent = panel1;
            b.Location = new Point(0, 0);
            b.Text = "Label";
        }
    }
}
