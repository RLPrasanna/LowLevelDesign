using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    internal class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public CellState CellState { get; set; }

        public Player Player { get; set; }

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.CellState = CellState.Empty;
            this.Player = null;
        }

        public void display()
        {
            if (this.Player == null)
            {
                Console.Write("| - |");
            }
            else
            {
                Console.Write("| " + this.Player.Symbol + " |");
            }
        }
    }
}
