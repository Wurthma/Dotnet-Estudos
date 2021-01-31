using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class CreateBoletoSubscriptionCommandTests
    {
        // Exemplo de teste de commands
        [Fact]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.Validate();
            Assert.False(command.Valid);
        }
    }
}