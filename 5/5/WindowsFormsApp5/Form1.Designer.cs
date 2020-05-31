namespace WindowsFormsApp5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.line_button = new System.Windows.Forms.RadioButton();
            this.rectangle_button = new System.Windows.Forms.RadioButton();
            this.ellipse_button = new System.Windows.Forms.RadioButton();
            this.casting = new System.Windows.Forms.CheckBox();
            this.eraser_button = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tolshina = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прямаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.криваяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фигурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прямоугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эллипсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ластикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paint_zone = new System.Windows.Forms.PictureBox();
            this.show_panel = new System.Windows.Forms.Panel();
            this.straight_button = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tolshina)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paint_zone)).BeginInit();
            this.show_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "(*.bmp)|*.bmp|(*.png)|*.png|(*.jpeg)|*.jpeg|(*.jpg)|*.jpg";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "(*.bmp)|*.bmp|(*.png)|*.png|(*.jpeg)|*.jpeg";
            // 
            // line_button
            // 
            this.line_button.AutoSize = true;
            this.line_button.Location = new System.Drawing.Point(636, 278);
            this.line_button.Name = "line_button";
            this.line_button.Size = new System.Drawing.Size(65, 17);
            this.line_button.TabIndex = 3;
            this.line_button.TabStop = true;
            this.line_button.Text = "ЛИНИЯ";
            this.line_button.UseVisualStyleBackColor = true;
            this.line_button.Visible = false;
            // 
            // rectangle_button
            // 
            this.rectangle_button.AutoSize = true;
            this.rectangle_button.Location = new System.Drawing.Point(636, 324);
            this.rectangle_button.Name = "rectangle_button";
            this.rectangle_button.Size = new System.Drawing.Size(125, 17);
            this.rectangle_button.TabIndex = 4;
            this.rectangle_button.TabStop = true;
            this.rectangle_button.Text = "ПРЯМОУГОЛЬНИК";
            this.rectangle_button.UseVisualStyleBackColor = true;
            this.rectangle_button.Visible = false;
            // 
            // ellipse_button
            // 
            this.ellipse_button.AutoSize = true;
            this.ellipse_button.Location = new System.Drawing.Point(637, 368);
            this.ellipse_button.Name = "ellipse_button";
            this.ellipse_button.Size = new System.Drawing.Size(71, 17);
            this.ellipse_button.TabIndex = 5;
            this.ellipse_button.TabStop = true;
            this.ellipse_button.Text = "ЭЛЛИПС";
            this.ellipse_button.UseVisualStyleBackColor = true;
            this.ellipse_button.Visible = false;
            // 
            // casting
            // 
            this.casting.AutoSize = true;
            this.casting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.casting.Location = new System.Drawing.Point(613, 118);
            this.casting.Name = "casting";
            this.casting.Size = new System.Drawing.Size(170, 29);
            this.casting.TabIndex = 6;
            this.casting.Text = "Заливка фигур";
            this.casting.UseVisualStyleBackColor = true;
            // 
            // eraser_button
            // 
            this.eraser_button.AutoSize = true;
            this.eraser_button.Location = new System.Drawing.Point(636, 301);
            this.eraser_button.Name = "eraser_button";
            this.eraser_button.Size = new System.Drawing.Size(69, 17);
            this.eraser_button.TabIndex = 7;
            this.eraser_button.TabStop = true;
            this.eraser_button.Text = "ЛАСТИК";
            this.eraser_button.UseVisualStyleBackColor = true;
            this.eraser_button.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(608, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Толщина линии:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(608, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Цвет заливки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(658, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(752, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // tolshina
            // 
            this.tolshina.Location = new System.Drawing.Point(626, 92);
            this.tolshina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tolshina.Name = "tolshina";
            this.tolshina.Size = new System.Drawing.Size(75, 20);
            this.tolshina.TabIndex = 11;
            this.tolshina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tolshina.ValueChanged += new System.EventHandler(this.tolshina_ValueChanged);
            this.tolshina.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tolshina_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.линииToolStripMenuItem,
            this.фигурыToolStripMenuItem,
            this.ластикToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить экран";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // линииToolStripMenuItem
            // 
            this.линииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прямаяToolStripMenuItem,
            this.криваяToolStripMenuItem});
            this.линииToolStripMenuItem.Name = "линииToolStripMenuItem";
            this.линииToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.линииToolStripMenuItem.Text = "Линии";
            // 
            // прямаяToolStripMenuItem
            // 
            this.прямаяToolStripMenuItem.Name = "прямаяToolStripMenuItem";
            this.прямаяToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.прямаяToolStripMenuItem.Text = "Кривая";
            this.прямаяToolStripMenuItem.Click += new System.EventHandler(this.прямаяToolStripMenuItem_Click);
            // 
            // криваяToolStripMenuItem
            // 
            this.криваяToolStripMenuItem.Name = "криваяToolStripMenuItem";
            this.криваяToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.криваяToolStripMenuItem.Text = "Прямая";
            this.криваяToolStripMenuItem.Click += new System.EventHandler(this.криваяToolStripMenuItem_Click);
            // 
            // фигурыToolStripMenuItem
            // 
            this.фигурыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прямоугольникToolStripMenuItem,
            this.эллипсToolStripMenuItem});
            this.фигурыToolStripMenuItem.Name = "фигурыToolStripMenuItem";
            this.фигурыToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.фигурыToolStripMenuItem.Text = "Фигуры";
            // 
            // прямоугольникToolStripMenuItem
            // 
            this.прямоугольникToolStripMenuItem.Name = "прямоугольникToolStripMenuItem";
            this.прямоугольникToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.прямоугольникToolStripMenuItem.Text = "Прямоугольник";
            this.прямоугольникToolStripMenuItem.Click += new System.EventHandler(this.прямоугольникToolStripMenuItem_Click);
            // 
            // эллипсToolStripMenuItem
            // 
            this.эллипсToolStripMenuItem.Name = "эллипсToolStripMenuItem";
            this.эллипсToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.эллипсToolStripMenuItem.Text = "Эллипс";
            this.эллипсToolStripMenuItem.Click += new System.EventHandler(this.эллипсToolStripMenuItem_Click);
            // 
            // ластикToolStripMenuItem
            // 
            this.ластикToolStripMenuItem.Name = "ластикToolStripMenuItem";
            this.ластикToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ластикToolStripMenuItem.Text = "Ластик";
            this.ластикToolStripMenuItem.Click += new System.EventHandler(this.ластикToolStripMenuItem_Click);
            // 
            // paint_zone
            // 
            this.paint_zone.Location = new System.Drawing.Point(0, 33);
            this.paint_zone.Name = "paint_zone";
            this.paint_zone.Size = new System.Drawing.Size(782, 523);
            this.paint_zone.TabIndex = 14;
            this.paint_zone.TabStop = false;
            this.paint_zone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.paint_zone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.paint_zone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // show_panel
            // 
            this.show_panel.AutoScroll = true;
            this.show_panel.Controls.Add(this.paint_zone);
            this.show_panel.Location = new System.Drawing.Point(9, 26);
            this.show_panel.Margin = new System.Windows.Forms.Padding(2);
            this.show_panel.Name = "show_panel";
            this.show_panel.Size = new System.Drawing.Size(599, 372);
            this.show_panel.TabIndex = 14;
            // 
            // straight_button
            // 
            this.straight_button.AutoSize = true;
            this.straight_button.Location = new System.Drawing.Point(636, 346);
            this.straight_button.Margin = new System.Windows.Forms.Padding(2);
            this.straight_button.Name = "straight_button";
            this.straight_button.Size = new System.Drawing.Size(72, 17);
            this.straight_button.TabIndex = 16;
            this.straight_button.TabStop = true;
            this.straight_button.Text = "ПРЯМАЯ";
            this.straight_button.UseVisualStyleBackColor = true;
            this.straight_button.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.straight_button);
            this.Controls.Add(this.show_panel);
            this.Controls.Add(this.tolshina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eraser_button);
            this.Controls.Add(this.casting);
            this.Controls.Add(this.ellipse_button);
            this.Controls.Add(this.rectangle_button);
            this.Controls.Add(this.line_button);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.tolshina)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paint_zone)).EndInit();
            this.show_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RadioButton line_button;
        private System.Windows.Forms.RadioButton rectangle_button;
        private System.Windows.Forms.RadioButton ellipse_button;
        private System.Windows.Forms.CheckBox casting;
        private System.Windows.Forms.RadioButton eraser_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown tolshina;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox paint_zone;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.Panel show_panel;
        private System.Windows.Forms.RadioButton straight_button;
        private System.Windows.Forms.ToolStripMenuItem линииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прямаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem криваяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фигурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прямоугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эллипсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ластикToolStripMenuItem;
    }
}

