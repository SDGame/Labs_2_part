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
            this.listBox1.Items.Add("Hello");               
            this.listBox1.Items.Add("Hello world");           
            this.listBox1.Items.Add("Hello my world");     
            this.listBox1.Items.Add("Hello my sweet wotld");  
            this.listBox1.Items.Add("How are you?"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем номер выделенной строки
            int index = listBox1.SelectedIndex;
            // Считываем строку в переменную str
            string stri = "";
            string str = "";
            try
            {
                stri = (string)listBox1.Items[index];
            }
            catch
            {
                MessageBox.Show("Выберите элемент из списка.");
                return;
            }
            // Узнаем количество символов в строке
            int len = stri.Length;
            // Считаем, что количество пробелов равно 0
            int count = 0;
            int i = 0;
            while (i < len)
            {
                // Если нашли пробел, то увеличиваем 
                // счетчик пробелов на 1
                if (stri[i] != ' ') { str += '+'; count++; }
                else str += ' ';
                i++;
            }
            label1.Text = str.ToString();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
