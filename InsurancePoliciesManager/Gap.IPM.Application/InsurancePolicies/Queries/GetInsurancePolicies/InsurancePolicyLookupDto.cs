using AutoMapper;
using Gap.IPM.Application.Common.Mappings;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Domain.Enums;

namespace Gap.IPM.Application.InsurancePolicies.Queries.GetInsurancePolicies
{
    public class InsurancePolicyLookupDto : IMapFrom<InsurancePolicy>
    {

        public int InsurancePolicyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageTypeId { get; set; }
        public string CoverageTypeName { get; set; }
        public int Coverage { get; set; }
        public string CoverageStart { get; set; }
        public int CoveragePeriod { get; set; }
        public int PolicyValue { get; set; }
        public int RiskType { get; set; }
        public string RiskTypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<InsurancePolicy, InsurancePolicyLookupDto>()
                .ForMember(d => d.InsurancePolicyId, opt => opt.MapFrom(s => (int)s.InsurancePolicyId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.CoverageTypeId, opt => opt.MapFrom(s => s.CoverageTypeId))
                .ForMember(d => d.CoverageTypeName, opt => opt.MapFrom(s => s.CoverageType.CoverageTypeName))
                .ForMember(d => d.Coverage, opt => opt.MapFrom(s =>  s.Coverage))
                .ForMember(d => d.CoverageStart, opt => opt.MapFrom(s => s.CoverageStart.ToString()))
                .ForMember(d => d.CoveragePeriod, opt => opt.MapFrom(s => s.CoveragePeriod))
                .ForMember(d => d.PolicyValue, opt => opt.MapFrom(s => (int)s.PolicyValue))
                .ForMember(d => d.RiskType, opt => opt.MapFrom(s => (int)s.RiskType))
                .ForMember(d => d.RiskTypeName, opt => opt.MapFrom(s =>  ((RiskType)(s.RiskType)).ToString()));
        }
    }
}
