using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
	public class AIEngine : TTT_Base, IAIEngine
	{
		private List<AvailableBlocksMap> blocks = new List<AvailableBlocksMap>();
		private Player[,] map;

		public List<AvailableBlocksMap> Blocks()
		{
			return blocks;
		}

		public void SetVariables(int size, int winLine, Player[,] map)
		{
			this.size = size;
			this.winLine = winLine;
			this.map = map;
		}

		public AvailableBlocksMap AIMove(Player aiType)
		{
			if (aiType == Player.NONE) return null;
			for (int i = blocks.Count - 1; i >= 0; i--)
				blocks.RemoveAt(i);

			CheckH();
			CheckV();
			CheckTLBR();
			CheckTRBL();

			AvailableBlocksMap bMap = null;
			if (blocks.Count <= 0) return null;
			if (blocks.Count == 1) bMap = blocks[0];
			else
			{
				List<AvailableBlocksMap> bestBlocks = new List<AvailableBlocksMap>();
				int maxBlock = 0;

				foreach (AvailableBlocksMap b in blocks)
				{
					if (maxBlock < b.Max) maxBlock = b.Max;
				}
				foreach (AvailableBlocksMap b in blocks)
				{
					if (maxBlock == b.Max) bestBlocks.Add(b);
				}
				if (bestBlocks.Count == 1) bMap = bestBlocks[0];
				if (bestBlocks.Count > 1)
				{
					// Expected win
					if (maxBlock + 1 >= winLine)
					{
						List<AvailableBlocksMap> bestBlocksTemp = new List<AvailableBlocksMap>();
						for (int i = bestBlocks.Count - 1; i >= 0; i--)
						{
							switch (aiType)
							{
								case Player.X:
									if (maxBlock == bestBlocks[i].MaxX)
										bestBlocksTemp.Add(bestBlocks[i]);
									break;
								case Player.O:
									if (maxBlock == bestBlocks[i].MaxO)
										bestBlocksTemp.Add(bestBlocks[i]);
									break;
							}
						}
						if (bestBlocksTemp.Count == 1) bMap = bestBlocksTemp[0];
						else if (bestBlocksTemp.Count > 1)
						{
							int index = new Random().Next(bestBlocksTemp.Count);
							bMap = bestBlocksTemp[index];
						}
						else
						{
							int index = new Random().Next(bestBlocks.Count);
							bMap = bestBlocks[index];
						}
					}
					else
					{
						CheckFreeBlocks();
						List<AvailableBlocksMap> bestBlocksTemp = new List<AvailableBlocksMap>();
						for (int i = bestBlocks.Count - 1; i >= 0; i--)
						{
							switch (aiType)
							{
								case Player.X:
									if (winLine <= bestBlocks[i].AvailableMaxX)
										bestBlocksTemp.Add(bestBlocks[i]);
									break;
								case Player.O:
									if (winLine <= bestBlocks[i].AvailableMaxO)
										bestBlocksTemp.Add(bestBlocks[i]);
									break;
							}
						}
						if (bestBlocksTemp.Count == 1) bMap = bestBlocksTemp[0];
						else if (bestBlocksTemp.Count > 1)
						{
							int index = new Random().Next(bestBlocksTemp.Count);
							bMap = bestBlocksTemp[index];
						}
						else
						{
							int index = new Random().Next(bestBlocks.Count);
							bMap = bestBlocks[index];
						}
					}
				}
			}
			if (bMap != null)
			{
				switch (aiType)
				{
					case Player.X:
						map[bMap.X, bMap.Y] = Player.X;
						break;
					case Player.O:
						map[bMap.X, bMap.Y] = Player.O;
						break;
				}
			}
			return bMap;
		}

		#region Check for available blocks
		private void Check(int x, int y, int lineNr, ref int pos,
			ref AvailableBlock blk,
			List<AvailableBlock> blks)
		{
			if (lineNr != pos)
			{
				if (blk.X >= 0 && (blk.PlayerRateX > 0 || blk.PlayerRateO > 0))
				{
					blks.Add(blk);
					blk = new AvailableBlock();
				}
				else blk.SetDefault();
				pos = lineNr;
			}
			if (map[x, y] == Player.NONE)
			{
				if (blk.SelectedPlayer == Player.NONE)
				{
					if (blk.PlayerRateX > 0 || blk.PlayerRateO > 0)
					{
						blks.Add(blk);
						blk = new AvailableBlock(x, y);
					}
					else blk.SetDefault(x, y);
				}
				else if (blk.SelectedPlayer == Player.X)
				{
					if (blk.X >= 0)
					{
						if (blk.PlayerRateX > 0 || blk.PlayerRateO > 0)
						{
							blks.Add(blk);
							blk = new AvailableBlock(x, y, blk.PlayerRateX);
						}
					}
					else blk.SetDefault(x, y, blk.PlayerRateX);
				}
				else if (blk.SelectedPlayer == Player.O)
				{
					if (blk.X >= 0)
					{
						if (blk.PlayerRateX > 0 || blk.PlayerRateO > 0)
						{
							blks.Add(blk);
							blk = new AvailableBlock(x, y, 0, blk.PlayerRateO);
						}
					}
					else blk.SetDefault(x, y, 0, blk.PlayerRateO);
				}
			}
			else if (map[x, y] == Player.X)
			{
				if (blk.SelectedPlayer == Player.O)
				{
					if (blk.X >= 0)
					{
						if (blk.PlayerRateX > 0 || blk.PlayerRateO > 0)
							blks.Add(blk);
						blk = new AvailableBlock();
					}
					else blk.SetDefault();
				}
				blk.SelectedPlayer = Player.X;
				blk.PlayerRateX++;
			}
			else if (map[x, y] == Player.O)
			{
				if (blk.SelectedPlayer == Player.X)
				{
					if (blk.X >= 0)
					{
						if (blk.PlayerRateX > 0 || blk.PlayerRateO > 0)
							blks.Add(blk);
						blk = new AvailableBlock();
					}
					else blk.SetDefault();
				}
				blk.SelectedPlayer = Player.O;
				blk.PlayerRateO++;
			}
		}

		private void CheckH()
		{
			int pos = 0;
			List<AvailableBlock> blks = new List<AvailableBlock>();
			AvailableBlock blk = new AvailableBlock();
			base.HorizontalCheck((x, y, lineNr) =>
			{
				Check(x, y, lineNr, ref pos, ref blk, blks);
				return false;
			});
			if (blk.X >= 0 && (blk.PlayerRateX > 0 || blk.PlayerRateO > 0))
			{
				blks.Add(blk);
			}
			foreach (AvailableBlocksMap bs in blocks)
			{
				for (int i = blks.Count - 1; i >= 0; i--)
				{
					if (bs.X == blks[i].X && bs.Y == blks[i].Y)
					{
						bs.Horizontal.O += blks[i].PlayerRateO;
						bs.Horizontal.X += blks[i].PlayerRateX;
						blks.RemoveAt(i);
					}
				}
			}
			if (blks.Count > 0)
			{
				foreach (AvailableBlock b in blks)
				{
					AvailableBlocksMap abm = new AvailableBlocksMap(b.X, b.Y);
					abm.Horizontal.X = b.PlayerRateX;
					abm.Horizontal.O = b.PlayerRateO;
					blocks.Add(abm);
				}
			}
		}

		private void CheckV()
		{
			int pos = -1;
			List<AvailableBlock> blks = new List<AvailableBlock>();
			AvailableBlock blk = new AvailableBlock();
			base.VerticalCheck((x, y, lineNr) =>
			{
				Check(x, y, lineNr, ref pos, ref blk, blks);
				return false;
			});
			if (blk.X >= 0 && (blk.PlayerRateX > 0 || blk.PlayerRateO > 0))
			{
				blks.Add(blk);
			}
			foreach (AvailableBlocksMap bs in blocks)
			{
				for (int i = blks.Count - 1; i >= 0; i--)
				{
					if (bs.X == blks[i].X && bs.Y == blks[i].Y)
					{
						bs.Vertical.O += blks[i].PlayerRateO;
						bs.Vertical.X += blks[i].PlayerRateX;
						blks.RemoveAt(i);
					}
				}
			}
			if (blks.Count > 0)
			{
				foreach (AvailableBlock b in blks)
				{
					AvailableBlocksMap abm = new AvailableBlocksMap(b.X, b.Y);
					abm.Vertical.X = b.PlayerRateX;
					abm.Vertical.O = b.PlayerRateO;
					blocks.Add(abm);
				}
			}
		}

		private void CheckTLBR()
		{
			int pos = -1;
			List<AvailableBlock> blks = new List<AvailableBlock>();
			AvailableBlock blk = new AvailableBlock();
			base.TopLeftBottomRightCheck((x, y, lineNr) =>
			{
				Check(x, y, lineNr, ref pos, ref blk, blks);
				return false;
			});
			if (blk.X >= 0 && (blk.PlayerRateX > 0 || blk.PlayerRateO > 0))
			{
				blks.Add(blk);
			}
			foreach (AvailableBlocksMap bs in blocks)
			{
				for (int i = blks.Count - 1; i >= 0; i--)
				{
					if (bs.X == blks[i].X && bs.Y == blks[i].Y)
					{
						bs.TopLeftBottomRight.O += blks[i].PlayerRateO;
						bs.TopLeftBottomRight.X += blks[i].PlayerRateX;
						blks.RemoveAt(i);
					}
				}
			}
			if (blks.Count > 0)
			{
				foreach (AvailableBlock b in blks)
				{
					AvailableBlocksMap abm = new AvailableBlocksMap(b.X, b.Y);
					abm.TopLeftBottomRight.X = b.PlayerRateX;
					abm.TopLeftBottomRight.O = b.PlayerRateO;
					blocks.Add(abm);
				}
			}
		}

		private void CheckTRBL()
		{
			int pos = -1;
			List<AvailableBlock> blks = new List<AvailableBlock>();
			AvailableBlock blk = new AvailableBlock();
			base.TopRightBottomLeftCheck((x, y, lineNr) =>
			{
				Check(x, y, lineNr, ref pos, ref blk, blks);
				return false;
			});
			if (blk.X >= 0 && (blk.PlayerRateX > 0 || blk.PlayerRateO > 0))
			{
				blks.Add(blk);
			}
			foreach (AvailableBlocksMap bs in blocks)
			{
				for (int i = blks.Count - 1; i >= 0; i--)
				{
					if (bs.X == blks[i].X && bs.Y == blks[i].Y)
					{
						bs.TopRightBottomLeft.O += blks[i].PlayerRateO;
						bs.TopRightBottomLeft.X += blks[i].PlayerRateX;
						blks.RemoveAt(i);
					}
				}
			}
			if (blks.Count > 0)
			{
				foreach (AvailableBlock b in blks)
				{
					AvailableBlocksMap abm = new AvailableBlocksMap(b.X, b.Y);
					abm.TopRightBottomLeft.X = b.PlayerRateX;
					abm.TopRightBottomLeft.O = b.PlayerRateO;
					blocks.Add(abm);
				}
			}
		}

		private void CheckFreeBlocks()
		{
			int x, y;
			int n = (size - winLine < 0 ? 1 : size - winLine + 1);

			foreach (AvailableBlocksMap b in blocks)
			{
				//Horizontal
				for (x = 0; x < size; x++)
				{
					if (map[x, b.Y] == Player.NONE) b.Horizontal.Free++;
				}

				//Vertical
				for (y = 0; y < size; y++)
				{
					if (map[b.X, y] == Player.NONE) b.Vertical.Free++;
				}

				//Top Left , Bottom Right
				if (b.X - b.Y < n && b.Y - b.X < n)
				{
					for (x = b.X, y = b.Y; x >= 0 && y >= 0; x--, y--)
					{
						if (map[x, y] == Player.NONE) b.TopLeftBottomRight.Free++;
					}
					for (x = b.X + 1, y = b.Y + 1; x < size && y < size; x++, y++)
					{
						if (map[x, y] == Player.NONE) b.TopLeftBottomRight.Free++;
					}
				}

				//Top Right , Bottom Left
				if (b.X + b.Y >= winLine - 1 && (size - b.X - 1) + (size - b.Y - 1) >= winLine - 1)
				{
					for (x = b.X, y = b.Y; x < size && y >= 0; x++, y--)
					{
						if (map[x, y] == Player.NONE) b.TopRightBottomLeft.Free++;
					}
					for (x = b.X - 1, y = b.Y + 1; x >= 0 && y < size; x--, y++)
					{
						if (map[x, y] == Player.NONE) b.TopRightBottomLeft.Free++;
					}
				}
			}
		}

		#endregion

	}
}
