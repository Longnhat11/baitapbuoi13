using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ILibraryservices
{
    public interface IOrderServices
    {
        void PlaceOrder(Orders order);
        void GetOrderdetails(int id);
        List<Orders> GetAllOrders();
    }
}
