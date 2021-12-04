
using System;

namespace TC.DomainModels.CoreInterfaces
{
    public interface IModificationAuditedEntity
    {
        DateTimeOffset? LastModified { get; set; }
        string ModifiedBy { get; set; }
    }
}
