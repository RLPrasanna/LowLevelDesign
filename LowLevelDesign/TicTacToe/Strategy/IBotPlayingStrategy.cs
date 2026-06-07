using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Strategy
{
    internal interface IBotPlayingStrategy
    {
        Move makeMove(Board board, Player player);
    }
}
