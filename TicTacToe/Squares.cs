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
        public int x, y, size;
        public string contents;
        public PointF[] sqPoint, square;

        public Squares(int _x, int _y, int _size, string _contents)
        {
            x = _x;
            y = _y;
            size = _size;
            //sqPoint = _sqPoint;
            //square = _square;
            contents = _contents;
        }
    }
}
