using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace Battleship_Project
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public int [] ship { get; set; }

        public int length { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public char direction { get; set; }
        
    }

    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            ship = new int[5] { 1, 1, 1, 1, 1 };
            length = 5;
            row = 0;
            column = 0;
            direction = ' ';
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            ship = new int[3] { 1, 1, 1 };
            length=3;
            row = 0;
            column = 0;
            direction = ' ';
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            ship = new int[2] { 1, 1 };
            length=2;
            row = 0;
            column = 0;
            direction = ' ';
        }
    }

    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarines";
            ship = new int[3] { 1, 1, 1 };
            length=3;
            row = 0;
            column = 0;
            direction = ' ';
        }
    }
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            ship = new int[4] { 1, 1, 1, 1 };
            length = 4;
            row = 0;
            column = 0;
            direction = ' ';
        }
    }
}
