using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  
        String File_name;
        
        Bitmap image1, image2, image;
        bool save = true, grey = true;

        string message_save = "Хотите сохранить изменения в файле?";
        string caption = "Сообщение"; 
        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
        DialogResult result;

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
                save = true;
                File_name = openFileDialog1.FileName;

                first_var.Visible = false;
                first_var.Checked = false;
                second_var.Visible = false;
                second_var.Checked = false;
                start_button.Visible = true;
                progressBar1.Visible = true;
                image = new Bitmap(File_name, true);
                image1 = new Bitmap(File_name, true);
                image2 = new Bitmap(File_name, true);
                pictureBox1.Image = image;

                progressBar1.Value = 0;
                grey = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!grey)
                {
                    progressBar1.Maximum = (image.Width - 1) * (image.Height - 1);

                    int x, y;

                    for (x = 0; x < image.Width; x++)
                    {
                        for (y = 0; y < image.Height; y++)
                        {
                            Color pixelColor = image.GetPixel(x, y);

                            byte Y1, Y2;
                            Y1 = (byte)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                            Y2 = (byte)(0.2126 * pixelColor.R + 0.7152 * pixelColor.G + 0.0722 * pixelColor.B);

                            Color newColor1 = Color.FromArgb(255, Y1, Y1, Y1);
                            Color newColor2 = Color.FromArgb(255, Y2, Y2, Y2);

                            image1.SetPixel(x, y, newColor1);
                            image2.SetPixel(x, y, newColor2);

                            progressBar1.PerformStep();
                        }
                    }
                    save = false;

                    first_var.Visible = true; 
                    second_var.Visible = true;

                    first_var.Checked = true;
                    grey = true;
                }
            }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File_name = saveFileDialog1.FileName;
                    image.Save(File_name, Format[saveFileDialog1.FilterIndex - 1]);
                    save = true;
                }
            }
            catch( Exception )
            {
                MessageBox.Show("Не удалось сохранить файл! Файл отсутствует");
            }
        }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            result = 0;
            if (!save)
            {
                result = MessageBox.Show(message_save, caption, buttons);
                if (result == DialogResult.Yes)
                    сохранитьКакToolStripMenuItem_Click(null, null);
            }
            if (result == DialogResult.Cancel)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            switch (radio.Name)
            {
                case "first_var":
                    pictureBox1.Image = image1;
                    break;
                case "second_var":
                    pictureBox1.Image = image2;
                    break;
            }
        }
    }
}
