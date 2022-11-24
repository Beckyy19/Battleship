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
        public Player(Board board, string name)
        {
            this.board = board;
            this.name = name;
        }

        public string Name 
        { 
            get { return name; } 
            set { name = value; }
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
            do
            {
                row=Row();
                column=Column();

                do
                {
                    Console.WriteLine("Input the direction H (Horizontal) or V (Vertical)");
                    direction = Convert.ToChar(Console.ReadLine());
                } while (direction != 'H' && direction != 'V');

            } while (!board.PutShip(row, column, direction, shipi));
            board.PutShip(row, column, direction, shipi);
        }
        public void PlayerPlaying()
        {
            Console.WriteLine("You can attack: ");
            int row=Row();
            char column=Column();
            board.Attack_board[row, column] = 2;
        }
    }
}
