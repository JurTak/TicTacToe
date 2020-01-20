using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModuleTTT;

namespace TicTacToe
{
	public class Game
	{
		ManualResetEvent resetEvent = new ManualResetEvent(true);
		private readonly TableLayoutPanel tableLayoutPanel1;
		private Board board;
		private ModuleTTT.TicTacToe ttt;
		private bool allowedAction = true;
		private bool endGame = false;
		public Form2 form { get; set; }

		public Game(TableLayoutPanel tableLayoutPanel1)
		{
			this.tableLayoutPanel1 = tableLayoutPanel1;
			board = new Board(tableLayoutPanel1);
			ttt = new ModuleTTT.TicTacToe { AIEngine = new AIEngine() };
		}

		public void NewGame(int boardSize)
		{
			ttt.NewGame(boardSize, boardSize);
			board.ClearAll();
			board.Resize(boardSize);
			board.SetPics(MouseUp);
		}

		private void MouseUp(object sender, MouseEventArgs e)
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
			if (pw.Player != Player.NONE)
			{
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
			if (ttt.PlayerMove(Player.X, pos.X, pos.Y))
			{
				resetEvent.Reset();
				form.BeginInvoke((MethodInvoker)delegate
				{
					FindWinner(ttt.CheckWinner());
					ttt.View(board);
					resetEvent.Set();
				});
				resetEvent.WaitOne();
				if (!endGame)
				{
					Thread.Sleep(500);
					AvailableBlocksMap bMap = ttt.AIEngine.AIMove(Player.O);
					resetEvent.Reset();
					form.BeginInvoke((MethodInvoker)delegate
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
	}
}
