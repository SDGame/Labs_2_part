using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_5_19
{
    public partial class Form1 : Form
    {
        Point lastPoint;        //Класс координат для создания элементов
        Point lastPoint2;       //Класс координат для внесения изменений
        private bool flag = false;      //Флаг первого элемента
        public Form1()
        {
            InitializeComponent();
        }
        private void Start()        //Общий метод динамического создания элементов
        {
            if (radioButton1.Checked)       //Если выбран textBox
            {   
                TextBox a = new TextBox();      //Создание элемента TextBox для динамической генерации
                a.Text = "TextBox";             //Пишем тект, который будет внутри
                a.Parent = panel2;              //Назначаем родительский элемент
                lastPoint = Point(102);         //Вызываем метод для получения координат
                a.Location = new Point(lastPoint.X, lastPoint.Y);       //Создаём элемент по координатам, которые получили
            }
            else if (radioButton2.Checked)      //Если выбран Button
            {
                Button b = new Button();
                b.Text = "Button";
                b.Parent = panel2;
                lastPoint = Point(102);
                b.Location = new Point(lastPoint.X, lastPoint.Y);
            }
            else if (radioButton3.Checked)      //Если выбран Label
            {
                Label lb = new Label();
                lb.Text = "Label";
                lb.Parent = panel2;
                lastPoint = Point(102);
                lb.Location = new Point(lastPoint.X, lastPoint.Y);
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)      //При нажатии на Panel
        {
            if(e.Button == MouseButtons.Left)
            {
                Start();
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)       //При нажатии на Form
        {
            if (e.Button == MouseButtons.Left)
            {
                Start();
            }
        }
        private Point Point(int Tab)        //Функция переноса строки с сдвига по вертикали
        {
            if (lastPoint2.X >= 700)        //Ушли за форму?
            {
                flag = true;                //Поднять флаг
                lastPoint2.X = 0;           //Обнулить вертикаль
                lastPoint2.Y += 22;         //Перенести строку
            }
            else if (!flag)                 //Опущен флаг? Первый символ
            {
                lastPoint2.X = 0;           //Обнулить вертикаль
                flag = true;                //Поднять флаг 
            }
            else                            //Если не первый элемент, то 
            {
                lastPoint2.X += Tab;        //Назначаем новую позицию для горизонтали
            }
            return lastPoint2;              //Возвращаем все координаты
        }
    }
}
