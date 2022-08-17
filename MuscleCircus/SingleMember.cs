using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleCircus
{
    public class SingleMember : Members
    {
        public SingleMember(int aID, string aFirstName, string aLastName, string aAddress, Locations aHomeClub)
        {
            Id = aID;
            FirstName = aFirstName;
            LastName = aLastName;
            Address = aAddress;
            HomeClub = aHomeClub.ToString();
        }

        public override void CheckIn()
        {
            Console.WriteLine("Please enter member's ID: ");
            string checkInID = Console.ReadLine();

            if (this.HomeClub == Locations.Detroit.ToString())
            {
                Console.WriteLine("Welcome back!");
            }
            else
            {
                Console.WriteLine("This isn't your home club! You can't out pizza the hut!");
            }
        }
    }
}
