using Gap.IPM.Application.InsurancePolicies.Commands.CreateInsurancePolicy;
using Gap.IPM.ApplicationUnitTest.Common;
using Gap.IPM.Domain.Enums;
using FluentValidation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Gap.IPM.ApplicationUnitTest.InsurancePolicy.Commands
{
    public class CreateInsurancePolicyCommandTest:CommandTestBase
    {

        [Fact]
        public void Handle_GivenValidRequestInsurancePolicy_ShouldCreateInsurancePolicy()
        {
            //Arrange
          
            var sut = new CreateInsurancePolicyCommandHandler(_context);
          
            var name = "Poliza 90 Riego Medio";
            var description = "RamirezTest";
            var coverageTypeId = 3;
            var coverage = 90;
            var coverageStart = DateTime.Now.ToString();
            var coveragePeriod =12;
            var policyValue =1000000;
            var riskType =(int)RiskType.Bajo;

            // Act
            var result = sut.Handle(new CreateInsurancePolicyCommand
            {
                Name = name,
                Description = description,
                CoverageTypeId = coverageTypeId,
                Coverage = coverage,
                CoverageStart = coverageStart,
                CoveragePeriod= coveragePeriod,
                PolicyValue= policyValue,
                RiskType= riskType,
                
            }, CancellationToken.None).Result;

            // Assert
            result.ShouldBeGreaterThan(0);
        }
        
    }
}
