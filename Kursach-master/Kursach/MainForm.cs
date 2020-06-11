using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    ChildForm childForm = new ChildForm();
                    childForm.MdiParent = this;
                    childForm.open_file(openFileDialog1.FileName);

                    childForm.Text = openFileDialog1.FileName;

                    childForm.Show();
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Соболева Елизавета Петровна");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Length == 0)
            {
                MessageBox.Show("Не создано ни одного изображения!", "Ошибка");
                return;
            }

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                ChildForm childForm = (ChildForm)this.ActiveMdiChild;
                if (childForm.save_file(saveFileDialog1.FileName))
                {
                    childForm.Text = saveFileDialog1.FileName;
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void каскадноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void вертикальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void горизонтальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void создатьНовыеИзображенияИзВыделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = (ChildForm)this.ActiveMdiChild;
            if (childForm != null)
            {
                if (childForm.get_fragment())
                {
                    ChildForm childForm2 = new ChildForm();
                    childForm2.MdiParent = this;
                    childForm2.Text = "Новое изображение";

                    childForm2.Show();

                    childForm2.image_fragment = childForm.image_fragment;
                    childForm2.paste_image();
                }
            }
            else
            {
                MessageBox.Show("Не открыто ни одного изображения!", "Ошибка");
            }
        }
    }
}
