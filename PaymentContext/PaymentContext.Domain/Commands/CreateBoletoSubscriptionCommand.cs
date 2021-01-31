using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public CreateBoletoSubscriptionCommand()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, $@"{nameof(Name)}.{nameof(Name.FirstName)}", "Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, $@"{nameof(Name)}.{nameof(Name.LastName)}", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, $@"{nameof(Name)}.{nameof(Name.FirstName)}", "Nome deve conter até 40 caracteres")
            );
        }
    }
}