using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gap.IPM.Domain.Common;
using Gap.IPM.Domain.Enums;
namespace Gap.IPM.Domain.Entities
{
    public class InsurancePolicy:AuditableEntity
    {
        [Key]
        public int InsurancePolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageTypeId { get; set; }
        public int Coverage { get; set; }        
        public DateTime CoverageStart { get; set; }
        public int CoveragePeriod { get; set; }
        public int PolicyValue { get; set; }
        public int RiskType { get; set; }
        public bool IsActive { get; set; }

        public CoverageType CoverageType { get; set; }


    }
}
