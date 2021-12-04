using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class Match : BaseEntity
    {
        public DateTime DateOfMatch { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }
    }
}
