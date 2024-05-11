using DataAccess.DBContext;
using DataAccess.DTO;
using DataAccess.ILibraryservices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Libraryservices
{
    public class OrderServices : IOrderServices
    {
        private EBookDBContext _eBookDBContext = new EBookDBContext();
        
        public void GetOrderdetails(int id)
        {
            BookServices bookServices = new BookServices();
            if(id <= 0) { Console.WriteLine("Dữ liệu vào không hợp lệ!");return; }
            int dem = 0;
            var orders = new Orders();
            var ordersdetails=new OrderDetails();
            var books = new Book();
            var listorder = _eBookDBContext.Orders.ToList();
            var listorderdetails = _eBookDBContext.OrderDetails.ToList();
            foreach (var item in listorder)
            {
                if(item.OrderID==id) 
                {
                    dem = dem + 1;
                    orders=item;
                    break;
                }
            }
            if(dem==0) { Console.WriteLine("không tìm thấy đơn hàng có id " +id);return; }
            dem=0;
            int Quanyityoder = 0;
            decimal TotalAmount = 0;
            string bookname="";
            foreach (var item in listorderdetails) 
            {
                if(item.OrderID==id) { 
                    dem++;
                    ordersdetails = item;
                    Quanyityoder=Quanyityoder+ item.Quantity;
                    TotalAmount =TotalAmount+ item.PriceAtTheTime;
                    books = bookServices.GetBooks(item.BookID);
                    bookname += " | " + books.BookName;
                }
            }
            if (dem == 0) { Console.WriteLine("không tìm thấy chi tiểt của đơn hàng có id " + id); return; }
            Console.WriteLine("đã tìm thấy chi tiết đơn hàng: ");
            Console.WriteLine("Oderid: "+id);
            Console.WriteLine("OderDate: "+orders.OrderDate);
            Console.WriteLine("CustomerName:"+ _eBookDBContext.Customer.Find(orders.CustomerID).customerName);
            Console.WriteLine("TotalAmount:" + TotalAmount);
            Console.WriteLine("Quantity :" + Quanyityoder);
            Console.WriteLine("BookName:" + bookname);
        }

        public void PlaceOrder(Orders order)
        {
            if(order==null
                ||order.CustomerID<=0
                ||order.OrderID <=0
                ||order.OrderDate==null
                ||order.TotalAmount<=0
                ||_eBookDBContext.Customer.Find(order.CustomerID)==null)
            {
                Console.WriteLine("Dữ liệu vòa không hợp lệ!");
                return;
            }
            var listoderdetails= _eBookDBContext.OrderDetails.ToList().Where(x => x.OrderID==order.OrderID).ToList();
            if(listoderdetails.Count<=0) {
                Console.WriteLine("Không có dữ liệu mua hàng trong orderdetails!");
                return;
            }
            foreach (var item in listoderdetails)
            {
                var bookInDb = _eBookDBContext.Books.Find(item.BookID);
                if (bookInDb == null || bookInDb.Stock < item.Quantity)
                {
                    Console.WriteLine("Số lượng tồn kho không đủ.");
                    return; 
                }

                // Cập nhật số lượng tồn kho
                bookInDb.Stock -= item.Quantity;
                _eBookDBContext.Books.Update(bookInDb);
            }
            _eBookDBContext.Orders.Add(order);
            _eBookDBContext.SaveChanges();
        }

        public List<Orders> GetAllOrders()
        {
            return _eBookDBContext.Orders.ToList();
        }
    }
}
