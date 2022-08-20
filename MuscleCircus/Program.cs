﻿using MuscleCircus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


Clubs Detroit = new Clubs();

    StartOfLoop:
    Console.WriteLine("Welcome to "+ Detroit.Name + "!");
    Console.WriteLine("\nPlease select an option: ");
    Console.WriteLine("\n1. Check in a member");
    Console.WriteLine("2. Add a member");
    Console.WriteLine("3. Remove a member");
    Console.WriteLine("4. Print a bill of sales");
    Console.WriteLine("5. Log off \n\n");
int menuChoice;

bool success = int.TryParse(Console.ReadLine(), out menuChoice);
if (success)
{
    if (menuChoice >= 1 && menuChoice <= 5)
    Console.WriteLine($"{menuChoice}.");
    else
    {
        Console.WriteLine($"\n\nPlease enter a digit within the menu range.");
        goto StartOfLoop;
    }
}
else
{
    Console.WriteLine($"Please enter a digit.");
    goto StartOfLoop;
}


switch (menuChoice)
    {
        case 1:
            Detroit.MemberCheckIn();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Add a member menu -");
            Console.WriteLine("____________\n");
            Console.WriteLine("Is this person going to be a Grand or Single member? (grand/single) ");
            Console.WriteLine("(Enter \"x\" to return to the main menu)");
            string tierChoice = Console.ReadLine().ToLower();
        
        if (tierChoice == "grand")
            {
                GrandMember NewMember = new GrandMember();
                Detroit.AddMember(NewMember);
            }
            else if (tierChoice == "single")
            {
                SingleMember NewMember = new SingleMember();
                Detroit.AddMember(NewMember);
            }
            else if (tierChoice == "x")
            {
            Console.Clear();
            goto StartOfLoop;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not a valid input. Press any key to start over");
                Console.ReadKey();
                goto case 2;
            }
            break;
        case 3:
            Detroit.RemoveMember();

            break;
        case 4:
        Detroit.PrintBillOfSales();
            break;
        case 5:
        Console.Clear();
        Console.WriteLine("Log off menu");
        Console.WriteLine("____________\n\n");
        Console.WriteLine("Are you sure you want to log off?");

        string logOffInput = Console.ReadLine().ToLower();

        if (logOffInput == "y")
        {
            Console.Clear();
            Console.WriteLine("Log off menu");
            Console.WriteLine("____________\n\n");
            Console.WriteLine("Goodbye! \n\nI am your father’s brother’s nephew’s cousin’s former roommate.");
            Thread.Sleep(2500);
            Environment.Exit(0);
        }
        else if (logOffInput == "n")
        {
            Console.Clear();
            Console.WriteLine("Log off menu");
            Console.WriteLine("____________\n\n");
            Console.WriteLine("Log off cancelled");

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Log off menu");
            Console.WriteLine("____________\n\n");
            Console.WriteLine("That wasn't a valid choice.");
            break;
        }
        break;
    }


Console.WriteLine("\nPress any key to return to the main menu");
Console.ReadKey();

Console.Clear();
goto StartOfLoop;