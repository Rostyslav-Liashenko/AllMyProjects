
namespace ExcelForSmila
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBeginRecord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxBeginCopy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxEndCopy = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Виконати програму";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(281, 64);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Знайдені записи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введіть вулиці";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 23);
            this.textBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Номер з якого запису починати:";
            // 
            // textBoxBeginRecord
            // 
            this.textBoxBeginRecord.Location = new System.Drawing.Point(204, 151);
            this.textBoxBeginRecord.Name = "textBoxBeginRecord";
            this.textBoxBeginRecord.Size = new System.Drawing.Size(68, 23);
            this.textBoxBeginRecord.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Колонка для умови:";
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Location = new System.Drawing.Point(204, 180);
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.Size = new System.Drawing.Size(68, 23);
            this.textBoxCondition.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Колонки для копіювання:";
            // 
            // textBoxBeginCopy
            // 
            this.textBoxBeginCopy.Location = new System.Drawing.Point(204, 211);
            this.textBoxBeginCopy.Name = "textBoxBeginCopy";
            this.textBoxBeginCopy.Size = new System.Drawing.Size(68, 23);
            this.textBoxBeginCopy.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = ":";
            // 
            // textBoxEndCopy
            // 
            this.textBoxEndCopy.Location = new System.Drawing.Point(295, 210);
            this.textBoxEndCopy.Name = "textBoxEndCopy";
            this.textBoxEndCopy.Size = new System.Drawing.Size(56, 23);
            this.textBoxEndCopy.TabIndex = 14;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(363, 189);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 45);
            this.button4.TabIndex = 15;
            this.button4.Text = "Про програму";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 259);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxEndCopy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBeginCopy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCondition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxBeginRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.MaximumSize = new System.Drawing.Size(477, 298);
            this.MinimumSize = new System.Drawing.Size(477, 298);
            this.Name = "Form1";
            this.Text = "Обробка excel файла";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBeginRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxBeginCopy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEndCopy;
        private System.Windows.Forms.Button button4;
    }
}

