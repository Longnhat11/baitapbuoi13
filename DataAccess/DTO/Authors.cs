using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class Authors
    {
        [Key] public int AuthorId { get; set; }   
        public string AuthorName { get; set; }
        public string Country { get; set; }
    }
}
