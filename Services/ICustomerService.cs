using Bolo.WebShop.Models;
using Orchard;

namespace Bolo.WebShop.Services
{
    public interface ICustomerService : IDependency 
    {
        CustomerPart CreateCustomer(string email, string password);
        AddressPart GetAddress(int customerId, string addressType);
        AddressPart CreateAddress(int customerId, string addressType);
    }
}
