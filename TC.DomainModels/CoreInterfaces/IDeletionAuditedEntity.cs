
using System;

namespace TC.DomainModels.CoreInterfaces
{
    public interface IDeletionAuditedEntity
    {
        DateTimeOffset? DateDeleted { get; set; }
        string DeletedBy { get; set; }
    }
}
