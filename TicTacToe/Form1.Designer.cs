namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightGray;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(367, 239);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 40);
			this.button1.TabIndex = 3;
			this.button1.Text = "Exit";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.LightGray;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(34, 239);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 40);
			this.button2.TabIndex = 4;
			this.button2.Text = "New Game";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(34, 106);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 110);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "X O -  Select";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(380, 73);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tic Tak Toe";
			// 
			// radioButton1
			// 
			this.radioButton1.BackgroundImage = global::TicTacToe.Properties.Resources.X;
			this.radioButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.radioButton1.Checked = true;
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton1.Location = new System.Drawing.Point(15, 25);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(42, 71);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.radioButton1.UseMnemonic = false;
			this.radioButton1.UseVisualStyleBackColor = false;
			// 
			// radioButton2
			// 
			this.radioButton2.BackgroundImage = global::TicTacToe.Properties.Resources.O;
			this.radioButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton2.Location = new System.Drawing.Point(76, 25);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(42, 71);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.radioButton2.UseMnemonic = false;
			this.radioButton2.UseVisualStyleBackColor = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton8);
			this.groupBox2.Controls.Add(this.radioButton7);
			this.groupBox2.Controls.Add(this.radioButton6);
			this.groupBox2.Controls.Add(this.radioButton5);
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(188, 106);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(204, 110);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Select Table Size";
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Checked = true;
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton3.Location = new System.Drawing.Point(31, 25);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(59, 24);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "3 x 3";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton4.Location = new System.Drawing.Point(31, 48);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(59, 24);
			this.radioButton4.TabIndex = 1;
			this.radioButton4.Text = "4 x 4";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton5.Location = new System.Drawing.Point(31, 72);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(59, 24);
			this.radioButton5.TabIndex = 2;
			this.radioButton5.Text = "5 x 5";
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton6.Location = new System.Drawing.Point(115, 25);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(59, 24);
			this.radioButton6.TabIndex = 3;
			this.radioButton6.Text = "6 x 6";
			this.radioButton6.UseVisualStyleBackColor = true;
			this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton7.Location = new System.Drawing.Point(115, 48);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(59, 24);
			this.radioButton7.TabIndex = 4;
			this.radioButton7.Text = "7 x 7";
			this.radioButton7.UseVisualStyleBackColor = true;
			this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton8.Location = new System.Drawing.Point(115, 72);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(59, 24);
			this.radioButton8.TabIndex = 5;
			this.radioButton8.Text = "8 x 8";
			this.radioButton8.UseVisualStyleBackColor = true;
			this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(26, 60);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(93, 26);
			this.numericUpDown1.TabIndex = 8;
			this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.numericUpDown1);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(398, 106);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(146, 110);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Number Of Blocks To Win";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 318);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tic Tac Toe";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.GroupBox groupBox3;
	}
}

