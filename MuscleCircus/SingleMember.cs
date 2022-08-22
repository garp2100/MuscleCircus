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
            CostOfMembership = 10m;
        }

        public   string HomeClub { get; set; }
        public SingleMember()
        {
        }



        public override string  ToString()
        {
            string finalString =
            String.Format("{0, -15} {1, -15}", "ID: ", this.Id) + "\n" +
            String.Format("{0, -15} {1, -15}", "First name: ", this.FirstName) + "\n" +
            String.Format("{0, -15} {1, -15}", "Last name: ", this.LastName) + "\n" +
            String.Format("{0, -15} {1, -15}", "Address: ", this.Address) + "\n" +
            String.Format("{0, -15} {1, -15}", "Home club: ", HomeClub.ToString().Replace("_", " ")) + "\n";
            return finalString;
        }
    }
}
