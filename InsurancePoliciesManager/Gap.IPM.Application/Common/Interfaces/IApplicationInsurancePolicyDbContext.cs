using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.Common.Interfaces
{
    public interface IApplicationInsurancePolicyDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
