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
            foreach (Members member in MembersList)
            {
                
                member.ToString();

            }

            
        }

        public void RemoveMember()
        {


            Console.Write("What member ID would you like to remove: ");
            int removeThisID = int.Parse(Console.ReadLine());

            var found = MembersList.FindAll(memberPerson => memberPerson.Id == removeThisID);
            if (found.Count() != 0)
            {

                foreach (var person in found)
                {
                    MembersList.RemoveAll(memberPerson => memberPerson.Id == removeThisID);

                    Console.WriteLine($"{person.FirstName} with ID of {person.Id} was removed successfully.");

                }
                ListAllMembers();
            }
            else
            {
                Console.WriteLine("No Member found to remove.");
            }

        }

        public void MemberCheckIn()
        {
            Console.Write("Enter the member's ID: ");

            int incomingMemberID = int.Parse(Console.ReadLine());

            var found = MembersList.FindAll(memberPerson => memberPerson.Id == incomingMemberID);

            if (found.Count() != 0)
            {
                foreach (var member in found)
                {
 
                    if (member is GrandMember)
                    {
                        Console.WriteLine("Grand Member " + member.FirstName + " was checked in successfully.");
                        GrandMember.MembershipPointsAdd();
                        Console.WriteLine(GrandMember.MembershipPoints);
                    }
                    else if (member is SingleMember s  && s.HomeClub == this.Address)
                    {
                        Console.WriteLine("Single Member " + s.FirstName + " was checked in successfully.");                     
                    }
                    else
                    {
                        Console.WriteLine("This isn't your home club!");
                    }
                }
            }
            else
            {
                Console.WriteLine("That member doesn't exist!");
            }
        }

        public void PrintBillOfSales()
        {
            bool loopChoice = true;
            while (loopChoice)
            {
                Console.WriteLine("Select from the following bill print options:\n\n1.Display bill of sale of a specifc person\n\n2.Display bill of sale of all members.");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Write("Enter the member's ID: ");

                    int incomingMemberID = int.Parse(Console.ReadLine());

                    var found = MembersList.FindAll(memberPerson => memberPerson.Id == incomingMemberID);

                    if (found.Count() != 0)
                    {
                        foreach (var member in found)
                        {
                            if (member is GrandMember)
                            {

                                Console.WriteLine($"{ ((GrandMember)member).FirstName }'s Bill of sale:");
                                Console.Write($"Amout due for the month of {(today.ToString("MMMM,yyyy"))}: {((GrandMember)member).CostOfMembership.ToString("C2")}\n");
                                Console.WriteLine(String.Format("{0, -15} {1, -15}", "Membership Points: ", GrandMember.MembershipPoints));

                            }
                            else if (member is SingleMember s)
                            {
                                Console.WriteLine($"{s.FirstName}'s Bill of sale:");
                                Console.Write($"Amout due for the month of {(today.ToString("MMMM,yyyy"))}: {s.CostOfMembership.ToString("C2")}\n");

                            }
                            else
                            {
                                Console.WriteLine("Bill of sale cannot be generated. :/");
                            }
                        }                      
                        loopChoice = false;
                    }
                }
                else if (option == 2)
                {
                    foreach (Members member in MembersList)
                    {
                        if (member is GrandMember)
                        {

                            Console.WriteLine($"\n\n{((GrandMember)member).FirstName}'s Bill of sale:");
                            Console.Write($"Amout due for the month of {(today.ToString("MMMM,yyyy"))}: {((GrandMember)member).CostOfMembership.ToString("C2")}\n");
                            Console.WriteLine(String.Format("{0, -15} {1, -15}", "Membership Points: ", GrandMember.MembershipPoints));

                        }
                        else if (member is SingleMember s)
                        {
                            Console.WriteLine($"\n\n{s.FirstName}'s Bill of sale:");
                            Console.Write($"Amout due for the month of {(today.ToString("MMMM,yyyy"))}: {s.CostOfMembership.ToString("C2")}\n");

                        }
                        else
                        {
                            Console.WriteLine("\n\nBill of sale cannot be generated. :/");
                        }

                    }
                    loopChoice = false;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    Thread.Sleep(2500);
                    loopChoice = true;
                }
            }
        }

        public  void AddMember(Members newMember)
        {
            Console.Write("What's the member's first name? ");
            newMember.FirstName = Console.ReadLine();

            Console.Clear();

            Console.Write("What's the member's last name? ");
            newMember.LastName = Console.ReadLine();

            Console.Clear();

            Console.Write("What's the member's address? ");
            newMember.Address = Console.ReadLine();

            if (newMember is SingleMember s)
            {
                Console.Write("Please choose a location that will be your home club: \n");

                foreach (Locations location in Locations.GetValues(typeof(Locations)))
                {
                    Console.WriteLine(((int)location).ToString() + ". " + location.ToString().Replace("_", " "));
                }
                int homeClubChoice = int.Parse(Console.ReadLine());

                var homeClubAdd = (Locations)homeClubChoice;
                s.HomeClub = homeClubAdd.ToString();
            } 

            //newMember.HomeClub = Locations.Detroit.ToString();

            Random rand = new Random();

            if (newMember is GrandMember)
            {
                newMember.Id = rand.Next(500, 599);
                
            }
            else
            {
                newMember.Id = rand.Next(100, 199);
            }

            

            MembersList.Add(newMember);

            ListAllMembers();
        }


    }
}
