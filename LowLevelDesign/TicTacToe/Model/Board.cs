using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    internal class Board
    {
        public int Size { get; set; }
        public List<List<Cell>> Grid  { get; set; }

        public Board(int dimension)
        {
            this.Size = dimension;
            this.Grid = new List<List<Cell>>();
            for(int i = 0; i < Size; i++)
            {
                this.Grid.Add(new List<Cell>());
                for(int j = 0; j < dimension; j++)
                {
                    this.Grid[i].Add(new Cell(i, j));
                }
            }
        }

        public void printBoard()
        {
            foreach(var row in this.Grid)
            {
                foreach(var cell in row)
                {
                    cell.display();
                }
                Console.WriteLine();
            }
        }
    }
}
