using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Controller;
using TicTacToe.Model;

namespace TicTacToe
{
    internal class Client
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            try
            {
                // This class will Interact with GameController.
                int dimension = 3;
                List<Player> players = [];
                players.Add(new Player(1, "Prasanna", "X", PlayerType.Human));
                players.Add(new Player(2, "Karthik", "O", PlayerType.Human));

                GameController gameController = new GameController();
                Game game = gameController.StartGame(dimension, players);

                while (gameController.CheckGameStatus(game) == GameState.InProgress)
                {
                    // Display the Board
                    gameController.DisplayBoard(game);

                    if (game.Moves.Count() != 0)
                    {
                        Console.Write("Do you want to Undo? Y/N: ");
                        string undoInput = Console.ReadLine();
                        if (undoInput.ToLower() == "y")
                        {
                            gameController.Undo(game);
                            continue;
                        }
                    }

                    Console.WriteLine("Please make your move");
                    gameController.MakeMove(game);
                }

                if (gameController.CheckGameStatus(game) == GameState.Win)
                {
                    Console.WriteLine("Player " + gameController.GetWinner(game).Name + " has won the game...");
                }
                else if (gameController.CheckGameStatus(game) == GameState.Draw)
                {
                    Console.WriteLine("Game is Draw!");
                }

                //
                //Console.WriteLine("Enter the name of the first player:");
                //string player1 = Console.ReadLine();
                //Console.WriteLine("Enter the name of the second player:");
                //string player2 = Console.ReadLine();
                //Game game = new Game(player1, player2);
                //game.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
