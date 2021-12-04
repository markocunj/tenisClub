using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class MemberAddress : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

    }
}
