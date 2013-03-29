using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bolo.WebShop.Models;
using Orchard.ContentManagement.Drivers;

namespace Bolo.WebShop.Drivers
{
    public class ProductPartDriver : ContentPartDriver<ProductPart>
    {
        protected override string Prefix
        {
            get
            {
                return "Product";
            }
        }

        protected override DriverResult Editor(ProductPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Product_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts.Product", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(ProductPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override DriverResult Display(ProductPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                // Shape 1: Parts_Product
                ContentShape("Parts_Product", () => shapeHelper.Parts_Product(
                Price: part.UnitPrice,
                Sku: part.Sku
                )),

                 // Shape 2: Parts_Product_AddButton
                 ContentShape("Parts_Product_AddButton",()=>shapeHelper.Parts_Product_AddButton(ProductId:part.Id))
                );
        }
    }
}