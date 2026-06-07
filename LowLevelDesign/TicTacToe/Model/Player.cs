using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Factory;
using TicTacToe.Strategy;

namespace TicTacToe.Model
{
    internal class Player
    {
        public long Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public PlayerType PlayerType { get; set; }

        public Player(long id, string name, string symbol, PlayerType playerType)
        {
            this.Id = id;
            this.Name = name;
            this.Symbol = symbol;
            this.PlayerType = playerType;
            this.DifficultyLevel = DifficultyLevel.Easy;
        }

        // For making the move, we need to take input from the user
        public Move GetInputAndMakeMove(Board board)
        {
            /*
             * step1: check for playerType
             *      - get the difficulty level and according to that, get object
             *      of the strategy (easy/medium/hard) and fetch the input
             * step2: if playerType is Human, take row and column input
             * */
            if (this.PlayerType == PlayerType.Bot)
            {
                IBotPlayingStrategy botPlayingStrategy=BotDifficultyLevelFactory.GetBotPlayingStrategyByDifficultyLevel(this.DifficultyLevel);
                return botPlayingStrategy.makeMove(board, this);
            }

            Console.Write("Please input the row number: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input the col number: ");
            int col = Convert.ToInt32(Console.ReadLine());
            return new Move(new Cell(row, col), this);
        }
    }
}
