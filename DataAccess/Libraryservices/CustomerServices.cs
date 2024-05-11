using DataAccess.DBContext;
using DataAccess.DTO;
using DataAccess.ILibraryservices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Libraryservices
{
    public class CustomerServices : ICustomerServices
    {
        private EBookDBContext _eBookDBContext = new EBookDBContext();
        public void AddCustomer(customer customer)
        {
            if (customer==null
                ||customer.customerID<=0
                ||customer.customerName==null
                ||customer.customeraddrress==null
                ||_eBookDBContext.Customer.Find(customer.customerID)!=null)
            {
                Console.WriteLine("Dữ liệu đầu vào không hợp lệ!");
                return;
            }
            _eBookDBContext.Customer.Add(customer);
            _eBookDBContext.SaveChanges();
            Console.WriteLine("Thêm khách hàng thành công!");
        }

        public async void DeleteCustomer(int id)
        {
            if (id<=0) {
                Console.WriteLine("Dữ liệu đầu vào không hợp lệ!");
                return;
            }
            var customer = _eBookDBContext.Customer.Find(id);
            if (customer != null)
            {
                _eBookDBContext.Customer.Remove(customer);
                _eBookDBContext.SaveChanges();
                Console.WriteLine("xóa khách hàng thành công!");
            }
            else { Console.WriteLine("dữ liệu vào không hợp lệ!"); }
        }

        public customer GetCustomer(int id)
        {
            return _eBookDBContext.Customer.Find(id);
        }

        public List<customer> SearchCustomers(string keyword)
        {
            if (keyword==null) {
                Console.WriteLine("Dữ liệu đầu vào không hợp lệ!");
                return null;
            }
            return _eBookDBContext.Customer
           .Where(c => c.customerName.Contains(keyword) || c.customeraddrress.Contains(keyword))
           .ToList();
        }

        public void UpdateCustomer(customer customer)
        {
            if (customer == null
               || customer.customerID <= 0
               || customer.customerName == null
               || customer.customeraddrress == null
               ||_eBookDBContext.Customer.Find(customer.customerID)==null)
            {
                Console.WriteLine("Dữ liệu đầu vào không hợp lệ!");
                return;
            }
            _eBookDBContext.Customer.Update(customer);
            _eBookDBContext.SaveChanges();
            Console.WriteLine("cập nhật khách hàng thành công!");
        }
    }
}
