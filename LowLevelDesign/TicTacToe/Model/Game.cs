using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Exceptions;
using TicTacToe.Strategy;

namespace TicTacToe.Model
{
    internal class Game
    {
        public List<Player> Players { get; set; }
        public Board Board { get; set; }
        public List<Move> Moves { get; set; }
        public Player? Winner { get; set; }
        public GameState GameState { get; set; }
        public int NextMovePlayerIndex { get; set; }
        public List<IWinningStrategy> WinningStrategies { get; set; }


        public Game(int dimension, List<Player> players)
        {
            this.Board = new Board(dimension);
            this.Players = players;
            this.Moves = new List<Move>();
            this.Winner = null;
            this.GameState = GameState.InProgress;
            this.NextMovePlayerIndex = 0;
            this.WinningStrategies = [new RowWinningStrategy(), new ColWinningStrategy(), new DiagonalWinningStrategy()];
        }

        #region public Methods
        /**
         * step1: Get the currentPlayer for whom we would like to make a move.
         * step2: Take Input(row, col) from the player.
         * step3: Validate the input (eg. invalid Row/Col, cell is not empty)
         * step4: Store the move in moves[] and mark the Cell as Filled
         * step5: Increment the nextMovePlayerIndex
         * step6: Check for player win. If player has won, assign the winner to the player.
         */
        public void MakeMove()
        {
            //step1
            Player currentPlayer = this.Players[NextMovePlayerIndex];
            Console.WriteLine("It is player: " + currentPlayer.Name + "'s move");

            //step2
            Move newMove = currentPlayer.GetInputAndMakeMove(this.Board);

            //step3
            if (invalidMove(newMove))
            {
                throw new InvalidMoveException("Move is Invalid!");
            }

            int currRow = newMove.Cell.Row;
            int currCol = newMove.Cell.Col;

            Console.WriteLine("move is made in --> Row: " + currRow + "col: " + currCol);

            Cell currCell = this.Board.Grid[currRow][currCol];
            currCell.CellState = CellState.Filled;
            currCell.Player = currentPlayer;

            //step4
            Move finalMove = new Move(currCell, currentPlayer);
            Moves.Add(finalMove);

            //step5
            NextMovePlayerIndex += 1;
            NextMovePlayerIndex = NextMovePlayerIndex % Players.Count();

            //step6
            if (checkWinner(this.Board, newMove))
            {
                this.Winner = currentPlayer;
                this.GameState = GameState.Win;
            }
            else if(Moves.Count==(this.Board.Size*this.Board.Size))
            {
                this.GameState = GameState.Draw;
            }
        }

        /**
         * Steps for UNDO:
         * 
         * 1. Get the last move from the moves list
         * 2. Remove the last move from the list.
         * 3. Update the cell status to EMPTY and player to null in CELL.
         * 4. Decreament the lastPlayerIndex
         * 5. handle undo in winning strategy.
         */
        public void Undo()
        {
            if (this.Moves.Count() == 0)
            {
                throw new InvalidMoveException("No moves made yet!");
            }

            if (this.GameState != GameState.InProgress)
            {
                throw new InvalidMoveException("Game is not in progress anymore!");
            }

            Move lastMove = this.Moves.Last();
            this.Moves.Remove(lastMove);

            this.NextMovePlayerIndex -= 1;
            this.NextMovePlayerIndex = (this.NextMovePlayerIndex + Players.Count()) % Players.Count();

            foreach(IWinningStrategy winningStrategy in this.WinningStrategies)
            {
                winningStrategy.handleUndo(this.Board, lastMove);
            }

            lastMove.Cell.CellState = CellState.Empty;
            lastMove.Cell.Player = null;
        }
        public void PrintBoard()
        {
            this.Board.printBoard();
        }
        #endregion
        #region private Methods
        //Todo: Implement validations
        private bool invalidMove(Move currentMove)
        {
            /**
             * 
             */
            Cell currMoveCell = this.Board.Grid[currentMove.Cell.Row][currentMove.Cell.Col];
            if (currMoveCell.CellState == CellState.Filled)
            {
                return true;
            }

            return false;
        }

        private bool checkWinner(Board board, Move newMove)
        {
            foreach(IWinningStrategy winningStrategy in this.WinningStrategies)
            {
                if(winningStrategy.CheckWinner(board, newMove))
                {
                    Console.WriteLine("Player has won the game: " + winningStrategy.GetType().Name);
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
