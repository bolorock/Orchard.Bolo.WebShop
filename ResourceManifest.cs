using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace Bolo.WebShop
{
    public class ResourceManifest : IResourceManifestProvider
    {

        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();

            // Define a "common" style sheet
            manifest.DefineStyle("Bolo.WebShop.Common").SetUrl("common.css");

            // Define the "shoppingcart" style sheet
            manifest.DefineStyle("Bolo.WebShop.ShoppingCart").SetUrl("shoppingcart.css").SetDependencies("Bolo.WebShop.Common");

            // Define the "shoppingcartwidget" style sheet             
            manifest.DefineStyle("Bolo.WebShop.ShoppingCartWidget").SetUrl("shoppingcartwidget.css").SetDependencies("Webshop.Common");

             // Define the "shoppingcart" script and set a dependency on the "jQuery" resource
            manifest.DefineScript("Bolo.WebShop.ShoppingCart").SetUrl("shoppingcart.js").SetDependencies("jQuery", "jQuery_LinqJs", "ko");

            manifest.DefineStyle("Bolo.WebShop.Checkout.Summary").SetUrl("checkout-summary.css").SetDependencies("Bolo.WebShop.Common");
        }
    }
}