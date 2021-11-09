using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Location
    {
        Player _player;

        static Random rand = new Random();

        public Player Player { get { return _player; } set { _player = value; } }

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

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int East { get; set; }
        public int West { get; set; }
        public Item KeyCard { get; set; }

        

        public void Level1(Player _player)
        {
            Encounters encounter = new Encounters();

            encounter.Player = _player;

            Location level1 = new Location();
            level1.ID = 1;
            level1.Name = "Kaneda Tower Floor 1";
            level1.Description = "Financing";

            bool canMove = true;
            bool canMoveEast = true;
            bool canMoveWest = true;

            
            Console.Clear();
            Print($"This is {level1.Name}, {level1.Description}. " + "Lets take a look around.");
            Console.ReadKey();   


            while (canMove)
            {
                Console.Clear();
                Print("Which direction would you like to move (e)ast or (w)est?");

                string userInput = Console.ReadLine();
                userInput.ToLower();

                if (userInput == "e" && canMove && canMoveEast)
                {
                    level1.East = 1;
                    _player.East = 1;

                    while (canMoveEast)
                    {
                        if (level1.East == 1)
                        {
                            Console.Clear();
                            Print("You move east down the corridor.");
                            Console.ReadKey();
                            encounter.BasicFightEncounter();
                            Console.Clear();
                            Print("Which direction would you like to move (e)ast or (w)est?");
                            userInput = Console.ReadLine();
                            userInput.ToLower();
                            level1.East += 1;

                        }
                        else if (level1.East == 2)
                        {
                            Console.Clear();
                            Print("You move further east down the corridor. There is nothing of interest here.");
                            Console.ReadKey();
                            Console.Clear();
                            Print("Which direction would you like to move (e)ast or (w)est?");
                            userInput = Console.ReadLine();
                            userInput.ToLower();
                            level1.East += 1;
                            
                        }
                        else if (level1.East == 3)
                        {
                            Console.Clear();
                            Print("You move further east down the corridor.");
                            encounter.BasicFightEncounter();
                            Console.Clear();
                            Print("You can't move east any further.");
                            canMoveEast = false;
                            Console.Clear();
                            Print("Which direction would you like to move (e)ast or (w)est?");
                            userInput = Console.ReadLine();
                            userInput.ToLower();
                        }
                        else if (level1.East > 3)
                        {
                            Print("You can't move east any further.");
                            canMoveEast = false;
                            Console.Clear();
                            Print("Which direction would you like to move (e)ast or (w)est?");
                            userInput = Console.ReadLine();
                            userInput.ToLower();
                        }
                    }
                }
                else if (userInput == "w" && canMove && canMoveWest)
                {
                    level1.West = 1;
                    _player.West = 1;


                    Print("You move to the west down the hallway.");
                    Item keyCard = new Item(1, "Floor 2 Key Card", "Key Card needed to reach floor 2 from the elevator.");
                    _player.Item = keyCard;

                    Print($"You've found {keyCard.Name}. {keyCard.Description}");
                    canMove = false;
                    canMoveWest = false; 
                }
            } 
        }
    }
}
