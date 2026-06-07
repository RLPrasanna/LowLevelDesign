using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe.Controller
{
    internal class GameController
    {
        public Game StartGame(int dimension, List<Player> players)
        {
            return new Game(dimension, players);
        }

        public GameState CheckGameStatus(Game game)
        {
            return game.GameState;
        }

        public void MakeMove(Game game)
        {
            game.MakeMove();
        }

        public void Undo(Game game)
        {
            game.Undo();
        }

        public void DisplayBoard(Game game)
        {
            game.PrintBoard();
        }
        /**
         * 
         * | - | - | - |
         * | - | X | - |
         * | - | - | O |
         * 
         */

        public Player GetWinner(Game game)
        {
            return game.Winner;
        }


    }
}
