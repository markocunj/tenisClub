using TC.DomainModels.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TC.DomainModels.Models
{
    [Table("AuditLog", Schema = "dbo")]
    public class Audit : BaseEntityBasic
    {
        public string TableName { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string UserId { get; set; }
    }
}