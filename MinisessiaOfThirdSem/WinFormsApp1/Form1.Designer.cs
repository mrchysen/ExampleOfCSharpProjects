namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button3 = new Button();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            richTextBox1 = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 450);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(8, 92);
            label3.Name = "label3";
            label3.Size = new Size(184, 38);
            label3.TabIndex = 6;
            label3.Text = "Категория:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(8, 159);
            label2.Name = "label2";
            label2.Size = new Size(184, 38);
            label2.TabIndex = 5;
            label2.Text = "Курс доллара:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 200);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(184, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "70,0";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "ВЗ";
            // 
            // button3
            // 
            button3.Location = new Point(8, 66);
            button3.Name = "button3";
            button3.Size = new Size(184, 23);
            button3.TabIndex = 2;
            button3.Text = "Вывести по категории";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(0, 382);
            label1.Name = "label1";
            label1.Size = new Size(196, 64);
            label1.TabIndex = 1;
            label1.Text = "Information:";
            // 
            // button2
            // 
            button2.Location = new Point(8, 37);
            button2.Name = "button2";
            button2.Size = new Size(184, 23);
            button2.TabIndex = 0;
            button2.Text = "Сортировать по коду";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(8, 8);
            button1.Name = "button1";
            button1.Size = new Size(184, 23);
            button1.TabIndex = 0;
            button1.Text = "Загрузить из файла";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(richTextBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(200, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(600, 450);
            panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(600, 450);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "SFU_DataBase";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private RichTextBox richTextBox1;
        private OpenFileDialog openFileDialog1;
        private Button button3;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
    }
}