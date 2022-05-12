using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_2_2
{
    public partial class Form1 : Form
    {
        int[] Mas = new int[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Очищаем элемент управления
            listBox1.Items.Clear();
            // Инициализируем класс случайных чисел
            Random rand = new Random();
            // Генерируем и выводим 15 элементов
            Mass render = new Mass();
            for (int i = 0; i < 10; i++)
            {
                Mas[i] = rand.Next(-50, 50);
                if (Mas[i] > render.max)           //Поиск максимального значения и его индекса
                {
                    render.max = Mas[i];
                    render.i = i;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (i == render.i)
                {
                    listBox1.Items.Add("Mas[" + i.ToString() + "] = " + Mas[i].ToString() + " <==Макс");
                }
                else
                {
                    listBox1.Items.Add("Mas[" + i.ToString() + "] = " + Mas[i].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищаем элемент управления
            listBox2.Items.Clear();
            // Обрабатываем все элементы
            Mass mass = new Mass();
            int Zero = Mas[9];
            for (int i = 0; i < 10; i++)        //Поиск максимального значения и его индекса
            {
                if (Mas[i] > mass.max)
                {
                    mass.max = Mas[i];
                    mass.i = i;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Mas[mass.i] = Zero;
                Mas[9] = mass.max;
                if(i == 9)
                {
                    listBox2.Items.Add("Mas[" + Convert.ToString(i) + "] = " + Mas[i].ToString() + " <==Макс");
                }
                else if(i == mass.i)
                {
                    listBox2.Items.Add("Mas[" + Convert.ToString(i) + "] = " + Mas[i].ToString() + " <==[9]-индекс");
                }
                else
                {
                    listBox2.Items.Add("Mas[" + Convert.ToString(i) + "] = " + Mas[i].ToString());
                }
            }
        }
        struct Mass     //Структура для запоминания наибольшего числа и индекса этого числа
        {
            public int max;
            public int i;
        }
    }
}
