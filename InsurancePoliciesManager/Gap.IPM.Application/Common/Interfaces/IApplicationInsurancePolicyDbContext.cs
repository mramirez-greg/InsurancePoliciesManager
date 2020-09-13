using Gap.IPM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.Common.Interfaces
{
    public interface IApplicationInsurancePolicyDbContext
    {
        DbSet<CoverageType> CoverageType { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<CustomerInsurancePolicy> CustomerInsurancePolicy { get; set; }
        DbSet<InsurancePolicy> InsurancePolicy { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
