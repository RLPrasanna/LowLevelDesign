using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Strategy
{
    internal class RowWinningStrategy : IWinningStrategy
    {
        /*
         * Create Dictionary
         * For every row in the system, we will have a Dictionary
         * <2: {"X":1, "O":2}>
         * If any of the symbol in Dictionary has a count == size of row, it means player has won the game
         */
        private Dictionary<int, Dictionary<string, int>> counts = new Dictionary<int, Dictionary<string, int>>();
        public bool CheckWinner(Board board, Move move)
        {
            int rowNo = move.Cell.Row;
            string symbol = move.Player.Symbol;

            if (!counts.ContainsKey(rowNo))
            {
                counts.Add(rowNo, new Dictionary<string, int>());
            }

            Dictionary<string, int> internalDict = counts[rowNo]; // get from existing dictionary
            if (!internalDict.ContainsKey(symbol))
            {
                internalDict.Add(symbol, 0);
            }

            internalDict[symbol] = internalDict[symbol] + 1; // increamenting

            if (internalDict[symbol] == board.Size)
            {
                return true;
            }
            return false;
        }

        public void handleUndo(Board board, Move move)
        {
            int rowNo = move.Cell.Row;
            string symbol = move.Player.Symbol;

            Dictionary<string, int> internalDict = counts[rowNo];
            if (internalDict.ContainsKey(symbol))
            {
                internalDict[symbol] -= 1;
                if (internalDict[symbol] <= 0)
                {
                    internalDict.Remove(symbol);
                }
            }
        }
    }
}
