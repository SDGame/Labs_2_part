using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_2_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listBox1.Items.Add("10100");               //20
            this.listBox1.Items.Add("11001000");            //200
            this.listBox1.Items.Add("100111000100000");     //20000
            this.listBox1.Items.Add("110000110101000000");  //200000
            this.listBox1.Items.Add("101010101010101010101"); //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем номер выделенной строки
            int index = listBox1.SelectedIndex;
            // Считываем строку в переменную str
            string str = "";
            try
            {
                str = (string)listBox1.Items[index];
            }
            catch
            {
                MessageBox.Show("Выберите элемент из списка.");
                return;
            }
            // Узнаем количество символов в строке
            int len = str.Length;
            // Считаем, что количество пробелов равно 0
            int count = 0;
            int i = 0;
            while (i < len)
            {
                // Если нашли пробел, то увеличиваем 
                // счетчик пробелов на 1
                if (str[i] == '0')
                    count++;
                i++;
            }
            label1.Text = "Количество 0 = " + count.ToString();
            count = 0;
            i = 0;
            while (i < len)
            {
                // Если нашли пробел, то увеличиваем 
                // счетчик пробелов на 1
                if (str[i] == '1')
                    count++;
                i++;
            }
            label1.Text += "\r\nКоличество 1 = " + count.ToString();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
