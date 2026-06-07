using System;

namespace TicTacToe.Exceptions
{
    internal class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message)
        {
            // custom logic here if needed
        }
    }
}
