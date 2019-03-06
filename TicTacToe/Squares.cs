using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Squares
    {
        public int x, y, size;
        public string contents;


        public Squares(int _x, int _y, int _size, string _contents)
        {
            x = _x;
            y = _y;
            size = _size;
            contents = _contents;
        }
    }
}
