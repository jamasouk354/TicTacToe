using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToe
{
    class Squares
    {
        public int x, y;
        public string contents;
        public PointF[] square = new PointF[4];

        public Squares(int _x, int _y, PointF[] _square, string _contents)
        {
            x = _x;
            y = _y;
            square = _square;
            contents = _contents;
        }        
    }
}
