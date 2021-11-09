using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Entities
    {
        public int Health { get; set; }

        public Entities(int health)
        {
            Health = health;
        }
    }
}
