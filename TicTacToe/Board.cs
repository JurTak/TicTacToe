using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ModuleTTT;

namespace TicTacToe
{
	public class Board : ITicTacToe_View
	{
		private readonly TableLayoutPanel tableLayoutPanel1;
		private int size = 3;
		public enum Res { X, O }
		private int[,] table = new int[3, 3];
		
		public Board(TableLayoutPanel tableLayoutPanel1)
		{
			this.tableLayoutPanel1 = tableLayoutPanel1;
		}

		public Position GetPos(MouseEventArgs e)
		{
			Position pos = new Position();
			pos.X = e.Location.X / (tableLayoutPanel1.Size.Width / size);
			pos.Y = e.Location.Y / (tableLayoutPanel1.Size.Height / size);
			return pos;
		}
		
		public void Map(Player player, int x, int y)
		{
			if (table[x, y] == 0 && player != Player.NONE)
			{
				PictureBox p = (PictureBox)tableLayoutPanel1.GetControlFromPosition(x, y);
				switch (player)
				{
					case Player.X:
						p.Image = global::TicTacToe.Properties.Resources.X;
						break;
					case Player.O:
						p.Image = global::TicTacToe.Properties.Resources.O;
						break;
				}
				table[x, y] = 1;
			}
		}

		public void Resize(int size)
		{
			this.size = size < 3 ? 3 : size;
			table = new int[this.size, this.size];
			for (int y = 0; y < this.size; y++)
			{
				for (int x = 0; x < this.size; x++)
				{
					table[x, y] = 0;
				}
			}

			tableLayoutPanel1.ColumnCount = this.size;
			for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
				tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

			tableLayoutPanel1.RowCount = this.size;
			for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
				tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		}

		public void ClearAll()
		{
			for (int y = 0; y < size; y++)
			{
				for (int x = 0; x < size; x++)
				{
					table[x, y] = 0;
					PictureBox p = (PictureBox)tableLayoutPanel1.GetControlFromPosition(x, y);
					p.Image = global::TicTacToe.Properties.Resources.None;
					p.BackColor = System.Drawing.Color.White;
				}
			}
		}

		public delegate void DMouseUp(object sender, MouseEventArgs e);
		public void SetPics(DMouseUp MouseUp)
		{
			int i = 0;
			for (int y = 0; y < size; y++)
			{
				for (int x = 0; x < size; x++)
				{
					PictureBox pictureBox1 = new PictureBox();
					pictureBox1.Dock = DockStyle.Fill;
					pictureBox1.Image = global::TicTacToe.Properties.Resources.None;
					pictureBox1.Location = new System.Drawing.Point(4, 4);
					pictureBox1.Name = string.Format("pictureBox{0}", i + 1);
					pictureBox1.Size = new System.Drawing.Size(192, 192);
					pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
					pictureBox1.TabIndex = i++;
					pictureBox1.Tag = new Position(x, y);
					pictureBox1.TabStop = false;
					pictureBox1.MouseUp += new MouseEventHandler(MouseUp);
					tableLayoutPanel1.Controls.Add(pictureBox1, x, y);
				}
			}
		}

		
	}
}
