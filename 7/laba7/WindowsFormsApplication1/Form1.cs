using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte color(byte A, double k) {
            return (A * k > 255) ? (byte)255 : (byte)(A * k);
        }

        String File_name;
        Bitmap image, image1;
        bool save = true;

        string message_save = "Хотите сохранить изменения в файле?";
        string caption = "Сохранение";
        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
        DialogResult result;

        ImageFormat[] Format = { ImageFormat.Bmp, ImageFormat.Png, ImageFormat.Jpeg };

        private void button1_Click(object sender, EventArgs e) {
            try {
                progressBar1.Maximum = (image.Width - 1) * (image.Height - 1);
                progressBar1.Value = 0;
                
                double k = (double)numericUpDown1.Value;

                int x, y;

                for (x = 0; x < image.Width; x++) {
                    for (y = 0; y < image.Height; y++) {
                        Color pixelColor = image.GetPixel(x, y);

                        byte R = color(pixelColor.R, k);
                        byte G = color(pixelColor.G, k);
                        byte B = color(pixelColor.B, k);

                        Color newColor = Color.FromArgb(pixelColor.A, R, G, B);
                        image1.SetPixel(x, y, newColor);
                        progressBar1.PerformStep();
                    }
                }
                save = false;
                pictureBox1.Image = image1;
            }
            catch (ArgumentException) {MessageBox.Show("ошибка");}
        }

        private void openMenu_Click(object sender, EventArgs e) {
            result = 0;
            if (!save) {
                result = MessageBox.Show(message_save, caption, buttons);
                if (result == DialogResult.Yes)
                    saveasMenu_Click(null, null);
            }
            if (result != DialogResult.Cancel && openFileDialog.ShowDialog() == DialogResult.OK) {
                File_name = openFileDialog.FileName;
                image = new Bitmap(File_name, true);
                image1 = new Bitmap(File_name, true);
                pictureBox1.Image = image;
                progressBar1.Value = 0;
                save = true;

                progressBar1.Visible = true;
                start_button.Visible = true;
                label1.Visible = true;
                numericUpDown1.Visible = true;
            }
        }

        private void saveasMenu_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                File_name = saveFileDialog.FileName;
                image.Save(File_name, Format[saveFileDialog.FilterIndex - 1]);
                save = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            result = 0;
            if (!save) {
                result = MessageBox.Show(message_save, caption, buttons);
                if (result == DialogResult.Yes)
                    saveasMenu_Click(null, null);
            }
            if (result == DialogResult.Cancel) e.Cancel = true;
            else e.Cancel = false;
        }
    }
}
