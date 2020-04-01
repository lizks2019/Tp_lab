using System;
using System.IO;
using System.Windows.Forms;

namespace Laba3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string path = "";
        private string form_name = "Новый.rtf";

        private DialogResult ansDio()
        {
            return MessageBox.Show("Вы хотите сохранить изменения в файле\n" + form_name + "?", "Уведомление", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        private void split()
        {
            string[] words = path.Split(new char[] { '\\' });
            form_name = words[words.Length - 1];
        }

        private void save(object sender, EventArgs e)
        {
            RichTextBox rich_text_box = new RichTextBox();
            if (path != "")
            {
                rich_text_box.LoadFile(path);
            }
            if ((path == "" && text_box.Text != "") || (path != "" && text_box.Rtf != rich_text_box.Rtf))
            {
                DialogResult res = ansDio();
                if (res == DialogResult.Cancel)
                {
                    rich_text_box.Dispose();
                    return;
                }
                if (res == DialogResult.Yes)
                    сохранитьToolStripMenuItem1_Click(sender, e);
            }
            rich_text_box.Dispose();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save(sender, e);
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RichTextBox rich_text_box = new RichTextBox();
            if (path != "")
            {
                rich_text_box.LoadFile(path);
            }
            if ((path == "" && text_box.Text != "") || (path != "" && text_box.Rtf != rich_text_box.Rtf))
            {
                DialogResult res = ansDio();
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                if (res == DialogResult.Yes)
                    if (path == "" || !File.Exists(path))
                    {
                        SaveFileDialog1.FileName = form_name;
                        if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            path = SaveFileDialog1.FileName;
                            text_box.SaveFile(path);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        text_box.SaveFile(path);
                    }
            }
            rich_text_box.Dispose();
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save(sender, e);
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            path = openFileDialog1.FileName;
            split();
            Text = form_name;
            text_box.LoadFile(path);
            text_box.SelectionStart = text_box.Rtf.Length;
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = text_box.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                text_box.SelectionColor = colorDialog1.Color;
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = text_box.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                text_box.SelectionFont = fontDialog1.Font;
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = text_box.SelectionBackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                text_box.SelectionBackColor = colorDialog1.Color;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Соболева Елизавета Петровна");
        }

        private void сохранитькакToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog1.FileName = form_name;

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = SaveFileDialog1.FileName;
                text_box.SaveFile(path);
                split();
                Text = form_name;
            }
        }

        private void txt_TextChanged_1(object sender, EventArgs e)
        {
            RichTextBox rich_text_box = new RichTextBox();
            if (path != "")
            {
                rich_text_box.LoadFile(path);
            }
            if ((path == "" && text_box.Text != "") || (path != "" && text_box.Rtf != rich_text_box.Rtf))
            {
                Text = "*" + form_name;
            }
            else
            {
                Text = form_name;
            }
            rich_text_box.Dispose();
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (path == "" || !File.Exists(path))
            {
                сохранитькакToolStripMenuItem1_Click(sender, e);
            }
            else
            {
                text_box.SaveFile(path);
            }
            txt_TextChanged_1(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            text_box.Copy();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            text_box.Paste();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            text_box.Cut();
        }
    }
}
