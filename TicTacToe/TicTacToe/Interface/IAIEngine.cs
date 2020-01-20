using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
    public interface IAIEngine
    {
		AvailableBlocksMap AIMove(Player aiType);
		void SetVariables(int size, int winLine, Player[,] map);
		List<AvailableBlocksMap> Blocks();
	}
}
