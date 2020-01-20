using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
	public class Winner
	{
		public Player Player { get; set; }
		public List<Position> Positions { get; set; }
		public bool IsTie { get; set; }

		public Winner(Player player, List<Position> positions, bool isTie = false)
		{
			Player = player;
			Positions = positions;
			IsTie = isTie;
		}
	}
}
