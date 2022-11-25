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

        
    }

    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            ship = new int[5] { 1, 1, 1, 1, 1 };
           
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            ship = new int[3] { 1, 1, 1 };
            
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            ship = new int[2] { 1, 1 };
            
        }
    }

    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarines";
            ship = new int[3] { 1, 1, 1 };
            
        }
    }
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            ship = new int[4] { 1, 1, 1, 1 };
        }
    }
}
