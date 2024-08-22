using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Models.ViewModels;
using MusicStore.Services;
using System.Linq;
using System.Net.Http;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;
        private IDiscountService _discountService;

        public ShoppingCartController(StoreContext context, IDiscountService discountService)
        {
            _context = context;
            _discountService = discountService;
        }

        public IActionResult Index()
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            var cartItems = shoppingCart.GetCartItems();

            ListShoppingCartViewModel shoppingCartVM = new ListShoppingCartViewModel();
            shoppingCartVM.CartItems = cartItems;

            // set the discount
            int discount = _discountService.GetDiscount(shoppingCartVM.CartItems);
            shoppingCartVM.discount = discount;

            shoppingCartVM.cartTotal = (int)HttpContext.Session.GetInt32("CartTotal");
            return View(shoppingCartVM);
        }

        public IActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _context.Albums.FirstOrDefault(a => a.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            var shoppingCart = new ShoppingCart(HttpContext, _context);
            int existingCartTotal = HttpContext.Session.GetInt32("CartTotal") ?? 0;
            shoppingCart.AddCartTotal(existingCartTotal + album.Price);
            shoppingCart.AddToCart(album);
            HttpContext.Session.SetInt32("CartTotal", shoppingCart.CartTotal);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int? AlbumID)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            int existingCartTotal = HttpContext.Session.GetInt32("CartTotal") ?? 0;
            shoppingCart.SubtractCartTotal(existingCartTotal - _context.Albums.SingleOrDefault(a => a.AlbumID == AlbumID).Price * _context.CartItems.SingleOrDefault(c => c.AlbumID == AlbumID).Count);
            HttpContext.Session.SetInt32("CartTotal", shoppingCart.CartTotal);
            shoppingCart.RemoveFromCart((int)AlbumID);
            return RedirectToAction("Index");
        }

        public IActionResult DiminishCartItem(int AlbumID)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.RemoveOneCart(AlbumID);

            int existingCartTotal = HttpContext.Session.GetInt32("CartTotal") ?? 0;
            shoppingCart.SubtractCartTotal(existingCartTotal - _context.Albums.SingleOrDefault(a => a.AlbumID == AlbumID).Price);
            HttpContext.Session.SetInt32("CartTotal", shoppingCart.CartTotal);
            return RedirectToAction("Index");
        }        
        
        public IActionResult AddCartItem(Album album)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.AddToCart(album);
            return RedirectToAction("Index");
        }
    }
}
