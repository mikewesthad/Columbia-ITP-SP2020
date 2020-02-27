using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace VirtualPet
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Pet Sim";
            ForegroundColor = ConsoleColor.DarkGreen;
            BackgroundColor = ConsoleColor.White;
            Clear();
            WriteLine("Welcome to the Pet Sim!");

            VirtualPet jimothy = new VirtualPet("Jimothy", "Blue", 4);
            jimothy.Greet();
            jimothy.Feed("An apple");
            
            VirtualPet bubs = new VirtualPet("Bubs", "Black", 2);
            bubs.Greet();
            bubs.Feed("Brownie");

            VirtualPet bob = new VirtualPet("Bob", "BluePinkOrange", 0);
            bob.Greet();
            bob.Feed("Candy Bar");

            ReadKey();
        }
    }
}
