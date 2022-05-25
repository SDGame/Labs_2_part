using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_6_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.Items.Add("Предложение для примера");
            this.listBox1.Items.Add("Второе предложение для примера");
            this.listBox1.Items.Add("Пример предложения не словосочетания");
            this.listBox1.Items.Add("Пример длинного предложени из которое я придумал");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем номер выделенной строки
            int index = listBox1.SelectedIndex;
            // Считываем строку в переменную str
            string str;
            try
            {
                str = (string)listBox1.Items[index];
            }
            catch
            {
                MessageBox.Show("Выберите элемент из списка.");
                return;
            }
            string s1 = str.Substring(0, str.IndexOf(' '));
            str = str.Remove(0, str.IndexOf(' ') + 1);
            string s2 = str.Substring(0, str.IndexOf(' '));
            str = str.Remove(0, str.IndexOf(' ') + 1);
            label1.Text = "Результат: " + s2 + " " + s1 + " " + str;
        }
    }
}
