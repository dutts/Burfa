using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Common.Exceptions
{
    public class BoardIndexOutOfRangeException : Exception
    {
        public BoardIndexOutOfRangeException(string message) : base(message)
        {
        }
    }
}
