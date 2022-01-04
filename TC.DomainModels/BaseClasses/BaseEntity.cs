using TC.DomainModels.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackableEntities.Common.Core;

namespace TC.DomainModels.BaseClasses
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseEntity : ICreationAuditedEntity, IModificationAuditedEntity, IDeletionAuditedEntity, ISoftDeletableEntity, IAmFullyAudited, ITrackable
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }

        public string ErrorMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? DateDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeletedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        [NotMapped]
        public string DateCreatedString { get { return DateCreated.ToString("dd.MM.yyyy."); } }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? LastModified { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public TrackingState TrackingState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public ICollection<string> ModifiedProperties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
