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

namespace Lab2_8_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = 8;
            int[,] a = new int[n, n]; // создается двухмерный массив
            a.Initialize();
            dataGridView1.RowCount = n; // кол-во строк
            dataGridView1.ColumnCount = n; // кол-во столбцов
            Random rand = new Random();
            // создание все возможных ходов
            Point[] points = new Point[8] { new Point(-2, -1), new Point(-1, -2), new Point(2, -1), new Point(-1, 2), new Point(2, 1), new Point(1, 2), new Point(-2, 1), new Point(1, -2) };
            List<Point> q = new List<Point>(); // создание листа (подобие массива)
            Point w = new Point(rand.Next(n), rand.Next(n)); // заполнение двумя рандомными цифрами до 8
            a[w.X, w.Y] = 1; 
            for (int i = 2; i < 65; i++)
            {
                q.Clear();
                for (int j = 0; j < 8; j++) 
                {   // условия для того, чтобы конь не выходил за матрицу и чтобы не становился где уже был
                    if (((w.X + points[j].X) < n) && ((w.X + points[j].X) > -1) && ((w.Y + points[j].Y) < n) && ((w.Y + points[j].Y) > -1) && (a[w.X + points[j].X, w.Y + points[j].Y] == 0))
                    {
                        q.Add(new Point(w.X + points[j].X, w.Y + points[j].Y)); // перемещает точку в новое место
                    }
                }
                if (q.Count > 0)
                {
                    w = q[rand.Next(q.Count)]; 
                    a[w.X, w.Y] = i; // записывает в новую точку число
                }
                else
                {
                    label1.Text = "Кол-во ходов:" + Convert.ToString(i-1);
                    break;
                }
            }
            Output(a);
        }

        private void Output(int[,] a)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    dataGridView1.Rows[i].Cells[j].Value = a[i, j]; // выводит всё
        }
    }
}
