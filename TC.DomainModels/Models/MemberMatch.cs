using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class MemberMatch : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
