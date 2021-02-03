using System;
using Xunit;
using Store.Domain.Commands;
using Store.Domain.Repositories.Interfaces;
using Store.Tests.Repositories;
using Store.Domain.Handlers;
using System.Collections.Generic;

namespace Store.Tests.Handlers
{
    public class OrderHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandlerTests()
        {
            _customerRepository = new FakeCustomerRepository();
            _deliveryFeeRepository = new FakeDeliveryFeeRepository();
            _discountRepository = new FakeDiscountRepository();
            _orderRepository = new FakeOrderRepository();
            _productRepository = new FakeProductRepository();
        }

        [Fact]
        [Trait("Handlers", "Unit")]
        public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand("", "13411080", "12345678", 
                new List<CreateOrderItemCommand>(){
                    new CreateOrderItemCommand(Guid.NewGuid(), 1),
                    new CreateOrderItemCommand(Guid.NewGuid(), 1)
                }
            );
            command.Validate();
            Assert.False(command.Valid);
        }

        [Fact]
        [Trait("Handlers", "Unit")]
        public void Dado_um_cep_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand("12345678911", "abc", "12345678", 
                new List<CreateOrderItemCommand>(){
                    new CreateOrderItemCommand(Guid.NewGuid(), 1),
                    new CreateOrderItemCommand(Guid.NewGuid(), 1)
                }
            );
            command.Validate();
            Assert.False(command.Valid);
        }

        [Fact]
        [Trait("Handlers", "Unit")]
        public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
        {
            var command = new CreateOrderCommand("12345678911", "13411080", "666", 
                new List<CreateOrderItemCommand>(){
                    new CreateOrderItemCommand(Guid.NewGuid(), 1),
                    new CreateOrderItemCommand(Guid.NewGuid(), 1)
                }
            );
            command.Validate();
            Assert.True(command.Valid);
        }

        [Fact]
        [Trait("Handlers", "Unit")]
        public void Dado_um_pedido_sem_itens_o_mesmo_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand("12345678911", "13411080", "12345678", null);
            command.Validate();
            Assert.False(command.Valid);
        }

        [Fact]
        [Trait("Handlers", "Unit")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.False(command.Valid);
        }

        [Fact]
        [Trait("Handlers", "Unit")]
        public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
        {
            var command = new CreateOrderCommand();
            command.Customer = "12345678";
            command.ZipCode = "13411080";
            command.PromoCode = "12345678";
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

            var handler = new OrderHandler(
                _customerRepository,
                _deliveryFeeRepository,
                _discountRepository,
                _productRepository,
                _orderRepository);

            handler.Handle(command);
            Assert.True(handler.Valid);
        }
    }
}