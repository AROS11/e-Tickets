﻿using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using ZendeskApi_v2.Models.Views;

namespace e_Tickets.Data.ViewComponent
{
    [ViewComponent]
    public class ShoppingCartSummary
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
