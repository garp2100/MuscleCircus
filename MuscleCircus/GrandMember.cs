using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleCircus
{
     public class GrandMember : Members
    {
        public GrandMember(int aID, string aFirstName, string aLastName, string aAddress)
          
        {
            Id = aID;
            FirstName = aFirstName;
            LastName = aLastName;
            Address = aAddress;
            CostOfMembership = 20m;

        }

        public GrandMember()
        {

        }

        public static int MembershipPoints { get; set; }

        public static void MembershipPointsAdd()
        {
            MembershipPoints += 10;
        }

        public override string ToString()
        {
            string finalString =
            String.Format("{0, -15} {1, -15}", "ID: ", this.Id) + "\n" +
            String.Format("{0, -15} {1, -15}", "First name: ", this.FirstName) + "\n" +
            String.Format("{0, -15} {1, -15}", "Last name: ", this.LastName) + "\n" +
            String.Format("{0, -15} {1, -15}", "Address: ", this.Address) + "\n" +
            String.Format("{0, -15} {1, -15}", "Membership Points: ", MembershipPoints);
            
            return finalString;
        }



    }
}
