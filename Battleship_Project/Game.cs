using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Media;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows;


namespace Battleship_Project
{
    internal class Game
    {
        static void Main(string[] args)
        {


            GameSetting();
          

            //Test
            /*Board board1 = new Board();
             Player player1 = new Player(board1, "ALINE");

             Board board2 = new Board();
             Player player2 = new Player(board2, "REB");

             string des= player1.PlayerPutShip(player1.Destroyer.ship);
             IndexShip(des, player1.Destroyer);

             string sub = player2.PlayerPutShip(player2.Destroyer.ship);
             IndexShip(sub, player2.Destroyer);

             bool WinPlayer1 = false;
             bool WinPlayer2 = false;

             while (!WinPlayer1 && !WinPlayer2)
             {
                 //Joueur 1 joue
                 player1.PlayerPlaying(board2);
                 board1.ToStringStrategy();
                 board1.ToStringAttack();
                 CheckShipHit(board2, player2);
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
                     CheckShipHit(board1, player1);
                     WinPlayer2 = WinOrLose(board1);
                     if (WinPlayer2)
                     {
                         Console.WriteLine(player2.Name + " won\n" + player1.Name + " lost");
                     }
                 }

             }*/
            
            //Test 2

           /* Board board1 = new Board();
            Player player1 = new Player(board1, "ALINE");
            string desa = player1.PlayerPutShip(player1.Carrier.ship);




            Board boardAI = new Board();
            AI playerAI=new AI  (boardAI);
            bool BateauHit = false;
            string car = playerAI.AIPutShip(playerAI.Carrier.ship);
            IndexShip(car, playerAI.Carrier);
            string cru = playerAI.AIPutShip(playerAI.Cruiser.ship);
            IndexShip(cru, playerAI.Cruiser);
            string sub = playerAI.AIPutShip(playerAI.Submarine.ship);
            IndexShip(sub, playerAI.Submarine);
            string des = playerAI.AIPutShip(playerAI.Destroyer.ship);
            IndexShip(des, playerAI.Destroyer);
            string bat = playerAI.AIPutShip(playerAI.Battleship.ship);
            IndexShip(bat, playerAI.Battleship);
            board1.ToStringStrategy();
            int aaa;
            do
            {
                BateauHit = playerAI.AIPlaying(board1, BateauHit);
                boardAI.ToStringAttack();





                aaa = Convert.ToInt32(Console.ReadLine());


            }while(aaa != 0);*/
            Console.ReadKey();
        }

        public static void GameSetting()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------- Welcome to the Battleship--------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1: PlayerVsComputer \n2: Play with a friend \n3: See the rules \n4: Play a back-up of a game against the AI\n5: Exit the game\n\n");
            Console.Write("Enter a number : ");
            string n = Number();

            switch (n)
            {
                case "1":
                    Console.Clear();
                    PlayWithAI();
                    break;
                case "2":
                    Console.Clear();
                    PlayWithPlayer();
                    break;
                case "3":
                    LoadingPage();
                    Console.WriteLine("\n The rules are ready.");
                    Console.WriteLine("Please press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    Rules();
                    Console.ReadKey();
                    Console.Clear();
                    GameSetting();

                    break;

                case "4":

                    PlayWithAI_Back_Up();

                    Console.ReadKey();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// File with all the rules in it
        /// </summary>
        /// 

        #region Rules
        public static void Rules()
        {
            string rules = System.IO.File.ReadAllText(Path.GetFullPath("Rules.txt"));
            Console.WriteLine(rules + "\n\n");
            Console.WriteLine("Enter a keyword to comeback to the main");

        }
        #endregion

        /// <summary>
        /// Enter a number for the main of the game
        /// </summary>
        /// <returns>istring number</returns>

        static string Number()
        {
            string n;
            do
            {
                n = Convert.ToString(Console.ReadLine());
            } while (n == "");
            return n;
        }

        /// <summary>
        /// Method to do the animation of the loading page
        /// </summary>

        static void LoadingPage()
        {
            Console.Write("|");
            for (int i = 0; i <= 10; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    Console.Write("=");
                }
                Console.Write("> {0}0%", i);
                Console.SetCursorPosition(1, Console.BufferHeight - 1);
                System.Threading.Thread.Sleep(100);
            }
        }

        static void BackUp_Against_AI(Board boardPlayer, Board boardAI, Player player, string choose)
        {

              StreamWriter file = new StreamWriter(Path.GetFullPath("sauvegarde.txt"));
            // Ecriture des emplacementsIA dans un fichier save.txt

            file.Write(player.Name+" ");
            file.Write(choose+" ");


              for (int i = 0; i < 10; i++)
              {
                  for (int j = 0; j < 10; j++)
                  {
                      file.Write(boardPlayer.Strategy_board[i, j]+" ");
                  }
              }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    file.Write(boardAI.Strategy_board[i, j] + " ");
                }
            }

