using DataAccess.DBContext;
using DataAccess.DTO;
using DataAccess.ILibraryservices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Libraryservices
{
    public class AuthorServices : IAuthorServices
    {
        private EBookDBContext _eBookDBContext = new EBookDBContext();
        public void AddAuthor(Authors author)
        {
            if(author.AuthorId<=0
                ||author.AuthorName==null
                ||author.Country==null
                ||_eBookDBContext.Authors.Find(author.AuthorId)!=null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ!");
                return;
            }
           _eBookDBContext.Authors.Add(author);
           _eBookDBContext.SaveChanges();
            Console.WriteLine("thêm tác giả thành công!");
        }

        public void DeleteAuthor(int id)
        {
            if (id <= 0
                ||_eBookDBContext.Authors.Find(id)==null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ!");
                return;
            }
            var author = _eBookDBContext.Authors.Find(id);
                         _eBookDBContext.Authors.Remove(author);
                         _eBookDBContext.SaveChanges();
            Console.WriteLine("Xóa tác giả thành công!");
        }

        public Authors GetAuthor(int id)
        {
            return _eBookDBContext.Authors.Find(id);
        }

        public List<Authors> SearchAuthors(string keyword)
        {
            if (keyword==null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ.");
                return null;
            }
            return _eBookDBContext.Authors
           .Where(a => a.AuthorName.Contains(keyword) || a.Country.Contains(keyword))
           .ToList();
        }

        public void UpdateAuthor(Authors author)
        {
            if (author.AuthorId <= 0
               || author.AuthorName == null
               || author.Country == null
               || _eBookDBContext.Authors.Find(author.AuthorId)==null)
            {
                Console.WriteLine("Dữ liệu vào không hợp lệ!");
                return;
            }
            _eBookDBContext.Authors.Update(author);
            _eBookDBContext.SaveChanges();
            Console.WriteLine("cập nhật tác giả thành công!");
        }
    }
}