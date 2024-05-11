using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class Book
    {
        [Key]public int BookID { get; set; } 
        public string ?BookName { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
    }
}
