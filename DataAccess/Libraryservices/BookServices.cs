using DataAccess.DBContext;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Libraryservices
{
    public class BookServices : DataAccess.IBookservices.IBookServices
    {
        private EBookDBContext _eBookDBContext = new EBookDBContext();

        public void AddBook(Book book)
        {
            if(book.BookID<=0
                ||book.AuthorID<=0
                ||book.CategoryID<=0
                ||book==null
                ||book.Stock<=0
                ||book.Price<=0
                ||book.BookName==null
                ||_eBookDBContext.Books.Find(book.BookID)!=null)
            { Console.WriteLine("Dữ liệu vào không hợp lệ");
                return;
            }
            _eBookDBContext.Books.Add(book);
            _eBookDBContext.SaveChanges();
            Console.WriteLine("thêm sách vào DB thành công!");
        }

        public void DeleteBook(int id)
        {
            if(id<=0
                ||_eBookDBContext.Books.Find(id)==null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ!");
                return;
            }
            var book = _eBookDBContext.Books.Find(id);
            _eBookDBContext.Books.Remove(book);
            _eBookDBContext.SaveChanges();
            Console.WriteLine("xóa sách khỏi DB thành công");
        }
        public Book GetBooks(int id)
            {
                return _eBookDBContext.Books.Find(id);
            }

        public List<Book> SearchBooks(string keyword)
        {
            if (keyword == null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ!");
                return null;
            }
            return _eBookDBContext.Books
            .Where(b => b.BookName.Contains(keyword)).ToList();
        }
        public void UpdateBook(Book book)
        {
            if (book.BookID <= 0
                || book.AuthorID <= 0
                || book.CategoryID <= 0
                || book == null
                || book.Stock <= 0
                || book.Price <= 0
                || book.BookName == null
                || _eBookDBContext.Books.Find(book.BookID)==null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ");
                return;
            }
            _eBookDBContext.Books.Update(book);
            _eBookDBContext.SaveChanges();
            Console.WriteLine("cập nhật sách thành công!");
        }
    }
}
