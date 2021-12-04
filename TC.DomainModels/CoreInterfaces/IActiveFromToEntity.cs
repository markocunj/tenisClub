
using System;

namespace TC.DomainModels.CoreInterfaces
{
    public interface IActiveFromToEntity
    {
        bool IsActive { get; set; }
        DateTimeOffset ActiveFrom { get; set; }
        DateTimeOffset? ActiveTo { get; set; }
    }
}
