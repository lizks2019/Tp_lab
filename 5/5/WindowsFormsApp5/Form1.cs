using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WindowsFormsApp5{
    public partial class Form1 : Form{
        public Form1()
        {
            InitializeComponent();

            g = Graphics.FromImage(image);
            g.Clear(Color.White);
            paint_zone.Image = image;
        }

        void Save()
        {
            paint_zone.Image = image;
            save = false;
        }

        string File_name = "";
        static Bitmap image = new Bitmap(574, 428);

        bool save = true;

        string message_save = "Хотите сохранить изменения в файле?";
        string caption = "Сообщение";
        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
        DialogResult result;

        Graphics g;
        static int width = 1;
        static Color color = Color.Black;
        Pen pen = new Pen(color, width);
        SolidBrush brush = new SolidBrush(color);

        bool paint = false;
        Point Last, First;

        int P;

        ImageFormat[] Format = { ImageFormat.Bmp, ImageFormat.Png, ImageFormat.Jpeg };

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = 0;
            if (!save)
            {
                result = MessageBox.Show(message_save, caption, buttons);
                if (result == DialogResult.Yes)
                    сохранитьКакToolStripMenuItem_Click(null, null);
            }
            if (result != DialogResult.Cancel && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File_name = openFileDialog1.FileName;
                image = new Bitmap(File_name);
                paint_zone.Image = image;
                paint_zone.Width = image.Width;
                paint_zone.Height = image.Height;
                g = Graphics.FromImage(image);
                save = true;
            }
        }
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File_name = saveFileDialog1.FileName;
                image.Save(File_name, Format[saveFileDialog1.FilterIndex - 1]);
                save = true;
            }
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            result = 0;
            if (!save)
            {
                result = MessageBox.Show(message_save, caption, buttons);
                if (result == DialogResult.Yes)
                    сохранитьКакToolStripMenuItem_Click(null, null);
            }
            e.Cancel = result == DialogResult.Cancel ? true : false;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            Last = e.Location;

            if (straight_button.Checked)
                g.DrawLine(pen, Last, First);

            if (Last.X < First.X)
            {
                P = Last.X;
                Last.X = First.X;
                First.X = P;
            }
            if (Last.Y < First.Y)
            {
                P = Last.Y;
                Last.Y = First.Y;
                First.Y = P;
            }

            if (rectangle_button.Checked)
            {
                if (casting.Checked)
                    g.FillRectangle(brush, First.X, First.Y, Last.X - First.X, Last.Y - First.Y);
                else
                    g.DrawRectangle(pen, First.X, First.Y, Last.X - First.X, Last.Y - First.Y);
            }
            if (ellipse_button.Checked)
            {
                if (casting.Checked)
                    g.FillEllipse(brush, First.X, First.Y, Last.X - First.X, Last.Y - First.Y);
                else
                    g.DrawEllipse(pen, First.X, First.Y, Last.X - First.X, Last.Y - First.Y);
            }
            Save();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tolshina.Text == "") tolshina.Text = "1";
            paint = true;
            First = e.Location;
            if (line_button.Checked)
            {
                g.DrawLine(pen, First.X - (int)Math.Floor(width / 2.0), First.Y, First.X + (int)Math.Ceiling(width / 2.0), First.Y);
                Save();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                Last = e.Location;
                if (line_button.Checked)
                {
                    g.DrawLine(pen, Last, First);
                    First = Last;
                }
                if (eraser_button.Checked)
                { 
                    g.DrawLine(new Pen(Color.White, width), Last, First);
                    First = Last;
                }

                
                Save();
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
                pen.Color = color;
                brush.Color = color;
                label4.BackColor = colorDialog1.Color;
            }
        }

        private void tolshina_ValueChanged(object sender, EventArgs e)
        {
            width = (int)tolshina.Value;
            pen.Width = width;
        }

        private void tolshina_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                width = (int)tolshina.Value;
                pen.Width = width;
            }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void ластикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eraser_button.Checked = true;
        }

        private void прямаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            line_button.Checked = true;
        }

        private void криваяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            straight_button.Checked = true;
        }

        private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangle_button.Checked = true;
        }

        private void эллипсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ellipse_button.Checked = true;
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Save();
        }

       
    }
}
