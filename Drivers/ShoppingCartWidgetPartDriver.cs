using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bolo.WebShop.Models;
using Bolo.WebShop.Services;
using Orchard.ContentManagement.Drivers;

namespace Bolo.WebShop.Drivers
{
    public class ShoppingCartWidgetPartDriver : ContentPartDriver<ShoppingCartWidgetPart>
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartWidgetPartDriver(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        protected override DriverResult Display(ShoppingCartWidgetPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_ShoppingCartWidget", () => shapeHelper.Parts_ShoppingCartWidget(
                ItemCount: _shoppingCart.ItemCount(),
                TotalAmount: _shoppingCart.Total()
            ));
        }
    }
}