using AutoMapper;
using Gap.IPM.Application.Common.Mappings;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gap.IPM.Application.CustomersInsurancePolicies.Queries.GetCustomerInsurancePolicy
{
    public class CustomerInsurancePolicyLookupDto : IMapFrom<CustomerInsurancePolicy>
    {
        public int CustomerInsurancePolicyId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int InsurancePolicyId { get; set; }
        public string InsurancePolicyName { get; set; }
        public CustomerInsurancePolicyStatus Status { get; set; }
        public string StatusName { get; set; }
        public DateTime StatusDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerInsurancePolicy, CustomerInsurancePolicyLookupDto>()
                .ForMember(d => d.CustomerInsurancePolicyId, opt => opt.MapFrom(s => s.CustomerInsurancePolicyId))
                .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.FirstName + " " + s.Customer.LastName))
                .ForMember(d => d.InsurancePolicyId, opt => opt.MapFrom(s => s.InsurancePolicyId))
                .ForMember(d => d.InsurancePolicyName, opt => opt.MapFrom(s => s.InsurancePolicy.Name))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(d => d.StatusName, opt => opt.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.StatusDate, opt => opt.MapFrom(s => s.StatusDate));
        }

    }
}
