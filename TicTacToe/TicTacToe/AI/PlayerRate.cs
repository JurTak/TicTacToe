using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
    public class PlayerRate
    {
        public int X { get; set; }
        public int O { get; set; }
        public int Free { get; set; }

        public PlayerRate(int x = 0, int o = 0, int free = 0)
        {
            X = x;
            O = o;
            Free = free;
        }
    }
}
