using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class Player
    {
        private Board board;
        private Ship ship;

        public Player(Board board, Ship ship)
        {
            this.board = new Board();
            this.ship = ship;
        }

        public void PlayerPutShip()
        {
            int row=2;
            char column='A';
            char direction='V';
            /*do
            {
                do
                {
                    Console.WriteLine("Input the row (1 to 10)");
                    row = Convert.ToInt32(Console.ReadLine());
                } while (row < 1 && row > 10);

                do
                {
                    Console.WriteLine("Input the column (A to J)");
                    column = Convert.ToChar(Console.ReadLine());
                } while (column != 'A' && column != 'B' && column != 'C' && column != 'D' && column != 'E' && column != 'F' && column != 'G' && column != 'H' && column != 'I' && column != 'J');
                do
                {
                    Console.WriteLine("Input the direction H (Horizontal) or V (Vertical)");
                    direction = Convert.ToChar(Console.ReadLine());
                } while (direction != 'H' && direction != 'V');

                
            } while (!board.PutShip(row, column, direction, shipi));*/

            board.PutShip(2, 'A', 'H', ship.Battleship);
        }

    }
}
