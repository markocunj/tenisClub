

using System;

namespace TC.DomainModels.CoreInterfaces
{
    public interface ICreationAuditedEntity
    {
        DateTimeOffset DateCreated { get; set; }
        string CreatedBy { get; set; }
    }
}
