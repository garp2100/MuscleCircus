using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MuscleCircus
{
    public class Clubs
    {
        public string Name { get; set; }
        public string Address { get; set; }

        List<Members> MembersList = new List<Members>
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
           

    }
}
