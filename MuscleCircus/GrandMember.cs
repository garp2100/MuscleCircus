using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleCircus
{
     public class GrandMember : Members
    {
        public GrandMember(int aID, string aFirstName, string aLastName, string aAddress, Locations aHomeClub)
        {
            Id = aID;
            FirstName = aFirstName;
            LastName = aLastName;
            Address = aAddress;
            HomeClub = aHomeClub.ToString();
        }
        public override void CheckIn()
        {
            throw new NotImplementedException();
        }
    }
}
