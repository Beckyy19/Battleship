using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class Board
    {
        private int[,] strategy_board;
        private int[,] attack_board;


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
            Console.WriteLine("  A\tB\tC\tD\tE\tF\tG\tH\tI\tJ"); //Coordonnées
            for (int i = 0; i < this.strategy_board.GetLength(0); i++)
            {
                Console.Write(i + " ");

                for (int j = 0; j < this.strategy_board.GetLength(1); j++)
                {
                    if (this.Strategy_board[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("| \t");
                    }
                    else
                    {
                        Console.Write(this.strategy_board[i, j] + "\t");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        /* Console.ResetColor();
           Console.BackgroundColor = ConsoleColor.Black;
           Console.ForegroundColor = ConsoleColor.White;*/

        public void ToStringAttack()
        {
            Console.WriteLine("\tA\tB\tC\tD\tE\tF\tG\tH\tI\tJ"); //Coordonnées

            for (int i = 0; i < this.attack_board.GetLength(0); i++)
            {
                for (int j = 0; j < this.attack_board.GetLength(1); j++)
                {
                    Console.Write(this.attack_board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }



    }
}
