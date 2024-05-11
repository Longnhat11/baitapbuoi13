using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class customer
    {
        [Key]public int customerID {  get; set; }
        public string customerName { get; set; }
        public string customeraddrress {  get; set; }
    }
}
