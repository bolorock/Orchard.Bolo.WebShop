using Orchard.Data.Migration;
using Orchard.Core.Contents.Extensions;
using Orchard.ContentManagement.MetaData;
using System;

namespace Bolo.WebShop
{
    public class Migrations : DataMigrationImpl 
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("ProductPartRecord", table => table
                .ContentPartRecord()
                .Column<decimal>("UnitPrice")
                .Column<string>("Sku", column => column.WithLength(50))
                );
            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                .Attachable());

            return 2;
        }

        public int UpdateFrom2()
        {

            // Define a new content type called "ShoppingCartWidget"
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type

                // Attach the "ShoppingCartWidgetPart"
                .WithPart("ShoppingCartWidgetPart")

                // In order to turn this content type into a widget, it needs the WidgetPart
                .WithPart("WidgetPart")

                // It also needs a setting called "Stereotype" to be set to "Widget"
                .WithSetting("Stereotype", "Widget")
                );

            return 3;
        }

        public int UpdateFrom3()
        {
            // Update the ShoppingCartWidget so that it has a CommonPart attached, which is required for widgets (it's generally a good idea to have this part attached)
            ContentDefinitionManager.AlterTypeDefinition("ShoppingCartWidget", type => type
                .WithPart("CommonPart")
            );

            return 4;
        }

        public int UpdateFrom4()
        {
            SchemaBuilder.CreateTable("CustomerPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("FirstName", c => c.WithLength(50))
                .Column<string>("LastName", c => c.WithLength(50))
                .Column<string>("Title", c => c.WithLength(10))
                .Column<DateTime>("CreatedUtc")
                );

            SchemaBuilder.CreateTable("AddressPartRecord", table => table
                .ContentPartRecord()
                .Column<int>("CustomerId")
                .Column<string>("Type", c => c.WithLength(50))
                );

            ContentDefinitionManager.AlterPartDefinition("CustomerPart", part => part
                .Attachable(false)
                );

            ContentDefinitionManager.AlterTypeDefinition("Customer", type => type
                .WithPart("CustomerPart")
                .WithPart("UserPart")
                );

            ContentDefinitionManager.AlterPartDefinition("AddressPart", part => part
                .Attachable(false)
                .WithField("Name", f => f.OfType("TextField"))
                .WithField("AddressLine1", f => f.OfType("TextField"))
                .WithField("AddressLine2", f => f.OfType("TextField"))
                .WithField("Zipcode", f => f.OfType("TextField"))
                .WithField("City", f => f.OfType("TextField"))
                .WithField("Country", f => f.OfType("TextField"))
                );

            ContentDefinitionManager.AlterTypeDefinition("Address", type => type
                .WithPart("CommonPart")
                .WithPart("AddressPart")
                );

            return 5;
        }
    }
}