using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace MuscleCircus
{
    public class Clubs
    {
        public Clubs()
        {
            Name = "Muscle Circus of Detroit";
            Address = Locations.Detroit.ToString();
        }

        public string Name { get; set; }
        public string Address { get; set; }

        // Adding days to a date  
        readonly DateTime today = DateTime.Now; // 12/20/2015 11:48:09 AM  
        //DateTime newDate2 = today.AddDays(30); // Adding one month(as 30 days)  
        //Console.WriteLine(newDate2); // 1/19/2016 11:48:09 AM

        public List<Members> MembersList = new List<Members>
        {  
        new GrandMember(50,"Eddy", "Garcia", "100 Circus Way"),
        new GrandMember(51, "Gustavo", "Rivera", "5000 Chirpus Road"),
        new SingleMember(10, "Michael", "Swope", "123 HelloWorld Way", Locations.Los_Angeles),
        new SingleMember(11, "Jacob", "Magyar", "321 Woodward Ave", Locations.Detroit)
        };

        public void ListAllMembers()
        {
            Console.Clear();
            Console.WriteLine("List All Members Menu");
            Console.WriteLine("_______________\n");

            List<Members> listOrderedGrand = MembersList.Where(x => x is GrandMember).ToList();
            List<Members> listOrderedSingle = MembersList.Where(x => x is SingleMember).ToList();

            foreach (Members member in listOrderedGrand) 
            {
                Console.WriteLine(member.ToString());
            }

            foreach (Members member in listOrderedSingle) 
            {
                Console.WriteLine(member.ToString());
            }
        }

        public void RemoveMember()
        {
            BeginRemoveMember:
            Console.Clear();
            Console.WriteLine("Remove Member Menu");
            Console.WriteLine("_______________\n");

            Console.Write("What member ID would you like to remove: ");
            int removeThisID = 0;

            try
            {
                removeThisID = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("\nNot a valid option. Press any key to start over");
                Console.ReadKey();
                goto BeginRemoveMember;
            }

            var found = MembersList.FindAll(memberPerson => memberPerson.Id == removeThisID);

            MemberFound:
            if (found.Count() != 0)
            {
                foreach (var person in found)
                {
                    Console.Clear();
                    Console.WriteLine("Remove Member Menu");
                    Console.WriteLine("_______________\n");
                    Console.WriteLine("Member found: ");

                    if (person is GrandMember grand)
                    {
                        string finalString =
                            String.Format("{0, -15} {1, -15}", "ID: ", grand.Id) + "\n" +
                            String.Format("{0, -15} {1, -15}", "First name: ", grand.FirstName) + "\n" +
                            String.Format("{0, -15} {1, -15}", "Last name: ", grand.LastName) + "\n" +
                            String.Format("{0, -15} {1, -15}", "Address: ", grand.Address) + "\n" +
                            String.Format("{0, -15} {1, -15}", "Membership Points: ", grand.MembershipPoints) + "\n";

                        Console.WriteLine(finalString);

                        Console.WriteLine("Are you sure you want to remove this member? (y/n)");
                        Console.WriteLine(); //line spacing
                        string removeChoice = Console.ReadLine().ToLower();


                        if (removeChoice == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Remove Member Menu");
                            Console.WriteLine("_______________\n");
                            MembersList.RemoveAll(memberPerson => memberPerson.Id == removeThisID);
                            Console.WriteLine(grand.FirstName + " " + grand.LastName + " was removed successfully\n");
                            Console.WriteLine("Going to the List All Members menu...");
                            Thread.Sleep(2500);
                            ListAllMembers();
                        }
                        else if (removeChoice == "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Remove Member Menu");
                            Console.WriteLine("_______________\n");
                            Console.WriteLine(grand.FirstName + " " + grand.LastName + " was not removed\n");
                            Console.WriteLine("Going to the List All Members menu...");
                            Thread.Sleep(2500);
                            ListAllMembers();
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid option. Press any key to try again");
                            Console.ReadKey();
                            goto MemberFound;
                        }
                    }
                    else if (person is SingleMember single) 
                    {
                        string finalString =
                            String.Format("{0, -15} {1, -15}", "ID: ", single.Id) + "\n" +
                            String.Format("{0, -15} {1, -15}", "First name: ", single.FirstName) + "\n" +
                            String.Format("{0, -15} {1, -15}", "Last name: ", single.LastName) + "\n" +
                            String.Format("{0, -15} {1, -15}", "Address: ", single.Address) + "\n" +
                            String.Format("{0, -15} {1, -15}", "Home club: ", single.HomeClub.ToString().Replace("_", " ")) + "\n";

                        Console.Clear();
                        Console.WriteLine("Remove Member Menu");
                        Console.WriteLine("_______________\n");
                        Console.WriteLine("Member found: ");
                        Console.WriteLine(finalString);

                        Console.WriteLine("Are you sure you want to remove this member? (y/n)");
                        Console.WriteLine(); //line spacing
                        string removeChoice = Console.ReadLine().ToLower();


                        if (removeChoice == "y")
                        {
                            Console.Clear();
                            Console.WriteLine("Remove Member Menu");
                            Console.WriteLine("_______________\n");
                            MembersList.RemoveAll(memberPerson => memberPerson.Id == removeThisID);
                            Console.WriteLine(single.FirstName + " " + single.LastName + " was removed successfully\n");
                            Console.WriteLine("Going to the List All Members menu...");
                            Thread.Sleep(2500);
                            ListAllMembers();
                        }
                        else if (removeChoice == "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Remove Member Menu");
                            Console.WriteLine("_______________\n");
                            Console.WriteLine(single.FirstName + " " + single.LastName + " was not removed\n");
                            Console.WriteLine("Going to the List All Members menu...");
                            Thread.Sleep(2500);
                            ListAllMembers();
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid option. Press any key to try again");
                            Console.ReadKey();
                            goto MemberFound;
                        }
                    }
                }
                    //MembersList.RemoveAll(memberPerson => memberPerson.Id == removeThisID);

                    //Console.WriteLine($"{person.FirstName} {person.LastName} with the ID number of " +
                    //    $"{person.Id} was removed successfully.");
                    //Thread.Sleep(2500);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Remove Member Menu");
                Console.WriteLine("_______________\n");
                Console.WriteLine("No Member found to remove");
            }

        }

        public void MemberCheckIn()
        {
            bool checkInLoop = true;
            while (checkInLoop) { 
            Console.Clear();
            Console.WriteLine("Member Check In Menu");
            Console.WriteLine("_______________\n");
            Console.Write("Enter the member's ID: ");

            int incomingMemberID = 0;

            try
            {
                incomingMemberID = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("\nNot a valid option. Press any key to start over.");
                Console.ReadKey();
                continue;
            }

            var found = MembersList.FindAll(memberPerson => memberPerson.Id == incomingMemberID);

                DateTime dt = DateTime.Now;

                if (found.Count() != 0)
                {
                    foreach (var member in found)
                    {

                        if (member is GrandMember grand)
                        {
                            Console.Clear();
                            Console.WriteLine("Member Check In Menu");
                            Console.WriteLine("_______________\n");
                            Console.WriteLine("Grand Member " + member.FirstName + " was checked in successfully at " + dt.ToLongTimeString() + "\n");
                            grand.MembershipPointsAdd();
                            Console.WriteLine(member.FirstName + "'s " + "membership points: " + grand.MembershipPoints + "\n");
                            checkInLoop = false;
                        }
                        else if (member is SingleMember single && single.HomeClub == this.Address)
                        {
                            Console.Clear();
                            Console.WriteLine("Member Check In Menu");
                            Console.WriteLine("_______________\n");
                            Console.WriteLine("Single Member " + single.FirstName + " was checked in successfully at " + dt.ToLongTimeString() + "\n");
                            checkInLoop = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Member Check In Menu");
                            Console.WriteLine("_______________\n");
                            Console.WriteLine("Single Member: " + member.FirstName + " " + member.LastName + "\n");
                            Console.WriteLine("This isn't their home club! You cannot out pizza the hut!\n");
                            checkInLoop = false;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Member Check In Menu");
                    Console.WriteLine("_______________\n");
                    Console.WriteLine("Member ID " + incomingMemberID + " isn't assigned to a member!");
                    checkInLoop = false;
                }
            }
        }

        public void PrintBillOfSales()
        {
            bool loopChoice = true;
            while (loopChoice)
            {
                Console.Clear();
                Console.WriteLine("Print Bill Of Sales Menu");
                Console.WriteLine("_______________\n\n");
                Console.WriteLine("Select from the following bill print options:\n\n1.Display bill of sale of a specific person\n\n2.Display bill of sale of all members");
                Console.WriteLine(); //Line spacing
                int option = 0;

                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Not a valid option. Press any key to start over");
                    Console.ReadKey();
                    continue;
                }

                if (option == 1)
                {
                BillOfSalesOption1:
                    Console.Clear();
                    Console.WriteLine("Print Bill Of Sales Menu");
                    Console.WriteLine("_______________\n\n");
                    Console.Write("Enter the member's ID: ");

                    int incomingMemberID = 0;

                    try
                    {
                        incomingMemberID = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\nNot a valid option. Press any key to start over");
                        Console.ReadKey();
                        goto BillOfSalesOption1;
                    }

                    var found = MembersList.FindAll(memberPerson => memberPerson.Id == incomingMemberID);

                    if (found.Count() != 0)
                    {
                        foreach (var member in found)
                        {
                            if (member is GrandMember grand)
                            {
                                Console.Clear();
                                Console.WriteLine("Print Bill Of Sales Menu");
                                Console.WriteLine("_______________\n\n");
                                Console.WriteLine($"{((GrandMember)member).FirstName}'s Bill of sale:");
                                Console.Write($"Amount due for the month of {(today.ToString("MMMM yyyy"))}: {((GrandMember)member).CostOfMembership.ToString("C2")}\n");
                                Console.WriteLine(String.Format("{0, -15} {1, -15}", "Membership Points: ", grand.MembershipPoints + "\n"));

                            }
                            else if (member is SingleMember single)
                            {
                                Console.Clear();
                                Console.WriteLine("Print Bill Of Sales Menu");
                                Console.WriteLine("_______________\n\n");
                                Console.WriteLine($"{single.FirstName}'s Bill of sale:");
                                Console.WriteLine($"Amount due for the month of {(today.ToString("MMMM yyyy"))}: {single.CostOfMembership.ToString("C2")}\n");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Print Bill Of Sales Menu");
                        Console.WriteLine("_______________\n\n");
                        Console.WriteLine("Member ID does not exist");
                    }
                    loopChoice = false;
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Print Bill Of Sales Menu");
                    Console.WriteLine("_______________");

                    foreach (Members member in MembersList)
                    {
                        if (member is GrandMember grand)
                        {

                            Console.WriteLine($"\n\n{((GrandMember)member).FirstName}'s Bill of sale - ");
                            Console.Write($"Amout due for the month of {(today.ToString("MMMM yyyy"))}: {((GrandMember)member).CostOfMembership.ToString("C2")}\n");
                            Console.WriteLine(String.Format("{0, -15} {1, -15}", "Membership Points: ", grand.MembershipPoints));

                        }
                    }

                    foreach (Members member in MembersList)
                    {
                        if (member is SingleMember single)
                        {
                            Console.WriteLine($"\n\n{single.FirstName}'s Bill of sale - ");
                            Console.Write($"Amout due for the month of {(today.ToString("MMMM yyyy"))}: {single.CostOfMembership.ToString("C2")}\n");
                        }
                    }

                    //foreach (Members member in MembersList)
                    //{
                    //    if (member is GrandMember grand)
                    //    {

                    //        Console.WriteLine($"\n\n{((GrandMember)member).FirstName}'s Bill of sale - ");
                    //        Console.Write($"Amout due for the month of {(today.ToString("MMMM yyyy"))}: {((GrandMember)member).CostOfMembership.ToString("C2")}\n");
                    //        Console.WriteLine(String.Format("{0, -15} {1, -15}", "Membership Points: ", grand.MembershipPoints));

                    //    }
                    //    else if (member is SingleMember single)
                    //    {
                    //        Console.WriteLine($"\n\n{single.FirstName}'s Bill of sale - ");
                    //        Console.Write($"Amout due for the month of {(today.ToString("MMMM yyyy"))}: {single.CostOfMembership.ToString("C2")}\n");

                    //    }

                    //}
                    loopChoice = false;
                }
                else
                {
                    Console.WriteLine("\nNot a valid option. Press any key to start over");
                    Console.ReadKey();
                    loopChoice = true;
                }
            }
        }

        public  void AddMember(Members newMember)
        {
            Console.Clear();
            Console.WriteLine("Add a Member Menu");
            Console.WriteLine("____________\n");
            Console.Write("What's the member's first name? ");
            newMember.FirstName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Add a Member Menu");
            Console.WriteLine("____________\n");
            Console.Write("What's the member's last name? ");
            newMember.LastName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Add a Member Menu");
            Console.WriteLine("____________\n");
            Console.Write("What's the member's address? ");
            newMember.Address = Console.ReadLine();


            HomeClubChoice:
            if (newMember is SingleMember single)
            {
                Console.Clear();
                Console.WriteLine("Add a Member Menu");
                Console.WriteLine("____________\n");
                Console.Write("Please choose a location that will be your home club: \n");

                foreach (Locations location in Locations.GetValues(typeof(Locations)))
                {
                    Console.WriteLine(((int)location).ToString() + ". " + location.ToString().Replace("_", " "));
                }

                Console.WriteLine(); //Line spacing

                int homeClubChoice = 0;

                try 
                { 
                    homeClubChoice = int.Parse(Console.ReadLine());
                } 
                catch (Exception e) 
                {
                    Console.WriteLine("\nNot a valid option. Press any key to start over.");
                    Console.ReadKey();
                    goto HomeClubChoice;
                }

                if (homeClubChoice < 1 || homeClubChoice > 6)
                {
                    Console.WriteLine("\nNot a valid option. Press any key to start over.");
                    Console.ReadKey();
                    goto HomeClubChoice;
                }
                

                var homeClubAdd = (Locations)homeClubChoice;
                single.HomeClub = homeClubAdd.ToString();
            }

            Random rand = new Random();

            if (newMember is GrandMember)
            {
                newMember.Id = rand.Next(50, 59);
                newMember.CostOfMembership = 20m;
            }
            else
            {
                newMember.Id = rand.Next(1, 49);
                newMember.CostOfMembership = 10m;
            }

            MembersList.Add(newMember);

            Console.WriteLine();
            Console.WriteLine(newMember.FirstName + " " + newMember.LastName + " was successfully added!");
            Console.WriteLine("\nListing all members now...");
            Thread.Sleep(2500);

            ListAllMembers();
        }
    }
}
