using Gap.IPM.Application.Customers.Commands.CreateCustomer;
using Gap.IPM.ApplicationUnitTest.Common;
using MediatR;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Gap.IPM.ApplicationUnitTest.Customer.Commands
{
    public class CreateCustomerCommandTests : CommandTestBase
    {
        [Fact]
        public void Handle_GivenValidRequestCustomer_ShouldCreateCustomer()
        {
            //Arrange
            Random random = new Random();

          
            var sut = new CreateCustomerCommandHandler(_context);
            var customerId = random.Next(100).ToString();
            var firstName = "MauricioTest";
            var lastName = "RamirezTest";
            var address = "Avenida simpre viva 742Test";
            var phone = "3001234567Test";
            var city = "SpringfieldTest";
            var region = "UnknownTest";
            var country = "United StatesTest";
            var postalCode = "055450Test";

            // Act
            var result = sut.Handle(new CreateCustomerCommand { 
                CustomerId = customerId,
                FirstName=firstName,
                LastName=lastName,
                Address=address,
                Phone=phone,
                City=city,
                Region=region,
                Country=country,
                PostalCode=postalCode
            }, CancellationToken.None).Result;

            // Assert
            Assert.True(result.Equals(customerId));

        }

    }
}
