using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

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
        #endregion

        static int Number()
        {
            int n;
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 1);
            return n;
        }
        static void PlayWithAI()
        {
            //AI
            Board boardAI = new Board();
            string A = "AI";
            AI playerAI = new AI(boardAI);

            //Joueur
            Board boardPlayer=new Board();
            Console.WriteLine("Input the name of player:");
            string name = Convert.ToString(Console.ReadLine());
            Player player = new Player(boardPlayer,name);

            //Initialisation AI
            playerAI.AIPutShip(playerAI.Carrier.ship);
            playerAI.AIPutShip(playerAI.Cruiser.ship);
            playerAI.AIPutShip(playerAI.Submarine.ship);
            playerAI.AIPutShip(playerAI.Destroyer.ship);
            playerAI.AIPutShip(playerAI.Battleship.ship);

            //Initialisation Joueur
            InitializationGamePlayer(boardPlayer, player);

            //Jouer 
            Console.WriteLine("Do you want to start the game:\nTape 1: Yes, I do\nTape 2: No, I don't");
            int choose = Number();
            bool WinAI = false;
            bool WinPlayer = false;

            while (!WinAI && !WinPlayer)
            {
                if(choose == 2)
                {
                    //AI joue
                    playerAI.AIPlaying(boardPlayer);
                    
                    WinAI = WinOrLose(boardPlayer);
                    if (WinAI)
                    {
                        Console.WriteLine(playerAI.Name + " won\n" + player.Name + " lost");
                        Console.WriteLine(player.Name + " board: ");
                        boardPlayer.ToStringStrategy();
                    }
                    
                }

                if (!WinAI)
                {
                    //Joueur 2 joue
                    player.PlayerPlaying(boardAI);
                    boardPlayer.ToStringStrategy();
                    boardPlayer.ToStringAttack();
                    WinPlayer = WinOrLose(boardAI);
                    if (WinPlayer)
                    {
                        Console.WriteLine(player.Name + " won\n" + playerAI.Name + " lost");
                        Console.WriteLine(playerAI.Name + " board: ");
                        boardAI.ToStringStrategy();
                    }
                }
                choose = 2;

            }


        }

        static void PlayWithPlayer()
        {

            //Joueur 1
            Board board1=new Board();
            Console.WriteLine("Input the name of player 1:");
            string name1 = Convert.ToString(Console.ReadLine());
            Player player1 = new Player(board1,name1);
          


            //Joueur 2
            Board board2 = new Board();
            Console.WriteLine("Input the name of player 2:");
            string name2 = Convert.ToString(Console.ReadLine());
            Player player2 = new Player(board2,name2);


            //Initialisation du jeu
            InitializationGamePlayer(board1, player1);
           
            InitializationGamePlayer(board2, player2);


            //Jouer 
            bool WinPlayer1 = false;
            bool WinPlayer2 = false;

            while (!WinPlayer1 && !WinPlayer2)
            {
                //Joueur 1 joue
                player1.PlayerPlaying(board2);
                board1.ToStringStrategy();
                board1.ToStringAttack();
                WinPlayer1 = WinOrLose(board2);
                if (WinPlayer1)
                {
                    Console.WriteLine(player1.Name + " won\n" + player2.Name + " lost");
                    Console.WriteLine(player2.Name + " board: ");
                    board2.ToStringStrategy();
                }

                if (!WinPlayer1)
                {
                    //Joueur 2 joue
                    player2.PlayerPlaying(board1);
                    board2.ToStringStrategy();
                    board2.ToStringAttack();
                    WinPlayer2 = WinOrLose(board1);
                    if (WinPlayer2)
                    {
                        Console.WriteLine(player2.Name + " won\n" + player1.Name + " lost");
                        Console.WriteLine(player1.Name + " board: ");
                        board1.ToStringStrategy();
                    }
                }

            }

        }

        static void InitializationGamePlayer(Board board, Player player)
        {
            Console.WriteLine("\n"+player.Name+":");
            board.ToStringStrategy();
            Console.WriteLine("Now Put your ships in your board");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Put your carrier");
            Console.ResetColor();
            player.PlayerPutShip(player.Carrier.ship);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Put your cruiser");
            Console.ResetColor();
            player.PlayerPutShip(player.Cruiser.ship);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Put your submarine");
            Console.ResetColor();
            player.PlayerPutShip(player.Submarine.ship);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Put your destroyer");
            Console.ResetColor();
            player.PlayerPutShip(player.Destroyer.ship);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Put your battleship");
            Console.ResetColor();
            player.PlayerPutShip(player.Battleship.ship);
            board.ToStringStrategy();
        }
        
        
        static bool WinOrLose(Board ennemy)
        {
            //Méthode qui regarde si tous les bateaux de l'ennemi sont touchés
            bool Win = true;

            for(int i = 0; i < ennemy.Strategy_board.GetLength(0)&&Win; i++)
            {
                for(int j=0;j<ennemy.Strategy_board.GetLength(1);j++)
                {
                    if (ennemy.Strategy_board[i, j] != 0 && ennemy.Strategy_board[i, j] != 3)
                    {
                        Win = false;
                    }
                }
            }
            return Win;
        }
       
        static void Main(string[] args)
        {
            Rules();

            Console.WriteLine("Input a number: \n1: PlayerVsComputer \n2: Play with a friend");
            int n = Number();
            switch (n)
            {
                case 1:
                    PlayWithAI(); //AI N'affiche pas quand ca hit à travailler demain!
                    break;
                case 2:
                    PlayWithPlayer();
                    break;
                default:
                    break;
            }

            //Test
            /*Board board1 = new Board();
            Player player1 = new Player(board1, "ALINE");

            Board board2 = new Board();
            Player player2 = new Player(board2, "REB");

            board1.PutShip(1, 'A', 'V', player1.Submarine.ship);
            board2.PutShip(1, 'A', 'V', player1.Destroyer.ship);

            bool WinPlayer1 = false;
            bool WinPlayer2 = false;

            while (!WinPlayer1 && !WinPlayer2)
            {
                //Joueur 1 joue
                player1.PlayerPlaying(board2);
                board1.ToStringStrategy();
                board1.ToStringAttack();
                WinPlayer1 = WinOrLose(board2);
                if (WinPlayer1)
                {
                    Console.WriteLine(player1.Name + " won\n"+player2.Name+" lost");
                    Console.WriteLine(player2.Name + " board: ");
                    board2.ToStringStrategy();
                }

                if (!WinPlayer1)
                {
                    //Joueur 2 joue
                    player2.PlayerPlaying(board1);
                    board2.ToStringStrategy();
                    board2.ToStringAttack();
                    WinPlayer2 = WinOrLose(board1);
                    if (WinPlayer2)
                    {
                        Console.WriteLine(player2.Name + " won\n" + player1.Name + " lost");
                    }
                }
               
            }
            */
           

            Console.ReadKey();
        }




       
    }
}
