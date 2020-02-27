using System;
using static System.Console;

namespace VirtualPet
{
    class VirtualPet
    {
        // Fields (variables that are defined in a class):
        public int HappinessLevel;
        public string Name;
        public int HungerLevel;
        public string Color;
        public bool IsInvicible;

        public VirtualPet()
        {
            Name = "Unknown name";
            Color = "Unknown color";
            HappinessLevel = 0;
        }

        public VirtualPet(string name, string color, int happinessLevel)
        {
            Name = name;
            Color = color;
            HappinessLevel = happinessLevel;
        }

        public void Greet()
        {
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("> Hello, I am " + Name + ".");
            WriteLine("> I am a " + Color + " pet.");
            WriteLine("> I am a " + HappinessLevel + " happy.");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public void Feed(string foodName)
        {
            WriteLine("> I am eating " + foodName + ".");
        }
    }
}
