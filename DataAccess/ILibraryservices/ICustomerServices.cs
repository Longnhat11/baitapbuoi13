using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ILibraryservices
{
    public interface ICustomerServices
    {
        void AddCustomer(customer customer);
        void UpdateCustomer(customer customer);
        void DeleteCustomer(int id);
        customer GetCustomer(int id);
        List<customer> SearchCustomers(string keyword);
    }
}
