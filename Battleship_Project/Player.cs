using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class Player
    {
        private Board board;
        private string name;
        private Ship carrier;
        private Ship cruiser;
        private Ship submarine;
        private Ship destroyer;
        private Ship battleship;
        public Player(Board board, string name)
        {
            this.board = board;
            this.name = name;
            this.carrier = new Carrier();
            this.cruiser = new Cruiser();
            this.submarine = new Submarine();
            this.destroyer = new Destroyer();
            this.battleship = new Battleship();
        }

        public string Name 
        { 
            get { return name; }  
            set { name = value; }
        }

        public Board _Board
        {
            get { return board; }
            set { board = value; }
        }
        public Ship Carrier
        { 
            get { return carrier; } 
        }

        public Ship Cruiser
        {
            get { return cruiser; }
        }

        public Ship Submarine
        {
            get { return submarine; }
        }

        public Ship Destroyer
        {
            get { return destroyer; }
        }

        public Ship Battleship
        {
            get { return battleship; }
        }
        public int Row()
        {
            int row;
            do
            {
                Console.WriteLine("Input the row (1 to 10)");
                row = Convert.ToInt32(Console.ReadLine());
            } while (row < 1 && row > 10);

            return row;
        }

        public char Column()
        {
            char column;
            do
            {
                Console.WriteLine("Input the column (A to J)");
                column = Convert.ToChar(Console.ReadLine());
            } while (column != 'A' && column != 'B' && column != 'C' && column != 'D' && column != 'E' && column != 'F' && column != 'G' && column != 'H' && column != 'I' && column != 'J');
            return column;
        }
        public void PlayerPutShip(int[] shipi)
        {
            int row;
            char column;
            char direction;
            int first = 1;
            do
            {
                if (first != 1) 
                {
                    Console.WriteLine("You can't place here, so replace your ship");
                }

                row=Row();
                column=Column();

                do
                {
                    Console.WriteLine("Input the direction H (Horizontal) or V (Vertical)");
                    direction = Convert.ToChar(Console.ReadLine());
                } while (direction != 'H' && direction != 'V');

                first++;

            } while (!board.PutShip(row, column, direction, shipi));
            board.PutShip(row, column, direction, shipi);
        }
        public void PlayerPlaying(Board enemy)
        {
            Console.WriteLine("\n"+name+", you can attack: ");
            bool attack = false;
            int row;
            int column;
            do
            {
                row = Row() - 1;
                column = Convert.ToInt32(Column()) - 65;

                if (board.Attack_board[row, column] == 0)
                {
                    board.Attack_board[row, column] = 2;
                    attack = true;
                }
                else
                {
                    Console.WriteLine("you already attacked here, please change your attack\n");
                }
            } while (!attack); // Cette condition interdit d'attaquer un endroit qu'on a déjà attaqué
            
          
            // Ici je regarde si j'ai touche le bateau de l'ennemie 
            if (enemy.Strategy_board[row, column] == 1)
            {
                board.Attack_board[row, column] = 3;
                enemy.Strategy_board[row, column] = 3;
            }

        }

    }
}
