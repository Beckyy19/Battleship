using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Battleship_Project
{
    internal class Game
    {
        /// <summary>
        /// File with all the rules in it
        /// </summary>
        #region Rules
        public static void Rules()
        {
            string rules = System.IO.File.ReadAllText(Path.GetFullPath("Rules.txt"));
            Console.WriteLine(rules);

        }

        static int Number()
        {
            int n;
            do
            {
                n=Convert.ToInt32(Console.ReadLine());  
            } while (n < 1);
            return n;
        }
        #endregion
        static void PlayWithAI()
        {
           

        }

        static void PlayWithPlayer()
        {

            //Joueur 1
            Board board1=new Board();
            Console.WriteLine("Input the name of player 1:");
            string name1 = Convert.ToString(Console.ReadLine());
            Player player1 = new Player(board1,name1);
            Ship carrier1 = new Carrier();
            Ship cruiser1=new Cruiser();
            Ship submarine1 = new Submarine();
            Ship destroyer1=new Destroyer();
            Ship battleship1=new Battleship();  


            //Joueur 2
            Board board2 = new Board();
            Console.WriteLine("Input the name of player 2:");
            string name2 = Convert.ToString(Console.ReadLine());
            Player player2 = new Player(board2,name2);
            Ship carrier2 = new Carrier();
            Ship cruiser2 = new Cruiser();
            Ship submarine2 = new Submarine();
            Ship destroyer2= new Destroyer();
            Ship battleship2 = new Battleship();


            //Initialisation du jeu

            Console.WriteLine(player1.Name+":");
            InitializationGamePlayer(board1, player1, carrier1, cruiser1, submarine1, destroyer1, battleship1);


            Console.WriteLine(player2.Name + ":");
            InitializationGamePlayer(board2, player2, carrier2, cruiser2, submarine2, destroyer2, battleship2);
        }

        static void InitializationGamePlayer(Board board, Player player,Ship carrier,Ship cruiser, Ship submarine, Ship destroyer, Ship battleship)
        {
            board.ToStringStrategy();
            Console.WriteLine("Now Put your ships in your board");

            Console.WriteLine("Put your carrier");
            player.PlayerPutShip(carrier.ship);
            board.ToStringStrategy();

            Console.WriteLine("Put your cruiser");
            player.PlayerPutShip(cruiser.ship);
            board.ToStringStrategy();

            Console.WriteLine("Put your submarine");
            player.PlayerPutShip(submarine.ship);
            board.ToStringStrategy();

            Console.WriteLine("Put your destroyer");
            player.PlayerPutShip(destroyer.ship);
            board.ToStringStrategy();

            Console.WriteLine("Put your battleship");
            player.PlayerPutShip(battleship.ship);
            board.ToStringStrategy();
        }
        static void GamePlayer(Board board, Player player)
        {

        }
        
        static void Main(string[] args)
        {
            Rules();

            Console.WriteLine("Input a number: \n1: PlayerVsComputer \n2: Play with a friend");
            int n = Number();
            switch (n)
            {
                case 1:
                    PlayWithAI();
                    break;
                case 2:
                    PlayWithPlayer();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }




       
    }
}
