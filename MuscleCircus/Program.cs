using MuscleCircus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


Clubs Detroit = new Clubs();

//Detroit.ListAllMembers();
//Detroit.RemoveMember(50000001);

bool loopChoice = false;

//do
//{

    StartOfLoop:
    Console.WriteLine("Welcome to Muscle Circus of " + Locations.Detroit.ToString() + "!");

    Console.WriteLine("\nPlease select an option: ");
    Console.WriteLine("\n1. Check in a member");
    Console.WriteLine("2. Add a member");
    Console.WriteLine("3. Remove a member");
    Console.WriteLine("4. Print a bill of sales");
    Console.WriteLine("5. Log off");

int menuChoice = int.Parse(Console.ReadLine());


    switch (menuChoice)
    {
        case 1:
            Detroit.MemberCheckIn();
            break;
        case 2:
            Console.WriteLine("Is this person going to be a Grand or Single member? (Grand/Single): ");
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

            break;
        case 3:
            Detroit.RemoveMember();

            break;
        case 4:
            Console.WriteLine("Thursday");
            break;
        case 5:
        Console.WriteLine("Are you sure you want to log off?");

        string logOffInput = Console.ReadLine().ToLower();

        if (logOffInput == "y")
        {
            Console.WriteLine("Goodbye!");
            Thread.Sleep(2500);
            Environment.Exit(0);
        }
        else if (logOffInput == "n")
        {
            goto StartOfLoop;
        }
        else
        {
            Console.WriteLine("That wasn't a valid choice. Going to main menu...");
            Thread.Sleep(2500);
            break;
        }
        break;
    }


Thread.Sleep(2500);

Console.Clear();
goto StartOfLoop;

//    Console.Write("Go back to main menu? (y/n) ");

//            string loopInput = Console.ReadLine().ToLower();

//            if (loopInput == "y")
//            {
//                loopChoice = true;
//            }
//            else if (loopInput == "n")
//            {
//                loopChoice = false;
//            }
//            else
//            {
//                Console.WriteLine("That wasn't a valid choice. Going to main menu...");
//                Thread.Sleep(2500);
//                loopChoice = true;
//            }
    
//} while (loopChoice);