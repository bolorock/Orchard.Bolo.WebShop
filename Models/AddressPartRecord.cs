using Orchard.ContentManagement.Records;

namespace Bolo.WebShop.Models
{
    public class AddressPartRecord : ContentPartRecord
    {
        public virtual int CustomerId { get; set; }
        public virtual string Type { get; set; }
    }
}