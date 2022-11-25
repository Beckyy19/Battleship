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
        private string name;
        private Ship carrier;
        private Ship cruiser;
        private Ship submarine;
        private Ship destroyer;
        private Ship battleship;
        public AI(Board board)
        {
            this.board = board;
            this.name = "AI";
            this.carrier = new Carrier();
            this.cruiser = new Cruiser();
            this.submarine = new Submarine();
            this.destroyer = new Destroyer();
            this.battleship = new Battleship();
        }

        public string Name { get { return name; } }

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
        public string AIPutShip(int[]shipi)
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
            return "" + row + column + direction;
        }

        public void AIPlaying(Board enemy)
        {
            bool attack = false;
            Random random = new Random();
            int row;
            int column;

            do
            {
                row = random.Next(0, 10);
                column = random.Next(0, 10);

                if (board.Attack_board[row, column] == 0)
                {
                    board.Attack_board[row, column] = 2;
                    attack = true;
                }
            } while (!attack); //evite IA d'attaquer un endroit qu'il a déjà attaqué

            char CharColumn = Convert.ToChar(column + 65);
            Console.WriteLine("AI attack: " +(row+1)+ CharColumn);


            // Ici je regarde si IA a touche le bateau du joueur
            if (enemy.Strategy_board[row, column] == 1)
            {
                board.Attack_board[row, column] = 3;
                enemy.Strategy_board[row, column] = 3;
                Console.WriteLine("AI hits your ship");
            }
            else
            {
                Console.WriteLine("AI misses your ship");
            }
        }
        
    }

}
