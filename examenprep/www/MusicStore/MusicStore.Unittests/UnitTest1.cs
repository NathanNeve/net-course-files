using Moq;
using MusicStore.Models;
using MusicStore.Services;
using System.Collections.Generic;

namespace MusicStore.Unittests
{
    [TestClass]
    public class DiscountTotalPriceUnitTest
    {
        [TestMethod]
        public void GetDiscount_ArticlesPrice10_Returns0()
        {
            // Arrange
            CartItem cartItem = new CartItem();
            Album album = new Album();
            album.Price = 10;
            CartItem cart = new CartItem();
            cart.Album = album;
            cart.Count = 1; 
            List<CartItem> items = new List<CartItem>();
            items.Add(cart);

            // Act
            DiscountTotalPrice discountTotalPrice = new DiscountTotalPrice();
            int discount = discountTotalPrice.GetDiscount(items);

            // Assert
            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice30_Returns5()
        {
            CartItem cartItem = new CartItem();
            Album album = new Album();
            album.Price = 30;
            CartItem cart = new CartItem();
            cart.Album = album;            
            cart.Count = 1;
            List<CartItem> items = new List<CartItem>();
            items.Add(cart);

            // Act

            DiscountTotalPrice discountTotalPrice = new DiscountTotalPrice();
            int discount = discountTotalPrice.GetDiscount(items);

            // Assert
            Assert.AreEqual(5, discount);
        }

        [TestMethod]
        public void GetDiscount_ArticlesPrice60_Returns10()
        {
            CartItem cartItem = new CartItem();
            Album album = new Album();
            album.Price = 60;
            CartItem cart = new CartItem();
            cart.Album = album;
            cart.Count = 1;
            List<CartItem> items = new List<CartItem>();
            items.Add(cart);

            // Act

            DiscountTotalPrice discountTotalPrice = new DiscountTotalPrice();
            int discount = discountTotalPrice.GetDiscount(items);

            // Assert
            Assert.AreEqual(10, discount);
        }

    }
}