using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Strategy
{
    internal interface IWinningStrategy
    {
        bool CheckWinner(Board board, Move move);
        void handleUndo(Board board, Move move);

    }
}
