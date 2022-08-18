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

       public List<Members> MembersList = new List<Members>
        {  
        new GrandMember(50000000,"Eddy", "Garcia", "100 Circus Way", Locations.Washington_DC),
        new GrandMember(50000001, "Gustavo", "Rivera", "5000 Chirpus Road", Locations.Miami),
        new SingleMember(10000000, "Michael", "Swope", "123 HelloWorld Way", Locations.Los_Angeles),
        new SingleMember(10000001, "Jacob", "Magyar", "321 Woodward Ave", Locations.Detroit)
        };

        public void ListAllMembers()
        {
            foreach (var member in MembersList)
            {
                Console.WriteLine(String.Format("{0, -15} {1, -15}", "ID: ", member.Id));
                Console.WriteLine(String.Format("{0, -15} {1, -15}", "First name: ", member.FirstName));
                Console.WriteLine(String.Format("{0, -15} {1, -15}", "Last name: ", member.LastName));
                Console.WriteLine(String.Format("{0, -15} {1, -15}", "Address: ", member.Address));
                Console.WriteLine(String.Format("{0, -15} {1, -15}", "Home club: ", member.HomeClub.ToString().Replace("_", " ")));
                Console.WriteLine();
            }
        }
        public void RemoveMember()
        {

            Console.Write("What member ID would you like to remove: ");
            int removeThisID = int.Parse(Console.ReadLine());


            //MembersList.Contains.Where(x => removeThisID == memberPerson.ID);

            MembersList.RemoveAll(memberPerson => memberPerson.Id == removeThisID);
            Console.WriteLine("Member was removed!");
            //Console.WriteLine(String.Format("{0, -15} {1, -15}", "Address: ", removeThisID));
            ListAllMembers();
        }

        public void MemberCheckIn()//int incomingMemberID)
        {
            Console.Write("Enter the member's ID: ");

           int incomingMemberID = int.Parse(Console.ReadLine());

            var found = MembersList.FindAll(memberPerson => memberPerson.Id == incomingMemberID);

            if (found.Count() != 0)
            {
                foreach (var member in found)
                {
                    //Console.WriteLine("Member: " + member.FirstName + " was checked in successfully");                   
                    //Console.WriteLine(String.Format("{0, -15} {1, -15}", "First name: ", member.FirstName));
                    //Console.WriteLine(String.Format("{0, -15} {1, -15}", "Last name: ", member.LastName));
                    //Console.WriteLine(String.Format("{0, -15} {1, -15}", "Address: ", member.Address));
                    //Console.WriteLine(String.Format("{0, -15} {1, -15}", "Home club: ", member.HomeClub.ToString().Replace("_", " ")));
                    //Console.WriteLine();
                    if (member is GrandMember)
                    {
                        Console.WriteLine("Grand Member " + member.FirstName + " was checked in successfully.");
                        GrandMember.MembershipPointsAdd();
                        Console.WriteLine(GrandMember.MembershipPoints);
                    }
                    else if (member is SingleMember && member.HomeClub == Locations.Detroit.ToString())
                    {
                        Console.WriteLine("Single Member " + member.FirstName + " was checked in successfully.");
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

            newMember.HomeClub = Locations.Detroit.ToString();

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
