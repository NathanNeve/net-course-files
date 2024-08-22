using MusicStore.Models;
using System.Collections.Generic;

namespace MusicStore.Services
{
    public interface IDiscountService
    {
        int GetDiscount(List<CartItem> items);
    }
}
