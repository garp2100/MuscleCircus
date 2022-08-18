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

        public SingleMember()
        {

        }

    }
}
