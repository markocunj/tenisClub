using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels.BaseClasses;

namespace TC.DomainModels.Models
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
       
    }
}
