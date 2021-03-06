﻿using Gap.IPM.Domain.Common;
using Gap.IPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gap.IPM.Domain.Entities
{
    public class CustomerInsurancePolicy : AuditableEntity
    {
        [Key]
        public int CustomerInsurancePolicyId { get; set; }
        public string CustomerId { get; set; }
        public int InsurancePolicyId { get; set; }
        public CustomerInsurancePolicyStatus Status{ get; set; }
        public DateTime StatusDate { get; set; }
       


        public Customer Customer { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
    }
}
