using System;
using System.Windows.Forms;

namespace Lab2_2_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Начальное значение X
            this.textBox1.Text = "14,26";
            // Начальное значение Y
            this.textBox2.Text = "-1,22";
            // Начальное значение Z
            this.textBox3.Text = "3,5*10^-2";
        }
        public void pow(string StrVar, char[] CharVar, out double outVar)
        {
            string subzOsn = "";
            string subzPoc = "";
            string other = "";
            outVar = 0;
            bool flag = false;
            for (int i = 0; i < StrVar.Length; i++)
            {
                if (CharVar[i] == '^')
                {
                    flag = true;
                    for (int j = i; j >= 0; j--)
                    {
                        if (CharVar[j] == '*')
                        {
                            subzOsn = StrVar.Substring(j + 1, StrVar.Length - 1 - i);
                            other = StrVar.Substring(0, j);
                            break;
                        }
                    }
                    subzPoc = StrVar.Substring(i + 1, StrVar.Length - 1 - i);
                }
            }
            if (flag != false)
            {
                outVar = double.Parse(other) * Math.Pow(double.Parse(subzOsn), double.Parse(subzPoc));
            }
            else
            {
                outVar = double.Parse(StrVar);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                this.textBox5.Text = "\t\tЛаб. раб. №2, Сычёв Данил ИБб-212";
                // Считывание значения X
                string sx = textBox1.Text;
                char[] cx = sx.ToCharArray();
                double x = 0;
                try
                {
                    pow(sx, cx, out x);
                }
                catch { err = "X"; }
                pow(sx, cx, out x);
                // Вывод значения X в окно
                this.textBox5.Text += "\r\nX = " + x.ToString();
                // Считывание значения Y
                string sy = textBox2.Text;
                char[] cy = sy.ToCharArray();
                double y = 0;
                try
                {
                    pow(sy, cy, out y);
                }
                catch { err = "Y"; }
                pow(sy, cy, out y);
                // Вывод значения Y в окно
                this.textBox5.Text += "\r\nY = " + y.ToString();
                // Считывание значения Z
                string sz = textBox3.Text;
                char[] cz = sz.ToCharArray();
                double z = 0;
                try
                {
                    pow(sz, cz, out z);
                }
                catch { err = "Z"; }
                pow(sz, cz, out z);
                // Вывод значения Z в окно
                this.textBox5.Text += "\r\nZ = " + z.ToString();
                //double dx = double.Parse(x);
                //double dy = double.Parse(y);
                //double dz = double.Parse(z);
                double res = ((2 * Math.Cos(x - (Math.PI / 6))) / (0.5 + Math.Pow(Math.Sin(y), 2))) * (1 + (Math.Pow(z, 2)) / (3 - Math.Pow(z, 2) / 5));
                res = Math.Round(res, 6, MidpointRounding.AwayFromZero);
                this.textBox5.Text += "\r\n\r\nt = " + res;
                this.textBox5.Text += "\r\n\r\nПравильное значение по заданию: 0,564849";
                this.textBox5.Text += "\r\n\r\nРеально правильное значение: 0,564846";
            }
            catch
            {
                MessageBox.Show($"Ошибка вычисления. Проверьте правильность заполнения поля {err}.");
            }
        }
    }
}
