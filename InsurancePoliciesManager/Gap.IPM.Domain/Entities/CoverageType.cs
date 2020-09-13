using Gap.IPM.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gap.IPM.Domain.Entities
{
    public class CoverageType : AuditableEntity
    {
        [Key]
        public int CovergaeTypeId { get; set; }
        public String CoverageTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
