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
            Ship ship = new Ship(board);
            // AI playerAI = new AI(board,ship);

            // mettre beteau avec AI
            /*playerAI.AIPutShip(ship.Carrier);
            playerAI.AIPutShip(ship.Cruiser);
            playerAI.AIPutShip(ship.Submarine);
            playerAI.AIPutShip(ship.Battleship);
            playerAI.AIPutShip(ship.Destroyer);
            //playerAI.PlayingAI()*/

            // mettre bateau avec Player

            Player playeur = new Player(board,ship);
            playeur.PlayerPutShip();

           
            board.ToStringStrategy();


            //board.ToStringAttack();

            
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
