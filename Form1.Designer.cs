namespace ChemicalСompoundRecognition
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
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            button1 = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox4 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            scatterplotView1 = new Accord.Controls.ScatterplotView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(17, 15);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            label1.Size = new System.Drawing.Size(782, 37);
            label1.TabIndex = 1;
            label1.Text = "LOAD YOUR GRAPH BY DRAG&DROP IMAGE ON ANY PLACE";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(952, 63);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox1.Size = new System.Drawing.Size(413, 577);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label2.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(952, 21);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(413, 37);
            label2.TabIndex = 4;
            label2.Text = "COORDINATES";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(17, 63);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(927, 580);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(17, 653);
            button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(351, 118);
            button1.TabIndex = 7;
            button1.Text = "PARSE DATA FROM GRAPH";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label4.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(377, 653);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(225, 74);
            label4.TabIndex = 8;
            label4.Text = "Enter width step";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(377, 733);
            textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(224, 31);
            textBox3.TabIndex = 9;
            textBox3.Text = "1";
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(813, 693);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(117, 31);
            textBox2.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(813, 733);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(117, 31);
            textBox4.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(644, 699);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(148, 25);
            label3.TabIndex = 12;
            label3.Text = "Нижняя граница";
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(642, 736);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(150, 25);
            label5.TabIndex = 13;
            label5.Text = "Верхняя граница";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(685, 653);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(216, 25);
            label6.TabIndex = 14;
            label6.Text = "Диапазон спектограммы";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(1026, 690);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(138, 45);
            button2.TabIndex = 15;
            button2.Text = "KNN";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(1195, 685);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(147, 52);
            button3.TabIndex = 16;
            button3.Text = "Decision Tree";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(1367, 675);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(141, 72);
            button4.TabIndex = 17;
            button4.Text = "Supported Vectors";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // scatterplotView1
            // 
            scatterplotView1.LinesVisible = false;
            scatterplotView1.Location = new System.Drawing.Point(1382, 63);
            scatterplotView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            scatterplotView1.Name = "scatterplotView1";
            scatterplotView1.ScaleTight = false;
            scatterplotView1.Size = new System.Drawing.Size(563, 580);
            scatterplotView1.SymbolSize = 7F;
            scatterplotView1.TabIndex = 18;
            scatterplotView1.Load += scatterplotView1_Load;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1924, 787);
            Controls.Add(scatterplotView1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Accord.Controls.ScatterplotView scatterplotView1;
    }
}
