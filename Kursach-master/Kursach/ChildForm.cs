using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Kursach
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }
        Bitmap show_bitmap;

        public Point start_mouse_position;
        public Point finish_mouse_position;

        public Bitmap image_fragment;

        int left_x = 0;
        int right_x = 0;

        int left_y = 0;
        int right_y = 0;

        public bool save_file(string file_name)   //Сохранение изображения в файл
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(file_name, System.Drawing.Imaging.ImageFormat.Bmp);
                return true;

            }
            else
            {
                MessageBox.Show("Для начала создайте изображение!", "Ошибка!");
                return false;
            }
        }
        public void open_file(string file_name)   
        {
            Bitmap temp_bitmap = new Bitmap(file_name);
            show_bitmap = new Bitmap(temp_bitmap.Width, temp_bitmap.Height);

            Graphics g = Graphics.FromImage(show_bitmap);
            g.DrawImage(temp_bitmap, new Point(0, 0));
            g.Dispose();
            temp_bitmap.Dispose();

            Size size_pic = new Size(show_bitmap.Width, show_bitmap.Height);
            pictureBox1.Image = new Bitmap(show_bitmap, size_pic);
            this.Size = size_pic;
            this.Update();

            this.Text = Path.GetFileNameWithoutExtension(file_name);

            save_file(file_name);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                finish_mouse_position = e.Location;
                right_x = e.Location.X;
                right_y = e.Location.Y;
                pictureBox1.Invalidate();
            }
            else
            {
                start_mouse_position = finish_mouse_position = e.Location;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            left_x = 0;
            right_x = 0;
            left_y = 0;
            right_y = 0;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(left_x, left_y, right_x - left_x, right_y - left_y)); //рисуем рамку

            if (start_mouse_position != finish_mouse_position)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, get_rectangle(start_mouse_position, finish_mouse_position)); //рисуем рамку

                left_x = Math.Min(start_mouse_position.X, finish_mouse_position.X);
                right_x = Math.Max(start_mouse_position.X, finish_mouse_position.X);
                left_y = Math.Min(start_mouse_position.Y, finish_mouse_position.Y);
                right_y = Math.Max(start_mouse_position.Y, finish_mouse_position.Y);
            }
        }
        Rectangle get_rectangle(Point p1, Point p2)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
        public bool get_fragment()
        {
            if (pictureBox1.Image != null)
            {
                Color pixel;
                show_bitmap = new Bitmap(pictureBox1.Image);
                image_fragment = new Bitmap(pictureBox1.Image);

                if ((left_x < show_bitmap.Width) & (right_x < show_bitmap.Width) & (left_y < show_bitmap.Height) & (right_y < show_bitmap.Height))
                {
                    if ((left_x != right_x) & (left_y != right_y))
                    {
                        int start_position_x = -1;
                        int start_position_y = -1;
                        for (int x = left_x; x < right_x; x++)
                        {
                            start_position_x = start_position_x + 1;
                            for (int y = left_y; y < right_y; y++)
                            {
                                start_position_y = start_position_y + 1;
                                pixel = show_bitmap.GetPixel(x, y);
                                image_fragment.SetPixel(start_position_x, start_position_y, pixel);
                            }
                            start_position_y = -1;
                        }
                        Bitmap temp_bitmap = image_fragment.Clone(new Rectangle(0, 0, right_x - left_x, right_y - left_y), show_bitmap.PixelFormat);
                        Size size_pic = new Size(right_x - left_x, right_y - left_y);
                        image_fragment = new Bitmap(temp_bitmap, size_pic);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Фрагмент не выделен!", "Ошибка!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Фрагмент вышел за границы изображения!", "Ошибка!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void paste_image()
        {
            Size size_pic = new Size(image_fragment.Width, image_fragment.Height);
            pictureBox1.Image = new Bitmap( image_fragment, size_pic );
            this.Size = size_pic;
            this.Update();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
