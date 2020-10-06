# Escape Room Breakdown

We're going to use our knowledge of loops to build an escape room game.

## Overview

You'll be creating an escape room. The player is trapped in a locked room that requires a code to escape. The player can non-linearly explore a series of objects in the room to find clues. Once the player has discovered all the clues, they should be able to use them to figure out the code to escape the room. Your finished version might look something like [this](https://nv.instructuremedia.com/fetch/QkFoYkIxc0hhUVRKRjZZRmFRUVlJZUFFYkNzSFp1NTlYdz09LS1iZmJhMWQyMGExNDRhN2VhZjEyY2Y4MTQ2OTNkOGEzMThkMjhlYWNm.mp4?disposition=download_original&filename=escape-demo).

- Your room should have three objects that the player can interact with. Keep it simple for now. For example, one object could be a piece of paper that the player can read.
- There should be a locked door (or something similar) that the player can interact with that prompts the player for a code.
- Each "move" of the game, the player should be presented with a menu of options that they can select from. For example, if I have a painting, a note and a dresser as my objects, the options might be: "What would you like to investigate? a) the painting, b) the note, c) the dresser, d) the locked door"
- The game should loop so that the player can keep exploring until they figure out the clue and escape.

## Objective

This assignment was developed for you to practice basic C# elements:

- Conditionals
- Loops
- Classes
- Constructors
- Methods

## Planning

Planning is essential to programming. Physically typing the characters in an IDE, like Visual Studio, is the easy part. Thinking through the application and coming up with an architecture that fits is the hard part. UML and flowcharts help us come up with that architecture.

So before you read through the UML and flowchart below, try creating them on your own! There are many ways to solve a problem and the way I'm showing you isn't the only way.

____

So you tried it on your own already? Without jumping ahead and reading the images below? Without jumping straight into the code? Good, I'm trusting you. 

![](escape-room-uml.png)

Remember, in an object-oriented language like C# we want to divide up our project into individual classes. So in this UML we have:

- A `Door` class which is mainly responsible for keeping track of the code and exposing a public `AttemptMethod()` method that prompts the player for the code returns a boolean that indicates whether they got it right or not.
- A `RoomObject` class which is mainly responsible for displaying information about the room when needed via the `DisplayInfo()` method.
- An `EscapeRoom` class that strings the whole thing together by creating `RoomObject` and `Door` instances and managing the logic for displaying the options to the player.

The flowchart of the logic might look something like:

![](flowchart.png)

## Instructions

Create a new project, or use your group work from class as a starting point. You'll need to create the following blank classes to get started:

- Door
- RoomObject
- EscapeRoom

### Puzzle

First things first, we'll need to design the world and the puzzle. If you've been to an escape room before, you could remix one of the puzzles you encountered. Or you could pick a theme or piece of media and design a puzzle around that. A couple examples:

- A "found words" puzzle where each clue is a word from a recognizable phrase ("three blind mice").
- A "guessing puzzle" where each clue gives you a hint about a person/thing ("she has white hair" + "she wants the iron throne" + "she's the mother of dragons" = Daenerys).

I'm going to run with "three blind mice" puzzle for this tutorial.

### RoomObject

When approaching a sizable project, you want to divide it up into small pieces that you can build and test individually - progressively working your way up to the whole thing. Let's start with the `RoomObject` class. This is a class that we can use to instantiate the three objects that will be in our room. It will need a few fields, like the name and description of the room.

```cs
using static System.Console;

class RoomObject
{
    string Name;
    string Description;
}
```

Note: all these fields are _private_ when we don't give them an explicit access modifier. Private means they can only be accessed within the class. As a general rule, we want to make as many field private to limit which parts of our codebase can manipulate them.

Almost any time you create a class that you plan to instantiate (e.g. non-static), you'll want a constructor to make it easy to create instances:

```cs
public RoomObject(string name, string description)
{
    Name = name;
    Description = description;
}
```

Then we'll want a _public_ method to display the information about the object to the player when they decide to interact with it:

```cs
public void DisplayInfo()
{
    WriteLine("You inspect the " + Name + ".");
    WriteLine(Description);
    Write("\n(press any key) ");
    ReadKey(true); // The "true" argument here prevents the key that is typed from displaying
}
```

We want this method to be public so that we can access it from within EscapeRoom. Time to check if it's working. Create an instance of it inside of you `Main` function and try the `DisplayInfo` method.

