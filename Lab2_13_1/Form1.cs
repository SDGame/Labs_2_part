using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_13_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int Min(int x, int y)
        {
            if (x > y) return y;
            else return x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] num = textBox2.Text.Split(' ');
                var numbers = new List<int>();
                foreach (string numStr in num)
                {
                    numbers.Add(int.Parse(numStr));
                }

                textBox1.Text = Convert.ToString(Min(Min(Min(numbers[0], numbers[1]), numbers[2]), numbers[3]));
            }
            catch
            {
                MessageBox.Show("Введите 4 числа для работы программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                try
                {
                    string[] num = textBox2.Text.Split(' ');
                    var numbers = new List<int>();
                    foreach (string numStr in num)
                    {
                        numbers.Add(int.Parse(numStr));
                    }

                    textBox1.Text = Convert.ToString(Min(Min(Min(numbers[0], numbers[1]), numbers[2]), numbers[3]));
                }
                catch
                {
                    MessageBox.Show("Введите 4 числа для работы программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
