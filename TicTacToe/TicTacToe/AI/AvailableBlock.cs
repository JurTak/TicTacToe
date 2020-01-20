using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
    public class AvailableBlock
    {
        public Player SelectedPlayer { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PlayerRateX { get; set; }
        public int PlayerRateO { get; set; }
        
        public AvailableBlock(int x = -1, int y = -1,
                        int playerRateX = 0, int playerRateO = 0,
                        Player player = Player.NONE)
        {
            SetDefault(x, y, playerRateX, playerRateO, player);
        }

        public void SetDefault(int x = -1, int y = -1, 
                        int playerRateX = 0, int playerRateO = 0, 
                        Player player = Player.NONE)
        {
            X = x;
            Y = y;
            PlayerRateX = playerRateX;
            PlayerRateO = playerRateO;
            SelectedPlayer = player;
        }
    }
}
