using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rules();

            Board board = new Board();
            board.ToStringStrategy();
            Console.WriteLine();
            board.ToStringAttack();
            Console.ReadKey();
        }

        /// <summary>
        /// File with all the rules in it
        /// </summary>
        #region Rules
        public static void Rules() 
        {
            string rules = System.IO.File.ReadAllText(Path.GetFullPath("Rules.txt"));
            Console.WriteLine(rules);

        }
        #endregion
    }
}
