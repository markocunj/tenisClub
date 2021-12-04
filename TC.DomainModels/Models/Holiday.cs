using TC.DomainModels.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.DomainModels
{
    public class Holiday: BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Name { get; set; }
    }
}
