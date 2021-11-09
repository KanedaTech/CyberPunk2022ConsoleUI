using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player : Entities
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int CreditChips { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public int ArmorValue { get; set; }
        public int Pills { get; set; }
        public int WeaponValue { get; set; }
        public int East { get; set; }
        public int West { get; set; }
        public Item Item { get; set; }


        public Player(string name, string playerClass, int health, int creditChips, int experiencePoints, int level, int armorValue, int pills, int weaponValue) : base(health)
        {
            Name = name;
            Class = playerClass;
            Health = health;
            CreditChips = creditChips;
            ExperiencePoints = experiencePoints;
            Level = level;
            ArmorValue = armorValue;
            Pills = pills;
            WeaponValue = weaponValue;
        }
    }
}
