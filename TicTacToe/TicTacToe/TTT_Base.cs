using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTTT
{
    public abstract class TTT_Base
    {
		protected int size;
		protected int winLine;

        protected delegate bool DCheck(int x, int y, int lineNr);
		
        protected void HorizontalCheck(DCheck func)
        {
            int lineNr = 0;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (func(x, y, lineNr)) return;
                }
                lineNr++;
            }
        }
        
        protected void VerticalCheck(DCheck func)
        {
            int lineNr = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (func(x, y, lineNr)) return;
                }
                lineNr++;
            }
        }
        
        protected void TopLeftBottomRightCheck(DCheck func)
        {
            int lineNr = 0;
            int n = (size - winLine < 0 ? 1 : size - winLine + 1);
            for (int line = 0; line < n; line++)
            {
                for (int x = line, y = 0; x < size && y < size; x++, y++)
                {
                    if (func(x, y, lineNr)) return;
                }
                lineNr++;
            }
            for (int line = 1; line < n; line++)
            {
                for (int x = size - 1 - line, y = size - 1; x >= 0 && y >= 0; x--, y--)
                {
                    if (func(x, y, lineNr)) return;
                }
                lineNr++;
            }
        }
        
        protected void TopRightBottomLeftCheck(DCheck func)
        {
            int lineNr = 0;
            int n = (size - winLine < 0 ? 1 : size - winLine + 1);
            for (int line = 0; line < n; line++)
            {
                for (int x = line, y = size - 1; x < size && y >= 0; x++, y--)
                {
                    if (func(x, y, lineNr)) return;
                }
                lineNr++;
            }
            for (int line = 1; line < n; line++)
            {
                for (int x = size - 1 - line, y = 0; x >= 0 && y < size; x--, y++)
                {
                    if (func(x, y, lineNr)) return;
                }
                lineNr++;
            }
        }
    }
}
