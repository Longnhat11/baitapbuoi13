using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IBookservices
{
    public interface IBookServices
    {
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        Book GetBooks(int id);
        List<Book> SearchBooks(string keyword);
    }
}
