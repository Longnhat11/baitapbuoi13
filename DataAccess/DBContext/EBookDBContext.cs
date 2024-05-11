using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public class EBookDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBSFM7Q;Initial Catalog=Librarys;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }
        public virtual DbSet<Book> ?Books { get; set; }
        public virtual DbSet<Authors>? Authors { get; set; }
        public virtual DbSet<customer>? Customer { get; set; }
        public virtual DbSet<OrderDetails>? OrderDetails { get; set; }
        public virtual DbSet<Orders>? Orders { get; set; }
    }
}
