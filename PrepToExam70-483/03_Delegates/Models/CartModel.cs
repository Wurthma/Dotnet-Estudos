using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Delegates.Models
{
    public class CartModel
    {
        public delegate void MentionSubtotal(decimal subTotal); // definição de um delegate
        
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        public decimal GenerateTotal(MentionSubtotal mentionSubtotal, Func<List<ProductModel>, decimal, decimal> calculateDiscountTotal, Action<string> mentionDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);
            
            mentionSubtotal(subTotal);

            mentionDiscounting("Estamos aplicando o seu desconto...");

            return calculateDiscountTotal(Items, subTotal);
        }
    }
}
