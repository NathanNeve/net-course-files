using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Services
{
    public class DiscountNumberOf : IDiscountService
    {
        public int GetDiscount(List<CartItem> items)
        {
            if (items.Count >= 5 && items.Count <= 10)
            {
                return 5;
            }
            if (items.Count > 10) 
            {
                return 10;
            }
            return 0;
        }
    }
}
