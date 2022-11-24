using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class Board
    {
        private int[,] strategy_board; //plateau où on place les bateaux
        private int[,] attack_board; // plateau où on attaque l'adversaire


        //Constructor
        public Board()
        {
            this.strategy_board = new int[10, 10];

            for (int i = 0; i < this.strategy_board.GetLength(0); i++)
            {
                for (int j = 0; j < this.strategy_board.GetLength(1); j++)
                {
                    this.strategy_board[i, j] = 0; //Initialazing the board
                }
            }

            this.attack_board = new int[10, 10];

            for (int i = 0; i < this.attack_board.GetLength(0); i++)
            {
                for (int j = 0; j < this.attack_board.GetLength(1); j++)
                {
                    this.attack_board[i, j] = 0; //Initialazing the board
                }
            }
        }

        //Properties
        public int[,] Strategy_board
        {
            get {return this.strategy_board ;} 
            set {this.strategy_board = value;}
        }

        public int[,] Attack_board
        {
            get { return this.attack_board; }
            set { this.attack_board = value; }
        }

        public void ToStringStrategy()
        {
            Console.WriteLine("Strategy board ");
            Console.WriteLine("    A  B  C  D  E  F  G  H  I  J"); //Coordonnées
            Console.WriteLine("  -------------------------------");

            for (int i = 0; i < this.strategy_board.GetLength(0); i++)
            {
                if (i + 1 < 10)
                {
                    Console.Write(i + 1 + " |");
                }
                else
                {
                    Console.Write(i + 1 + "|");
                }
                

                for (int j = 0; j < this.strategy_board.GetLength(1); j++)
                {
                    if (this.Strategy_board[i, j] == 0)
                    {
                        //Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("  |");
                    }
                    else
                    {
                        Console.Write(" "+this.strategy_board[i,j] +"|");
                    }
                    //Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("  -------------------------------");
        }

        /* Console.ResetColor();
           Console.BackgroundColor = ConsoleColor.Black;
           Console.ForegroundColor = ConsoleColor.White;*/

        public void ToStringAttack()
        {
            Console.WriteLine("Attack board");
            Console.WriteLine("    A  B  C  D  E  F  G  H  I  J"); //Coordonnées
            Console.WriteLine("  -------------------------------");

            for (int i = 0; i < this.attack_board.GetLength(0); i++)
            {
                if (i + 1 < 10)
                {
                    Console.Write(i + 1 + " |");
                }
                else
                {
                    Console.Write(i + 1 + "|");
                }
                for (int j = 0; j < this.attack_board.GetLength(1); j++)
                {
                    if (this.attack_board[i, j] == 0)
                    {
                        //Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("  |");
                    }
                    else
                    {
                        Console.Write(" ¤ ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  -------------------------------");
        }

        // Methode pour placer un bateau
        public bool PutShip(int row, char charColumn, char direction, int[] ship)
        {
            bool done = true;
            int column=ConvertStringColumnToIntColumn(charColumn);
            row -= 1; // comme ca on peut appeler la ligne de 1 à 10 au lieu de 0 à 9

            if (direction == 'H')
            {
                done = CheckHorizontal(row, column, ship);
                for (int i = 0; i<ship.Length && done; i++)
                {
                    strategy_board[row, column + i] = ship[i];
                }
            }
            else
            {
                done = CheckVertical(row, column, ship);
                for (int i = 0; i < ship.Length && done; i++)
                {
                    strategy_board[row+i, column] = ship[i];
                }

            }
            return done;
        }
        public int ConvertStringColumnToIntColumn(char charColumn)
        {
            int column= Convert.ToInt32(charColumn)-65;
            return column;
        }

        public bool CheckHorizontal(int row, int column, int[] ship)
        {
            bool ok = true;

            // Vérifie si le bateau sort du tableau
            if (column + ship.Length - 1 > 9)
            {
                ok = false;
            }
            
            for (int i=0; i < ship.Length && ok; i++)
            {
                // vérifie la ou on écrit s'il y a déjà un bâteau
                if (strategy_board[row, column + i]==1)
                {
                    ok = false;
                }

                // vérifie les 2 côtés horizontales par rapport au bateau
                if (row < 9)
                {
                    if (strategy_board[row + 1, column + i] == 1)
                    {
                        ok = false;
                    }
                }

                if (row > 0)
                {
                    if (strategy_board[row - 1, column + i] == 1)
                    {
                        ok = false;
                    }
                }
            }


            // Vérifie l'extrémité gauche du bateau
            if (ok && column!=0)
            {
                if (strategy_board[row, column - 1] == 1)
                {
                    ok = false;
                }

                if (ok && row != 0)
                {
                    if (strategy_board[row - 1, column - 1] == 1)
                    {
                        ok = false;
                    }
                }

                if (ok && row != 9)
                {
                    if (strategy_board[row + 1, column - 1] == 1)
                    {
                        ok = false;
                    }
                }
            }

            //Vérifie l'extrémité droite du bateau
            if (ok && column+ship.Length-1 != 9)
            {
                if (strategy_board[row, column + ship.Length] == 1)
                {
                    ok = false;
                }
                if (ok && row != 0)
                {
                    if (strategy_board[row - 1, column + ship.Length] == 1)
                    {
                        ok = false;
                    }
                }

                if (ok && row != 9)
                {
                    if (strategy_board[row + 1, column + ship.Length] == 1)
                    {
                        ok = false;
                    }
                }

            }           
            return ok;
        }


        // Meme principe que CheckHorizontal
        public bool CheckVertical(int row, int column, int[] ship)
        {
            bool ok = true;

            if (row + ship.Length - 1 > 9)
            {
                ok = false;
            }

            for (int i = 0; i < ship.Length && ok; i++)
            {
                if (strategy_board[row + i, column] == 1)
                {
                    ok = false;
                }

                if (column < 9)
                {
                    if (strategy_board[row + i, column + 1] == 1)
                    {
                        ok = false;
                    }

                }

                if (column > 0)
                {
                    if (strategy_board[row + i, column - 1] == 1)
                    {
                        ok = false;
                    }
                }
            }

            if (ok && row!= 0)
            {
                if (strategy_board[row-1, column] == 1)
                {
                    ok = false;
                }

                if (ok && column != 0)
                {
                    if (strategy_board[row - 1, column - 1] == 1)
                    {
                        ok = false;
                    }
                }

                if (ok && column != 9)
                {
                    if (strategy_board[row - 1, column + 1] == 1)
                    {
                        ok = false;
                    }
                }
            }

            if (ok && row + ship.Length - 1 != 9)
            {
                if (strategy_board[row + ship.Length, column] == 1)
                {
                    ok = false;
                }

                if (ok && column != 0)
                {
                    if (strategy_board[row + ship.Length, column - 1] == 1)
                    {
                        ok = false;
                    }
                }

                if (ok && column != 9)
                {
                    if (strategy_board[row + ship.Length, column + 1] == 1)
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }
    }
}
