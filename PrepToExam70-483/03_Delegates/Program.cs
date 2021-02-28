using System;
using System.Collections.Generic;
using _03_Delegates.Models;

namespace _03_Delegates
{
    class Program
    {
        static CartModel cart = new CartModel();
        
        static void Main(string[] args)
        {
            PopulateCartWithData();

            Console.WriteLine();
            Console.WriteLine($"O total da sua compra é: {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");
            Console.WriteLine();

            // Exemplo 2 para chamadas do delegate:
            cart.GenerateTotal(
                (subTotal) => Console.WriteLine($"O total da sua segunda compra é: {subTotal:C2}"),
                (products, subTotal) => {
                    if (subTotal > 100)
                    {
                        return subTotal * 0.95M;
                    }
                    return subTotal;
                },
                (message) => { } // fazer nada para a ação da mensagem
            );
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"O subtotal é: {subTotal:C2}");
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.90M; // desconto de 10% para compras acima de 100
            }
            else if (subTotal > 80)
            {
                return subTotal * 0.95M; // desconto de 5% para compras acima de 100
            }

            return subTotal;
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static void PopulateCartWithData()
        { // adiciona valores de exemplo no carrinho de compras
            cart.Items.Add(new ProductModel { Name = "Caixa de Leite", Price = 38.51M });
            cart.Items.Add(new ProductModel { Name = "Aveia 500g", Price = 7.90M });
            cart.Items.Add(new ProductModel { Name = "Banana KG", Price = 5.30M });
            cart.Items.Add(new ProductModel { Name = "Caixa de Cerveja", Price = 39.15M });
            cart.Items.Add(new ProductModel { Name = "Bolo", Price = 26.39M });
        }
    }
}
