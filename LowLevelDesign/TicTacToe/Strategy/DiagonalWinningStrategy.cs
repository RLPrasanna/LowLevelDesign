using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Strategy
{
    internal class DiagonalWinningStrategy : IWinningStrategy
    {
        private Dictionary<string, int> leftDiagonal = new Dictionary<string, int>();
        private Dictionary<string, int> rightDiagonal = new Dictionary<string, int>();
        public bool CheckWinner(Board board, Move move)
        {
            int row = move.Cell.Row;
            int col = move.Cell.Col;
            string symbol = move.Player.Symbol;

            //check left diagonal
            if (row == col)
            {
                this.leftDiagonal.TryAdd(symbol, 0);
                this.leftDiagonal[symbol] += 1;

                if (leftDiagonal[symbol] == board.Size)
                {
                    return true;
                }
            }

            //check right diagonal
            if (row + col == board.Size -1)
            {
                this.rightDiagonal.TryAdd(symbol, 0);
                rightDiagonal[symbol] += 1;

                if (rightDiagonal[symbol] == board.Size)
                {
                    return true;
                }
            }

            return false;
        }

        public void handleUndo(Board board, Move move)
        {
            int row = move.Cell.Row;
            int col = move.Cell.Col;
            string symbol = move.Player.Symbol;

            // undo left diagonal
            if(row==col && leftDiagonal.ContainsKey(symbol))
            {
                leftDiagonal[symbol]--;
                if (leftDiagonal[symbol] <= 0)
                {
                    leftDiagonal.Remove(symbol);
                }
            }

            // undo right diagonal
            if (row == col && rightDiagonal.ContainsKey(symbol))
            {
                rightDiagonal[symbol]--;
                if (rightDiagonal[symbol] <= 0)
                {
                    rightDiagonal.Remove(symbol);
                }
            }
        }
    }
}
