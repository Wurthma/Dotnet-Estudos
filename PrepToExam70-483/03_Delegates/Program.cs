using System;
using _03_Delegates.Models;

namespace _03_Delegates
{
    class Program
    {
        static CartModel cart = new CartModel();
        
        static void Main(string[] args)
        {
            Console.WriteLine($"O total da sua compra é: {cart.GenerateTotal(SubTotalAlert):C2}");
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"O subtotal é: {subTotal:C2}");
        }

        private static void PopulateCartWithData()
        { // adiciona valores de exemplo no carrinho de compras
            cart.Items.Add(new ProductModel { Name = "Leite", Price = 3.81M });
            cart.Items.Add(new ProductModel { Name = "Aveia 500g", Price = 7.90M });
            cart.Items.Add(new ProductModel { Name = "Banana KG", Price = 5.30M });
            cart.Items.Add(new ProductModel { Name = "Caixa de Cerveja", Price = 39.15M });
        }
    }
}
