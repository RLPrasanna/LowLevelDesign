using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Exceptions;
using TicTacToe.Model;

namespace TicTacToe.Strategy
{
    internal class EasyBotPlayingStrategy : IBotPlayingStrategy
    {
        public Move makeMove(Board board, Player player)
        {
            foreach(var row in board.Grid)
            {
                foreach(var cell in row)
                {
                    if (cell.CellState == CellState.Empty)
                    {
                        return new Move(cell, player);
                    }
                }
            }
            throw new NoValidCellFoundException("No Empty cell found!");
        }
    }
}
