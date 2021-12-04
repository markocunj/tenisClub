using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
