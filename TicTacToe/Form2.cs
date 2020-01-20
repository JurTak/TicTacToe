using ModuleTTT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class Form2 : Form
	{
		ManualResetEvent resetEvent = new ManualResetEvent(true);
		private Player player;
		private Player aiPlayer;
		private Board board;
		private ModuleTTT.TicTacToe ttt;
		private bool allowedAction = true;
		private bool endGame = false;
		private int size;
		private int winLine;

		public Form2(int size, int winLine, Player player)
		{
			InitializeComponent();
			this.size = size;
			this.winLine = winLine <= size ? winLine : size;
			label4.Text = string.Format("Win in {0} blocks", this.winLine);
			if (player == Player.O)
			{
				this.player = Player.O;
				this.aiPlayer = Player.X;
				label3.Text = "You are \'O\'";
				pictureBox1.Image = global::TicTacToe.Properties.Resources.O;
				pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			}
			else
			{
				this.player = Player.X;
				this.aiPlayer = Player.O;
				label3.Text = "You are \'X\'";
				pictureBox1.Image = global::TicTacToe.Properties.Resources.X;
				pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			}
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			board = new Board(tableLayoutPanel1);
			ttt = new ModuleTTT.TicTacToe { AIEngine = new AIEngine() };
			ttt.NewGame(size, winLine);
			board.Resize(size);
			board.SetPics(BoardMouseUp);
		}

		public void NewGame()
		{
			ttt.NewGame(size, winLine);
			board.ClearAll();
			allowedAction = true;
			endGame = false;
			label1.Visible = false;
			label2.Visible = false;
			pictureBox1.Visible = false;
			button2.Visible = false;
		}

		private void BoardMouseUp(object sender, MouseEventArgs e)
		{
			PictureBox b = sender as PictureBox;
			if (b != null)
			{
				if (allowedAction && !endGame)
				{
					allowedAction = false;
					Thread th = new Thread(new ParameterizedThreadStart(GameActionThread));
					th.Start((Position)b.Tag);
				}
			}
		}

		private void FindWinner(Winner pw)
		{
			if (pw.IsTie)
			{
				label2.Text = "Tie";
				label2.Visible = true;
				button2.Visible = true;
				endGame = true;
			}
			else if (pw.Player != Player.NONE)
			{
				try
				{
					switch (pw.Player)
					{
						case Player.X:
							if (player == Player.X)
								labelWin.Text = (int.Parse(labelWin.Text) + 1).ToString();
							else
								labelLose.Text = (int.Parse(labelLose.Text) + 1).ToString();
							break;
						case Player.O:
							if (player == Player.X)
								labelLose.Text = (int.Parse(labelLose.Text) + 1).ToString();
							else
								labelWin.Text = (int.Parse(labelWin.Text) + 1).ToString();
							break;
					}
				}
				catch { }

				pictureBox1.Visible = true;
				label1.Visible = true;
				label2.Text = player == pw.Player ? "Win!" : "Lose!";
				label2.Visible = true;
				button2.Visible = true;

				foreach (Position p in pw.Positions)
				{
					PictureBox pic = (PictureBox)tableLayoutPanel1.GetControlFromPosition(p.X, p.Y);
					pic.BackColor = System.Drawing.Color.LightGreen;
				}
				endGame = true;
			}
		}

		private void GameActionThread(object obj)
		{
			Position pos = (Position)obj;
			if (ttt.PlayerMove(player, pos.X, pos.Y))
			{
				resetEvent.Reset();
				this.BeginInvoke((MethodInvoker)delegate
				{
					FindWinner(ttt.CheckWinner());
					ttt.View(board);
					resetEvent.Set();
				});
				resetEvent.WaitOne();
				if (!endGame)
				{
					Thread.Sleep(500);
					AvailableBlocksMap bMap = ttt.AIEngine.AIMove(aiPlayer);
					resetEvent.Reset();
					this.BeginInvoke((MethodInvoker)delegate
					{
						FindWinner(ttt.CheckWinner());
						ttt.View(board);
						resetEvent.Set();
					});
					resetEvent.WaitOne();
				}
			}
			allowedAction = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			NewGame();
		}
	}
}
