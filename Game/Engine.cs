using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Engine
    {
        //Variables
        bool endGame;

        bool mainLoop = true;

        //Private Functions
        private void InitVariables()
        {
            this.endGame = false;
        }

        //Constructors And Destructors
        public Engine()
        {
            this.InitVariables();
        }

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
        public static string PlayerStatus(Player _player)
        {
            return $"Class: {_player.Class}\n"
                + $"Current Health: {_player.Health}\n"
                + $"Available Credit Chips: {_player.CreditChips}\n"
                + $"Experience Points: {_player.ExperiencePoints}\n"
                + $"Your current Level: {_player.Level}";
        }

        public static string CurrentLocation(string locationName, string locationDesc, Location _location)
        {
            return $"{locationName} {_location.Name}\n"
                + $"{locationDesc}{_location.Description}";
        }



        public void Run(Player _player)
        {
            Encounters encounter = new Encounters();
            

            encounter.Player = _player;

            while (this.endGame == false)
            {
                //Player _player = new Player("", "",  10, 0, 0, 1);

                Print("CyberPunk 2022\n");
                Print("Type 'Exit' if you arent ready for revenge. Otherwise hit the 'ENTER' key.");
                
                

                string userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Print("What is your name stranger?\n");
                }

                userInput = Console.ReadLine();


                _player.Name = userInput;
                _player.Class = "Street Kid";

                Console.Clear();
                Print($"Hello {_player.Name}.\n");
                Print("Okay, from what I can gather through your neural uplink, these are your current specifications: \n");
                Print(PlayerStatus(_player) + "\n");
                Print("How's about we get started?\n");
                Console.ReadKey();

                Location towerLobby = new Location();
                towerLobby.ID = 0;
                towerLobby.Name = "Kaneda Tower Lobby.\n";
                towerLobby.Description = "this is the right place!!!\n";

                Console.Clear();
                Print(CurrentLocation("You just came to in the", "Don't worry, ", towerLobby));


                Print("Press 'Enter' and let's take the elevator up one floor!");
                Console.ReadKey();


                Location level1 = new Location();

                level1.Level1(_player);

                //if (userInput == "exit")
                //{
                //    System.Environment.Exit(0);
                //}
                //else
                //{
                //    Console.Clear();
                //    Location firstFloor = new Location(2, "Kaneda Tower Floor 1.\n", "let's take a look around!\n");
                //    Console.Clear();
                //    //Print(CurrentLocation("This is", "Alright,", firstFloor));
                //    encounter.BasicFightEncounter();
                //}
                //Console.ReadKey();                

                //while (mainLoop)
                //{
                //    encounter.RandomEncounter();
                //}

                this.endGame = true;
            }

            Print("Ending game.....");
            Console.ReadKey();
        }        
    }
}
