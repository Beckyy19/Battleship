using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.ToStringStrategy();

            Console.ReadKey();
        }
    }
}
