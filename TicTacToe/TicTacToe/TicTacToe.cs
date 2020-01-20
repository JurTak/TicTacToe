using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
    public enum Player { NONE, O, X }

    public class TicTacToe : TTT_Base
    {
		private Player[,] map;
        private IAIEngine aiEngine = null;

        public IAIEngine AIEngine
        {
            set
            {
                aiEngine = value;
				aiEngine.SetVariables(size, winLine, map);
			}
			get
			{
				return aiEngine;
			}
        }

        public TicTacToe(int size = 3, int winLine = 3)
        {
            if (size < 3 || winLine < 3)
                throw new Exception("incorrect size");
			NewGame(size, winLine);
		}

		public void NewGame(int size = 3, int winLine = 3)
		{
			this.size = size;
			this.winLine = winLine;
			map = new Player[size, size];
			for (int y = 0; y < size; y++)
			{
				for (int x = 0; x < size; x++)
				{
					map[x, y] = Player.NONE;
				}
			}
			if (aiEngine != null)
			{
				aiEngine.SetVariables(size, winLine, map);
			}
		}

        public bool PlayerMove(Player playerType, int x, int y)
        {
            if (x < 0 || y < 0 || x >= size || y >= size)
                throw new Exception("incorrect move");

            if (map[x, y] == 0)
            {
                switch (playerType)
                {
                    case Player.O: map[x, y] = Player.O; break;
                    case Player.X: map[x, y] = Player.X; break;
                    default: return false;
                }
                return true;
            }
            return false;
        }
		
        private bool CheckPlayer(ref Player check, ref int count, 
			ref List<Position> bpos, int x, int y)
        {
            if (check != Player.NONE && check == map[x, y])
            {
				bpos.Add(new Position(x ,y));
                if (++count >= winLine)
                {
                    return true;
                }
            }
            else
            {
				bpos.Clear();
				bpos.Add(new Position(x, y));
				check = map[x, y];
                count = 1;
            }
            return false;
        }

        public Winner CheckWinner()
        {
            Player check = Player.NONE;
			List<Position> bpos = new List<Position>();
            int pos, count = 0;
            bool win = false;
			bool isTie = true;

            //Horizontal check
            pos = -1;
			base.HorizontalCheck((x, y, lineNr) =>
            {
				if (map[x, y] == Player.NONE) isTie = false;
                if (pos != lineNr)
                {
                    check = Player.NONE;
                    count = 0;
                    pos = lineNr;
                }
                win = CheckPlayer(ref check, ref count, ref bpos, x, y);
				return win;
            });
            if (win) return new Winner(check, bpos);

            //Vertical check
            pos = -1;
			bpos.Clear();
			base.VerticalCheck((x, y, lineNr) =>
            {
				if (map[x, y] == Player.NONE) isTie = false;
				if (pos != lineNr)
                {
                    check = Player.NONE;
                    count = 0;
                    pos = lineNr;
                }
				win = CheckPlayer(ref check, ref count, ref bpos, x, y);
				return win;
            });
            if (win) return new Winner(check, bpos);

			//(top left, bottom right) check
			pos = -1;
			bpos.Clear();
			base.TopLeftBottomRightCheck((x, y, lineNr) =>
            {
				if (map[x, y] == Player.NONE) isTie = false;
				if (pos != lineNr)
                {
                    check = Player.NONE;
                    count = 0;
                    pos = lineNr;
                }
				win = CheckPlayer(ref check, ref count, ref bpos, x, y);
				return win;
            });
            if (win) return new Winner(check, bpos);

			//(top right, bottom left) check
			pos = -1;
			bpos.Clear();
			base.TopRightBottomLeftCheck((x, y, lineNr) =>
            {
				if (map[x, y] == Player.NONE) isTie = false;
				if (pos != lineNr)
                {
                    check = Player.NONE;
                    count = 0;
                    pos = lineNr;
                }
				win = CheckPlayer(ref check, ref count, ref bpos, x, y);
				return win;
            });
            if (win) return new Winner(check, bpos);

			return new Winner(Player.NONE, null, isTie);
		}

        public void View(ITicTacToe_View v)
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    v.Map(map[x, y], x, y);
                }
            }
        }
    }
}
