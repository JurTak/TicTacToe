using ModuleTTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Player player = radioButton1.Checked ? Player.X : Player.O;
			int size = 3;
			if (radioButton4.Checked) size = 4;
			else if (radioButton5.Checked) size = 5;
			else if (radioButton6.Checked) size = 6;
			else if (radioButton7.Checked) size = 7;
			else if (radioButton8.Checked) size = 8;
			using (Form2 F = new Form2(size, (int)numericUpDown1.Value, player))
			{
				this.Hide();
				F.ShowDialog();
				this.Show();
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = 3;
			numericUpDown1.Value = 3;
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = 4;
			numericUpDown1.Value = 4;
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = 5;
			numericUpDown1.Value = 5;
		}

		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = 6;
			numericUpDown1.Value = 6;
		}

		private void radioButton7_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = 7;
			numericUpDown1.Value = 7;
		}

		private void radioButton8_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Maximum = 8;
			numericUpDown1.Value = 8;
		}
	}
}
