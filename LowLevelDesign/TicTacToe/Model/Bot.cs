using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    internal class Bot : Player
    {
        public DifficultyLevel botDifficultyLevel { get; set; }
        public Bot(long id, string name, string symbol, PlayerType type, DifficultyLevel difficultyLevel): base(id, name, symbol, type)
        {
            this.botDifficultyLevel = difficultyLevel;
        }
    }
}
