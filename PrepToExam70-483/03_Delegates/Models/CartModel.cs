using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Delegates.Models
{
    public class CartModel
    {
        public delegate void MentionDiscount(decimal subTotal); // definição de um delegate
        
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        public decimal GenerateTotal(MentionDiscount mentionDiscount) // recebe o delegate
        {
            decimal subTotal = Items.Sum(x => x.Price);
            
            mentionDiscount(subTotal); // O método atribuído ao delegate será chamado aqui...

            if (subTotal > 40)
            {
                subTotal *= 0.90M;
            }

            return subTotal;
        }
    }
}