```cs
RoomObject Painting = new RoomObject("painting", 
    "It's, oddly enough, a giant painting of mice. You think \"mice\" might be a clue.");
Painting.DisplayInfo();
```

![](./progress-1.png)

Create your two other objects and test out displaying them.

## EscapeRoom

Next up, let's tackle the skeleton for the `EscapeRoom` class. That's going to be the workhorse of the app. To keep things simple, let's display the three room objects to the player once and let them choose which to explore. We won't worry about looping so that they can explore multiple rooms, and we won't worry about the door.

Inside `EscapeRoom`, we'll need our three `RoomObject` instances and a way to start the room running:

```cs
class EscapeRoom
{
    private RoomObject Painting;
    private RoomObject DeskDrawer;
    private RoomObject Cane;

    public EscapeRoom()
    {
        Painting = new RoomObject("painting", "It's, oddly enough, a giant painting of mice. You think \"mice\" might be a clue.");
        DeskDrawer = new RoomObject("desk drawer", "It sticks slightly, but you manage to jiggle the drawer open. You find a post-it with the number \"three\" on it.");
        Cane = new RoomObject("cane", "You realize it is actually a walking stick that a \"blind\" person might use.");
    }
    
    public void StartRoom()
    {
        // TODO
    }
}
```

It's important that both of these methods are public - the constructor and StartRoom - because we will be accessing them from within Program. We can get everything running by clearing out the old code we had inside of `Main` and then adding:

```cs
EscapeRoom room = new EscapeRoom();
room.StartRoom();
```

Nothing interesting happens when we run yet because we didn't implement `StartRoom`. Before reading the code below, try implementing the conditional logic yourself - display the choices to the player and let them decide which they want to explore.

```cs
public void StartRoom()
{
    WriteLine("Where would you like to look?");
    WriteLine("  1) a painting\n  2) a desk drawer\n  3) a cane\n  4) a door");
    string choice = ReadLine();

    if (choice == "1")
    {
        Painting.DisplayInfo();
    }
    else if (choice == "2")
    {
        DeskDrawer.DisplayInfo();
    }
    else if (choice == "3")
    {
        Cane.DisplayInfo();
    }
}
```

And if all goes well, you should be able to play it and make one decision.

## Looping

Now, we just need to sprinkle in a loop to give the player the ability to explore the objects as many times as they want. What would be a good loop structure for this?

A _for loop_ wouldn't make sense because we aren't trying to iterate a known number of times. That leaves us with a _while loop_ or a _do while loop_. The latter is a good fit because we want to run the loop body at least once.

```cs
public void StartRoom()
{
    bool hasEscaped = false;

    do {
        WriteLine("Where would you like to look?");
        WriteLine("  1) a painting\n  2) a desk drawer\n  3) a cane\n  4) a door");
        string choice = ReadLine();

        if (choice == "1")
        {
            Painting.DisplayInfo();
        }
        else if (choice == "2")
        {
            DeskDrawer.DisplayInfo();
        }
        else if (choice == "3")
        {
            Cane.DisplayInfo();
        }
        else if (choice == "4")
        {
            // For now, we can just let the player leave without solving the code.
            hasEscaped = true;
        }
    } while (!hasEscaped);

    WriteLine("You escaped!");
    WriteLine("Thanks for playing.\nPress any key to exit...");
    ReadKey();
}
```

Test it out. You should be able to explore all your rooms and immediately escape if you choose the door.

## Finishing Up

- Make sure you have at least 3x objects in your room that the player can explore. They can be anything you want - the only constraint is that they be something different than this tutorial.
- Add in the `Door` class and get the code logic working. Review the flowchart and UML if you get lost. To be kind to the player, try making the code case-insensitive.
- Add an introduction before the loop starts.
- Change the console title.
- What happens if they don't choose a valid option? Give them some feedback when that happens.
- Give your app some ASCII design and color to make it pop. Give each room it's own color or distinctive design element.
- (Optional) Track the number of seconds that it took the player to escape using the [Systems.Diagnostics.Stopwatch](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=netframework-4.8) class. Give the player feedback on how they did (e.g. <= 30 seconds might be an excellent time, but taking 60 seconds might just be an okay time). You'll need to read the documentation for this - reading documentation is a skill that requires practice. Check out the examples, then look through the fields, properties and methods sections. You won't understand everything you see the first time you read it.
