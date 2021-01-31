using System;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void ShouldReturnErrorWhenExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "George";
            command.LastName = "Wurthmann";
            command.Document = "99999999999";
            command.Email = "teste@email.com";
            command.BarCode = "1286381263876123";
            command.BoletoNumber = "823476287";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNE CORP";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "Marta";
            command.Number = "827";
            command.Neighborhood = "Chelsea";
            command.City = "Gotham";
            command.State = "NY";
            command.Country = "EUA";
            command.ZipCode = "128376";

            handler.Handle(command);
            Assert.False(handler.Valid);
        }
    }
}