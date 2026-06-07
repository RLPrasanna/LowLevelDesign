using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    internal class Move
    {
        public Cell Cell { get; }
        public Player Player { get; }

        public Move(Cell cell, Player player)
        {
            this.Cell = cell;
            this.Player = player;
        }
    }
}
