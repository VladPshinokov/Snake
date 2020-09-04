using System;
using System.IO;

namespace Snake
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
            this.components = new System.ComponentModel.Container();
            this.pbSnakeWindow = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.snakeImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSnakeWindow)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snakeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSnakeWindow
            // 
            this.pbSnakeWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSnakeWindow.Location = new System.Drawing.Point(12, 12);
            this.pbSnakeWindow.Name = "pbSnakeWindow";
            this.pbSnakeWindow.Size = new System.Drawing.Size(600, 600);
            this.pbSnakeWindow.TabIndex = 0;
            this.pbSnakeWindow.TabStop = false;
            this.pbSnakeWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSnakeWindow_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Счет:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblScore);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(623, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.Location = new System.Drawing.Point(77, 16);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(23, 25);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            this.lblScore.Click += new System.EventHandler(this.label2_Click);
            // 
            // snakeImage
            // 
            this.snakeImage.Image = global::Snake.Properties.Resources.snake;
            this.snakeImage.Location = new System.Drawing.Point(618, 397);
            this.snakeImage.Name = "snakeImage";
            this.snakeImage.Size = new System.Drawing.Size(177, 215);
            this.snakeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.snakeImage.TabIndex = 4;
            this.snakeImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.snakeImage);
            this.Controls.Add(this.pbSnakeWindow);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Snake v1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbSnakeWindow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snakeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSnakeWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox snakeImage;
    }
}

