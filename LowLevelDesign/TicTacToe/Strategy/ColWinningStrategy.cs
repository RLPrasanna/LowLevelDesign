using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Strategy
{
    internal class ColWinningStrategy : IWinningStrategy
    {
        private Dictionary<int, Dictionary<string, int>> counts = new Dictionary<int, Dictionary<string, int>>();
        public bool CheckWinner(Board board, Move move)
        {
            int colNo = move.Cell.Col;
            string symbol = move.Player.Symbol;

            if (!counts.ContainsKey(colNo))
            {
                counts.Add(colNo, new Dictionary<string, int>());
            }

            Dictionary<string, int> internalDict = counts[colNo];
            if (!internalDict.ContainsKey(symbol))
            {
                internalDict.Add(symbol, 0);
            }

            internalDict[symbol] = internalDict[symbol] + 1;

            if (internalDict[symbol] == board.Size)
            {
                return true;
            }
            return false;
        }

        public void handleUndo(Board board, Move move)
        {
            int colNo = move.Cell.Col;
            string symbol = move.Player.Symbol;

            Dictionary<string, int> internalDict = counts[colNo];

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
