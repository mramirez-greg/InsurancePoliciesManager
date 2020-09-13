using AutoMapper;
using Gap.IPM.Application.Common.Mappings;
using Gap.IPM.Domain.Entities;
using System;

namespace Gap.IPM.Application.CoverageTypes.Queries.GetCoverageTypes
{
    public class CoverageTypeLookupDto: IMapFrom<CoverageType>
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CoverageType, CoverageTypeLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CovergaeTypeId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CoverageTypeName));
        }
    }
}
