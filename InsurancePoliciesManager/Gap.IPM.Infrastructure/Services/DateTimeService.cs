using Gap.IPM.Application.Common.Interfaces;
using System;

namespace Gap.IPM.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
