using System;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Xunit;

namespace Store.Tests.Domain
{
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("André Baltieri", "andre@balta.io");
        private readonly Product _product = new Product("Produto 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));


        [Fact]
        [Trait("Domain", "Unit")] // Categoria do teste
        // Outros exemplos possíveis para categoria:
        // [Trait("Category","Integration")]
        // [Trait("Category","UI")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var order = new Order(_customer, 0, null);
            Assert.Equal(8, order.Number.Length);
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_customer, 0, null);
            Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 1); // Total deve ser 10
            order.Pay(10);
            Assert.Equal(EOrderStatus.WaitingDelivery, order.Status);
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var order = new Order(_customer, 0, null);
            order.Cancel();
            Assert.Equal(EOrderStatus.Canceled, order.Status);
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(null, 10);
            Assert.Equal(0, order.Items.Count);
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_product, 0);
            Assert.Equal(0, order.Items.Count);
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.Equal(50, order.Total());
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            var expiredDiscount = new Discount(10, DateTime.Now.AddDays(-5)); // desconto expirado, não deve descontar os 10
            var order = new Order(_customer, 10, expiredDiscount); // Pedido com entrega no valor de 10
            order.AddItem(_product, 5); // _product.Price = 10 * 5 = 50 + 10 (entrega) = 60
            Assert.Equal(60, order.Total());
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, null);
            order.AddItem(_product, 5); 
            Assert.Equal(60, order.Total());
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 5);
            Assert.Equal(50, order.Total());
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_product, 6);
            Assert.Equal(60, order.Total());
        }

        [Fact]
        [Trait("Domain", "Unit")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var order = new Order(null, 10, _discount);
            Assert.False(order.Valid);
        }
    }
}