using AutoMapper;
using Gap.IPM.Application.Common.Mappings;
using Gap.IPM.Domain.Entities;

namespace Gap.IPM.Application.Customers.Queries.GetCustomer
{
    public class CustomersLookupDto : IMapFrom<Customer>
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomersLookupDto>()
               .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId))
               .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
               .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
               .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
               .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone))
               .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
               .ForMember(d => d.Region, opt => opt.MapFrom(s => s.Region))
               .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country))
               .ForMember(d => d.PostalCode, opt => opt.MapFrom(s => s.PostalCode));
        }
    }
}
