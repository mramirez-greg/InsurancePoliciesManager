using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gap.IPM.Application.CoverageTypes.Queries.GetCoverageTypes
{
    
    public class GetCoverageTypesListQuery : IRequest<CoverageTypesListVm>
    {
    }
}
