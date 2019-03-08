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

        public Squares(PointF[] _square, string _contents)
        {
            square = _square;
            contents = _contents;
        }        
    }
}
