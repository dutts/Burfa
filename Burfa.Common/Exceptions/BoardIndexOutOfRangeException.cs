using System;

namespace Burfa.Common.Exceptions
{
    public class BoardIndexOutOfRangeException : Exception
    {
        public BoardIndexOutOfRangeException(string message) : base(message)
        {
        }
    }
}