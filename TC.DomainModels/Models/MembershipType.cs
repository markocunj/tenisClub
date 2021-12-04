using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class MembershipType : BaseEntity
    {
        public string Name { get; set; }
        public string AnnualFees { get; set; }
    }
}
