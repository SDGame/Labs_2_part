using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab2_7_19
{
    public partial class Form1 : Form
    {
        int[] Mas1 = new int[20];
        int[] Mas2 = new int[20];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Очищаем элемент управления
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            // Инициализируем класс случайных чисел
            Random rand = new Random((int)DateTime.Now.Ticks);      //Генерация неповторяющихся чисел
            Thread.Sleep(10);                                       //Ожидание в 10 миллисекунд для корректной работы неповторяющийся генерации
            Random rand2 = new Random((int)DateTime.Now.Ticks);
            // Генерируем и выводим 5 элементов
            for (int i = 0; i < 20; i++)
            {
                Mas1[i] = rand.Next(0, 40);
                Mas2[i] = rand2.Next(0, 40);
            }
            BubbleSort(Mas1);       //Сортировка
            BubbleSort(Mas2);       //Сортировка
            for (int i = 0; i < 20; i++)
            {
                listBox1.Items.Add("Mas[" + i.ToString() + "] = " + Mas1[i].ToString());
                listBox2.Items.Add("Mas[" + i.ToString() + "] = " + Mas2[i].ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var Mas3 = Mas1.Concat(Mas2).ToArray();
            BubbleSort(Mas3);
            listBox3.Items.Clear();
            for (int i = 1; i < 40; i++)
            {
                if(Mas3[i-1] != Mas3[i])
                {
                    listBox3.Items.Add("Mas[" + Convert.ToString(i-1) + "] = " + Mas3[i].ToString());
                }
            }
        }
        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }
    }
}