            // Fin d'écriture dans le fichier
            file.Close();

              LoadingPage();
              Console.WriteLine("\n The save has been done.");
              Console.WriteLine("Please press any key to continue.");
              Console.ReadKey();

                Console.Clear();

                GameSetting();
        }


        static void PlayWithAI_Back_Up()
        {
            string texte = File.ReadAllText("sauvegarde.txt");
            string[] texte2 = texte.Split(' ');

            Console.Clear();

            Board sauvegardePlayer = new Board();
            Player sauvegarderPlayer = new Player(sauvegardePlayer, texte2[0]);

            Board sauvegarderIA = new Board();
            AI playerAI = new AI(sauvegarderIA);

            int compteur = 2;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sauvegardePlayer.Strategy_board[i, j] = Convert.ToInt32(texte2[compteur]);
                    compteur++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sauvegarderIA.Strategy_board[i, j] = Convert.ToInt32(texte2[compteur]);
                    compteur++;
                }
            }

            LoadingPage();
            Console.WriteLine("\n The game is ready.");
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome back to the game !\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("This is"+sauvegarderPlayer.Name+"'s board \n");


            sauvegardePlayer.ToStringStrategy();
            sauvegardePlayer.ToStringAttack();

            Console.WriteLine("\nThis is IA's board \n");


            sauvegarderIA.ToStringStrategy();
            sauvegarderIA.ToStringAttack();



            
            bool WinAI = false;
            bool WinPlayer = false;
            bool BateauHit = false;

            string choose = texte2[1];

            while (!WinAI && !WinPlayer)
            {
                if (choose == "2")
                {
                    //AI joue
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("IA's turn : \n");
                    Console.ForegroundColor = ConsoleColor.White;

                    BateauHit = playerAI.AIPlaying(sauvegardePlayer, BateauHit);
                    CheckShipHit(sauvegardePlayer, sauvegarderPlayer);
                    WinAI = WinOrLose(sauvegardePlayer);

                    Console.WriteLine("\n");
                    sauvegardePlayer.ToStringStrategy();
                    sauvegardePlayer.ToStringAttack();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();



                    if (WinAI)
                    {
                        Console.Clear();
                        Console.WriteLine(playerAI.Name + " won\n" + sauvegarderPlayer.Name + " lost");
                        Console.WriteLine(sauvegarderPlayer.Name + " board: ");
                        sauvegardePlayer.ToStringStrategy();
                        Console.Clear();
                        GameSetting();
                    }

                }

                if (!WinAI)
                {
                    //Joueur 2 joue


                    sauvegarderPlayer.PlayerPlaying(sauvegarderIA);

                    Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(sauvegarderPlayer.Name + "'s board : \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    sauvegardePlayer.ToStringStrategy();
                    sauvegardePlayer.ToStringAttack();

                    CheckShipHitAI(sauvegarderIA, playerAI);
                    WinPlayer = WinOrLose(sauvegarderIA);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                    if (WinPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine(sauvegarderPlayer.Name + " won\n" + playerAI.Name + " lost");
                        Console.WriteLine(playerAI.Name + " board: ");
                        sauvegarderIA.ToStringStrategy();
                        Console.Clear();
                        GameSetting();
                    }
                }
                choose = "2";

            }
            
        }


        /// <summary>
        /// Method to play alone against the AI
        /// </summary>
        static void PlayWithAI()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have chosen to play against the AI !");
            Console.ForegroundColor = ConsoleColor.White;

            //AI
            Board boardAI = new Board();
            AI playerAI = new AI(boardAI);

            //Player
            Board boardPlayer=new Board();
            Console.Write("What is your name ? : ");
            string name = Convert.ToString(Console.ReadLine());
            Player player = new Player(boardPlayer,name);

            //Initialisation AI
            string car = playerAI.AIPutShip(playerAI.Carrier.ship);
            IndexShip(car, playerAI.Carrier);
            string cru = playerAI.AIPutShip(playerAI.Cruiser.ship);
            IndexShip(cru, playerAI.Cruiser);
            string sub = playerAI.AIPutShip(playerAI.Submarine.ship);
            IndexShip(sub, playerAI.Submarine);
            string des = playerAI.AIPutShip(playerAI.Destroyer.ship);
            IndexShip(des, playerAI.Destroyer);
            string bat = playerAI.AIPutShip(playerAI.Battleship.ship);
            IndexShip(bat, playerAI.Battleship);

            LoadingPage();


            //Initialisation Joueur
            InitializationGamePlayer(boardPlayer, player);

            Console.Write("This is your game\n");

            Console.Clear();

            boardPlayer.ToStringStrategy();
            boardPlayer.ToStringAttack();

            //WHO is the first to play
            Console.WriteLine("Do you want to start the game:\nTape 1: Yes, I do\nTape 2: No, I don't");

            string choose = Number();
            
            bool WinAI = false;
            bool WinPlayer = false;
            bool BateauHit = false;

            int Counter = 0;

            while (!WinAI && !WinPlayer)
            {
                if(choose == "2")
                {
                    //AI joue
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("IA's turn : \n");
                    Console.ForegroundColor = ConsoleColor.White;

                    BateauHit =playerAI.AIPlaying(boardPlayer,BateauHit);
                    CheckShipHit(boardPlayer, player);
                    WinAI = WinOrLose(boardPlayer);

                    Console.WriteLine("\n");
                    boardPlayer.ToStringStrategy();
                    boardPlayer.ToStringAttack();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    


                    if (WinAI)
                    {
                        Console.Clear();
                        Console.WriteLine(playerAI.Name + " won\n" + player.Name + " lost");
                        Console.WriteLine(player.Name + " board: ");
                        boardPlayer.ToStringStrategy();
                        Console.Clear();
                        GameSetting();
                    }
                    
                }

                if (!WinAI)
                {
                    //Joueur 2 joue


                    player.PlayerPlaying(boardAI);

                    Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(player.Name+"'s board : \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    boardPlayer.ToStringStrategy();
                    boardPlayer.ToStringAttack();

                    CheckShipHitAI(boardAI, playerAI);
                    WinPlayer = WinOrLose(boardAI);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    
                    if (WinPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine(player.Name + " won\n" + playerAI.Name + " lost");
                        Console.WriteLine(playerAI.Name + " board: ");
                        boardAI.ToStringStrategy();
                        Console.Clear();
                        GameSetting();
                    }
                }
                choose = "2";

                Counter++;

                if (Counter == 1)
                {
                    Console.WriteLine("Do you want to save the game : y for yes or n for no ?");

                    char answer = Convert.ToChar(Console.ReadLine());

                    if(answer == 'y')
                    {
                        BackUp_Against_AI(boardPlayer,boardAI, player, choose);
                        break;
                    }

                    Counter = 0;
                }

                

            }
        }

        static void PlayWithPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have chosen to play against another player !");
            Console.ForegroundColor = ConsoleColor.White;

            //Joueur 1
            Board board1=new Board();
            Console.Write("What is your name player1 ? : ");
            string name1 = Convert.ToString(Console.ReadLine());
            Player player1 = new Player(board1,name1);
          


            //Joueur 2
            Board board2 = new Board();
            Console.Write("What is your name player2 ? : ");
            string name2 = Convert.ToString(Console.ReadLine());
            Player player2 = new Player(board2,name2);


            //Initialisation du jeu
            Console.Clear();
            Console.WriteLine("Press any key to initialize your board " + player1.Name);
            Console.ReadKey();
            InitializationGamePlayer(board1, player1);


            Console.Clear();
            Console.WriteLine("Press any key to initialize your board " + player2.Name);
            Console.ReadKey();

            InitializationGamePlayer(board2, player2);


            Console.Clear();
            Console.WriteLine(player1.Name+", do you want to start the game:\nTape 1: Yes, I do\nTape 2: No, I don't");

            string choose = Number();
            //Jouer 
            bool WinPlayer1 = false;
            bool WinPlayer2 = false;

            while (!WinPlayer1 && !WinPlayer2)
            {
                if (choose == "1")
                {
                    //Joueur 1 joue
                    Console.Clear();
                    Console.WriteLine(player1.Name + " : press any key to play ");
                    Console.ReadKey();
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(player1.Name + "'s turn : \n\n");
                    Console.ResetColor();


                    board1.ToStringStrategy();
                    board1.ToStringAttack();


                    player1.PlayerPlaying(board2);

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(player1.Name + "'s turn : \n\n");
                    Console.ResetColor();

                    board1.ToStringStrategy();
                    board1.ToStringAttack();

                    Console.Write("Press any key to continue");
                    Console.ReadKey();

                    CheckShipHit(board2, player2);
                    WinPlayer1 = WinOrLose(board2);

                    if (WinPlayer1)
                    {
                        Console.Clear();
                        Console.WriteLine(player1.Name + " won\n" + player2.Name + " lost");
                        Console.WriteLine(player2.Name + " board: ");
                        board2.ToStringStrategy();
                        Console.Clear();
                        GameSetting();
                    }
                    else
                    {
                        choose = "2";
                    }
                }
                
                if (!WinPlayer1 && choose == "2")
                {
                    //Joueur 2 joue

                    Console.Clear();
                    Console.WriteLine(player2.Name + " : press any key to play ");
                    Console.ReadKey();
                    Console.Clear();

                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(player2.Name + "'s turn : \n\n");
                    Console.ResetColor();

                    board2.ToStringStrategy();
                    board2.ToStringAttack();

                    player2.PlayerPlaying(board1);

                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(player2.Name + "'s turn : \n\n");
                    Console.ResetColor();
                    board2.ToStringStrategy();
                    board2.ToStringAttack();

                    Console.Write("Press any key to continue");
                    Console.ReadKey();

                    CheckShipHit(board1, player1);
                    WinPlayer2 = WinOrLose(board1);

                    if (WinPlayer2)
                    {
                        Console.Clear();
                        Console.WriteLine(player2.Name + " won\n" + player1.Name + " lost");
                        Console.WriteLine(player1.Name + " board: ");
                        board1.ToStringStrategy();
                        Console.Clear();
                        GameSetting();
                        break;
                    }
                    else
                    {
                        choose = "1";
                    }
                }

            }

            /*
            while (!WinPlayer1 && !WinPlayer2)
            {
                //Joueur 1 joue
                player1.PlayerPlaying(board2);

                Console.Clear();
                Console.WriteLine(player2.Name + "'s board : \n\n");
                board1.ToStringStrategy();
                board1.ToStringAttack();

                CheckShipHit(board2, player2);
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

                    Console.Clear();
                    Console.WriteLine(player2.Name + "'s board : \n\n");
                    board2.ToStringStrategy();
                    board2.ToStringAttack();

                    CheckShipHit(board1, player1);
                    WinPlayer2 = WinOrLose(board1);
                    if (WinPlayer2)
                    {
                        Console.WriteLine(player2.Name + " won\n" + player1.Name + " lost");
                        Console.WriteLine(player1.Name + " board: ");
                        board1.ToStringStrategy();
                    }
                }
            
            }
            */
            

        }


        static void InitializationGamePlayer(Board board, Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Hello " + player.Name + " !\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("This is your game :\n\n");

            board.ToStringStrategy();

            board.ToStringAttack();

            Console.WriteLine("To begin the game, let's put your 5 ships in the strategy board\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Put your carrier (size of 5 squares)");
            Console.ForegroundColor = ConsoleColor.White;

            string car=player.PlayerPutShip(player.Carrier.ship);
            IndexShip(car, player.Carrier);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Great ! Put your cruiser (size of 3 squares)");
            Console.ForegroundColor = ConsoleColor.White;
            string cru=player.PlayerPutShip(player.Cruiser.ship);
            IndexShip(cru, player.Cruiser);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Great ! Put your submarine (size of 3 squares)");
            Console.ForegroundColor = ConsoleColor.White;
            string sub=player.PlayerPutShip(player.Submarine.ship);
            IndexShip(sub, player.Submarine);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Great ! Put your destroyer (size of 2 squares)");
            Console.ForegroundColor = ConsoleColor.White;
            string des=player.PlayerPutShip(player.Destroyer.ship);
            IndexShip(des, player.Destroyer);
            board.ToStringStrategy();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Great ! Put your battleship (size of 4 squares)");
            Console.ForegroundColor = ConsoleColor.White;
            string bat=player.PlayerPutShip(player.Battleship.ship);
            IndexShip(bat, player.Battleship);
            board.ToStringStrategy();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void IndexShip(string shipPlaceInfo, Ship ship)
        {
            int row;
            int column;
            char direction;

            if (shipPlaceInfo.Length == 4)
            {

                row = 9;
                column = Convert.ToInt32(shipPlaceInfo[2] - 65);
                direction = shipPlaceInfo[3];


            }
            else
            {

                row = Convert.ToInt32(shipPlaceInfo[0]) - 49;//ASCII string 1 = int 49-48=1, or dans un tableau la ligne 0 correspond à la ligne de mon board 
                column = Convert.ToInt32(shipPlaceInfo[1] - 65);
                direction = shipPlaceInfo[2];

            }

            ship.row = row;
            ship.column = column;
            ship.direction = direction;
        }

        static void CheckShipHit(Board boardEnemy, Player enemy)
        {

            //Faire un compteur du nombre de bateau restant a faire couler + prévenir le joueur que son bateau est coulé 
            if (ShipHit(boardEnemy, enemy.Carrier))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Carrier.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Cruiser))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Cruiser.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Submarine))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Submarine.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Destroyer))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Destroyer.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Battleship))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Battleship.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else { }
       
        }

        static void CheckShipHitAI(Board boardEnemy, AI enemy)
        {
            if (ShipHit(boardEnemy, enemy.Carrier))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name+"'s "+enemy.Carrier.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Cruiser))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Cruiser.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Submarine))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Submarine.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Destroyer))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Destroyer.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else if (ShipHit(boardEnemy, enemy.Battleship))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.Name + "'s " + enemy.Battleship.Name + " is hit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else { }

        }
        static bool ShipHit(Board boardEnemy, Ship shipEnemy)
        {
            int row=shipEnemy.row;
            int column=shipEnemy.column;    
            char direction=shipEnemy.direction;
            bool hit = true;
            if (direction == 'H')
            {
                for(int i = 0; i < shipEnemy.length &&hit; i++)
                {
                    if (boardEnemy.Strategy_board[row, i] != 3)
                    {
                        hit = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < shipEnemy.length&&hit; i++)
                {
                    if (boardEnemy.Strategy_board[i, column] != 3)
                    {
                        hit = false;
                    }
                }
            }
            
            return hit;
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
       
       
    }
}
