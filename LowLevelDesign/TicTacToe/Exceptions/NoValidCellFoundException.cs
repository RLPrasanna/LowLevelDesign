using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Exceptions
{
    internal class NoValidCellFoundException : Exception
    {
        public NoValidCellFoundException(string message): base(message)
        {
            
        }
    }
}
