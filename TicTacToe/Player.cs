﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        public int x, y, size;

        public Player(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
    }
}
