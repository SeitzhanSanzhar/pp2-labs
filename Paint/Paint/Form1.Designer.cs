namespace Paint
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 433);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Rec";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChangeState);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Pen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ChangeState);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Line";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ChangeState);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(135, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 23);
            this.button4.TabIndex = 4;
            this.button4.Tag = "";
            this.button4.Text = "Circl";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ChangeState);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(53, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Fill";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ChangeState);
            // 
            // colorDialog1
            // 
            this.colorDialog1.HelpRequest += new System.EventHandler(this.ChangeColor);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Col";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ChangeColor);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(258, 1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(43, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.SaveImage);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(307, 1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(43, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "Open";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OpenFile);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(356, 1);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(43, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "New";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ClearPictureBox);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 485);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

