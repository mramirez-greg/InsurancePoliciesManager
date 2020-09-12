using System.Threading;
using System.Threading.Tasks;

namespace Gap.IPM.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
