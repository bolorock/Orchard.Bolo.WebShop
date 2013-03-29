using Orchard.ContentManagement.Records;

namespace Bolo.WebShop.Models
{
    public class ProductPartRecord : ContentPartRecord
    {
        public virtual decimal UnitPrice { get; set; }
        public virtual string Sku { get; set; }
    }
}