using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_6_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.Items.Add("Првиет12");
            this.listBox1.Items.Add("Да 120301230");
            this.listBox1.Items.Add("Поапв лап454");
            this.listBox1.Items.Add("апа545 4");
            this.listBox1.Items.Add("45 45папап");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;     // Получаем номер выделенной строки
            string str;     // Считываем строку в переменную str
            try
            {
                str = (string)listBox1.Items[index];
            }
            catch
            {
                MessageBox.Show("Выберите элемент из списка.");
                return;
            }
            int len = str.Length;       // Узнаем количество символов в строке
            label1.Text = "Вывод: ";
            for (int i = 0; i < len; i++)       //Цикл для заполнения label
            {
                if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9')
                {
                    label1.Text += str[i];
                }
            }
        }
    }
}
