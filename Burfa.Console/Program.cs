using Burfa.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burfa.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new GameEngine();
            while (true)
            {
                var key = System.Console.ReadKey();
                System.Console.WriteLine(key);
            }
        }
    }
}
