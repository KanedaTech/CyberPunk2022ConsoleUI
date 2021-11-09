using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Encounters
    {
        Player _player;

        static Random rand = new Random();

        public Player Player { get  { return _player; } set { _player = value; } }

        // Print
        //Method types text like typewriter and plays typing sound.
        private static void Print(string text, int speed = 90)
        {
            SoundPlayer soundPlayer = new SoundPlayer("sounds/type2.wav");
            soundPlayer.PlayLooping();
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            soundPlayer.Stop();
            Console.WriteLine();
        }

        // Encounters
        public void FirstEncounter()
        {
            Print("You throw open the door and grab a rusty iron sword, then charge toward your captor!");
            Print("He turns.....");
            Console.ReadKey();
            Combat(false, "Human Rogue", 1, 4);
        }

        public void BasicFightEncounter()
        {
            Console.Clear();
            Print("You turn the corner and there you see an armed cybernetically augmented guard...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public void MechEncounter()
        {
            Console.Clear();
            Print("The doors crash open as you run into the next room. You see a tall CombatMech with ");
            Print("rocket launcher and machine gun arms.");
            Console.ReadKey();
            Combat(false, "CombatMech", 4, 2);
        }

        public void RandomEncounter()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    MechEncounter();
                    break;
            }
        }


        // Encounter tools
        public void Combat(bool random, string name, int power, int health)
        {
                        
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = rand.Next(1, 5);
                h = rand.Next(1, 8);
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("=========================");
                Console.WriteLine(" | (A)ttack  (D)efend  |");
                Console.WriteLine(" |  (R)un     (H)eal   |");
                Console.WriteLine("=========================");
                Console.WriteLine("Pills: " + _player.Pills + " Health: " + _player.Health);

                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // Attack
                    Print("You blazenly take a shot with your CR3-x tech shotgun! The " + n + " fires back at you as you attack!");

                    int damage = p - _player.ArmorValue;
                    int attack = rand.Next(0, _player.WeaponValue) + rand.Next(1, 4);

                    Print("You lose " + damage + " health and deal " + attack + " damage.");

                    _player.Health -= damage;

                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // Defend
                    Print("As the " + n + " prepares to attack, you ready your Sony personal ballistic shield hoping to defend yourself.");

                    int damage = (p / 4) - _player.ArmorValue;

                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    int attack = rand.Next(0, _player.WeaponValue) / 2;

                    Print("You lose " + damage + " health and deal " + attack + " damage.");

                    _player.Health -= damage;

                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // Run
                    if (rand.Next(0, 2) == 0)
                    {
                        Print("As you sprint away from the " + n + ", they fire and catch you in the back sending you sprawling onto the ground.");

                        int damage = p - _player.ArmorValue;

                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Print("You lose " + damage + " health and are unable to escape.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Print("Your athletics are out of this world and you eveade the " + n + " sight and successfully escape!");
                        Console.ReadKey();
                        //go to store
                    }

                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // Heal
                    if (_player.Pills == 0)
                    {
                        Print("As you desperately grasp for a pill in your pocket, all that you feel is lint. Fuck!");

                        int damage = p - _player.ArmorValue;

                        if (damage < 0)
                        {
                            damage = 0;
                        }

                        Print("The " + n + " shoots you with his weapon and you lose " + damage + " health.");
                        _player.Health -= damage;
                    }
                    else
                    {
                        Print("You reach into your bag and pull out a handful of capsules. You POP them!");

                        int pillValue = rand.Next(1,5);

                        Print("You gain " + pillValue + " health");
                        _player.Health += pillValue;
                        _player.Pills -= 1;

                        Print("As you were healing, the " + n + " fired and struck you.");

                        int damage = (p / 2) - _player.ArmorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Print("You lose " + damage + " health.");
                        _player.Health -= damage;

                    }
                    Console.ReadKey();
                }
                if (_player.Health <= 0)
                {
                    //Death Code
                    Console.Clear();
                    Print(n + " lands a fatal blow against you!!!!\n");
                    Print("You are dead.....");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = rand.Next(10, 50);
            Console.Clear();
            Print("As you stand victorious over the " + n + ", you rummage through his pockets and find " + c + " credit chips!");
            _player.CreditChips += c;
            Console.ReadKey();
        }
        public static string GetName()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    return "Low-Level Security Guard";
                case 1:
                    return "" +
                        "NetRunner";
                case 2:
                    return "Tower Security";
                case 3:
                    return "Random Street Thug";
            }
            return "Rival Game Member";
        }
    }
}
