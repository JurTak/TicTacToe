using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
	public class AvailableBlocksMap
	{
		public int X { get; set; }
		public int Y { get; set; }
		public PlayerRate Horizontal { get; set; }
		public PlayerRate Vertical { get; set; }
		public PlayerRate TopLeftBottomRight { get; set; }
		public PlayerRate TopRightBottomLeft { get; set; }

		public int MaxX
		{
			get
			{
				return Math.Max(
					Math.Max(Horizontal.X, Vertical.X),
					Math.Max(TopLeftBottomRight.X, TopRightBottomLeft.X));
			}
		}

		public int MaxO
		{
			get
			{
				return Math.Max(
					Math.Max(Horizontal.O, Vertical.O),
					Math.Max(TopLeftBottomRight.O, TopRightBottomLeft.O));
			}
		}

		public int Max
		{
			get
			{
				return Math.Max(MaxX, MaxO);
			}
		}

		public int AvailableMaxX
		{
			get
			{
				int h = (Horizontal.X > 0 ? Horizontal.X + Horizontal.Free : 0);
				int v = (Vertical.X > 0 ? Vertical.X + Vertical.Free : 0);
				int l = (TopLeftBottomRight.X > 0 ? TopLeftBottomRight.X + TopLeftBottomRight.Free : 0);
				int r = (TopRightBottomLeft.X > 0 ? TopRightBottomLeft.X + TopRightBottomLeft.Free : 0);
				return Math.Max(Math.Max(h, v), Math.Max(l, r));
			}
		}

		public int AvailableMaxO
		{
			get
			{
				int h = (Horizontal.O > 0 ? Horizontal.O + Horizontal.Free : 0);
				int v = (Vertical.O > 0 ? Vertical.O + Vertical.Free : 0);
				int l = (TopLeftBottomRight.O > 0 ? TopLeftBottomRight.O + TopLeftBottomRight.Free : 0);
				int r = (TopRightBottomLeft.O > 0 ? TopRightBottomLeft.O + TopRightBottomLeft.Free : 0);
				return Math.Max(Math.Max(h, v), Math.Max(l, r));
			}
		}

		public AvailableBlocksMap(int x, int y)
		{
			X = x;
			Y = y;
			Horizontal = new PlayerRate();
			Vertical = new PlayerRate();
			TopLeftBottomRight = new PlayerRate();
			TopRightBottomLeft = new PlayerRate();
		}

	}
}
