﻿using Bolo.WebShop.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Bolo.WebShop.Handlers
{
    public class AddressPartHandler : ContentHandler 
    {
        public AddressPartHandler(IRepository<AddressPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}