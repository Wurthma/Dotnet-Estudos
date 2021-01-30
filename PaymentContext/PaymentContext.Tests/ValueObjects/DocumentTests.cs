using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {
        // Utilizar "Red, Green, Refactor" para melhorar os testes
        [Theory]
        [InlineData("")]
        [InlineData("012")]
        [InlineData("102030")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
        {
            var doc = new Document(cnpj, EDocumentType.CNPJ);
            Assert.True(doc.Invalid);
        }

        // É possível transformar esse método e o acima em um único método recebendo um segundo parâmetro no InlineData informando se é valido ou não...
        // Apenas exemplo didático
        [Theory]
        [InlineData("24243324000119")]
        [InlineData("98209243000139")]
        [InlineData("62601906000119")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
        {
            var doc = new Document(cnpj, EDocumentType.CNPJ);
            Assert.True(doc.Valid);
        }

        // Exemplo de teste recebendo segundo parâmetro que informa se valor é valido ou inválido...
        [Theory]
        [InlineData("", false)]
        [InlineData("123", false)]
        [InlineData("324000", false)]
        [InlineData("85369201064", true)]
        [InlineData("17283783032", true)]
        [InlineData("98010985031", true)]
        public void ShouldValidateCPF(string cpf, bool isValid)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.True(doc.Valid == isValid);
        }
    }
}