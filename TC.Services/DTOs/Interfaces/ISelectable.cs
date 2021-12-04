using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TC.Services.DTOs.Interfaces
{
    public interface ISelectable
    {
        long Id { get; set; }
        string SelectName { get; set; }
    }
}
