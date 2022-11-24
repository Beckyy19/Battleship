using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace Battleship_Project
{
    internal class Ship
    {
        private int[] carrier;
        private int[] battleship;
        private int[] cruiser;
        private int[] submarine;
        private int[] destroyer;


        public Ship(Board board)
        {
    
            this.carrier = new int[5] { 1, 1, 1, 1, 1 };
            this.battleship = new int[4] { 1, 1, 1, 1 };
            this.cruiser = new int[3] { 1, 1, 1 };
            this.submarine = new int[3] { 1, 1, 1 };
            this.destroyer = new int[2] { 1, 1 };
        }

        public int[] Carrier
        {
            get { return carrier; }
        }

        public int[] Battleship
        {
            get { return battleship; }
        }
        public int[] Cruiser
        {
            get { return cruiser; }
        }
        public int[] Submarine
        {
            get { return submarine; }
        }

        public int[] Destroyer
        {
            get { return destroyer; }
        }
    }
}
