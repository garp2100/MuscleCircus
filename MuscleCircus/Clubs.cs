﻿using System;
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
        public void RemoveMember(int removeThisID)
        {
            //MembersList.Contains.Where(x => removeThisID == memberPerson.ID);

            MembersList.RemoveAll(memberPerson => memberPerson.Id == removeThisID);
            Console.WriteLine("Member was removed!");
            //Console.WriteLine(String.Format("{0, -15} {1, -15}", "Address: ", removeThisID));
            ListAllMembers();
        }

        public void MemberCheckIn(int incomingMemberID)
        {
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
                        Console.WriteLine("Grand Member " + member.FirstName);
                    }
                    else if (member is SingleMember) //&& member.HomeClub == Address)
                    {
                        Console.WriteLine("Single Member " + member.FirstName);
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
    }
}
