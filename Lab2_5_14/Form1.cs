using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab14_5_2
{
    public partial class Form1 : Form
    {
        Point lastPoint;        //Переменная координат точек для информации о нахождении мышки
        Point Point;            //Переменная координат точек для размешения объектов
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)   //Вывод координат мыши в правый верхний угл для справшки
        {
            lastPoint = new Point(e.X, e.Y);    
            this.textBox1.Text = Convert.ToString(lastPoint.X) + "; " + Convert.ToString(lastPoint.Y);
        }

        private void Start_Click(object sender, EventArgs e)    //При нажатии на кнопку обработки
        {
            Button b = new Button();        //Инициализация эклезмпляра класса для динамического создания кнопки
            TextBox tb = new TextBox();     //Инициализация эклезмпляра класса для динамического создания поля ввода
            Label lb = new Label();         //Инициализация эклезмпляра класса для динамического создания label
            try
            {
                Point.X = Convert.ToInt32(x_point.Text);    //Получение значения X из поля ввода
                Point.Y = Convert.ToInt32(y_point.Text);    //Получения значения Y из поля ввода
            }
            catch
            {
                MessageBox.Show("Неправильно введены координаты!", "Ошибка", MessageBoxButtons.OK); //Вывод сообщения ошибки при неправильных координатах
                return;
            }
            string type = type_text.Text;       //Получение типа генерируемого объекта
            if (type.Contains("K") || type.Contains("k") || type.Contains("К") || type.Contains("к"))   //При К делаем кнопку
            {
                b.Parent = this;
                b.Location = new Point(Point.X, Point.Y);
                b.Text = "button";
            }
            else if(type.Contains("П") || type.Contains("п"))       //При П делаем поле ввода
            {
                tb.Parent = this;
                tb.Location = new Point(Point.X, Point.Y);
                tb.Text = "TextBox";
            }
            else if (type.Contains("М") || type.Contains("м") || type.Contains("M") || type.Contains("m"))      //При М делаем метку
            {
                lb.Parent = this;
                lb.Location = new Point(Point.X, Point.Y);
                lb.Text = "Label";
            }
            else
            {
                MessageBox.Show("Нет ни одной подходящей буквы!", "Ошибка", MessageBoxButtons.OK);      //Выводим ошибку если введено что-то другое
            }
        }

        private void type_text_KeyDown(object sender, KeyEventArgs e)        //При нажатии Enter в поле ввода запускается метод Start_Click
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Start_Click(sender, e);
            }
        }

        private void x_point_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Start_Click(sender, e);
            }
        }       //При нажатии Enter в поле ввода запускается метод Start_Click

        private void y_point_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Start_Click(sender, e);
            }
        }       //При нажатии Enter в поле ввода запускается метод Start_Click
    }
}
