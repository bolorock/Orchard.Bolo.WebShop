using Bolo.WebShop.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Bolo.WebShop.Handlers
{
    public class ProductPartHandler : ContentHandler
    {
        public ProductPartHandler(IRepository<ProductPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}