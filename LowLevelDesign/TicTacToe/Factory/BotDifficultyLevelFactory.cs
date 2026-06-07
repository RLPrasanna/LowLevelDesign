using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;
using TicTacToe.Strategy;

namespace TicTacToe.Factory
{
    internal class BotDifficultyLevelFactory
    {
        public static IBotPlayingStrategy GetBotPlayingStrategyByDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case DifficultyLevel.Easy:
                    return new EasyBotPlayingStrategy();
                case DifficultyLevel.Medium:
                    return new MediumBotPlayingStrategy();
                case DifficultyLevel.Hard:
                    return new HardBotPlayingStrategy();
                default:
                    return new EasyBotPlayingStrategy();
            }
        }
    }
}
