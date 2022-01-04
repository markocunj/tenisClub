using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class Match : BaseEntity
    {
        [Required]
        public DateTime DateAndStartTime { get; set; }
        [Required]
        public DateTime DateAndEndTime { get; set; }
        [Required]
        public int CourtId { get; set; }
        public Court Court { get; set; }
    }
}
