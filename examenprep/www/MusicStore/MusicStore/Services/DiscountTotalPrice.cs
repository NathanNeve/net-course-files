using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Services
{
    public class DiscountTotalPrice : IDiscountService
    {
        public DiscountTotalPrice()
        {
            
        }
        // No circular dependency here
        public int GetDiscount(List<CartItem> items)
        {
            int total = 0;
            foreach (CartItem item in items)
            {
                total += item.Album.Price * item.Count;
            }

            if (total > 25 && total < 50)
            {
                return 5;
            }

            if (total > 50)
            {
                return 10;
            }

            return 0;
        }
    }
}
