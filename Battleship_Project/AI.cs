using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Project
{
    internal class AI
    {

        private Board board;
        private Ship ship;
        public AI(Board board, Ship ship)
        {
            this.board = board;
            this.ship = ship;
        }

        public void PlayingAI()
        {
            Random random = new Random();
            int row = random.Next(0, 10);
            int column = random.Next(0, 10);

            Console.WriteLine("row : " + row);
            Console.WriteLine("column : " + column);

            board.Strategy_board[row, column] = 2;

        }
        /*

        bool resultat = etreCoule(ref couleIA, ref emplacementsBateauxJoueur);

        if (resultat)
        { Console.WriteLine("Un de vos navires a coulé"); }
        else
        { Console.WriteLine("Vos navires sont à l'épreuve des obus !"); }

        */
        public void AIPutShip(int[]shipi)
        {
            int row;
            char column;
            char direction;
            do
            {
                Random rand = new Random();
                row = rand.Next(1, 11);
                column = Convert.ToChar(rand.Next(65, 75));

                int d = rand.Next(0, 2);
                if (d == 0) { direction = 'H'; }
                else { direction = 'V'; }

            } while (!board.PutShip(row, column, direction, shipi));

            board.PutShip(row, column, direction, shipi);
        }
    }

}
