using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Infrastructure.Persistence;
using System;

namespace Gap.IPM.ApplicationUnitTest.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ApplicationInsurancePolicyDbContext _context;

        public ICurrentUserService _currentUserService;

        public IDateTime _datetime;

        public CommandTestBase()
        {
            _context = IPMDabaseContextFactory.Create();
        }

        public void Dispose()
        {
            IPMDabaseContextFactory.Destroy(_context);
        }
    }
}
