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
        private int roro;
        private int coco;
        public AI(Board board)
        {
            this.board = board;
            this.name = "AI";
            this.carrier = new Carrier();
            this.cruiser = new Cruiser();
            this.submarine = new Submarine();
            this.destroyer = new Destroyer();
            this.battleship = new Battleship();
            this.roro = 0;
            this.coco = 0;
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
        public int Roro
        {
            get { return roro; }
            set { this.roro = value; }
        }

        public int Coco
        {
            get { return coco; }
            set { coco = value; }
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

        public bool AIPlaying(Board enemy, bool BateauHit)
        {
            bool attack;
            Random random = new Random();
            int row;
            int column;
            attack = false;
            if (BateauHit == false)
            {
                do
                {
                    row = random.Next(0, 10);
                    column = random.Next(0, 10);


                    if (board.Attack_board[row, column] == 0)
                    {
                        attack = true;
                    }

                } while (!attack || !ProbabilityRandom(row, column)); //evite IA d'attaquer un endroit qu'il a déjà attaqué et vérifie une case sur 2

                board.Attack_board[row, column] = 2;
                roro = row;
                coco = column;

                char CharColumn = Convert.ToChar(column + 65);
                Console.WriteLine("AI attack: " + (row + 1) + CharColumn);


                // Ici je regarde si IA a touche le bateau du joueur
                if (enemy.Strategy_board[row, column] == 1)
                {
                    board.Attack_board[row, column] = 3;
                    enemy.Strategy_board[row, column] = 3;
                    Console.WriteLine("AI hits your ship");
                    BateauHit = true;
                }
                else
                {
                    enemy.Strategy_board[row, column] = 2;
                    Console.WriteLine("AI misses your ship");
                }
            }
            else
            {
                int choice4;
                int choice3;
                int choice2;
                do
                {
                    row = 0;
                    column = 0;
                    choice4 = random.Next(0, 4);
                    choice3 = random.Next(0, 3);
                    choice2 = random.Next(0, 2);
                    if (coco != 0 && coco != 9 && roro != 0 && roro != 9)
                    {
                        if (choice4 == 0) { column = coco; row = roro - 1; }
                        else if (choice4 == 1) { column = coco + 1; row = roro; }
                        else if (choice4 == 2) { column = coco; row = roro + 1; }
                        else { column = coco - 1; row = roro; }
                    }
                    else if (coco == 0)
                    {
                        if (roro != 0 && roro != 9)
                        {
                            if (choice3 == 0) { column = coco; row = roro - 1; }
                            else if (choice3 == 1) { column = coco + 1; row = roro; }
                            else { column = coco; row = roro + 1; }
                        }
                        else if (roro == 0)
                        {
                            if (choice2 == 0) { column = coco + 1; row = roro; }
                            else { column = coco; row = roro + 1; }
                        }
                        else
                        {
                            if (choice2 == 0) { column = coco + 1; row = roro; }
                            else { column = coco; row = roro - 1; }
                        }

                    }
                    else if (coco == 9)
                    {
                        if (roro != 0 && roro != 9)
                        {
                            if (choice3 == 0) { column = coco - 1; row = roro; }
                            else if (choice3 == 1) { column = coco; row = roro + 1; }
                            else { column = coco; row = roro - 1; }
                        }
                        else if (roro == 0)
                        {

                            if (choice2 == 0) { column = coco - 1; row = roro; }
                            else { column = coco; row = roro + 1; }
                        }
                        else
                        {

                            if (choice2 == 0) { column = coco - 1; row = roro; }
                            else { column = coco; row = roro - 1; }
                        }


                    }
                    else if (roro == 0)
                    {
                        if (coco != 0 && coco != 9)
                        {

                            if (choice3 == 0) { column = coco - 1; row = roro; }
                            else if (choice3 == 1) { column = coco; row = roro + 1; }
                            else { column = coco + 1; row = roro; }
                        }
                        else if (coco == 0)
                        {

                            if (choice2 == 0) { column = coco + 1; row = roro; }
                            else { column = coco; row = roro + 1; }
                        }
                        else
                        {

                            if (choice2 == 0) { column = coco; row = roro - 1; }
                            else { column = coco + 1; row = roro; }
                        }
                    }
                    else if (roro == 9)
                    {
                        if (coco != 0 && coco != 9)
                        {

                            if (choice3 == 0) { column = coco - 1; row = roro; }
                            else if (choice3 == 1) { column = coco; row = roro - 1; }
                            else { column = coco + 1; row = roro; }
                        }
                        else if (coco == 0)
                        {

                            if (choice2 == 0) { column = coco + 1; row = roro; }
                            else { column = coco; row = roro - 1; }
                        }
                        else
                        {

                            if (choice2 == 0) { column = coco; row = roro - 1; }
                            else { column = coco - 1; row = roro; }
                        }
                    }

                    if (board.Attack_board[row, column] == 0)
                    {
                        attack = true;
                    }
                } while (!attack);

                board.Attack_board[row, column] = 2;

                char CharColumn = Convert.ToChar(column + 65);
                Console.WriteLine("AI attack: " + (row + 1) + CharColumn);


                // Ici je regarde si IA a touche le bateau du joueur
                if (enemy.Strategy_board[row, column] == 1)
                {
                    board.Attack_board[row, column] = 3;
                    enemy.Strategy_board[row, column] = 3;
                    Console.WriteLine("AI hits your ship");
                    coco = column;
                    roro = row;
                }
                else
                {
                    Console.WriteLine("AI misses your ship");
                    enemy.Strategy_board[row, column] = 2;
                    if (CheckEveryDirection(coco, roro))
                    {
                        BateauHit = false;
                    }
                }

            }

            return BateauHit;
        }

        public bool CheckEveryDirection(int coco, int roro)
        {
            bool check = false;

            if (coco != 0 && coco != 9 && roro != 0 && roro != 9)
            {
                if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco + 1, roro] != 0 && board.Attack_board[coco, roro + 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }

            }
            else if (coco == 0)
            {
                if (roro != 0 && roro != 9)
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco + 1, roro] != 0 && board.Attack_board[coco, roro + 1] != 0) { check = true; }

                }
                else if (roro == 0)
                {
                    if (board.Attack_board[coco + 1, roro] != 0 && board.Attack_board[coco, roro + 1] != 0) { check = true; }

                }
                else
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco + 1, roro] != 0) { check = true; }
                }

            }
            else if (coco == 9)
            {
                if (roro != 0 && roro != 9)
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco, roro + 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }

                }
                else if (roro == 0)
                {
                    if (board.Attack_board[coco, roro + 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }
                }
                else
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }
                }


            }
            else if (roro == 0)
            {
                if (coco != 0 && coco != 9)
                {
                    if (board.Attack_board[coco + 1, roro] != 0 && board.Attack_board[coco, roro + 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }

                }
                else if (coco == 0)
                {
                    if (board.Attack_board[coco + 1, roro] != 0 && board.Attack_board[coco, roro + 1] != 0) { check = true; }
                }
                else
                {
                    if (board.Attack_board[coco, roro + 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }
                }
            }
            else if (roro == 9)
            {
                if (coco != 0 && coco != 9)
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco + 1, roro] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }
                }
                else if (coco == 0)
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco + 1, roro] != 0) { check = true; }
                }
                else
                {
                    if (board.Attack_board[coco, roro - 1] != 0 && board.Attack_board[coco - 1, roro] != 0) { check = true; }
                }
            }

            return check;
        }

        public bool ProbabilityRandom(int row, int column)
        {
            bool check = true;
            int[,] arrayProba = ArrayProba();
            if (arrayProba[row, column] != 1)
            {
                check = false;
            }
            return check;
        }

        public int[,] ArrayProba()
        {
            int k;
            int[,] arrayProba = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arrayProba[i, j] = 0;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0) { k = 1; }
                else { k = 0; }
                for (int j = k; j < 10; j = j + 2)
                {
                    arrayProba[i, j] = 1;

                }
            }

            return arrayProba;
        }


    }

}
