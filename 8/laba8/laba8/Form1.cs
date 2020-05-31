using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba8
{
    public partial class Контрастность : Form
    {
        Bitmap bitmap1;
        Bitmap bitmap2;
        BitmapData bitData1;
        BitmapData bitData2;
        float kR = 0.299f;
        float kG = 0.587f;
        float kB = 0.114f;
        private String path = "";
        private bool changed = false;
        public Контрастность()
        {
            InitializeComponent();
            bitmap1 = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            bitmap2 = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            pictureBox1.Image = bitmap1;
            pictureBox2.Image = bitmap2;
        }

        private void SaveCheck()
        {
            if (!changed)
                return;
            if (MessageBox.Show("Сохранить изменения в файле?", "Сохранение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFile();
            }

        }

        private void SaveFile()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            path = saveFileDialog1.FileName;
            try
            {
                pictureBox2.Image.Save(path);
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            saveFileDialog1.FileName = "";
            MessageBox.Show("Файл сохранен");
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCheck();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                path = openFileDialog1.FileName;
                bitmap1.Dispose();
                Image img = Image.FromFile(path);
                bitmap1 = new Bitmap(img);
                bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height);
                pictureBox1.Image = bitmap1;
                pictureBox2.Image = bitmap2;
            }
            catch
            {
                MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            changed = false;
            buttonContrast.Enabled = true;
            MessageBox.Show("Файл открыт");
            openFileDialog1.FileName = "";
        }

        private void ButtonContrast_Click(object sender, EventArgs e)
        {
            bitData1 = bitmap1.LockBits(new Rectangle(0, 0, bitmap1.Width, bitmap1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            bitData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            IntPtr ptr1 = bitData1.Scan0;
            IntPtr ptr2 = bitData2.Scan0;

            byte[] byte1 = new byte[bitmap1.Width * bitmap1.Height * 3];
            byte[] byte2 = new byte[bitmap1.Width * bitmap1.Height * 3];

            Marshal.Copy(ptr1, byte1, 0, byte1.Length);

            int totalBrightness = 0;
            for (int i = 0; i < byte1.Length; i += 3)
            {
                totalBrightness += calcBrightness(byte1[i], byte1[i + 1], byte1[i + 2], kR, kG, kB);
            }

            float averageBrightness = totalBrightness / (byte1.Length / 3);

            for (int i = 0; i < byte1.Length; i += 3)
            {
                int brightness = calcBrightness(byte1[i], byte1[i + 1], byte1[i + 2], kR, kG, kB);
                int newBrightness = (int)(brightness + (float)numericUpDown1.Value * (brightness - averageBrightness));
                byte2[i] = calcColor(newBrightness, byte1[i + 1], byte1[i + 2], kR, kG, kB);
                byte2[i + 1] = calcColor(newBrightness, byte1[i], byte1[i + 2], kG, kR, kB);
                byte2[i + 2] = calcColor(newBrightness, byte1[i], byte1[i + 1], kB, kR, kG);
            }

            Marshal.Copy(byte2, 0, ptr2, byte2.Length);

            bitmap1.UnlockBits(bitData1);
            bitmap2.UnlockBits(bitData2);

            pictureBox2.Image = bitmap2;

            int calcBrightness(int r, int g, int b, float factorR = 0.299f, float factorG = 0.587f, float factorB = 0.114f)
            {
                return (int)(factorR * r + factorG * g + factorB * b);
            }

            byte calcColor(int brightness, byte otherColor, byte anotherColor, float factorColor, float factorOtherColor, float factorAnotherColor)
            {
                return (byte)Math.Min(255, Math.Max(0, (brightness - factorOtherColor * otherColor - factorAnotherColor * anotherColor) / factorColor));
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOld.Checked)
            {
                kR = 0.299f;
                kG = 0.587f;
                kB = 0.114f;
            }
            else if (radioButtonNew.Checked)
            {
                kR = 0.2126f;
                kG = 0.7152f;
                kB = 0.0722f;
            }
        }

        private void Контрастность_Load(object sender, EventArgs e)
        {

        }
    }
}
