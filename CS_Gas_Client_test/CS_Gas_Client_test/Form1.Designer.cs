namespace CS_Gas_Client_test
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 28);
            textBox1.TabIndex = 1;
            textBox1.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 9);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 2;
            label2.Text = "Port:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(328, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(77, 28);
            textBox2.TabIndex = 3;
            textBox2.Text = "4001";
            // 
            // button1
            // 
            button1.Location = new Point(448, 6);
            button1.Name = "button1";
            button1.Size = new Size(101, 30);
            button1.TabIndex = 4;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 51);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 5;
            label3.Text = "Command(Hex,...):";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(166, 48);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(772, 28);
            textBox3.TabIndex = 6;
            textBox3.Text = "08,01,07,E8,07,18,09,06,38,03";
            // 
            // button2
            // 
            button2.Location = new Point(979, 46);
            button2.Name = "button2";
            button2.Size = new Size(101, 30);
            button2.TabIndex = 7;
            button2.Text = "Sent";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 123);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(1068, 465);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 90);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 9;
            label4.Text = "Information:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 600);
            Controls.Add(label4);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Button button1;
        private Label label3;
        private TextBox textBox3;
        private Button button2;
        private RichTextBox richTextBox1;
        private Label label4;
    }
}
