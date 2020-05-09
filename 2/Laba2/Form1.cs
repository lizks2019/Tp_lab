using System;
using System.IO;
using System.Windows.Forms;

namespace Laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string path="";
        private static string default_name = "Новый документ.txt";
        private string form_name = default_name;

        private DialogResult ansDio()
        {
            return MessageBox.Show("Вы хотите сохранить изменения в файле\n" + Text + "?", "Уведомление", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        private void split()
        {
            string[] words = path.Split(new char[] { '\\' });
            form_name = words[words.Length - 1];
        }

        private void save(object sender, EventArgs e)
        {
            if ((path == "" && text_box.Text != "") || (path != "" && text_box.Text != "" &&  text_box.Text != File.ReadAllText(path)))
            {
                DialogResult res = ansDio();
                if (res == DialogResult.Cancel)
                    return;
                if (res == DialogResult.Yes)
                    сохранитьToolStripMenuItem1_Click(sender, e);
            }
            Text = path;
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save(sender, e);
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((path == "" && text_box.Text != "") || (path != "" && text_box.Text != File.ReadAllText(path)))
            {
                DialogResult res = ansDio();
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                if (res == DialogResult.Yes)
                    if (path == "" || !File.Exists(path))
                    {
                        saveFileDialog1.FileName = form_name;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            path = saveFileDialog1.FileName;
                            File.WriteAllText(path, text_box.Text);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        File.WriteAllText(path, text_box.Text);
                    }
            }
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
            string fileText = File.ReadAllText(path);
            text_box.Text = fileText;
            text_box.SelectionStart = text_box.Text.Length;
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = text_box.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                text_box.ForeColor = colorDialog1.Color;
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = text_box.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                text_box.Font = fontDialog1.Font;
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = text_box.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                text_box.BackColor = colorDialog1.Color;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Соболева Елизавета Петровна");
        }

        private void сохранитькакToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text;
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {         
                path = saveFileDialog1.FileName;
                File.WriteAllText(path, text_box.Text);
                split();
                Text = form_name;
            }
        }

        private void txt_TextChanged_1(object sender, EventArgs e)
        {
            string s = "";
            if (path!="")
            {
                s = File.ReadAllText(path).ToString();
            }
            if ((path == "" && text_box.Text != "") || (path != "" && text_box.Text != s))
            {
                Text = default_name;
            }
            else
            {
                Text = form_name;
            }
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (path=="" || !File.Exists(path))
            {
                сохранитькакToolStripMenuItem1_Click(sender, e);
            }
            else
            {
                File.WriteAllText(path, text_box.Text);
            }
            //txt_TextChanged_1(sender, e);
        }

        private void new_file_Click(object sender, EventArgs e)
        {
            save(sender, e);
            text_box.Text = "";
            path = "";
            Text = "";
        }
    }
}
