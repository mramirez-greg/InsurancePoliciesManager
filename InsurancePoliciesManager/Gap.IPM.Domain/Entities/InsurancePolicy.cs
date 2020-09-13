﻿using System;
using System.ComponentModel.DataAnnotations;
using Gap.IPM.Domain.Common;
using Gap.IPM.Domain.Enums;
namespace Gap.IPM.Domain.Entities
{
    public class InsurancePolicy:AuditableEntity
    {
        [Key]
        public Int64 InsurancePolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CovergaeTypeId { get; set; }
        public int Coverge { get; set; }
        public DateTime CoverageStart { get; set; }
        public int CoveragePeriod { get; set; }
        public Int64 PolicyValue { get; set; }
        public RiskType RiksType { get; set; }
        public bool IsActive { get; set; }

        public CoverageType CoverageType { get; set; }


    }
}