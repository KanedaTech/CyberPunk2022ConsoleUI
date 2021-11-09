using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace CyberPunk2022_ConsoleRPG
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            Engine engine = new Engine();

            Player player = new Player("", "", 10, 0, 0, 1, 0, 5, 0);

            engine.Run(player);
        }
    }
}
