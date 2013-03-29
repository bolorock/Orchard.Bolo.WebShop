using System.Web.Mvc;
using System.Linq;
using Bolo.WebShop.Services;
using Orchard;
using Orchard.Mvc;
using Orchard.Themes;
using Bolo.WebShop.Models;
using Orchard.ContentManagement;
using Bolo.WebShop.ViewModels;
using System.Collections.Generic;

namespace Bolo.WebShop.Controllers
{
    public class ShoppingCartController : Controller 
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrchardServices _orchardServices;

        public ShoppingCartController(IShoppingCart shoppingCart,IOrchardServices orchardService)
        {
            _shoppingCart = shoppingCart;
            _orchardServices = orchardService;
        }
        [HttpPost]
        public ActionResult Add(int id)
        {
            _shoppingCart.Add(id, 1);
            return RedirectToAction("Index");
        }

        [Themed]
        public ActionResult Index()
        {
            // Create a new shape using the "New" property of IOrchardServices.
            var shape = _orchardServices.New.ShoppingCart(
                Products: _shoppingCart.GetProducts().Select(p => _orchardServices.New.ShoppingCartItem(
                    ProductPart: p.ProductPart,
                    Quantity: p.Quantity,
                    Title: _orchardServices.ContentManager.GetItemMetadata(p.ProductPart).DisplayText)
                ).ToList(),
                Total: _shoppingCart.Total(),
                Subtotal: _shoppingCart.Subtotal(),
                Vat: _shoppingCart.Vat()
            );
            return new ShapeResult(this, shape);
        }

        [HttpPost]
        public ActionResult Update(string command, UpdateShoppingCartItemViewModel[] items)
        {
            UpdateShoppingCart(items);

            if (Request.IsAjaxRequest())
                return Json(true);

            switch (command)
            {
                case "Checkout":
                    return RedirectToAction("SignupOrLogin", "Checkout");
                case "ContinueShopping":
                    break;
                case "Update":
                    break;
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetItems()
        {
            var products = _shoppingCart.GetProducts();

            var json = new
            {
                items = (from item in products
                         select new
                         {
                             id = item.ProductPart.Id,
                             title = _orchardServices.ContentManager.GetItemMetadata(item.ProductPart).DisplayText ?? "(No TitlePart attached)",
                             unitPrice = item.ProductPart.UnitPrice,
                             quantity = item.Quantity
                         }).ToArray()
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private void UpdateShoppingCart(IEnumerable<UpdateShoppingCartItemViewModel> items)
        {

            _shoppingCart.Clear();

            if (items == null)
                return;

            _shoppingCart.AddRange(items
                .Where(item => !item.IsRemoved)
                .Select(item => new ShoppingCartItem(item.ProductId, item.Quantity < 0 ? 0 : item.Quantity))
            );

            _shoppingCart.UpdateItems();
        }
    }
}