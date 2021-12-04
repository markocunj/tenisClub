using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class Bill : BaseEntity
    {
        public DateTime BillIssued { get; set; }
        public DateTime DueOn { get; set; }
        public string Cost { get; set; }
        public int MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
