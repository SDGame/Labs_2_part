using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_12_1
{
    public partial class Form1 : Form
    {
        // Глобальные переменные
        private Point PreviousPoint, point;
        private Bitmap bmp;
        private Pen MyPen;
        private Graphics g;
        private bool Press;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Подготавливаем перо для рисования
            MyPen = new Pen(Color.Black, 4);
            MyPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            comboBox1.Items.Clear();
            comboBox1.Items.Add(1); comboBox1.Items.Add(2); comboBox1.Items.Add(3); comboBox1.Items.Add(4); comboBox1.Items.Add(5); comboBox1.Items.Add(6); comboBox1.Items.Add(7); comboBox1.Items.Add(8); comboBox1.Items.Add(9); comboBox1.Items.Add(10);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Записываем в предыдущую точку текущие координаты
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // Проверяем нажата ли левая кнопка мыши
                if (e.Button == MouseButtons.Left)
                {
                    Press = true;
                    // Запоминаем текущее положение курсора мыши
                    point.X = e.X;
                    point.Y = e.Y;
                    // Соеденяем линией предыдущую точку с текущей
                    g.DrawLine(MyPen, PreviousPoint, point);
                    // Текущее положение курсора ‐ в PreviousPoint
                    PreviousPoint.X = point.X;
                    PreviousPoint.Y = point.Y;
                    // Принудительно вызываем перерисовку
                    pictureBox1.Invalidate();
                }
            }
            catch
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (Press) result = MessageBox.Show("Вы уверены что хотите выйти без сохранения?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { }
            else if (result == DialogResult.No) { e.Cancel = true; Save(); }
        }

        private void Save()
        {
            // Описываем и порождаем объект savedialog
            SaveFileDialog savedialog = new SaveFileDialog();
            // Задаем свойства для savedialog
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "JPEG File(*.jpg)|*.jpg|" +
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "PNG File(*.png)|*.png";
            // Показываем диалог и проверяем задано ли имя файла
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;
                // Убираем из имени расширение файла
                string strFilExtn = fileName.Remove(0,
                 fileName.Length - 3);
                // Сохраняем файл в нужном формате
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Open()
        {
            // Описываем объект класса OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Задаем расширения файлов 
            dialog.Filter = "Image files (*.BMP, *.JPG, " +
                "*.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";
            // Вызываем диалог и проверяем выбран ли файл
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                panel2.Visible = true;
                // Загружаем изображение из выбранного файла
                Image image = Image.FromFile(dialog.FileName);
                int width = image.Width;
                int height = image.Height;
                //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                // Создаем и загружаем изображение в формате bmp
                bmp = new Bitmap(image, width, height);
                // Записываем изображение в pictureBox1
                pictureBox1.Image = bmp;
                // Подготавливаем объект Graphics для рисования
                g = Graphics.FromImage(pictureBox1.Image);
            }
            Press = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyPen.Width = Convert.ToInt32(comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 192, 192);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 224, 192);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 255, 192);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(192, 255, 192);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(192, 255, 255);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(192, 192, 255);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 192, 255);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(224, 224, 224);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 128, 128);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 192, 128);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 255, 128);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.Black;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(128, 255, 128);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(128, 255, 255);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(128, 128, 255);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MyPen.Color = Color.FromArgb(255, 128, 255);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            MyPen.Color = button19.BackColor;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MyPen.Color = button20.BackColor;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            MyPen.Color = button20.BackColor;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            MyPen.Color = button22.BackColor;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MyPen.Color = button23.BackColor;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            MyPen.Color = button24.BackColor;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            MyPen.Color = button25.BackColor;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            MyPen.Color = button26.BackColor;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            MyPen.Color = button27.BackColor;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            MyPen.Color = button28.BackColor;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MyPen.Color = button29.BackColor;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            MyPen.Color = button30.BackColor;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            MyPen.Color = button31.BackColor;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            MyPen.Color = button32.BackColor;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            MyPen.Color = button33.BackColor;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            MyPen.Color = button34.BackColor;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            MyPen.Color = button35.BackColor;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            MyPen.Color = button36.BackColor;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            MyPen.Color = button37.BackColor;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            MyPen.Color = button38.BackColor;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            MyPen.Color = button39.BackColor;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            MyPen.Color = button40.BackColor;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            MyPen.Color = button41.BackColor;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            MyPen.Color = button42.BackColor;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            MyPen.Color = button44.BackColor;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            MyPen.Color = button50.BackColor;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            MyPen.Color = button45.BackColor;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            MyPen.Color = button46.BackColor;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            MyPen.Color = button47.BackColor;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            MyPen.Color = button48.BackColor;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            MyPen.Color = button49.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open();
        }
    }
}
