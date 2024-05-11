using DataAccess.DBContext;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ILibraryservices
{
    public interface IAuthorServices
    {
        void AddAuthor(Authors author);
        void UpdateAuthor(Authors author);
        void DeleteAuthor(int id);
        Authors GetAuthor(int id);
        List<Authors> SearchAuthors(string keyword);
    }
}
